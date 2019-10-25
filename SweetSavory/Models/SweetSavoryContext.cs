namespace SweetSavory.Models
{
    public class SweetSavoryContext : DbContext
    {
        public DbSet<Flavor> Flavors {get;set;}
    }
    
}