using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface IDeleteCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Response<TModel>>
    where TCommand : IDeleteCommand<TModel>;