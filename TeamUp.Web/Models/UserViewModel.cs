namespace TeamUp.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class UserViewModel : IMapFrom<User>
    {
        private ICollection<Game> games;

        public UserViewModel()
        {
            this.games = new HashSet<Game>();
        }

        public string PhoneNUmber { get; set; }

        public string ImgPath { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string TeamUpUsername { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}