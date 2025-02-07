﻿// <auto-generated />
using Institute_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Institute_Management.Migrations
{
    [DbContext(typeof(InstituteContext))]
    [Migration("20250207103415_AdminMoudleAdded")]
    partial class AdminMoudleAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Institute_Management.Models.AdminModule+Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.HasIndex("UserId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            UserId = 1
                        },
                        new
                        {
                            AdminId = 2,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.BatchModule+Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchId"));

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatchTiming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatchType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("BatchId");

                    b.HasIndex("CourseId");

                    b.ToTable("Batches");

                    b.HasData(
                        new
                        {
                            BatchId = 1,
                            BatchName = "Batch A",
                            BatchTiming = "9:00 AM - 11:00 AM",
                            BatchType = "Morning",
                            CourseId = 1
                        },
                        new
                        {
                            BatchId = 2,
                            BatchName = "Batch B",
                            BatchTiming = "2:00 PM - 4:00 PM",
                            BatchType = "Afternoon",
                            CourseId = 2
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.CourseModule+Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Algebra 101",
                            Description = "Introduction to Algebra",
                            TeacherId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Physics 101",
                            Description = "Basic concepts of Physics",
                            TeacherId = 2
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.StudentCourseModule+StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 2
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.StudentModule+Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int?>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("BatchId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BatchId = 1,
                            UserId = 2
                        },
                        new
                        {
                            StudentId = 2,
                            BatchId = 2,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.TeacherModule+Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("SubjectSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            SubjectSpecialization = "Mathematics",
                            UserId = 3
                        },
                        new
                        {
                            TeacherId = 2,
                            SubjectSpecialization = "Science",
                            UserId = 6
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.UserModule+User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ContactDetails = "123-456-7890",
                            Email = "admin@example.com",
                            Name = "Admin User",
                            Password = "admin123",
                            Role = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            ContactDetails = "234-567-8901",
                            Email = "student@example.com",
                            Name = "Student User",
                            Password = "student123",
                            Role = "Student"
                        },
                        new
                        {
                            UserId = 3,
                            ContactDetails = "345-678-9012",
                            Email = "teacher@example.com",
                            Name = "Teacher User",
                            Password = "teacher123",
                            Role = "Teacher"
                        },
                        new
                        {
                            UserId = 4,
                            ContactDetails = "234-567-8902",
                            Email = "student2@example.com",
                            Name = "Student Two",
                            Password = "student456",
                            Role = "Student"
                        },
                        new
                        {
                            UserId = 5,
                            ContactDetails = "123-456-7891",
                            Email = "admin2@example.com",
                            Name = "Admin Two",
                            Password = "admin456",
                            Role = "Admin"
                        },
                        new
                        {
                            UserId = 6,
                            ContactDetails = "345-678-9013",
                            Email = "teacher2@example.com",
                            Name = "Teacher Two",
                            Password = "teacher456",
                            Role = "Teacher"
                        });
                });

            modelBuilder.Entity("Institute_Management.Models.AdminModule+Admin", b =>
                {
                    b.HasOne("Institute_Management.Models.UserModule+User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Institute_Management.Models.BatchModule+Batch", b =>
                {
                    b.HasOne("Institute_Management.Models.CourseModule+Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Institute_Management.Models.CourseModule+Course", b =>
                {
                    b.HasOne("Institute_Management.Models.TeacherModule+Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Institute_Management.Models.StudentCourseModule+StudentCourse", b =>
                {
                    b.HasOne("Institute_Management.Models.CourseModule+Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Institute_Management.Models.StudentModule+Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Institute_Management.Models.StudentModule+Student", b =>
                {
                    b.HasOne("Institute_Management.Models.BatchModule+Batch", "Batch")
                        .WithMany()
                        .HasForeignKey("BatchId");

                    b.HasOne("Institute_Management.Models.UserModule+User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Institute_Management.Models.TeacherModule+Teacher", b =>
                {
                    b.HasOne("Institute_Management.Models.UserModule+User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Institute_Management.Models.CourseModule+Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Institute_Management.Models.StudentModule+Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
