namespace Teams.Domain.Exceptions;

public sealed class InvalidPhoneNumber : CustomException
{
    public string PhoneNumber { get; }

    public InvalidPhoneNumber(string phoneNumber) : base($"Phone number {phoneNumber} is invalid.")
    {
        PhoneNumber = phoneNumber;
    }
}
