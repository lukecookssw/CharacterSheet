using CharacterSheet.Domain.Common;
using CharacterSheet.Domain.Enums;

namespace CharacterSheet.Domain.Entities;

public class Item : _BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ItemType ItemType { get; set; }
    public ICollection<ItemProperty> ItemProperties { get; set; } = new HashSet<ItemProperty>();
}
