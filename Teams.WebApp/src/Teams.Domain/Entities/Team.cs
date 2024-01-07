using Teams.Domain.Exceptions;

namespace Teams.Domain.Entities;

public class Team
{
    private readonly HashSet<Member> _members = new();

    public Guid Id { get; }
    public IEnumerable<Member> Members => _members;
    
    public Team() { }

    public void AddMember(Member member)
    {
        var memberAlreadyExists = _members.Any(x => x.Email == member.Email);
        if (memberAlreadyExists)
            throw new MemberAlreadyExistsException(member.Email);
        
        _members.Add(member);
    }

    public void RemoveMember(Member member) => _members.RemoveWhere(x => x.Id == member.Id);
}
