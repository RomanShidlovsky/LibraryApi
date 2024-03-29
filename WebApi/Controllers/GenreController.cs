﻿using System.Net;
using Application.DTOs.Genre;
using Application.Features.GenreFeatures.Commands.AddGenreToBook;
using Application.Features.GenreFeatures.Commands.Create;
using Application.Features.GenreFeatures.Commands.Delete;
using Application.Features.GenreFeatures.Commands.DeleteGenreFromBook;
using Application.Features.GenreFeatures.Queries.GetAll;
using Application.Features.GenreFeatures.Queries.GetById;
using Application.Wrappers;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<GenreViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllGenresQuery();
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GenreViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetGenreByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(GenreViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Create(CreateGenreDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateGenreCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(GenreViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteGenreCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpPut(nameof(AddGenreToBook))]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddGenreToBook(AddGenreToBookDto dto, CancellationToken cancellationToken)
    {
        var command = new AddGenreToBookCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpPut(nameof(DeleteGenreFromBook))]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteGenreFromBook(DeleteGenreFromBookDto dto, CancellationToken cancellationToken)
    {
        var command = new DeleteGenreFromBookCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
}