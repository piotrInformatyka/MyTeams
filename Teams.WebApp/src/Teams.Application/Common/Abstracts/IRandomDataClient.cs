using Teams.Domain.Entities;

namespace Teams.Application.Common.Abstracts;

public interface IRandomMemberClient
{
    Task<Member> GetRandomMember(); 
}
