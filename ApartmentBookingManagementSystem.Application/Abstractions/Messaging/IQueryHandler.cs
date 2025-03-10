using ApartmentBookingManagementSystem.Domain.Abstractions;
using MediatR;

namespace ApartmentBookingManagementSystem.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}