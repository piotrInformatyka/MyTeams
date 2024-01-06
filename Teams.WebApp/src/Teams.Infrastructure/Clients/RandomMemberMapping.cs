using Teams.Domain.Entities;
using Teams.Infrastructure.Exceptions;

namespace Teams.Infrastructure.Clients;

internal static class RandomMemberMapping
{
    internal static Member AsMember(this RandomMemberResponse response)
    {
        var result = response.Results.FirstOrDefault() ?? throw new RandomDataClientException("No result found");

        var name = result.Name.First + " " + result.Name.Last;
        return new Member(name, result.Email, result.Cell);
    }
}
