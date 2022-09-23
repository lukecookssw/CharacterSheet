using CharacterSheet.Application.Characters.Queries.GetCharacter;
using CharacterSheet.Application.Common.Exceptions;
using CharacterSheet.Application.Common.Models;
using FluentAssertions;
using NUnit.Framework;
namespace CharacterSheet.Application.IntegrationTests.PlayerCharacters.Queries;

using static Testing;
public class GetPlayerCharacterTests
{
    // GetPlayerCharacter should throw ValidationException when id is not found
    [Test]
    public async Task ShouldReturnBadRequest_CharacterNotFound()
    {
        // Arrange
        GetCharacter request = new GetCharacter(-1);

        // Act
        var action = () => SendAsync(request);

        // Assert
        await action.Should().ThrowAsync<NotFoundException>();
    }
    // GetPlayerCharacter should return test character
    [Test]
    public async Task ShouldReturnPC_IntegrationTesty()
    {
        // Arrange
        var query = new GetCharacter(1);

        // Act
        var result = await SendAsync(query);

        // Assert
        result.Should().BeOfType<CharacterDto>();
        result.Name.Should().Be("Integration Testy");
        result.Id.Should().Be(1);
    }
}
