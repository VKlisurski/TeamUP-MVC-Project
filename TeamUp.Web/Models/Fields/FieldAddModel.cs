using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamUp.Models;

namespace TeamUp.Web.Models.Fields
{
    public class FieldAddModel
    {
        public int Id { get; set; }

        [StringLength(50), MinLength(5)]
        [UIHint("SingleLineText")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [StringLength(15), MinLength(7)]
        [UIHint("SingleLineText")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [StringLength(200)]
        [UIHint("SingleLineText")]
        [Display(Name = "Сайт")]
        public string Website { get; set; }

        public TimeSpan? OpenningHour { get; set; }

        public TimeSpan? ClosingHour { get; set; }

        [DataType(DataType.Time)]
        [UIHint("FormTimePicker")]
        [Display(Name = "Отваря")]
        public DateTime? OpeningHourDate { get; set; }

        [DataType(DataType.Time)]
        [UIHint("FormTimePicker")]
        [Display(Name = "Затваря")]
        public DateTime? ClosingHourDate { get; set; }

        [StringLength(50)]
        [UIHint("MultiLineText")]
        [Display(Name = "Допълнителна информация")]
        public string MoreInfo { get; set; }

        [StringLength(50), MinLength(5)]
        [UIHint("SingleLineText")]
        [Display(Name = "Град")]
        public string City { get; set; }

        [StringLength(50)]
        [UIHint("SingleLineText")]
        [Display(Name = "Квартал")]
        public string Neighbourhood { get; set; }

        [StringLength(50), MinLength(5)]
        [UIHint("SingleLineText")]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [UIHint("FormStreetNumber")]
        [Display(Name = "Номер")]
        public int? Number { get; set; }

        public Address Address { get; set; }

        [UIHint("FormImage")]
        [Display(Name = "Снимка на игрището")]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}