using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharacterSheet.API.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class _ApiBaseController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}