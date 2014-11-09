namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Models.Base;

    public class Game : AuditInfo
    {
        private ICollection<User> appliedPlayers;

        public Game()
        {
            this.appliedPlayers = new HashSet<User>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

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
