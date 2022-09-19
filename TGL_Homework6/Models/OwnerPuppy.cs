using System;
using System.Collections.Generic;

namespace TGL_Homework6.Models
{
    public partial class OwnerPuppy
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PuppyId { get; set; }

        public virtual Owner Owner { get; set; } = null!;
        public virtual Puppy Puppy { get; set; } = null!;
    }
}
