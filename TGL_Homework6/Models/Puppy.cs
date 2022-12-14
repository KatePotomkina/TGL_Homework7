using System;
using System.Collections.Generic;

namespace TGL_Homework6.Models
{
    public partial class Puppy
    {
        public Puppy()
        {
            OwnerPuppies = new HashSet<OwnerPuppy>();
            Owners = new HashSet<Owner>();
        }

        public int PuppyId { get; set; }
        public string? PuppyName { get; set; }

        public virtual ICollection<OwnerPuppy> OwnerPuppies { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
    }
}
