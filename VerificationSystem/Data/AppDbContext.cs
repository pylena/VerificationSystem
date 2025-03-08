using Microsoft.EntityFrameworkCore;
using System;
using VerificationSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VerificationSystem.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<VerificationLog> VerificationLogs { get; set; }

        //seed data , link relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Onexmany
           modelBuilder.Entity<Document>()
           .HasOne(d => d.User)
           .WithMany(u => u.Documents)
           .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<VerificationLog>()
            .HasOne(v => v.Document)
            .WithMany(d => d.VerificationLogs)
            .HasForeignKey(v => v.DocumentId);



            modelBuilder.Entity<Document>()
            .Property(d => d.VerificationCode)
            .HasDefaultValueSql("NEWID()");  // Auto-generate code

            modelBuilder.Entity<VerificationLog>()
           .Property(v => v.Timestamp)
           .HasDefaultValueSql("GETUTCDATE()");  //  current time

            //seed data:
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Admin User", Email = "admin@example.com", Password = "ancd", Role = "Admin" },
            new User { Id = 2, Name = "Regular User", Email = "user@example.com", Password = "qwer", Role = "User" }
                  );
            // Seed Documents
            modelBuilder.Entity<Document>().HasData(
                new Document
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Admin Document",
                    FilePath = "/docs/admin.pdf",
                    VerificationCode = Guid.NewGuid().ToString(),
                    Status = "Verified",
                    CreatedAt = DateTime.UtcNow
                },
                new Document
                {
                    Id = 2,
                    UserId = 2,
                    Title = "User Document",
                    FilePath = "/docs/user.pdf",
                    VerificationCode = Guid.NewGuid().ToString(),
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                }
            );



        }


        }
}
