using Library.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Reader>().ToTable("Reader");
            modelBuilder.Entity<Book>().ToTable("Book");
        }

    }
}