using System;
using System.Collections.Generic;

namespace TGL_Homework6.Models
{
    public partial class Owner
    {
        public Owner()
        {
            OwnerPuppies = new HashSet<OwnerPuppy>();
        }

        public int OwnerId { get; set; }
        public int Name { get; set; }
        public int? PuppyId { get; set; }

        public virtual Puppy? Puppy { get; set; }
        public virtual ICollection<OwnerPuppy> OwnerPuppies { get; set; }
    }
}
