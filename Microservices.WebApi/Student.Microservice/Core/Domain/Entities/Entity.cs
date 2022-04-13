using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Microservice.Core.Domain.Entities
{
    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string CreateUserId { get; set; }
        bool IsActive { get; set; }
        DateTime ModifyDate { get; set; }
        string ModifyUserId { get; set; }
        int StatusId { get; set; }
    }

    public abstract class AuditEntity<T> : Entity<T>, IAuditEntity
    {
        public DateTime CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        [MaxLength(256)]
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; } = true;
        public int StatusId { get; set; }
    }

    public abstract class BaseEntity { }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }

}
