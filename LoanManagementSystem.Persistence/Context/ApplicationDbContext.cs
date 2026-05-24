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
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<LoanPayment> LoansPayment => Set<LoanPayment>();

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

            //Seed Loan Data
            modelBuilder.Entity<Loan>().HasData(new Loan
            {
                Id = 1,
                Amount = 50000,
                DurationInMonths = 12,
                InterestRate = 10,
                Status = LoanStatus.Approved.ToString(),
                UserId = 1,
                CreatedDate = DateTime.UtcNow
            });

            //Refresh Token

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(x => x.Id);
                
                entity.HasIndex(x => x.Token).IsUnique();
                
                entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            });

            //loan Payment

            modelBuilder.Entity<LoanPayment>(entity =>
            {
                entity.HasKey(x => x.Id);
                
                entity.Property(x => x.AmountPaid).HasColumnType("decimal(18,2)");
                entity.Property(x => x.TransactionReference).HasMaxLength(200);
                entity.Property(x => x.PaymentMode).HasMaxLength(50);
                
                entity.HasIndex(x => x.LoanId);
                entity.HasIndex(x => x.PaymentDate);

                entity.HasOne(x => x.Loan).WithMany(x => x.Payments).HasForeignKey(x => x.LoanId);

            });

            modelBuilder.Entity<LoanPayment>().HasData(
            new LoanPayment
            {
                Id = 1,
                LoanId = 1,
                AmountPaid = 5000,
                PaymentDate = DateTime.UtcNow,
                PaymentMode = "UPI",
                TransactionReference = "TXN123456",
                CreatedDate = DateTime.UtcNow
            });
                        
        }
    }
}
