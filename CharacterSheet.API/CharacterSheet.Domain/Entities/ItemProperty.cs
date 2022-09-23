using CharacterSheet.Domain.Common;
using CharacterSheet.Domain.Enums;

namespace CharacterSheet.Domain.Entities;

public class ItemProperty : _BaseEntity
{
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? Value { get; set; }
    public ItemPropertyType? PropertyType { get; set; }
    public ModifierType? ModifierType { get; set; }
    public Item? Item { get; set; }
}
