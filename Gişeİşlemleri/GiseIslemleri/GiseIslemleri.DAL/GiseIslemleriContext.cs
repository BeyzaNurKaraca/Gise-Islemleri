using GiseIslemleri.Entity;
using GiseIslemleri.Entity.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.DAL
{
    public class GiseIslemleriContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Bill>? Bills { get; set; }
        public DbSet<Subscriptions>? Subscriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MURAT\SQLEXPRESS;Database=GiseIslemleri;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfigurations());
            modelBuilder.ApplyConfiguration(new SubscriptionsConfiguration());
        }
    }

}
