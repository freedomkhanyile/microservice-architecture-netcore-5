using System.ComponentModel.DataAnnotations;

namespace Application.Microservice.Core.Domain.Entities
{
    public class ApplicationResult : AuditEntity<int>
    {

        [Required]
        public int InstitutionId { get; set; }
        [Required]
        public int FacultyId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int QualificationId { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int ApsScoreResult { get; set; }
    }
}
