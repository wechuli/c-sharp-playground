using System;
using Microsoft.EntityFrameworkCore;
using Models;


namespace MigrationsPractise
{
    partial class BookContext : DbContext
    {

        public virtual DbSet<Author> authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Database=eflibrary;Username=postgres;Password=nairobi");
                // optionsBuilder.UseSqlite("Data Source=school.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("authors");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<Book>(entity =>
            {

                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.isbn);
                entity.ToTable("books");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.isbn).HasMaxLength(25);
                

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.ToTable("categories");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

            });



        }



    }
}