using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace SweetSavory.Models
{
    public class Treat
    {
        public int TreatID{get;set;}
        public string TreatName{get;set;}
        public StoreManager CreatedBy {get;set;}
        public ICollection<FlavorTreat> Flavors {get;set;}
        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat> {};
        }
    }
}