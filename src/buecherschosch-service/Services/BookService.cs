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
            return await Context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);
        }

        public IAsyncEnumerable<Book> AllBooksAsync()
        {
            return Context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .Include(b => b.Publisher)
            .AsAsyncEnumerable();
        }

        public async Task<int> PostBook(Book book)
        {
            var author = await Context.Authors.FirstOrDefaultAsync(a => book.Author != null && a.Id == book.Author.Id);
            var publisher = await Context.Publishers.FirstOrDefaultAsync(p => book.Publisher != null && p.Id == book.Publisher.Id);
            var genre = await Context.Genres.FirstOrDefaultAsync(
                g => book.Genre != null
                && g.category == book.Genre.category
                && g.genreType == book.Genre.genreType
            );
            if ( // Return -1 if field was provided but not found in database
                author is null && book.Author is not null
                || publisher is null && book.Publisher is not null
                || genre is null && book.Genre is not null)
            {
                return -1;
            }
            book.Author = author;
            book.Publisher = publisher;
            book.Genre = genre;
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