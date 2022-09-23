using CharacterSheet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharacterSheet.Infrastructure.Database;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Races.Any())
        {
            await CreateRaces();
        }
        if (!_context.Attributes.Any())
        {
            await CreateAttributes();
        }
        if (!_context.SavingThrows.Any())
        {
            await CreateSavingThrows();
        }
        if (!_context.Items.Any())
        {
            await CreateItems();
        }
        if (!_context.Characters.Any())
        {
            await CreateCharacters();
        }
    }

    private async Task CreateCharacters()
    {
        _context.Characters.Add(new Character
        {
            Id = 1,
            Name = "Sir Testy",
            RaceId = 1,
            Attributes = new List<CharacterAttribute>
            {
                new CharacterAttribute { AttributeId = 1, Value = 8 },
                new CharacterAttribute { AttributeId = 2, Value = 10 },
                new CharacterAttribute { AttributeId = 3, Value = 11 },
                new CharacterAttribute { AttributeId = 4, Value = 12 },
                new CharacterAttribute { AttributeId = 5, Value = 13 },
                new CharacterAttribute { AttributeId = 6, Value = 14 },
            }
            
        });
        await _context.SaveChangesAsync();

        var c = _context.Characters.ToList();
    }

    private async Task CreateSavingThrows()
    {
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 1,
            Name = "Strength",
            AttributeId = 1
        });
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 2,
            Name = "Dexterity",
            AttributeId = 2
        });
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 3,
            Name = "Constitution",
            AttributeId = 3
        });
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 4,
            Name = "Intelligence",
            AttributeId = 4
        });
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 5,
            Name = "Wisdom",
            AttributeId = 5
        });
        _context.SavingThrows.Add(new SavingThrow
        {
            Id = 6,
            Name = "Charisma",
            AttributeId = 6
        });
        await _context.SaveChangesAsync();
    }
    
    private async Task CreateRaces()
    {
        _context.Races.Add(new Race { Name = "Human" });
        _context.Races.Add(new Race { Name = "Elf" });
        _context.Races.Add(new Race { Name = "Dwarf" });
        _context.Races.Add(new Race { Name = "Halfling" });

        await _context.SaveChangesAsync();
    }
    private async Task CreateAttributes()
    {
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Strength" });
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Dexterity" });
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Constitution" });
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Intelligence" });
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Wisdom" });
        _context.Attributes.Add(new Domain.Entities.Attribute { Name = "Charisma" });
        
        await _context.SaveChangesAsync();
    }
    
    private async Task CreateItems()
    {
        _context.Items.Add(new Item { Name = "Helmet" });
        _context.Items.Add(new Item { Name = "Armor" });
        _context.Items.Add(new Item { Name = "Gloves" });
        _context.Items.Add(new Item { Name = "Boots" });
        _context.Items.Add(new Item
        {
            Name = "Ring of Protection +1",
            ItemProperties = new List<ItemProperty>
            {
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.ArmorModifier,
                    Value = 1
                }
            }
        });
        _context.Items.Add(new Item
        {
            Name = "Ring of Resistance +1",
            ItemProperties = new List<ItemProperty>
            {
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.StrengthSaveModifier,
                    Value = 1
                },
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.DexteritySaveModifier,
                    Value = 1
                },
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.ConstitutionSaveModifier,
                    Value = 1
                },
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.IntelligenceSaveModifier,
                    Value = 1
                },
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.WisdomSaveModifier,
                    Value = 1
                },
                new ItemProperty
                {
                    Name = "Bonus",
                    ModifierType = Domain.Enums.ModifierType.Enhancement,
                    PropertyType = Domain.Enums.ItemPropertyType.CharismaSaveModifier,
                    Value = 1
                }
            }
        });
        _context.Items.Add(new Item { Name = "Amulet of Natural Armor +1" });
        _context.Items.Add(new Item { Name = "Royal cape" });

        await _context.SaveChangesAsync();
    }
}