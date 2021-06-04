using ClientManager.DemoApp.Domain.Models;
using System.Data.Entity;

namespace ClientManager.DemoApp.Domain.DataAccess
{
    public class ClientManagmentContext : DbContext, IClientManagmentContext
    {
        public ClientManagmentContext() : base("ClientManagmentDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasRequired<Client>(a => a.Client).WithMany(c => c.Addresses)
                .HasForeignKey<int>(a => a.ClientId);

            modelBuilder.Entity<Client>().HasKey(x => x.Id);

            modelBuilder.Entity<Address>().HasKey(x => x.Id);

        }

        void IClientManagmentContext.SaveChanges()
        {
            this.SaveChanges();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
