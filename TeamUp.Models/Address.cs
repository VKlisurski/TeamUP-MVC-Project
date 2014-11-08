using System.ComponentModel.DataAnnotations;
namespace TeamUp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        public string Neighbourhood { get; set; }

        [Required]
        public string Street { get; set; }

        public int? Number { get; set; }
    }
}
