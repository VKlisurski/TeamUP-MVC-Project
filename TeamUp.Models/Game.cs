namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        private ICollection<User> appliedPlayers;

        public Game()
        {
            this.appliedPlayers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

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
