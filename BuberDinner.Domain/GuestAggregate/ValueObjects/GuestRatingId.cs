using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;
public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; private set; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new GuestRatingId(Guid.NewGuid());
    }

    public static GuestRatingId Create(Guid value)
    {
        return new GuestRatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}