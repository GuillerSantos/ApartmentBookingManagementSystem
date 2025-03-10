namespace ApartmentBookingManagementSystem.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        #region Public Methods

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        #endregion Public Methods
    }
}