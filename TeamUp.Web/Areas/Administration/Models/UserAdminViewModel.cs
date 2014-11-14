namespace TeamUp.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class UserAdminViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "Път на аватар")]
        public string ImgPath { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Display(Name = "Потребителско име")]
        public string TeamUpUsername { get; set; }
    }
}