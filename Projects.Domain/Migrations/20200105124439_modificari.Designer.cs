﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projects.Domain;

namespace Projects.Domain.Migrations
{
    [DbContext(typeof(ProjectsContext))]
    [Migration("20200105124439_modificari")]
    partial class modificari
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "SenderId", "ReceiverId");

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
                            Id = new Guid("43da652d-f503-45e5-bf47-46ddeaaccad6"),
                            Name = "Java"
                        },
                        new
                        {
                            Id = new Guid("1e4c2e44-e366-4ad8-8aab-55341fc7311a"),
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = new Guid("89e87ea5-066a-4b30-a1c7-328737fe9d63"),
                            Name = ".Net"
                        },
                        new
                        {
                            Id = new Guid("e4e9b4df-f1da-48fc-88e5-861f06f5ce7d"),
                            Name = "C#"
                        },
                        new
                        {
                            Id = new Guid("c0c4b011-85f0-45f1-b794-92d9100a0264"),
                            Name = "Unity"
                        },
                        new
                        {
                            Id = new Guid("7b54fda9-e0de-49f4-b923-202ed1e0eba2"),
                            Name = "Node.js"
                        },
                        new
                        {
                            Id = new Guid("96f11b84-7fb0-4e36-92f2-83754e60e638"),
                            Name = "Angular"
                        },
                        new
                        {
                            Id = new Guid("87f5df8d-677a-4d4c-8baf-54e4278fb23e"),
                            Name = "React"
                        },
                        new
                        {
                            Id = new Guid("4c8afae6-56bc-4403-828a-b843414f0bd6"),
                            Name = "Vue"
                        },
                        new
                        {
                            Id = new Guid("3293e537-c40c-4421-8aa3-2d6c1297cc48"),
                            Name = "Express"
                        },
                        new
                        {
                            Id = new Guid("0e00c228-7d39-4109-87b8-b6d11a89f003"),
                            Name = "Swift"
                        },
                        new
                        {
                            Id = new Guid("c7b796f8-e9d5-49b9-9952-ea6e2decea7a"),
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = new Guid("6ea2d65f-14d0-4dd6-bd63-199f376cb978"),
                            Name = "C++"
                        },
                        new
                        {
                            Id = new Guid("ec986892-c991-48bf-b02a-317820524569"),
                            Name = "Python"
                        },
                        new
                        {
                            Id = new Guid("b1173779-d557-430c-ac11-eb9518e0b621"),
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
