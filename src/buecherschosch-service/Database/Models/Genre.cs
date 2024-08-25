using System.ComponentModel.DataAnnotations;
using buecherschosch_service.Enums;

namespace  buecherschosch_service.Database.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public required GenreType genreType { get; set; }
        public required Category category { get; set; }
    }
}