using MediatorPattern; //rätt using?
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Handlers;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.Shared.Exceptions;


namespace Portfolio.Api;

[ApiController]
[Route("library")]
public class Controller : ControllerBase
{
    private readonly IRepository<Book> _repository;
    private readonly IMediator _mediator;

    public Controller(IRepository<Book> repository)
    {
        _repository = repository;
        _mediator = new Mediator([new GetHandler()]);

    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        _mediator.HandleRequest(new GetHandlerRequest { Id = id });

        try
        {
            return Ok(await _repository.Get(id));
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
    public async Task<IActionResult> Add(Book book)
    {
        try
        {
            await _repository.Add(book);
            return Ok();
        }
        catch (ConflictException)
        {
            return BadRequest("Conflict");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Book book)
    {
        try
        {
            await _repository.Update(book);
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

