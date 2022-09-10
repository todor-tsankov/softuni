using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class City
    {
        public City()
        {
            this.Gyms = new HashSet<Gym>();
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public byte[] ImageData { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public bool IsDeleted { get; set; }
    }
}
