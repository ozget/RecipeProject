using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeProjectEntity.Concreate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeProjectData
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipes> Recipess { get; set; }


       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //              .HasMany(j => j.SubCategories)
        //              .WithOne(j => j.Parent)
        //              .HasForeignKey(j => j.ParentId);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
