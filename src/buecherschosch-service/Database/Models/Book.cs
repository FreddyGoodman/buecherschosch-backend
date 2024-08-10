using System.ComponentModel.DataAnnotations;
using buecherschosch_service.Enums;

namespace buecherschosch_service.Models
{
    public class Book
    {
        [Key]
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? Author { get; set; }
        public Genre? Genre { get; set; }
        public int? Pages { get; set; }
        public string? Publisher { get; set; }
        public string? Language { get; set; }
        public required string ISBN { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}