using System;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public Doctor Doctor { get; set; }
    }
}
