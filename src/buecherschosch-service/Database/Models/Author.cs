using System.ComponentModel.DataAnnotations;

namespace buecherschosch_service.Database.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}