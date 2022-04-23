using System;

namespace Pets.Module.BusinessObjects
{
    public class Kitten : BabyPet
    {
        public virtual Cat Parent { get; set; }
    }
}
