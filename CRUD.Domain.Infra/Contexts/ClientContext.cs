using CRUD.Domain.Entities.Client;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<ClientItem> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientItem>().ToTable("Client");
            modelBuilder.Entity<ClientItem>().Property(x => x.Id);
            modelBuilder.Entity<ClientItem>().Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<ClientItem>().Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<ClientItem>().Property(x => x.Phone).HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<ClientItem>().Property(x => x.BirthDate).HasColumnType("datetime");
        }
    }
}