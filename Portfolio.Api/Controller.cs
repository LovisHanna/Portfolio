using Microsoft.AspNetCore.Mvc;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.Exceptions;

namespace Portfolio.Api;

[ApiController]
[Route("library")]
public class Controller : ControllerBase
{
    private readonly IRepository<Book> _mongoRepository;

    public Controller(IRepository<Book> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        try
        {
            return Ok(await _mongoRepository.Get(id));
        }
        catch (RepositoryNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("author/{author}")]
    public IActionResult GetByAuthor([FromRoute] string author)
    {
        return Ok(_mongoRepository.Query().Where(x => x.Author == author));
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(Book book)
    {
        try
        {
            await _mongoRepository.Add(book);
            return Ok();
        }
        catch (RepositoryConflictException)
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
            await _mongoRepository.Update(book);
            return Ok();
        }
        catch (RepositoryNotFoundException)
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
            await _mongoRepository.Delete(id);
            return Ok();
        }
        catch (RepositoryNotFoundException)
        {
            return NotFound();
        }
    }
}
