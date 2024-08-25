using buecherschosch_service.Enums;

namespace buecherschosch_service.Models.Objects
{
    public class GenreJson
    {
        public GenreType genreType { get; set; }
        public Category category { get; set; }

        public string genreTypeString { get; set; }
        public string categoryString { get; set; }

        public GenreJson(GenreType genreType, Category category)
        {
            this.genreType = genreType;
            this.category = category;
            this.genreTypeString = genreType.ToString();
            this.categoryString = category.ToString();
        }
    }
}