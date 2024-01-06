namespace Teams.Infrastructure.Clients;

internal record RandomMemberResponse(IEnumerable<Result> Results);
internal record Result(Name Name, string Email, string Cell);
internal record Name(string First, string Last);