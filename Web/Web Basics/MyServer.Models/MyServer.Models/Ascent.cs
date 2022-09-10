using System;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Ascent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int BoulderId { get; set; }

        [Required]
        public Boulder Boulder { get; set; }

        [Required]
        public int GradeId { get; set; }

        [Required]
        public Grade ProposedGrade { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }

        public bool Recommend { get; set; }

        [Range(0, 5)]
        public int? Stars { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int StyleId { get; set; }

        [Required]
        public Style Style { get; set; }

        public bool IsDeleted { get; set; }
    }
}
