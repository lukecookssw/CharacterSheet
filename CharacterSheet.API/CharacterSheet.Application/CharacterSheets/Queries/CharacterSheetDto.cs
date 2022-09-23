using AutoMapper;
using CharacterSheet.Application.Common.Calculators;
using CharacterSheet.Application.Common.Mappings;
using CharacterSheet.Application.Common.Models;
using CharacterSheet.Domain.Entities;

namespace CharacterSheet.Application.CharacterSheets.Queries;

public class CharacterSheetDto : IMapFrom<Character>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Character, CharacterSheetDto>();
    }
}