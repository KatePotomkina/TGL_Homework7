using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TGL_Homework6.Models;

namespace TGL_Homework6.Data
{
    public partial class PuppyEFContext : DbContext
    {
        public PuppyEFContext()
        {
        }

        public PuppyEFContext(DbContextOptions<PuppyEFContext> options)
            : base(options)
        {
        }

        public  virtual DbSet<Breed> Breeds{ get; set; }
        public virtual DbSet<Puppy> Puppies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=PuppyEF;trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>(entity =>
            {
                entity.Property(e => e.Breed_Id)
	                .ValueGeneratedNever();
            });

            modelBuilder.Entity<Puppy>(entity =>
            {
                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.Puppies)
                    .HasForeignKey(d => d.Breed_Id)
                    .HasConstraintName("Breed_Id");
            });

            // ReSharper disable once InvocationIsSkipped
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
