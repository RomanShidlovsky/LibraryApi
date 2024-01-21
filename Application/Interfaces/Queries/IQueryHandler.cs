using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface IQueryHandler<TQuery, TViewModel> : IRequestHandler<TQuery, Response<TViewModel>>
    where TQuery : IQuery<TViewModel>; 