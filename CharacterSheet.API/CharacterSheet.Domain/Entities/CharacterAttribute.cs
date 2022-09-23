using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class CharacterAttribute : _BaseEntity
{
    public int AttributeId { get; set; }
    public int PlayerCharacterId { get; set; }
    public int Value { get; set; }
    public Attribute? Attribute { get; set; }
    public Character? PlayerCharacter { get; set; }
}
