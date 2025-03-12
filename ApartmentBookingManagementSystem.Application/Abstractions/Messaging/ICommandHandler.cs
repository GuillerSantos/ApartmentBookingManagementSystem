using ApartmentBookingManagementSystem.Domain.Abstractions;
using MediatR;

namespace ApartmentBookingManagementSystem.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommad
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommad<TResponse>
{
}