using MediatR;
using Teams.Domain.Repositories;

namespace Teams.Application.Functions.Teams;

public record GetTeamsQuery : IRequest<GetTeamsResponse> { }

public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, GetTeamsResponse>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamsQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<GetTeamsResponse> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetAllAsync();
        return new GetTeamsResponse(teams);
    }
}
