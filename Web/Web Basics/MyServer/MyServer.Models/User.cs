using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class User
    {
        public User()
        {
            this.Ascents = new HashSet<Ascent>();
            this.CreatedBoulders = new HashSet<Boulder>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(10)]
        public string PasswordHash { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public virtual City HomeCity { get; set; }

        [Required]
        public int CountryId { get; set; }

        public int? GymId { get; set; }

        public virtual Gym FavouriteGym { get; set; }

        public virtual ICollection<Ascent> Ascents { get; set; }
        public virtual ICollection<Boulder> CreatedBoulders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
