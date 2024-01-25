using System.Net;
using Application.DTOs.Genre;
using Application.DTOs.User;
using Application.Features.UserFeatures.Commands.AddRole;
using Application.Features.UserFeatures.Commands.Delete;
using Application.Features.UserFeatures.Commands.DeleteRole;
using Application.Features.UserFeatures.Commands.Login;
using Application.Features.UserFeatures.Commands.Register;
using Application.Features.UserFeatures.Commands.Update;
using Application.Features.UserFeatures.Queries.GetAll;
using Application.Features.UserFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }

    [HttpPost(nameof(Register))]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }
    
    [HttpPost(nameof(Login))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }
    
    [HttpPut(nameof(AddRole))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddRole(AddUserRoleCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
    
    [HttpPut(nameof(DeleteRole))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteRole(DeleteUserRoleCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
}