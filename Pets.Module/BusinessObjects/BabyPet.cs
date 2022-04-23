using System;
using System.ComponentModel.DataAnnotations;

namespace Pets.Module.BusinessObjects
{
    public abstract class BabyPet
    {


        [Key] public int Id { get; set; }
        public Pet Parent { get; set; }
        public string Name { get; set; }
        public bool? IsCat { get; set; }

    }
}
