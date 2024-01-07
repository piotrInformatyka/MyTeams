using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teams.Application.Functions.Members;
using Teams.Application.Functions.Teams;

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

        [HttpGet]
        public async Task<ActionResult> GetTeams()
        {
            var result = await _mediator.Send(new GetTeamsQuery());
            return Ok(result);
        }
    }
}
