using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;

namespace Pets.Module.BusinessObjects
{
    [NavigationItem("Pets")]
    public class Cat : Pet
    {
        public Cat()
        {
            Kittens = new List<Kitten>();
        }
        [Aggregated]
        public virtual List<Kitten> Kittens { get; set; }
    }
}
