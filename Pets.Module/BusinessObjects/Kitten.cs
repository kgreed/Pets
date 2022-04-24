using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Module.BusinessObjects
{
    public class Kitten : BabyPet
    {
        // comment out the following to solve the issue
        //public int ParentPetId { get; set; }
        //[ForeignKey("ParentPetId")]
        // end comment
        public virtual Cat Parent { get; set; }
    }
}
