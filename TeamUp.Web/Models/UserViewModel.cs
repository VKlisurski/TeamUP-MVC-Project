namespace TeamUp.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string ImgPath { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string TeamUpUsername { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}