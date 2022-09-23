using AutoMapper;
using CharacterSheet.Application.Common.Mappings;
using CharacterSheet.Domain.Entities;

namespace CharacterSheet.Application.Common.Models;

public class CharacterClassDto : IMapFrom<CharacterClass>
{
    public int CharacterClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public int Level { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CharacterClass, CharacterClassDto>()
            .ForMember(dst => dst.CharacterClassId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.ClassName, opt => opt.MapFrom(src => src.Class.Name));
    }
}
