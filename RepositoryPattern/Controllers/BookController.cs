using Microsoft.AspNetCore.Mvc;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.Exceptions;

namespace RepositoryPattern.Controllers;

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
    public async Task<IActionResult> Get([FromRoute] int id)
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
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Book book)
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
    public async Task<IActionResult> Delete([FromRoute] int id)
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
