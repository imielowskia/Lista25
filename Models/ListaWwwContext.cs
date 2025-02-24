using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lista25.Models;

public partial class ListaWwwContext : DbContext
{
    public ListaWwwContext()
    {
    }

    public ListaWwwContext(DbContextOptions<ListaWwwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grupa> Grupas { get; set; }

    public virtual DbSet<Student> Students { get; set; }

// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=10.8.0.16;Database=ListaWWW;User ID=student;Password=informatyki;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_datareader");

        modelBuilder.Entity<Grupa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__grupas__3213E83F167235EB");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83F2304D652");

            entity.HasOne(d => d.Grupa).WithMany(p => p.Students).HasConstraintName("FK_students_grupas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
