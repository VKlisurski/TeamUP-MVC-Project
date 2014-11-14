namespace TeamUp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string City { get; set; }

        public string Neighbourhood { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Street { get; set; }

        public string MoreInfo { get; set; }

        public int? Number { get; set; }
    }
}
