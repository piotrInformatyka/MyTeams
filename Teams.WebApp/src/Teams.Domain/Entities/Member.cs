using Teams.Domain.ValueObjects;

namespace Teams.Domain.Entities;

public class Member
{
    public Guid Id { get; }
    public Name Name { get; }
    public Email Email { get; }
    public PhoneNumber PhoneNumber { get; }
    public DateTimeOffset CreatedAt { get; }
    public bool IsBlocked { get; private set; }
    
    protected Member() { }
    public Member(string name, string email, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTimeOffset.UtcNow;
        IsBlocked = false;
    }

    public void Block() => IsBlocked = !IsBlocked;
}
