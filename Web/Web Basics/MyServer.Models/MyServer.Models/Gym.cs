using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public byte[] ImageData { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public virtual City City { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public bool IsDeleted { get; set; }
    }
}
