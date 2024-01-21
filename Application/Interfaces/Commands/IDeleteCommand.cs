using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface IDeleteCommand<T> : IRequest<Response<T>>;