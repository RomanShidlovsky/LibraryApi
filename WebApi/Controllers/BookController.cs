﻿using System.Net;
using System.Runtime.InteropServices.JavaScript;
using Application.DTOs.Book;
using Application.Features.AuthorFeatures.Commands.AddAuthorToBook;
using Application.Features.BookFeatures.Commands.Create;
using Application.Features.BookFeatures.Commands.Delete;
using Application.Features.BookFeatures.Commands.Update;
using Application.Features.BookFeatures.Queries.GetAll;
using Application.Features.BookFeatures.Queries.GetById;
using Application.Features.BookFeatures.Queries.GetByISBN;
using Application.Features.GenreFeatures.Commands.AddGenreToBook;
using Application.Features.GenreFeatures.Commands.DeleteGenreFromBook;
using Application.Wrappers;
using Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Helpers;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllBooksQuery();
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetBookByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    
    [HttpGet("ISBN/{isbn}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByIsbn(string isbn, CancellationToken cancellationToken)
    {
        var query = new GetBookByIsbnQuery(isbn);
        var result = await mediator.Send(query, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
    

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Continue)]
    public async Task<IActionResult> Create(CreateBookDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateBookCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteBookCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }

    [HttpPut]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(IEnumerable<Error>), (int)HttpStatusCode.UnprocessableEntity)]
    [ProducesResponseType(typeof(Error),(int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update(UpdateBookDto dto, CancellationToken cancellationToken)
    {
        var command = new UpdateBookCommand(dto);
        var result = await mediator.Send(command, cancellationToken);

        return ApiResponse.GetObjectResult(result);
    }
}