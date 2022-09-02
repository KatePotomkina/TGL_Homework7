﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TGL_Homework6.Data;

#nullable disable

namespace TGL_Homework6.Migrations
{
    [DbContext(typeof(PuppyEFContext))]
    [Migration("20220902083720_Initial Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TGL_Homework6.Models.Breed", b =>
                {
                    b.Property<int>("Breed_Id")
                        .HasColumnType("int")
                        .HasColumnName("Breed_Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Breed_Id");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("TGL_Homework6.Models.Puppy", b =>
                {
                    b.Property<string>("PuppyId")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Puppy_Id");

                    b.Property<int>("Breed_Id")
                        .HasColumnType("int")
                        .HasColumnName("Breed_Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.HasKey("PuppyId");

                    b.HasIndex("Breed_Id");

                    b.ToTable("Puppies");
                });

            modelBuilder.Entity("TGL_Homework6.Models.Puppy", b =>
                {
                    b.HasOne("TGL_Homework6.Models.Breed", "Breed")
                        .WithMany("Puppies")
                        .HasForeignKey("Breed_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Breed_Id");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("TGL_Homework6.Models.Breed", b =>
                {
                    b.Navigation("Puppies");
                });
#pragma warning restore 612, 618
        }
    }
}
