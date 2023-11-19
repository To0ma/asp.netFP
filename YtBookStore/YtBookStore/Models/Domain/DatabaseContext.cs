using Microsoft.EntityFrameworkCore;

namespace YtBookStore.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base (options)
        {

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
}
