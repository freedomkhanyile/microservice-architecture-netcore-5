using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Account.Microservice.Filters.Swagger
{
    public class CustomSwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Title = "Account Microservice",
                Version = "v1.0.0",
                Description = ".Net Core C# Api that is the middleware between external services and our Front-end UI",
                Contact = new OpenApiContact
                {
                    Name = "Development Engineer",
                    Email = "freedom.khanyile@adaptit.com"
                }
            };
        }
    }
}
