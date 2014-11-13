using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace TeamUp.Web.Areas.Administration.Models.Base
{
    public abstract class AdministrationViewModel
    {

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Добавено на")]
        public DateTime CreatedOn { get; set; }


        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Променено на")]
        public DateTime? ModifiedOn { get; set; }
    }
}