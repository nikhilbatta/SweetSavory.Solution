using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SweetSavory.Models
{
    public class SweetSavoryContext : IdentityDbContext<StoreManager>
    {
        public DbSet<Flavor> Flavors {get;set;}
        public DbSet<Treat> Treats {get;set;}
        public DbSet<FlavorTreat> FlavorTreats {get;set;}
        public SweetSavoryContext(DbContextOptions options) : base(options) {}

    }
    
}