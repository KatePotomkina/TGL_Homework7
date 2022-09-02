using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TGL_Homework6.Models;

[Table("Breed")]
public class Breed
{
	public Breed()
	{
		Puppies = new HashSet<Puppy>();
	}

	[Key] [Column("Breed_Id")] public int Breed_Id { get; set; }

	[Required]
	[StringLength(300)]
	[Unicode(false)]
	public string? Name { get; set; }

	[InverseProperty("Breed")] public virtual ICollection<Puppy> Puppies { get; set; }
	}