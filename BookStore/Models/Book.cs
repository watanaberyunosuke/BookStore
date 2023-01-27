using System;
using System.Data.Entity;

namespace BookStore.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public String BookTitle { get; set; }
        public Boolean Reserved { get; set; }

        // Constructor
        public Book(Guid bookId, String bookTitle, Boolean reserved)
        {
            BookId = bookId;
            BookTitle = bookTitle;
            Reserved = reserved;
        }

        public Book()
        {

        }
        
    }

    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

}