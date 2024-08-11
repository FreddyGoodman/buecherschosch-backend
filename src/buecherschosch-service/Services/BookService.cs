using buecherschosch_service.Database;
using buecherschosch_service.Models;
using Microsoft.EntityFrameworkCore;

namespace buecherschosch_service.Services
{
    public class BookService
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<BookService> _logger;

        public BookService(DatabaseContext context,
            ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Book?> BookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public IAsyncEnumerable<Book> AllBooksAsync()
        {
            return _context.Books.AsAsyncEnumerable();
        }

        public async Task<int> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> PatchBook(Book book)
        {
            _context.Books.Update(book); // TODO: Research how Update() works
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int?> DeleteBook(int id)
        {
            Book? book = await BookById(id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return book.Id;
            }
            return null;
        }
    }
}