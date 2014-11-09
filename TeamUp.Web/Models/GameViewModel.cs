using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TeamUp.Infrastructure.Mapping;
using TeamUp.Models;

namespace TeamUp.Web.Models
{
    public class GameViewModel : IMapFrom<Game>
    {
        private ICollection<User> appliedPlayers;

        public GameViewModel()
        {
            this.appliedPlayers = new HashSet<User>();
        }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan StartHour { get; set; }

        [Required]
        [Range(0, 12)]
        public int AvailableSpots { get; set; }
        [Required]
        [Range(8, 12)]
        public int MaxPlayers { get; set; }

        [Required]
        [Range(20, 200)]
        public decimal Price { get; set; }
    }
}