using Application.Wrappers;
using MediatR;

namespace Application.Interfaces.Queries;

public interface ISingleQuery<T> : IRequest<Response<T>>; 
