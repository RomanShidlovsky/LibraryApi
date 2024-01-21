using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface IUpdateCommand<T> : IRequest<Response<T>>;