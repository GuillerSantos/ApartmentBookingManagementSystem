using ApartmentBookingManagementSystem.Domain.Abstractions;

namespace ApartmentBookingManagementSystem.Domain.Bookings.Events
{
    public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
}