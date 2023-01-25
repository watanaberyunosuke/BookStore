using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.DAL
{
    public class DbInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            var books = new List<Book>
            {
                new Book(Guid.Parse("9b0896fa-3880-4c2e-bfd6-925c87f22878"), "CQRS for Dummies"),
                new Book(Guid.Parse("0550818d-36ad-4a8d-9c3a-a715bf15de76"), "Visual Studio Tips"),
                new Book(Guid.Parse("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"), "NHibernate Cookbook")
            };
            
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}