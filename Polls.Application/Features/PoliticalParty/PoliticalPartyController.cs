using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polls.Application.Features.PoliticalParty.ReadPolitcalParties;

namespace Polls.Application.Features.PoliticalParty;

[Authorize]
[ApiController]
[Route("political-parties")]
public class PoliticalPartyController : ControllerBase
{
    private readonly IMediator _mediator;

    public PoliticalPartyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ReadPoliticalParties(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ReadPoliticalPartiesQuery(), cancellationToken);
        return Ok(result);
    }
}