using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Web.Models
{
    public class GameViewModel
    {
        private ICollection<User> appliedPlayers;

        public GameViewModel()
        {
            this.appliedPlayers = new HashSet<User>();
        }

        public GameViewModel(Game game)
        {

        }

        public static Expression<Func<Game, GameViewModel>> FromGame
        {
            get
            {
                return g => new GameViewModel
                {
                    DateCreated = g.DateCreated,
                    StartDate = g.StartDate,
                    StartHour = g.StartHour,
                    AvailableSpots = g.AvailableSpots,
                    MinPlayers = g.MinPlayers,
                    MaxPlayers = g.MaxPlayers,
                    HasReservetion = g.HasReservetion,
                    AdditionalInfo = g.AdditionalInfo,
                    Price = g.Price,
                    Creator = g.Creator,
                    Field = g.Field,
                    AppliedPlayers = g.AppliedPlayers
                };
            }
        }


        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan StartHour { get; set; }

        [Required]
        public int AvailableSpots { get; set; }

        [Required]
        public int MinPlayers { get; set; }

        [Required]
        public int MaxPlayers { get; set; }

        [Required]
        public bool HasReservetion { get; set; }

        public string AdditionalInfo { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        public int FieldId { get; set; }

        [Required]
        public virtual Field Field { get; set; }

        public virtual ICollection<User> AppliedPlayers
        {
            get
            {
                return this.appliedPlayers;
            }
            set
            {
                this.appliedPlayers = value;
            }
        }
    }
}