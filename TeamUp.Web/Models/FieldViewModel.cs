namespace TeamUp.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class FieldViewModel : IMapFrom<Field>
    {
        private ICollection<Game> games;

        public FieldViewModel()
        {
            this.games = new HashSet<Game>();
        }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }

        public Img Img { get; set; }

        public TimeSpan? OpenningHour { get; set; }

        public TimeSpan? ClosingHour { get; set; }

        [MaxLength(50)]
        public string MoreInfo { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}