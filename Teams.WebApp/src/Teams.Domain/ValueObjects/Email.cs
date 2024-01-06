using System.Text.RegularExpressions;
using Teams.Domain.Exceptions;

namespace Teams.Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (!IsValid(value))
            throw new InvalidEmailException(value);

        Value = value;
    }

    private static bool IsValid(string value) => Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string email) => new(email);
}
