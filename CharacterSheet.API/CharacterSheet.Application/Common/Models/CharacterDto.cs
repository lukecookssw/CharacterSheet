using AutoMapper;
using CharacterSheet.Application.Common.Mappings;
using CharacterSheet.Domain.Entities;

namespace CharacterSheet.Application.Common.Models;

public class CharacterDto : IMapFrom<Character>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string Background { get; set; } = string.Empty;
    public List<CharacterClassDto> CharacterClasses { get; set; } = new();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Character, CharacterDto>()
            .ForMember(dst => dst.Race, opt => opt.MapFrom(src => src.Race.Name))
            .ForMember(dst => dst.CharacterClasses, opt => opt.MapFrom(src => src.Classes));
    }
}

