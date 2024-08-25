using buecherschosch_service.Database.Models;
using buecherschosch_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace buecherschosch_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> Logger;
        private readonly BookService BookService;

        public BookController(ILogger<BookController> Logger, BookService BookService)
        {
            this.Logger = Logger;
            this.BookService = BookService;
        }

        [HttpGet("{id}", Name = "BookById")]
        public async Task<ActionResult<Book>> BookById(int id)
        {
            Book? book = await BookService.BookById(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("AllBooks")]
        public ActionResult<IAsyncEnumerable<Book>> AllBooks()
        {
            return Ok(BookService.AllBooksAsync());
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostBook(Book book)
        {
            return Ok(await BookService.PostBook(book));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await BookService.PostBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            int? deleted_id = await BookService.DeleteBook(id);
            if (deleted_id is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}