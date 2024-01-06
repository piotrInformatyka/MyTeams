using Teams.Domain.Exceptions;

namespace Teams.Infrastructure.Exceptions;

internal sealed class RandomDataClientException : CustomException
{
    public RandomDataClientException(string message) : base(message)
    {
    }
}
