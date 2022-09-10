using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyServer.Models
{
    public class Grade
    {
        public Grade()
        {
            this.Boulders = new HashSet<Boulder>();
            this.Ascents = new HashSet<Ascent>();
        }

        [Key]
        public int Id { get; set; }

        [Required, RegularExpression(@"^\d[ABC]\+{0,1}$")]
        public string GradeText { get; set; }

        public int Points { get; set; }

        public virtual ICollection<Boulder> Boulders { get; set; }
        public virtual ICollection<Ascent> Ascents { get; set; }

        public bool IsDeleted { get; set; }
    }
}