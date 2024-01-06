using MediatR;
using Teams.Application.Common.Abstracts;
using Teams.Application.Common.Exceptions;
using Teams.Domain.Repositories;

namespace Teams.Application.Functions.Members;

public record AddRandomMemberCommand(Guid TeamId) : IRequest;

public class AddRandomMemberCommandHandler : IRequestHandler<AddRandomMemberCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IRandomMemberClient _randomMemberClient;

    public AddRandomMemberCommandHandler(ITeamRepository teamRepository,
        IRandomMemberClient randomMemberClient)
    {
        _teamRepository = teamRepository;
        _randomMemberClient = randomMemberClient;
    }

    public async Task Handle(AddRandomMemberCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetTeamAsync(request.TeamId);
        if (team is null)
            throw new NoTeamFoundException(request.TeamId);

        var member = await _randomMemberClient.GetRandomMember();
        team.AddMember(member);
    }
}