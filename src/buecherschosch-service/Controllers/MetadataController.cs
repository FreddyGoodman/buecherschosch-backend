using buecherschosch_service.Database.Models;
using buecherschosch_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace buecherschosch_service.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly ILogger<MetadataController> Logger;
        private readonly MetadataService MetadataService;

        public MetadataController(ILogger<MetadataController> Logger, MetadataService MetadataService)
        {
            this.Logger = Logger;
            this.MetadataService = MetadataService;
        }

        [HttpGet("AllAuthors")]
        public ActionResult<IAsyncEnumerable<Author>> AllAuthors()
        {
            return Ok(MetadataService.AllAuthorsAsync());
        }

        [HttpGet("AllPublishers")]
        public ActionResult<IAsyncEnumerable<Publisher>> AllPublishers()
        {
            return Ok(MetadataService.AllPublishersAsync());
        }

        [HttpGet("AllGenres")]
        public ActionResult<IAsyncEnumerable<Genre>> AllGenres()
        {
            return Ok(MetadataService.AllGenresAsync());
        }

        [HttpGet("AllLanguages")]
        public ActionResult<IEnumerable<string>> AllLanguages()
        {
            return Ok(MetadataService.AllLanguages());
        }

        /* [HttpGet("CreateGenres")]
        public async Task<ActionResult> CreateGenres()
        {
            List<GenreType> fiction = [GenreType.Crime, GenreType.Thriller, GenreType.ScienceFiction, GenreType.Fantasy, GenreType.Romance, GenreType.Horror, GenreType.Adventure, GenreType.HistoricNovel];
            List<GenreType> nonfiction = [GenreType.Biography, GenreType.Autobiography, GenreType.History, GenreType.SelfHelp, GenreType.Politics, GenreType.Society, GenreType.Philosophy, GenreType.Economics, GenreType.Finance];
            List<GenreType> YouthLiteratur = [GenreType.YoungAdult, GenreType.YouthLiterature, GenreType.Childrens, GenreType.PictureBooks];
            List<GenreType> peotrydrama = [GenreType.Theater, GenreType.Peotry, GenreType.Epics];
            List<GenreType> other = [GenreType.Religious, GenreType.Spiritual, GenreType.HistoricReligion, GenreType.Other];

            foreach (GenreType type in fiction)
            {
                await MetadataService.PostGenre(new Genre { category = Category.Fiction, genreType = type });
            }

            foreach (GenreType type in nonfiction)
            {
                await MetadataService.PostGenre(new Genre { category = Category.NonFiction, genreType = type });
            }

            foreach (GenreType type in YouthLiteratur)
            {
                await MetadataService.PostGenre(new Genre { category = Category.YouthLiterature, genreType = type });
            }

            foreach (GenreType type in peotrydrama)
            {
                await MetadataService.PostGenre(new Genre { category = Category.PeotryDrama, genreType = type });
            }

            foreach (GenreType type in other)
            {
                await MetadataService.PostGenre(new Genre { category = Category.Other, genreType = type });
            }

            return Ok();
        } */
    }
}