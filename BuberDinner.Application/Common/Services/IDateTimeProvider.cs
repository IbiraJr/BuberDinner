namespace BuberDinner.Application.Common.Services;

public interface IDateTimerProvider
{
    DateTime UtcNow { get; }
}

