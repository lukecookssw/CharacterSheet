using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class SavingThrow : _BaseEntity
{
    public string Name { get; set; }
    public int? AttributeId { get; set; }
    public Attribute? Attribute { get; set; }
}
