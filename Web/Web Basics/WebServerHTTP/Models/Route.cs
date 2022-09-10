using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(1), MaxLength(3), RegularExpression(@"^\d[abc]\+{1}$")]
        public string Grade { get; set; }
    }
}
