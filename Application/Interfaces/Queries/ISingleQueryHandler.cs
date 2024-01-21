using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface ISingleQueryHandler<TQuery, TViewModel> : IRequestHandler<TQuery, Response<TViewModel>>
    where TQuery : ISingleQuery<TViewModel>;