namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vote
    {
        public int Id { get; set; }

        public double SkillsRating { get; set; }

        public double TeamPlayerRating { get; set; }

        public double CruidityRating { get; set; }

        public bool ShowedUp { get; set; }

        public Guid CreatorId { get; set; }

        public User Creator { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
