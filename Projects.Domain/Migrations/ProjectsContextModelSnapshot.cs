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

            modelBuilder.Entity("Projects.Domain.Models.Invitation", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollaboratorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InvitationType")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "CollaboratorId", "OwnerId");

                    b.ToTable("Invitations");
                });

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
                            Id = new Guid("356a2151-d666-4be5-a0cc-d90336ab51c4"),
                            Name = "Java"
                        },
                        new
                        {
                            Id = new Guid("a77e6e2b-8ebd-4c40-853f-a2d8a800f49c"),
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = new Guid("c175769a-4cb4-4c03-974a-58e4fc8b12a5"),
                            Name = ".Net"
                        },
                        new
                        {
                            Id = new Guid("4f6252fe-2e40-4c34-9da7-b186ed0d7958"),
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("2f558a73-0007-4e1b-84e9-9b87ce544e2b"),
                            Name = "Unity"
                        },
                        new
                        {
                            Id = new Guid("ee005f22-7313-4664-bd5b-cf1c1457e448"),
                            Name = "Node.js"
                        },
                        new
                        {
                            Id = new Guid("b6347884-9580-45de-87bb-7f3181269d1c"),
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("f00907c8-d1be-49b6-b281-37cbfe63f262"),
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("d3460bbd-c2b1-4916-86b4-e723e77d8751"),
                            Name = "Vue"
                        },
                        new
                        {
                            Id = new Guid("5c2fb546-c3c2-4780-b248-cd62a5f07eeb"),
                            Name = "Express"
                        },
                        new
                        {
                            Id = new Guid("c7dc9263-979f-4911-a71d-6e2231939653"),
                            Name = "Swift"
                        },
                        new
                        {
                            Id = new Guid("a66e368d-aeac-48f3-95b4-0c8f50f65b6c"),
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("41fce07d-721e-4f87-9879-31e428462702"),
                            Name = "C++"
                        },
                        new
                        {
                            Id = new Guid("1654a6c0-6cef-4516-a3bf-321a2b98341f"),
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("54a85e17-21a6-4d84-8ea6-32a64956776e"),
                            Name = "C"
                        });
                });

            modelBuilder.Entity("Projects.Domain.Models.Invitation", b =>
                {
                    b.HasOne("Projects.Domain.Models.Project", "Project")
                        .WithMany("Invitations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                });
#pragma warning restore 612, 618
        }
    }
}
