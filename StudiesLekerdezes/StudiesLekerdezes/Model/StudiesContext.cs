﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudiesLekerdezes.Model
{
    public partial class StudiesContext : DbContext
    {
        public StudiesContext()
        {
        }

        public StudiesContext(DbContextOptions<StudiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Day> Days { get; set; } = null!;
        public virtual DbSet<Employement> Employements { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=bit.uni-corvinus.hu;Initial Catalog=Studies;Persist Security Info=True;User ID=hallgato;Password=Password123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseSk)
                    .HasName("PK__Course__C92D8C48C0FF3089");

                entity.ToTable("Course");

                entity.Property(e => e.CourseSk).HasColumnName("CourseSK");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.Property(e => e.DayId).HasColumnName("DayID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employement>(entity =>
            {
                entity.ToTable("Employement");

                entity.Property(e => e.EmployementId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EmployementID")
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstructorSk)
                    .HasName("PK__Instruct__9D017A28F1AA49DE");

                entity.ToTable("Instructor");

                entity.Property(e => e.InstructorSk).HasColumnName("InstructorSK");

                entity.Property(e => e.EmployementFk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EmployementFK")
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Salutation).HasMaxLength(10);

                entity.Property(e => e.StatusFk).HasColumnName("StatusFK");

                entity.HasOne(d => d.EmployementFkNavigation)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.EmployementFk)
                    .HasConstraintName("FK_Instructor_ToEmployement");

                entity.HasOne(d => d.StatusFkNavigation)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.StatusFk)
                    .HasConstraintName("FK_Instructor_ToStatus");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.LessonSk)
                    .HasName("PK__Lesson__B08512E2B31DE1E1");

                entity.ToTable("Lesson");

                entity.Property(e => e.LessonSk).HasColumnName("LessonSK");

                entity.Property(e => e.CourseFk).HasColumnName("CourseFK");

                entity.Property(e => e.DayFk).HasColumnName("DayFK");

                entity.Property(e => e.InstructorFk).HasColumnName("InstructorFK");

                entity.Property(e => e.RoomFk).HasColumnName("RoomFK");

                entity.Property(e => e.TimeFk).HasColumnName("TimeFK");

                entity.HasOne(d => d.CourseFkNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseFk)
                    .HasConstraintName("FK_Lesson_ToCourse");

                entity.HasOne(d => d.DayFkNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.DayFk)
                    .HasConstraintName("FK_Lesson_ToDay");

                entity.HasOne(d => d.InstructorFkNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.InstructorFk)
                    .HasConstraintName("FK_Lesson_ToInstructor");

                entity.HasOne(d => d.RoomFkNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.RoomFk)
                    .HasConstraintName("FK_Lesson_ToRoom");

                entity.HasOne(d => d.TimeFkNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.TimeFk)
                    .HasConstraintName("FK_Lesson_ToTime");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomSk)
                    .HasName("PK__Room__328616CFC5DF441D");

                entity.ToTable("Room");

                entity.Property(e => e.RoomSk).HasColumnName("RoomSK");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("Time");

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
