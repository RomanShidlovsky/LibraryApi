using System.Net;
using Application.DTOs.Subscription;
using Application.Features.SubscriptionFeatures.Commands.Create;
using Application.Features.SubscriptionFeatures.Commands.Delete;
using Application.Features.SubscriptionFeatures.Commands.ReturnBook;
using Application.Features.SubscriptionFeatures.Queries.GetAll;
using Application.Features.SubscriptionFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SubscriptionViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllSubscriptionsQuery();
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(SubscriptionViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetSubscriptionByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SubscriptionViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(SubscriptionViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteSubscriptionCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }

    [HttpPut("ReturnBook/{bookId:int}")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> ReturnBook(int bookId, CancellationToken cancellationToken)
    {
        var command = new ReturnBookCommand(bookId);
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
}