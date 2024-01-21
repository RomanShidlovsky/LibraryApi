using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface ICreateCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Response<TModel>>
    where TCommand : ICreateCommand<TModel>;