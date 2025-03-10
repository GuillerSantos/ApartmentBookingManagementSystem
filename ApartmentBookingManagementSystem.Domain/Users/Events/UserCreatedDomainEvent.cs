using ApartmentBookingManagementSystem.Domain.Abstractions;

namespace ApartmentBookingManagementSystem.Domain.Users.Events
{
    public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}