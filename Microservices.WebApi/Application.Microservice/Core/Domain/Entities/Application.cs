using System.ComponentModel.DataAnnotations;

namespace Application.Microservice.Core.Domain.Entities
{
    public class Application : AuditEntity<int>
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int AcademicRecordId { get; set; }
        [Required]
        public int InstitutionId { get; set; }
        [Required]
        public int APSPoints { get; set; }
        public bool RecommendCourse { get; set; }
    }
}
