namespace TeamUp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Field
    {
        private ICollection<Game> games;

        public Field()
        {
            this.games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public int AddressId { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
