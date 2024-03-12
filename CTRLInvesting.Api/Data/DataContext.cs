using System.Xml.Linq;
using CTRLInvesting.Model;
using CTRLInvesting.Model.Investidor;
using CTRLInvesting.Model.Roles;
using CTRLInvesting.Model.Stocks;
using CTRLInvesting.Model.Usuario;
using Microsoft.EntityFrameworkCore;

namespace CTRLInvesting.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investidor>()
            .HasMany(x => x.Usuario)
            .WithMany(x => x.Investidors);

            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(u => u.IdRole)
            .IsRequired();

            // modelBuilder.Entity<Stock>()
            // .Property(e => e.Symbol)
            // .ValueGeneratedOnAdd();

            // modelBuilder.Entity<Stock>()
            // .Property(e => e.LongName)
            // .ValueGeneratedOnAdd();
        }
    }
}