namespace TeamUp.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class GameDetailsViewModel : IMapFrom<Game>
    {
        [Required]
        public DateTime StartDate { get; set; }

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

        public virtual User Creator { get; set; }

        public virtual Field Field { get; set; }

        public virtual ICollection<User> ApprovedPlayers { get; set; }

        public virtual ICollection<User> AppliedPlayers { get; set; }
    }
}