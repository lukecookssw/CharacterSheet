using CharacterSheet.Application.Common.Interfaces;
using CharacterSheet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CharacterSheet.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Entities.Attribute> Attributes => Set<Domain.Entities.Attribute>();
    public DbSet<CharacterAttribute> CharacterAttributes => Set<CharacterAttribute>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<CharacterClass> CharacterClasses => Set<CharacterClass>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<ItemProperty> ItemProperties => Set<ItemProperty>(); 
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<SavingThrow> SavingThrows => Set<SavingThrow>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}