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

        public async Task<IEnumerable<Book>> GetBooksAll()
        {
            return await _context.Books.ToListAsync();
        }
    }
}