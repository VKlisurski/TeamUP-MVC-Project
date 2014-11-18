namespace TeamUp.Web.Models.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TeamUp.Models;

    public class GameAddViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("FormDateTimePicker")]
        [Display(Name = "Дата/час")]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(1, 12)]
        [UIHint("FormAvailableSpots")]
        [Display(Name = "Свободни места")]
        public int AvailableSpots { get; set; }

        [Required]
        [Range(8, 12)]
        [UIHint("FormMinMaxPlayers")]
        [Display(Name = "Мин играчи")]
        public int MinPlayers { get; set; }

        [Required]
        [Range(8, 12)]
        [UIHint("FormMinMaxPlayers")]
        [Display(Name = "Макс играчи")]
        public int MaxPlayers { get; set; }

        [Required]
        [Display(Name = "Игрището е запазено")]
        [UIHint("HasReservation")]
        public bool HasReservetion { get; set; }
        
        [StringLength(500)]
        [UIHint("MultiLineText")]
        [Display(Name = "Допълнителна информация")]
        [AllowHtml]
        public string AdditionalInfo { get; set; }

        [Required]
        [Range(20, 200)]
        [UIHint("Price")]
        [Display(Name = "Цена на игрището")]
        public decimal Price { get; set; }

        [UIHint("DropDownList")]
        [Display(Name = "Игрище")]
        public int FieldId { get; set; }


        public User Creator { get; set; }

        public Field Field { get; set; }
        
        public IEnumerable<SelectListItem> Fields { get; set; }
    }
}