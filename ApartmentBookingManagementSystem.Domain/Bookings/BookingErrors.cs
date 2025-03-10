using ApartmentBookingManagementSystem.Domain.Abstractions;

namespace ApartmentBookingManagementSystem.Domain.Bookings
{
    public static class BookingErrors
    {
        #region Fields

        public static Error NotFound = new(
            "Booking.Found",
            "The Booking With The Specified Identifier Was Not Found");

        public static Error Overlap = new(
            "Booking.Oberlap",
            "The Current Booking Is Overlapping With An Existing One");

        public static Error NotReserved = new(
            "Booking.NotReserved",
            "The Booking Is Not Pending");

        public static Error NotConfirmed = new(
            "Booking.NotReserved",
            "The Booking Is Not Conformed");

        public static Error AlreadyStared = new(
            "Booking.AlreadyStarted",
            "The Booking Has Already Started");

        #endregion Fields
    }
}