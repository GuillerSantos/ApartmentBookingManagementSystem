using ApartmentBookingManagementSystem.Application.Abstractions.Messaging;

namespace ApartmentBookingManagementSystem.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand
    (
        Guid ApartmentId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate
    ) : ICommad<Guid>;