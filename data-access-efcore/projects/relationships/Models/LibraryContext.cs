using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace relationships.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }

        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;Database=LocalLibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(author => author.AuthorId);

                entity.ToTable("authors");


                // entity.Property(e => e.BrandName)
                //     .IsRequired()
                //     .HasColumnName("brand_name")
                //     .HasMaxLength(255)
                //     .IsUnicode(true);
            });



            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(book => book.BookId);

                entity.ToTable("books");



            });

            modelBuilder.Entity<BookAuthor>(entity =>
           {
               entity.HasKey(bookAuthor => bookAuthor.BookAuthorId);

               //entity.HasAlternateKey(bookAuthor => bookAuthor.AuthorId, bookAuthor.BookId);

               //entity.Property(bookAuthor => bookAuthor)

               entity.ToTable("bookauthors");



           });
            modelBuilder.Entity<BookGenre>(entity =>
           {
               entity.HasKey(bookGenre => bookGenre.BookGenreId);

               entity.ToTable("bookgenres");



           });
            modelBuilder.Entity<Genre>(entity =>
           {
               entity.HasKey(genre => genre.GenreId);

               entity.ToTable("genres");



           });
            modelBuilder.Entity<Image>(entity =>
           {
               entity.HasKey(image => image.ImageId);

               entity.ToTable("images");



           });
            modelBuilder.Entity<Publisher>(entity =>
           {
               entity.HasKey(publisher => publisher.PublisherId);

               entity.ToTable("publishers");



           });

        }
    }
}