using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TGL_Homework6.Data;

namespace TGL_Homework6.Models
{
    public partial class Puppy
    {
	   

	    [Key]
        [Column("Puppy_Id")]
        [StringLength(300)]
        [Unicode(false)]
        public string PuppyId { get; set; } = null!;
        [StringLength(300)]
        [Required]
        [Unicode(false)]
        public string? Name { get; set; }
		[Column("Breed_Id")]
		public int Breed_Id { get; set; }
		[StringLength(300)]
        [Required]
        [Unicode(false)]
        public string? Owner { get; set; }

        [ForeignKey("Breed_Id")]
        [InverseProperty("Puppies")]
        public virtual Breed? Breed{ get; set; }

        
    }
}
