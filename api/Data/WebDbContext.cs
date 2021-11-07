using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<User>().Property(b => b.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<User>().Property(b => b.Name).IsRequired().HasMaxLength(50);
        }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public static class DbInitializer
    {
        public static void Initialize(MyDbContext ctx)
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Users.Any())
            {
                ctx.Users.Add(new User { Name = "Emre", IsActive = true });
                ctx.Users.Add(new User { Name = "Duru", IsActive = false });
                ctx.SaveChanges();
            }
        }
    }
}