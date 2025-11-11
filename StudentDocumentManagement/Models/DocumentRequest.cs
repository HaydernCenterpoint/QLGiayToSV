using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDocumentManagement.Models
{
    public class DocumentRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentType { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;

        public string? AdminNotes { get; set; }
    }
}
