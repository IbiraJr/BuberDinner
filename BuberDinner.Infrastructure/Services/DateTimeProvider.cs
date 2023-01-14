using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimerProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

