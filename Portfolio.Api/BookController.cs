using Microsoft.AspNetCore.Mvc;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.Exceptions;

namespace Portfolio.Api;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    private readonly IRepository<Book> _bookRepository;

    public BookController(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        try
        {
            return Ok(await _bookRepository.Get(id));
        }
        catch (RepositoryNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("/author/{author}")]
    public  IActionResult GetByAuthor([FromRoute] string author)
    {
        return Ok(_bookRepository.Query().Where(x => x.Author == author));
    }


    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(Book book)
    {
        try
        {
            await _bookRepository.Add(book);
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
            await _bookRepository.Update(book);
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
            await _bookRepository.Delete(id);
            return Ok();
        }
        catch (RepositoryNotFoundException)
        {
            return NotFound();
        }
        
    }
}
