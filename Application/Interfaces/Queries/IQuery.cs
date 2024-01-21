using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface IQuery<T> : IRequest<PagedResponse<T>>;