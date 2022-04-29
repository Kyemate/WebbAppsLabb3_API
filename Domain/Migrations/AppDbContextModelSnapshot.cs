﻿// <auto-generated />
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "this is a test interest",
                            PersonId = 1,
                            Title = "test interest 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "this is a test interest",
                            PersonId = 2,
                            Title = "test interest 2"
                        });
                });

            modelBuilder.Entity("Domain.Models.Link", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            InterestId = 1,
                            Url = "http://sample.com"
                        });
                });

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Henrik",
                            Phone = "072-XXXXXXX"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hanna",
                            Phone = "072-XXXXXXX"
                        });
                });

            modelBuilder.Entity("Domain.Models.Interest", b =>
                {
                    b.HasOne("Domain.Models.Person", null)
                        .WithMany("Interests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Link", b =>
                {
                    b.HasOne("Domain.Models.Interest", null)
                        .WithMany("Links")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Interest", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.Navigation("Interests");
                });
#pragma warning restore 612, 618
        }
    }
}
