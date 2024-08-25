using buecherschosch_service.Database;
using buecherschosch_service.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace buecherschosch_service.Services
{
    public class BookService
    {
        private readonly DatabaseContext Context;
        private readonly ILogger<BookService> Logger;

        public BookService(DatabaseContext Context,
            ILogger<BookService> Logger)
        {
            this.Context = Context;
            this.Logger = Logger;
        }

        public async Task<Book?> BookById(int id)
        {
            return await Context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public IAsyncEnumerable<Book> AllBooksAsync()
        {
            return Context.Books.AsAsyncEnumerable();
        }

        public async Task<int> PostBook(Book book)
        {
            Context.Books.Add(book);
            await Context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> PatchBook(Book book)
        {
            Context.Books.Update(book); // TODO: Research how Update() works
            await Context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int?> DeleteBook(int id)
        {
            Book? book = await BookById(id);
            if (book is not null)
            {
                Context.Books.Remove(book);
                await Context.SaveChangesAsync();
                return book.Id;
            }
            return null;
        }
    }
}