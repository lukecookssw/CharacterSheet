using CharacterSheet.Domain.Entities;
using CharacterSheet.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Application.IntegrationTests;

public static class TestData
{
    public static void InitialiseTestData(ApplicationDbContext context)
    {
        context.Characters.Add(new Character { Id = 1, Name = "Integration Testy", Race = new Race { Name = "Human" } });
        context.SaveChanges();

        var v = context.Characters.ToList();
    }
}
