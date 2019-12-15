﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projects.Domain;

namespace Projects.Domain.Migrations
{
    [DbContext(typeof(ProjectsContext))]
    partial class ProjectsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projects.Domain.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Projects.Domain.Models.ProjectTechnology", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TechnologieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "TechnologieId");

                    b.HasIndex("TechnologieId");

                    b.ToTable("ProjectTechnologies");
                });

            modelBuilder.Entity("Projects.Domain.Models.ProjectUser", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUsers");
                });

            modelBuilder.Entity("Projects.Domain.Models.Technology", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("30ad2e71-56d9-44a0-864d-d2b53a097f40"),
                            Name = "Java"
                        },
                        new
                        {
                            Id = new Guid("a5e32fcb-2576-48d6-aa60-dd464c91179e"),
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = new Guid("d8e57ab4-de9a-4cd2-a814-9626b1287921"),
                            Name = ".Net"
                        },
                        new
                        {
                            Id = new Guid("1c83f71f-18f3-4fe7-9010-6964e9907caf"),
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("8d5cee13-eef5-439f-8b0c-08163464346b"),
                            Name = "Unity"
                        },
                        new
                        {
                            Id = new Guid("618767ab-cd25-4b58-8f6a-1cb7c9592d60"),
                            Name = "Node.js"
                        },
                        new
                        {
                            Id = new Guid("f862b3ce-8216-4496-953a-c7038739894a"),
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("bec40c4d-b1f2-4d29-b744-138a1536cc87"),
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("da7e8d5c-8d3a-4ae9-9ec9-a0661bed95ef"),
                            Name = "Vue"
                        },
                        new
                        {
                            Id = new Guid("7033fd1e-fb60-4db6-b74a-0d7e2e781758"),
                            Name = "Express"
                        },
                        new
                        {
                            Id = new Guid("fa72d3ec-ceb9-4c9f-9a4a-cf75db9abfdc"),
                            Name = "Swift"
                        },
                        new
                        {
                            Id = new Guid("ab5c84ab-a47e-476d-a7d7-224b2c0956b6"),
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("ff2dcc27-f64a-4202-b430-9b3a27cc2bda"),
                            Name = "C++"
                        },
                        new
                        {
                            Id = new Guid("1cac5531-dd49-4caf-b5cf-86754a6dd7b1"),
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("86450be6-2cfd-4a7d-aba9-adf035963f4e"),
                            Name = "C"
                        });
                });

            modelBuilder.Entity("Projects.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Projects.Domain.Models.ProjectTechnology", b =>
                {
                    b.HasOne("Projects.Domain.Models.Project", "Project")
                        .WithMany("ProjectTechnologies")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projects.Domain.Models.Technology", "Technologie")
                        .WithMany("ProjectTechnologies")
                        .HasForeignKey("TechnologieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projects.Domain.Models.ProjectUser", b =>
                {
                    b.HasOne("Projects.Domain.Models.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projects.Domain.Models.User", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
