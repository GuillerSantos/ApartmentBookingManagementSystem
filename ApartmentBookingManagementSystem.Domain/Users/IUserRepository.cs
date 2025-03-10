namespace ApartmentBookingManagementSystem.Domain.Users
{
    public interface IUserRepository
    {
        #region Public Methods

        Task<User?> GetByIdAync(Guid id, CancellationToken cancellationToken = default);

        void Add(User user);

        #endregion Public Methods
    }
}