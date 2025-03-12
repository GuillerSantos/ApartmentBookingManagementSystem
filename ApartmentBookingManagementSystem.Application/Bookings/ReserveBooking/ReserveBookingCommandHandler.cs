using ApartmentBookingManagementSystem.Application.Abstractions.Messaging;
using ApartmentBookingManagementSystem.Domain.Abstractions;
using ApartmentBookingManagementSystem.Domain.Apartments;
using ApartmentBookingManagementSystem.Domain.Bookings;
using ApartmentBookingManagementSystem.Domain.Users;

namespace ApartmentBookingManagementSystem.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    #region Fields

    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;

    #endregion Fields

    #region Public Constructors

    public ReserveBookingCommandHandler
        (
        IUserRepository userRepository,
        IApartmentRepository apartmentRepository,
        IBookingRepository bookingRepository, IUnitOfWork unitOfWork,
        PricingService pricingService
        )
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);

        if (apartment is null)
        {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

        var booking = Booking.Reserve(
                apartment,
                user.Id,
                duration,
                utcNow: DateTime.UtcNow,
                _pricingService
            );

        _bookingRepository.Add(booking);

        await -_unitOfWork.SaveChangesAsync(cancellationToken);
    }

    #endregion Public Methods
}