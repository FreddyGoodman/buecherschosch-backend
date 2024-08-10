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


    [HttpGet(Name = "AllBooks")]
    public ActionResult<IAsyncEnumerable<Book>> AllBooks()
    {
        return Ok(_bookService.AllBooksAsync());
    }
 
    [HttpPost(Name = "PostBook")]
    public async Task<ActionResult<int>> PostBook(Book book)
    {
        return Ok(await _bookService.SaveBook(book));
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
}
