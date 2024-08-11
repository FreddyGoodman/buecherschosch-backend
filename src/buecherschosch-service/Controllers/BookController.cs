using buecherschosch_service.Models;
using buecherschosch_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace buecherschosch_service.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly BookService _bookService;

    public BookController(ILogger<BookController> logger, BookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet("{id}", Name = "BookById")]
    public async Task<ActionResult<Book>> BookById(int id)
    {
        Book? book = await _bookService.BookById(id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpGet("AllBooks")]
    public ActionResult<IAsyncEnumerable<Book>> AllBooks()
    {
        return Ok(_bookService.AllBooksAsync());
    }

    [HttpPost]
    public async Task<ActionResult<int>> PostBook(Book book)
    {
        return Ok(await _bookService.PostBook(book));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }
        await _bookService.PostBook(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        int? deleted_id = await _bookService.DeleteBook(id);
        if (deleted_id is null) {
            return NotFound();
        }
            return NoContent();
    }
}
