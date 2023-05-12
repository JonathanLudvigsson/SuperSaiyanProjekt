﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperSaiyanProjekt.Data;

#nullable disable

namespace SuperSaiyanProjekt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230512104541_update1")]
    partial class update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "ProjectsProjectId");

                    b.HasIndex("ProjectsProjectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Age = 30,
                            FirstName = "John",
                            HireDate = new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Doe",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Age = 29,
                            FirstName = "Jane",
                            HireDate = new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Doe",
                            Phone = "098-765-4321"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Age = 35,
                            FirstName = "Bob",
                            HireDate = new DateTime(2017, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            Phone = "555-555-1234"
                        },
                        new
                        {
                            EmployeeId = 4,
                            Age = 28,
                            FirstName = "Alice",
                            HireDate = new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Johnson",
                            Phone = "555-555-5678"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Age = 32,
                            FirstName = "Charlie",
                            HireDate = new DateTime(2018, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Brown",
                            Phone = "555-555-9999"
                        });
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.ToTable("projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            EndDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectDescription = "Description of Project A",
                            ProjectName = "Project A",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 2,
                            EndDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectDescription = "Description of Project B",
                            ProjectName = "Project B",
                            StartDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Models.TimeReport", b =>
                {
                    b.Property<int>("RepoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepoId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("RepoId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("timereports");

                    b.HasData(
                        new
                        {
                            RepoId = 1,
                            EmployeeId = 1,
                            HoursWorked = 40,
                            ProjectId = 1,
                            WeekNumber = 1
                        },
                        new
                        {
                            RepoId = 2,
                            EmployeeId = 1,
                            HoursWorked = 35,
                            ProjectId = 2,
                            WeekNumber = 2
                        },
                        new
                        {
                            RepoId = 3,
                            EmployeeId = 2,
                            HoursWorked = 30,
                            ProjectId = 1,
                            WeekNumber = 1
                        },
                        new
                        {
                            RepoId = 4,
                            EmployeeId = 3,
                            HoursWorked = 20,
                            ProjectId = 2,
                            WeekNumber = 2
                        },
                        new
                        {
                            RepoId = 5,
                            EmployeeId = 4,
                            HoursWorked = 45,
                            ProjectId = 1,
                            WeekNumber = 3
                        },
                        new
                        {
                            RepoId = 6,
                            EmployeeId = 5,
                            HoursWorked = 25,
                            ProjectId = 2,
                            WeekNumber = 4
                        });
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.TimeReport", b =>
                {
                    b.HasOne("Models.Employee", "Employee")
                        .WithMany("TimeReps")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Project", "Project")
                        .WithMany("TimeReports")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Navigation("TimeReps");
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Navigation("TimeReports");
                });
#pragma warning restore 612, 618
        }
    }
}
