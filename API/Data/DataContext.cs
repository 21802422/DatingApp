using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace API.Data;
    public class DataContext : DbContext
    {
      public DataContext(DbContextOptions options) : base(options)
      {

      }
      public DbSet<AppUser> User { get; set;} //dbSet is a collection of entities that can be querid and saved to DB
    }
