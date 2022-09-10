using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Boulder
    {
        public Boulder()
        {
            this.Ascents = new HashSet<Ascent>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public byte[] ImageData { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public int GymId { get; set; }

        [Required]
        public virtual Gym Gym { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public virtual ICollection<Ascent> Ascents { get; set; }

        public bool IsDeleted { get; set; }
    }
}
