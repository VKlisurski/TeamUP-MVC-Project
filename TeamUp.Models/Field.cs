﻿namespace TeamUp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Models.Base;

    public class Field : AuditInfo
    {
        private ICollection<Game> games;

        public Field()
        {
            this.games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
