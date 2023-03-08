using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<MonedaSucursal> MonedaSucursals { get; set; } = null!;
        public virtual DbSet<Monedum> Moneda { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Monedas__06370DADEFDF7118");

                entity.ToTable("Monedas", "TestQuala");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MonedaSucursal>(entity =>
            {
                entity.ToTable("Moneda_Sucursal");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdModena).HasColumnName("Id_Modena");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModenaNavigation)
                    .WithMany(p => p.MonedaSucursals)
                    .HasForeignKey(d => d.IdModena)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK");
            });

            modelBuilder.Entity<Monedum>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Sucursal__06370DAD9903C8D8");

                entity.ToTable("Sucursales", "TestQuala");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.MonedaNavigation)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.Moneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sucursale__Estad__39E294A9");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users", "TestQuala");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}