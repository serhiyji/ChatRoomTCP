using Database.Entities;
using Database.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Credentials> Credential { get; set; }
        public DbSet<LogMassageInfo> LogMassageInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source = DataSource;
                                        Initial Catalog = InitialCatalog;
                                        Integrated Security = false; 
                                        User ID = UserID; 
                                        Password = Password;
                                        Connect Timeout = 30; Encrypt = False;
                                        TrustServerCertificate = False;
                                        ApplicationIntent = ReadWrite;
                                        MultiSubnetFailover = False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().HasKey(g => g.Id);
            modelBuilder.Entity<Credentials>().Property(g => g.Login).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Credentials>().Property(g => g.Password).HasMaxLength(20);

            modelBuilder.SeedUser();
        }
    }
}
