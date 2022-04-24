using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Module.BusinessObjects
{
    public abstract class BabyPet
    {


        [Key] public int Id { get; set; }

        public int ParentPetId { get; set; }

        [ForeignKey("ParentPetId")]
        public virtual Pet Parent { get; set; }
        public string Name { get; set; }
        public bool? IsCat { get; set; }

    }
}
