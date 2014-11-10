namespace TeamUp.Models
{
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Models.Base;

    public class Address : AuditInfo
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
