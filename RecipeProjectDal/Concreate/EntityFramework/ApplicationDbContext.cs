using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeProjectEntity.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeProjectDal.Concreate.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(bc=>new { bc.CategoryId,bc.RecipeId});

            modelBuilder.Entity<RecipeCategory>().HasOne(bc => bc.Category).WithMany(b => b.Recipes).HasForeignKey(bc => bc.CategoryId);
            modelBuilder.Entity<RecipeCategory>().HasOne(bc => bc.Recipe).WithMany(b => b.Categories).HasForeignKey(bc => bc.RecipeId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
