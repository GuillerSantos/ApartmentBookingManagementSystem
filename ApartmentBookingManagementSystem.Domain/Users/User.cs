using ApartmentBookingManagementSystem.Domain.Abstractions;
using ApartmentBookingManagementSystem.Domain.Users.Events;

namespace ApartmentBookingManagementSystem.Domain.Users
{
    public sealed class User : Entity
    {
        #region Public Constructors

        private User(Guid id, FirstName firstName, LastName lastName, Email email)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        #endregion Public Constructors

        #region Properties

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }

        #endregion Properties

        #region Public Methods

        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

        #endregion Public Methods
    }
}