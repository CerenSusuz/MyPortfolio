using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EF.Context
{
    public class PortfolioDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PortfolioDb;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateImage> CertificateImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
