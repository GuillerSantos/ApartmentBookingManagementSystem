using ApartmentBookingManagementSystem.Domain.Shared;

namespace ApartmentBookingManagementSystem.Domain.Bookings
{
    public record PricingDetails(
        Money PriceForPeriod,
        Money CleaningFee,
        Money AmenitiesUpCharge,
        Money TotalPrice);
}