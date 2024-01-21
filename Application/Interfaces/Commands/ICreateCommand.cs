using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface ICreateCommand<T> : IRequest<Response<T>>;