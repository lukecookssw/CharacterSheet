using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class CharacterClass : _BaseEntity
{
    public int CharacterId { get; set; }
    public int ClassId { get; set; }
    public int Level { get; set; }
    public Character Character { get; set; }
    public Class Class { get; set; }
}
