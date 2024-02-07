using System.Net;
using Application.DTOs.Role;
using Application.Features.RoleFeatures.Commands.AddRoleToUser;
using Application.Features.RoleFeatures.Commands.Create;
using Application.Features.RoleFeatures.Commands.Delete;
using Application.Features.RoleFeatures.Commands.DeleteRoleFromUser;
using Application.Features.RoleFeatures.Queries.GetAll;
using Application.Features.RoleFeatures.Queries.GetById;
using Application.Wrappers;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(IEnumerable<RoleViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllRolesQuery();
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(RoleViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetRoleByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPost]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(RoleViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(RoleViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteRoleCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpPut(nameof(AddRoleToUser))]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddRoleToUser(AddRoleToUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpPut(nameof(DeleteRoleFromUser))]
    [Authorize(Roles = "SuperAdmin")]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteRoleFromUser(DeleteRoleFromUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
}