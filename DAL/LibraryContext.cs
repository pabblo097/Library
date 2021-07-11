using Library.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.DAL
{
public class LibraryContext: DbContext
{

public LibraryContext(): base("Library")
{
}

public DbSet<Author> Authors { get; set; }
public DbSet<Reader> Readers { get; set; }
public DbSet<Student> Students { get; set; }
public DbSet<Teacher> Teachers { get; set; }
public DbSet<Book> Books { get; set; }

protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
}
}
}