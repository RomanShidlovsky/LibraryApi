using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface IQueryHandler<TQuery, TModel> : IRequestHandler<TQuery, PagedResponse<TModel>>
    where TQuery : IQuery<TModel>; 