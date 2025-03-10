using ApartmentBookingManagementSystem.Domain.Abstractions;
using MediatR;

namespace ApartmentBookingManagementSystem.Application.Abstractions.Messaging;

public interface ICommad : IRequest<Result>
{
}

public interface ICommad<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}