using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teams.Application.Functions.Members;

namespace Teams.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{teamId}/random")]
        public async Task<ActionResult> RandomMember(Guid teamId, AddRandomMemberCommand command)
        {
            await _mediator.Send(command with { TeamId = teamId});
            return Ok();
        }
    }
}
