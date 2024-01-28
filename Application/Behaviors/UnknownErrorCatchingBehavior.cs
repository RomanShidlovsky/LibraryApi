using Application.Wrappers;
using Domain.Errors;
using MediatR;

namespace Application.Behaviors;

public class UnknownErrorCatchingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            return (TResponse)Response.Failure(DomainErrors.UnknownError);
        }
    }
}