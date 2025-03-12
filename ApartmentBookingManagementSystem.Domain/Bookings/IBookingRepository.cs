using ApartmentBookingManagementSystem.Domain.Apartments;

namespace ApartmentBookingManagementSystem.Domain.Bookings;

public interface IBookingRepository
{
    #region Public Methods

    Task<Booking> IsOverlappingAsync
        (
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken = default
        );

    void Add(Booking booking);

    #endregion Public Methods
}