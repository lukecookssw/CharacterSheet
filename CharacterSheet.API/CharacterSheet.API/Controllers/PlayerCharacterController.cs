using CharacterSheet.Application.Characters.Queries.GetCharacter;
using CharacterSheet.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharacterSheet.API.Controllers;

public class PlayerCharacterController : _ApiBaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDto>> Get(int id)
    {
        return await Mediator.Send(new GetCharacter(id));
    }
}