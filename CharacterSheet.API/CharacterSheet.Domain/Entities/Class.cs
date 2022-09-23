using CharacterSheet.Domain.Common;

namespace CharacterSheet.Domain.Entities;

public class Class : _BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
