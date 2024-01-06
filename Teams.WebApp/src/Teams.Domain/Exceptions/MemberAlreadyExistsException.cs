namespace Teams.Domain.Exceptions;

public sealed class MemberAlreadyExistsException : CustomException
{
    public string Name { get; }

    public MemberAlreadyExistsException(string name) : base($"Member with name {name} already exists.")
    {
        Name = name;
    }
}
