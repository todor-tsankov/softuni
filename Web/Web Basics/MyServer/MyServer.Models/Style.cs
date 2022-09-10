using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Style
    {
        public Style()
        {
            this.Ascents = new HashSet<Ascent>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string StyleTextShort { get; set; }

        [Required]
        public string StyleTextLong { get; set; }

        [Required]
        public int BonusPoints { get; set; }

        public ICollection<Ascent> Ascents;

        public bool IsDeleted { get; set; }
    }
}
