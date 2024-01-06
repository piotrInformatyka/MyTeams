using Microsoft.Extensions.Configuration;
using Teams.Application.Common.Abstracts;
using Teams.Domain.Entities;

namespace Teams.Infrastructure.Clients;

internal sealed class RandomMemberClient : IRandomMemberClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public RandomMemberClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["RandomDataUrl"] ?? string.Empty;
    }

    public async Task<Member> GetRandomMember()
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        response.EnsureSuccessStatusCode();

        var test = response.Content;

        return new Member("test", "test", "test");
    }
}
