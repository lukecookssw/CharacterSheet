using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class Character : _BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int RaceId { get; set; }
    public string Background { get; set; } = string.Empty;
    public Race Race { get; set; }
    public ICollection<CharacterAttribute> Attributes { get; set; } = new HashSet<CharacterAttribute>();
    public ICollection<CharacterClass> Classes { get; set; } = new HashSet<CharacterClass>();
}
