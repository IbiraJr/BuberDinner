using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        // TODO: enforce invariants
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
