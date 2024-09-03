using buecherschosch_service.Database;
using buecherschosch_service.Enums;
using buecherschosch_service.Database.Models;
using buecherschosch_service.Models;
using Microsoft.EntityFrameworkCore;

namespace buecherschosch_service.Services
{
    public class MetadataService
    {
        private readonly DatabaseContext Context;
        private readonly ILogger<MetadataService> Logger;

        public MetadataService(DatabaseContext Context,
        ILogger<MetadataService> Logger)
        {
            this.Context = Context;
            this.Logger = Logger;
        }

        public IAsyncEnumerable<Author> AllAuthorsAsync()
        {
            return Context.Authors.AsAsyncEnumerable();
        }

        public IAsyncEnumerable<Publisher> AllPublishersAsync()
        {
            return Context.Publishers.AsAsyncEnumerable();
        }

        public IAsyncEnumerable<GenreJson> AllGenresAsync()
        {
            return Context.Genres
                .Select(genre => new GenreJson(genre.genreType, genre.category))
                .AsAsyncEnumerable();
        }

        public IEnumerable<LanguageJson> AllLanguages()
        {
            return Enum.GetValues(typeof(Language)).Cast<Language>().Select(l => new LanguageJson(l));
        }

        public async Task<int> PostAuthor(Author author)
        {
            Context.Authors.Add(author);
            await Context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<int> PostPublisher(Publisher publisher)
        {
            Context.Publishers.Add(publisher);
            await Context.SaveChangesAsync();
            return publisher.Id;
        }

        public async Task<int> PostGenre(Genre genre)
        {
            Context.Genres.Add(genre);
            await Context.SaveChangesAsync();
            return genre.Id;
        }
    }
}