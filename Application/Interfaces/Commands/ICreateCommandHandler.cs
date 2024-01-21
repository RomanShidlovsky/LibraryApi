using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface ICreateCommandHandler<TCommand, TViewModel> : IRequestHandler<TCommand, Response<TViewModel>>
    where TCommand : ICreateCommand<TViewModel>;