using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using jav.Entities;

namespace jav.Helpers
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Lesson> Lessons { get; set; }
  }
}
