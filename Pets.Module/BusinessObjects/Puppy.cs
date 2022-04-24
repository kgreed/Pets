using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Module.BusinessObjects
{
    public class Puppy : BabyPet
    {
        // comment out the following to solve the problem
        //public int ParentPetId { get; set; }
        //[ForeignKey("ParentPetId")]
        // end  comment
        public virtual Dog Parent { get; set; }


    }
}
