using Domain.Microservices.Core.Bus;
using Domain.Microservices.Core.Commands;
using Domain.Microservices.Core.Events;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Broker
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;

        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Get the name of the event
                var eventName = @event.GetType().Name;

                // Declare a queue
                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException(
                    $"Handler type {handlerType.Name} already exists for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            // create a factory with DispatchConsumerAsync for asynchronous consuming.
            var factory = new ConnectionFactory() { HostName = "localhost", DispatchConsumersAsync = true };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false,null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            // Everytime we recieve a message this method will kickof a processs.
            consumer.Received += Consumer_Recieved;

            channel.BasicConsume(eventName, false, consumer);

        }

        private async Task Consumer_Recieved(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.Span);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                               
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                var subs = _handlers[eventName];

                foreach (var subscription in subs)
                {
                    // Create an instance of our handler.
                    var handler = Activator.CreateInstance(subscription);
                    if (handler == null) continue;

                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @ev = JsonConvert.DeserializeObject(message, eventType);

                    var concreteType  = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(concreteType, new object[] { @ev });
                }
            }
        }
    }
}
