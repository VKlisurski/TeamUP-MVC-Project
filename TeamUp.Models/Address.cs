using System.ComponentModel.DataAnnotations;
namespace TeamUp.Models
{
    public class Address
    {
        [Key]
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

        public int? Number { get; set; }
    }
}
