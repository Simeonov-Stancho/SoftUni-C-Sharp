using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BookShop;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(x => new { x.BookId, x.CategoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
