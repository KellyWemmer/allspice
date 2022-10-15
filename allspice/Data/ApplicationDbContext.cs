using allspice.Models;
using Microsoft.EntityFrameworkCore;

namespace allspice.Data
{
    public class ApplicationDbContext : DbContext //inheriting DbContext
    {
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Step> Steps {get; set;}
        public DbSet<Ingredient> Ingredients {get; set;}

        //required constructor
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
       {
        
       }
       //required method
       protected override void OnModelCreating(ModelBuilder builder) 
       {
            base.OnModelCreating(builder);
       }
    }
}