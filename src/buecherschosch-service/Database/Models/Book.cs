using System.ComponentModel.DataAnnotations;
using buecherschosch_service.Enums;

namespace buecherschosch_service.Database.Models
{
    public class Book
    {
        // TODO: Add Produktnummer Attribut
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
        public int? Pages { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublicationYear { get; set; }
        public Language? Language { get; set; }
        public required string ISBN { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}