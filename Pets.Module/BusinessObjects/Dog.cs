using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;

namespace Pets.Module.BusinessObjects
{
    [NavigationItem("Pets")]
    public class Dog : Pet
    {
        public Dog()
        {
            Puppies = new List<Puppy>();
        }
        [Aggregated]
        public virtual List<Puppy> Puppies { get; set; }
    }
}
