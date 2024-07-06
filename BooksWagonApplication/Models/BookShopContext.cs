using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksWagonApplication.Models
{
    public partial class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtsPhotography> ArtsPhotographies { get; set; } = null!;
        public virtual DbSet<ArtsPhotographyDatum> ArtsPhotographyData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RAMYASRI\\SQLEXPRESS; Database=Bookswagon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtsPhotography>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__ArtsPhot__3DE0C207F2C47ACD");

                entity.ToTable("ArtsPhotography");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Bindingtype)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Languagetype)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Publisher)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.SubTypeOfBook)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfBook)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.BookType)
                    .WithMany(p => p.ArtsPhotographies)
                    .HasForeignKey(d => d.BookTypeId)
                    .HasConstraintName("FK_ArtsBookType");
            });

            modelBuilder.Entity<ArtsPhotographyDatum>(entity =>
            {
                entity.HasKey(e => e.BookTypeId)
                    .HasName("PK__Arts_Pho__259BDEF3FA763D7F");

                entity.ToTable("Arts_PhotographyData");

                entity.Property(e => e.BookTypeId).ValueGeneratedNever();

                entity.Property(e => e.SubTypeOfBook)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfBook)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
