using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp5
{
    public partial class TestCoreEFDBContext : DbContext
    {
        public TestCoreEFDBContext()
        {
        }

        public TestCoreEFDBContext(DbContextOptions<TestCoreEFDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Должность> Должностьs { get; set; } = null!;
        public virtual DbSet<Пользователь> Пользовательs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MONCBKJ;Database=TestCoreEFDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Должность>(entity =>
            {
                entity.HasKey(e => e.Код);

                entity.ToTable("Должность");

                entity.Property(e => e.Наименование)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Пользователь>(entity =>
            {
                entity.HasKey(e => e.Код);

                entity.ToTable("Пользователь");

                entity.Property(e => e.Имя).HasMaxLength(100);

                entity.Property(e => e.Отчество).HasMaxLength(150);

                entity.Property(e => e.Фамилия).HasMaxLength(150);

                entity.HasOne(d => d.Должность)
                    .WithMany(p => p.Пользовательs)
                    .HasForeignKey(d => d.КодПользователя)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Пользователь_Должность");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
