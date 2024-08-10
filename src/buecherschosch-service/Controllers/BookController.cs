using buecherschosch_service.Models;
using buecherschosch_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace buecherschosch_service.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly BookService _bookService;

    public BooksController(ILogger<BooksController> logger, BookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }


    [HttpGet(Name = "GetBooksAll")]
    public async Task<IEnumerable<Book>> GetBooksAll()
    {
        return await _bookService.GetBooksAll();
    }
}
