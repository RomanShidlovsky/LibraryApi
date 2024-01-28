﻿using System.Net;
using Application.DTOs.Author;
using Application.Features.AuthorFeatures.Commands.Create;
using Application.Features.AuthorFeatures.Commands.Delete;
using Application.Features.AuthorFeatures.Commands.Update;
using Application.Features.AuthorFeatures.Queries.GetAll;
using Application.Features.AuthorFeatures.Queries.GetById;
using Application.Wrappers;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<AuthorViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllAuthorsQuery();
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetAuthorByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteAuthorCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(AuthorViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(Error),(int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        
        return ApiResponse.GetObjectResult(result);
    }
}