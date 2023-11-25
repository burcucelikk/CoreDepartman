using Microsoft.EntityFrameworkCore;

namespace CoreDepartman.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Departman> departman { get; set; }
        public DbSet<Personel> personel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-A166KCM\SQLEXPRESS;Initial Catalog=PersonelDepartmenDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
