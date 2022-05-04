using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Domain.Entities
{
    public abstract class BaseEntity { }
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }

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
        [Required]
        public DateTime CreatedDate { get; set; }
        [MaxLength(256)]
        public string CreateUserId { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [MaxLength(256)]
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public int StatusId { get; set; }
    }
}
