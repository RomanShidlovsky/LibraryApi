using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface ISingleQueryHandler<TQuery, TModel> : IRequestHandler<TQuery, Response<TModel>>
    where TQuery : ISingleQuery<TModel>;