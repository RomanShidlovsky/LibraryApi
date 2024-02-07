using System.Net;
using Application.Auth;
using Application.DTOs.User;
using Application.Features.RoleFeatures.Commands.AddRoleToUser;
using Application.Features.RoleFeatures.Commands.DeleteRoleFromUser;
using Application.Features.UserFeatures.Commands.Delete;
using Application.Features.UserFeatures.Commands.Login;
using Application.Features.UserFeatures.Commands.RefreshToken;
using Application.Features.UserFeatures.Commands.Register;
using Application.Features.UserFeatures.Queries.GetAll;
using Application.Features.UserFeatures.Queries.GetById;
using Application.Wrappers;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(IEnumerable<UserViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Client, Admin, SuperAdmin")]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPost(nameof(Register))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> Register(RegisterUserDto dto, CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPost(nameof(Login))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Login(LoginUserDto dto, CancellationToken cancellationToken)
    {
        var command = new LoginUserCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpPost(nameof(RefreshToken))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(TokenModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> RefreshToken(RefreshTokenDto dto, CancellationToken cancellationToken)
    {
        var command = new RefreshTokenCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
}