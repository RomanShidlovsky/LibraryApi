using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface IUpdateCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Response<TModel>>
    where TCommand : IUpdateCommand<TModel>;