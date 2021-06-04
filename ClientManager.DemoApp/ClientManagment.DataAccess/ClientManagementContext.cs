using ClientManager.DemoApp.Domain.Models;
using System.Data.Entity;

namespace ClientManagment.DataAccess
{
    public class ClientManagementContext : DbContext
    {
        public ClientManagementContext() : base("ClientManagmentDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasRequired<Client>(a => a.Client).WithMany(c => c.Addresses)
                .HasForeignKey<int>(a => a.ClientId);

            modelBuilder.Entity<Client>().HasKey(x => x.Id);

            modelBuilder.Entity<Address>().HasKey(x => x.Id);

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
