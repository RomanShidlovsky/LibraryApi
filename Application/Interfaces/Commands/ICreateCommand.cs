using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Commands;

public interface ICreateCommand<TViewModel> : IRequest<Response<TViewModel>>;