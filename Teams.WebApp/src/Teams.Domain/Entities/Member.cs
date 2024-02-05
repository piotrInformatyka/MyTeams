using Teams.Domain.ValueObjects;

namespace Teams.Domain.Entities;

public class Member
{
    public Guid Id { get; }
    public Name Name { get; }
    public Email Email { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public DateTimeOffset CreatedAt { get; }
    public bool IsBlocked { get; private set; }
    
    protected Member() { }
    public Member(string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTimeOffset.UtcNow;
        IsBlocked = false;
    }

    public void Block() => IsBlocked = !IsBlocked;

    public void ChangeContact(Email? email, PhoneNumber? phoneNumber)
    {
        if(email is null && phoneNumber is null)
            throw new ArgumentException("At least one of the contact details must be provided");

        Email = email ?? Email;
        PhoneNumber = phoneNumber ?? PhoneNumber;


    }
}
