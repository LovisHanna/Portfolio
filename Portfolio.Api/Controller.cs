using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Handlers;
using Portfolio.RepositoryPattern.Shared;
using Portfolio.RepositoryPattern.Shared.Exceptions;


namespace Portfolio.Api;

[ApiController]
[Route("library")]
public class Controller : ControllerBase
{
    private readonly IRepository<Book> _repository;
    private readonly IMediator _mediator;

    public Controller(IRepository<Book> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator; //?
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetBookRequest { Id = id });

        try
        {
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("author/{author}")]
    public IActionResult GetByAuthor([FromRoute] string author)
    {
        return Ok(_repository.Query().Where(x => x.Author == author));
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(Book bookDto)
    {
        try
        {
            await _repository.Add(bookDto);
            return Ok();
        }
        catch (ConflictException)
        {
            return BadRequest("Conflict");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Book bookDto)
    {
        try
        {
            await _repository.Update(bookDto);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        try
        {
            await _repository.Delete(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}

