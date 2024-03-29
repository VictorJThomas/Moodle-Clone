﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moodle_Clone.Infraestructure.Context;

#nullable disable

namespace Moodle_Clone.Infraestructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240220005745_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssigmentsStudent", b =>
                {
                    b.Property<Guid>("AssigmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubmittedByStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssigmentsId", "SubmittedByStudentId");

                    b.HasIndex("SubmittedByStudentId");

                    b.ToTable("AssigmentsStudent");
                });

            modelBuilder.Entity("CoursesStudent", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("CoursesStudent");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Answers", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnswerId");

                    b.HasIndex("ForumId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Assigments", b =>
                {
                    b.Property<Guid>("AssigmentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssigmentsDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssigmentsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AssigmentsStatus")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LimitDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssigmentsId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Assigments");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Courses", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Forum", b =>
                {
                    b.Property<Guid>("ForumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForumId");

                    b.HasIndex("CourseId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Resources", b =>
                {
                    b.Property<Guid>("ResourcesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoursesCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourcesId");

                    b.HasIndex("CoursesCourseId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeacherId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RolId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("RolId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssigmentsStudent", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Assigments", null)
                        .WithMany()
                        .HasForeignKey("AssigmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moodle_Clone.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("SubmittedByStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoursesStudent", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Courses", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moodle_Clone.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Answers", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Forum", "Forum")
                        .WithMany("Answer")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forum");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Assigments", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Courses", "Course")
                        .WithMany("Assigment")
                        .HasForeignKey("CourseId");

                    b.HasOne("Moodle_Clone.Domain.Models.Teacher", "Teacher")
                        .WithMany("Assigment")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Courses", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Teacher", "Teacher")
                        .WithMany("Course")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Forum", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Courses", "Courses")
                        .WithMany("Forums")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Resources", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Courses", null)
                        .WithMany("Resource")
                        .HasForeignKey("CoursesCourseId");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Student", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Users", "Users")
                        .WithOne("Student")
                        .HasForeignKey("Moodle_Clone.Domain.Models.Student", "UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Teacher", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Users", "Users")
                        .WithOne("Teacher")
                        .HasForeignKey("Moodle_Clone.Domain.Models.Teacher", "UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Users", b =>
                {
                    b.HasOne("Moodle_Clone.Domain.Models.Role", "Rol")
                        .WithMany("User")
                        .HasForeignKey("RolId1");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Courses", b =>
                {
                    b.Navigation("Assigment");

                    b.Navigation("Forums");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Forum", b =>
                {
                    b.Navigation("Answer");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Teacher", b =>
                {
                    b.Navigation("Assigment");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Moodle_Clone.Domain.Models.Users", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
