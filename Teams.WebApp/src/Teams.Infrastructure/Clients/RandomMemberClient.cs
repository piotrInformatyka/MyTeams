using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Teams.Application.Common.Abstracts;
using Teams.Domain.Entities;
using Teams.Infrastructure.Exceptions;

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
        var result = await HandleResponseAsync(response);

        return result;
    }

    private async Task<Member> HandleResponseAsync(HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode)
            throw new Exception($"Reques finished with {response.StatusCode}");
    
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<RandomMemberResponse>(content);

        return result is null ? throw new RandomDataClientException("Can not deserialize response") : result.AsMember();
    }
}
