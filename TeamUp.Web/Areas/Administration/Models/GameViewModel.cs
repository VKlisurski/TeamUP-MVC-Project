namespace TeamUp.Web.Areas.Administration.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using TeamUp.Infrastructure.Mapping;
    using TeamUp.Models;

    public class GameViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Начало")]
        public DateTime StartDate { get; set; }

        [Range(1, 11)]
        [Display(Name = "Места")]
        public int AvailableSpots { get; set; }

        [Display(Name = "Мин. Играчи")]
        [Range(8, 12)]
        public int MinPlayers { get; set; }

        [Required]
        [Range(8, 12)]
        [Display(Name = "Макс Играчи")]
        public int MaxPlayers { get; set; }

        [Required]
        [Display(Name = "Резервация")]
        public bool HasReservetion { get; set; }

        [Range(30, 100)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        [UIHint("GridForeignKey")]
        public int FieldId { get; set; }

        [Display(Name = "Игрище")]
        public virtual Field Field { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Създател")]
        public string CreatorName { get; set; }

        [Display(Name = "Игрище")]
        [HiddenInput(DisplayValue = false)]
        public string FieldName { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, GameViewModel>()
                .ForMember(g => g.CreatorName, opt => opt.MapFrom(b => b.Creator.TeamUpUsername));

            configuration.CreateMap<Game, GameViewModel>()
                .ForMember(g => g.FieldName, opt => opt.MapFrom(b => b.Field.Name));
        }
    }
}