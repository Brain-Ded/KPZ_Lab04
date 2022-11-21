using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KPZ_Lab04.Models;

public partial class KpzLab03DbContext : DbContext
{
    public KpzLab03DbContext()
    {
    }

    public KpzLab03DbContext(DbContextOptions<KpzLab03DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7POQ0P0\\SQLEXPRESS; Database=KPZ_Lab03DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student_1");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TId).HasColumnName("t_ID");

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.TId)
                .HasConstraintName("FK_Student_Teacher");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TId);

            entity.ToTable("Teacher");

            entity.Property(e => e.TId)
                .ValueGeneratedNever()
                .HasColumnName("t_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
