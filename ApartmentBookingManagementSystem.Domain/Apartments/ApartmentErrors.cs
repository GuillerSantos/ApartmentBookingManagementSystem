using ApartmentBookingManagementSystem.Domain.Abstractions;

namespace ApartmentBookingManagementSystem.Domain.Apartments;

public static class ApartmentErrors
{
    #region Fields

    public static Error NotFound = new
        (
            "Property.Found",
            "The Property With The Specified Identifier Was Not Found"
        );

    #endregion Fields
}