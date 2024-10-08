using buecherschosch_service.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace buecherschosch_service.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }


        public string DbPath { get; private set; }

        public DatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Combine(Environment.GetFolderPath(folder), "buecherschosch-service");
            Directory.CreateDirectory(Path.Combine(path, "buecherschosch-service"));
            DbPath = Path.Combine(path, "buecherschosch.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}