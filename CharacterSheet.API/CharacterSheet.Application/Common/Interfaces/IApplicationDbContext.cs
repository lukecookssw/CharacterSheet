using CharacterSheet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterSheet.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.Attribute> Attributes { get; }
        public DbSet<CharacterAttribute> CharacterAttributes { get; }
        public DbSet<CharacterClass> CharacterClasses { get; }
        public DbSet<Class> Classes { get; }
        public DbSet<Item> Items { get; }
        public DbSet<ItemProperty> ItemProperties { get; }

        public DbSet<Character> Characters { get; }
        public DbSet<Race> Races { get; }
        public DbSet<SavingThrow> SavingThrows { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
