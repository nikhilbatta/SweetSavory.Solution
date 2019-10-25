using System;
using Microsoft.EntityFrameworkCore;

namespace SweetSavory.Models
{
    public class SweetSavoryContext : DbContext
    {
        public DbSet<Flavor> Flavors {get;set;}
        public DbSet<Treat> Treats {get;set;}
        public DbSet<FlavorTreat> FlavorTreats {get;set;}
        public SweetSavoryContext(DbContextOptions options) : base(options) {}

    }
    
}