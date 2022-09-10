using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(3)]
        public string CountryCode { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public byte[] ImageData { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public bool IsDeleted { get; set; }
    }
}
