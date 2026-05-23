using LoanManagementSystem.Domain.Entities;
using LoanManagementSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Loan> Loans => Set<Loan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //User 
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName).HasMaxLength(100);
                entity.Property(x => x.LastName).HasMaxLength(100);
                entity.Property(x => x.Email).HasMaxLength(100);

                entity.HasIndex(x => x.Email).IsUnique();
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@loan.com",
                    PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    Role = UserRole.Admin.ToString(),
                    CreatedDate = DateTime.UtcNow
                });

            //Loan
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Amount).HasColumnType("decimal(18,2)");

                entity.Property(x => x.InterestRate).HasColumnType("decimal(18,2)"); 
                entity.HasIndex(x => x.UserId);

                entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            });
        }
    }
}
