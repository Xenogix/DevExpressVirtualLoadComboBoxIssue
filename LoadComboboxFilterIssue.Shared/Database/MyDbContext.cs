using LoadComboboxFilterIssue.Database;
using Microsoft.EntityFrameworkCore;

namespace LoadComboboxFilterIssue.Shared.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }

        public string DbPath = AppDomain.CurrentDomain.BaseDirectory ?? throw new InvalidOperationException("Cannot determine assembly location.");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Path.Join(DbPath, "my.db")}");
    }
}
