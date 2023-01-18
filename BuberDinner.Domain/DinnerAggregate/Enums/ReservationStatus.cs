
namespace BuberDinner.Domain.Dinner.Enums;
public class ReservationStatus 
{
    public ReservationStatus(string name, int value)
    {
    }

    public static readonly ReservationStatus PendingGuestApproval = new(nameof(PendingGuestApproval), 1);
    public static readonly ReservationStatus Reserved = new(nameof(Reserved), 2);
    public static readonly ReservationStatus Cancelled = new(nameof(Cancelled), 3);
}
