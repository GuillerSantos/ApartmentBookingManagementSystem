using ApartmentBookingManagementSystem.Domain.Abstractions;
using MediatR;

namespace ApartmentBookingManagementSystem.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommad
{
}

public interface ICommandHandlers<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommad
{
}