﻿using System.Net;
using Application.DTOs.Book;
using Application.Features.BookFeatures.Commands.AddAuthor;
using Application.Features.BookFeatures.Commands.AddGenre;
using Application.Features.BookFeatures.Commands.Create;
using Application.Features.BookFeatures.Commands.Delete;
using Application.Features.BookFeatures.Commands.DeleteAuthor;
using Application.Features.BookFeatures.Commands.DeleteGenre;
using Application.Features.BookFeatures.Commands.Update;
using Application.Features.BookFeatures.Queries.GetAll;
using Application.Features.BookFeatures.Queries.GetById;
using Application.Features.BookFeatures.Queries.GetByISBN;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllBooksQuery();
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetBookByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }
    
    [HttpGet("ISBN/{isbn}")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByIsbn(string isbn, CancellationToken cancellationToken)
    {
        var query = new GetBookByIsbnQuery(isbn);
        var result = await mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }
    

    [HttpPost]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteBookCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, NotFound);
    }

    [HttpPut]
    [ProducesResponseType(typeof(BookViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }

    [HttpPut(nameof(AddAuthor))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddAuthor(AddBookAuthorCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
    
    [HttpPut(nameof(DeleteAuthor))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteAuthor(DeleteBookAuthorCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
    
    [HttpPut(nameof(AddGenre))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddGenre(AddBookGenreCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
    
    [HttpPut(nameof(DeleteGenre))]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteGenre(DeleteBookGenreCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result.Data ? Ok("Success.") : BadRequest(result.Message);
    }
}