using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryContext: IdentityDbContext<User, Role, int>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
         base.OnModelCreating(modelBuilder);
             // Fluent API commands
         modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>((int)RoleValue.User)
            .HasValue<Student>((int)RoleValue.Student)
            .HasValue<Reader>((int)RoleValue.Reader)
            .HasValue<Teacher>((int)RoleValue.Teacher)
            .HasValue<Admin>((int)RoleValue.Admin);
        }
    }
}