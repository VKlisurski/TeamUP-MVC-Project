namespace TeamUp.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class GameViewModel : IMapFrom<Game>
    {
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

        [Required]
        public virtual Field Field { get; set; }
    }
}