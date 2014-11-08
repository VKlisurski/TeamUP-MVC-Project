namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public double SkillsRating { get; set; }
        
        [Required]
        public double TeamPlayerRating { get; set; }
        
        [Required]
        public double CruidityRating { get; set; }

        [Required]
        public bool ShowedUp { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public virtual Game Game { get; set; }
    }
}
