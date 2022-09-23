using CharacterSheet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Domain.Entities;

public class Race : _BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Character> Characters { get; set; } = new HashSet<Character>();
}
