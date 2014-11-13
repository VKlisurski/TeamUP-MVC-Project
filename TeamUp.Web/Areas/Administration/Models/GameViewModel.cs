namespace TeamUp.Web.Areas.Administration.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;
    using TeamUp.Web.Areas.Administration.Models.Base;

    public class GameViewModel : AdministrationViewModel, IMapFrom<Game>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Начало")]
        public DateTime StartDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Създател")]
        public string CreatorName { get; set; }

        [Display(Name = "Игрище")]
        public string FieldName { get; set; }

        [Required]
        [Display(Name = "Места")]
        public int AvailableSpots { get; set; }

        [Required]
        [Display(Name = "Мин. Играчи")]
        public int MinPlayers { get; set; }

        [Required]
        [Display(Name = "Макс. Играчи")]
        public int MaxPlayers { get; set; }

        [Required]
        [Display(Name = "Резервация")]
        public bool HasReservetion { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Игрище")]
        public Field Field { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, GameViewModel>()
                .ForMember(g => g.CreatorName, opt => opt.MapFrom(b => b.Creator.TeamUpUsername));

            configuration.CreateMap<Game, GameViewModel>()
                .ForMember(g => g.FieldName, opt => opt.MapFrom(b => b.Field.Name));
        }
    }
}