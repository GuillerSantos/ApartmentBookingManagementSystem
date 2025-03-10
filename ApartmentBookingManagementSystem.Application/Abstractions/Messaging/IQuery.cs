using ApartmentBookingManagementSystem.Domain.Abstractions;
using MediatR;

namespace ApartmentBookingManagementSystem.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}