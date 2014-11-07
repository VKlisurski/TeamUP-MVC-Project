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

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan StartHour { get; set; }

        public int AvailableSpots { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public bool HasReservetion { get; set; }

        public string AdditionalInfo { get; set; }

        public decimal Price { get; set; }

        public Guid CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int FieldId { get; set; }

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
