using Teams.Domain.Exceptions;

namespace Teams.Application.Common.Exceptions;

public sealed class NoTeamFoundException : CustomException
{
    public NoTeamFoundException(Guid id) : base($"Team with id: '{id}' does not exist)")
    {

    }
}
