using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class Attribute : _BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<CharacterAttribute> CharacterAttributes { get; set; } = new HashSet<CharacterAttribute>();
    public ICollection<SavingThrow> SavingThrows { get; set; } = new HashSet<SavingThrow>();
}
