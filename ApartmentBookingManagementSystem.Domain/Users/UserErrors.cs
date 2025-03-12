using ApartmentBookingManagementSystem.Domain.Abstractions;

namespace ApartmentBookingManagementSystem.Domain.Users;

public static class UserErrors
{
    #region Fields

    public static Error NotFound = new
        (
            "User.Found",
            "The User With The Specified Identifier Was Not Found"
        );

    public static Error InvalidCredentials = new
        (
            "User.InvalidCredentials",
            "The Provided Credentials Were Invalid"
        );

    #endregion Fields
}