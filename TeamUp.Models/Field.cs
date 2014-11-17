namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Field
    {
        public Field()
        {
            this.Img = "Content\\Images\\Fields\\default.jpg";
        }

        public int Id { get; set; }

        [StringLength(50), MinLength(5)]
        public string Name { get; set; }

        [StringLength(15), MinLength(10)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        [StringLength(200)]
        public string Img { get; set; }

        public TimeSpan? OpenningHour { get; set; }

        public TimeSpan? ClosingHour { get; set; }

        [StringLength(50)]
        public string MoreInfo { get; set; }

        public int? GamesCount { get; set; }

        [Required]
        public virtual Address Address { get; set; }
    }
}
