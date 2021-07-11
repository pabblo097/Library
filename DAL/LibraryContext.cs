using Library.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.DAL
{
public class LibraryContext: DbContext
{

public LibraryContext(): base("LibraryContext")
{
}

public DbSet<Student> Students { get; set; }
public DbSet<Enrollment> Enrollments { get; set; }
public DbSet<Course> Courses { get; set; }

protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
}
}
}