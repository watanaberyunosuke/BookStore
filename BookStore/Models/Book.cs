using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public String BookTitle { get; set; }
        
        // Constructor
        public Book(Guid bookId, String bookTitle)
        {
            BookId = bookId;
            BookTitle = bookTitle;
        }
        
    }

    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

}