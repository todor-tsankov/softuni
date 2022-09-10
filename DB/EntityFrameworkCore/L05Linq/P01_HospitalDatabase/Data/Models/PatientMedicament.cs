using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int MedicamentId { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public Medicament Medicament { get; set; }
    }
}
