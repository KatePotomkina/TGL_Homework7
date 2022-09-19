using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TGL_Homework6.Models;

namespace TGL_Homework6.Data
{
	public partial class MyDbContext : DbContext
	{
		public MyDbContext()
		{
		}

		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Owner> Owners { get; set; } = null!;
		public virtual DbSet<OwnerPuppy> OwnerPuppies { get; set; } = null!;
		public virtual DbSet<Puppy> Puppies { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer("Data Source=DESKTOP-HGVMRFD\\MSSQLSERVER1;Initial Catalog=MyDb;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Owner>(entity =>
			{
				entity.Property(e => e.OwnerId)
					.ValueGeneratedNever()
					.HasColumnName("Owner_id");

				entity.Property(e => e.PuppyId).HasColumnName("Puppy_id");

				entity.HasOne(d => d.Puppy)
					.WithMany(p => p.Owners)
					.HasForeignKey(d => d.PuppyId)
					.HasConstraintName("FK__Owners__Puppy_id__3D5E1FD2");
			});

			modelBuilder.Entity<OwnerPuppy>(entity =>
			{
				entity.ToTable("Owner_Puppy");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.OwnerId).HasColumnName("Owner_Id");

				entity.Property(e => e.PuppyId).HasColumnName("Puppy_Id");

				entity.HasOne(d => d.Owner)
					.WithMany(p => p.OwnerPuppies)
					.HasForeignKey(d => d.OwnerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Owner_Pup__Owner__3E52440B");

				entity.HasOne(d => d.Puppy)
					.WithMany(p => p.OwnerPuppies)
					.HasForeignKey(d => d.PuppyId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Owner_Pup__Puppy__3F466844");
			});

			modelBuilder.Entity<Puppy>(entity =>
			{
				entity.ToTable("Puppy");

				entity.Property(e => e.PuppyId)
					.ValueGeneratedNever()
					.HasColumnName("Puppy_id");

				entity.Property(e => e.PuppyName)
					.HasMaxLength(10)
					.HasColumnName("Puppy_Name")
					.IsFixedLength();
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
