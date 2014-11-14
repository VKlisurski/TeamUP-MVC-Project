namespace TeamUp.Web.Areas.Administration.Models
{
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class FieldViewModel : IMapFrom<Field>, IHaveCustomMappings
    {
        public FieldViewModel()
        {
            this.Img = "Content\\Images\\Fields\\default.jpg";
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [MaxLength(200)]
        [Display(Name = "Сайт")]
        public string Website { get; set; }

        [MaxLength(200)]
        [Display(Name = "Снимка")]
        public string Img { get; set; }

        [HiddenInput(DisplayValue = false)]
        public TimeSpan? OpenningHour { get; set; }

        [HiddenInput(DisplayValue = false)]
        public TimeSpan? ClosingHour { get; set; }

        [MaxLength(50)]
        [Display(Name = "Допълнителна информация")]
        public string MoreInfo { get; set; }


        [HiddenInput(DisplayValue = false)]
        public Address Address { get; set; }


        [Required]
        [Display(Name = "Град")]
        public string City { get; set; }

        [Display(Name = "Квартал")]
        public string Neighbourhood { get; set; }

        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Display(Name = "Номер на улица")]
        public int? StreetNumber { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Field, FieldViewModel>()
                .ForMember(g => g.City, opt => opt.MapFrom(b => b.Address.City));

            configuration.CreateMap<Field, FieldViewModel>()
                .ForMember(g => g.Neighbourhood, opt => opt.MapFrom(b => b.Address.Neighbourhood));

            configuration.CreateMap<Field, FieldViewModel>()
                .ForMember(g => g.Street, opt => opt.MapFrom(b => b.Address.Street));

            configuration.CreateMap<Field, FieldViewModel>()
                .ForMember(g => g.StreetNumber, opt => opt.MapFrom(b => b.Address.Number));
        }
    }
}