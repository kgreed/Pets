using System;

namespace Pets.Module.BusinessObjects
{
    public class Puppy : BabyPet
    {

        public virtual Dog Parent { get; set; }


    }
}
