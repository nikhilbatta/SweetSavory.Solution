

namespace SweetSavory.Models
{
    public class Flavor 
    {
        public int FlavorID {get;set;}
        public string FlavorName {get;set;}
        public ICollection<FlavorTreat> Treats {get;set;}

        // thhis will be a collection of the join entity class, which is the treats 
        public Flavor()
        {
            this.Treats = new HashSet<FlavorTreat>{};
        }
    }
}