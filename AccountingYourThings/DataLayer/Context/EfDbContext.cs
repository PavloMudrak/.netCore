using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Context
{
    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(x => x.Id)
                .UseIdentityColumn(seed: 0, increment: 1);
            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .HasDefaultValue("No data");
            modelBuilder.Entity<Category>()
                .Property(x => x.Description)
                .HasDefaultValue("No data");

            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .UseIdentityColumn(seed: 0, increment: 1);
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasDefaultValue("No data");
            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasDefaultValue("No data");
            modelBuilder.Entity<Product>()
                .Property(x => x.CategoryId)
                .HasDefaultValue(1);

        }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EfDbContext>
    {
        public EfDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Accounting;Trusted_Connection=False;Integrated Security=True;MultipleActiveResultSets=true");
            return new EfDbContext(optionsBuilder.Options);
        }
    }
}
