using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teams.Application.Functions.Members.Commands;

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
        public async Task<IActionResult> RandomMember(Guid teamId, AddRandomMemberCommand command)
        {
            if (teamId != command.TeamId)
                return BadRequest();

            await _mediator.Send(command);
            return Ok();
        }
    }
}
