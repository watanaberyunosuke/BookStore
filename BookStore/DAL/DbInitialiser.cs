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
                new Book(Guid.Parse("1278A6C0-3338-4C45-8222-9B19F01461F0"), "CQRS for Dummies", true),
                new Book(Guid.Parse("942E5171-95DE-45CF-B951-C18D659EACB0"), "Visual Studio Tips", true),
                new Book(Guid.Parse("BE4C1039-31A3-4E6B-8563-ACA05EBDAF53"), "NHibernate Cookbook", false)
            };

            var customers = new List<Customer>
            {
                new Customer(Guid.Parse("192468C6-901C-4B24-BC66-4B11730ADD9C"), "John", "Doe", "JD@gmail.com"),
                new Customer(Guid.Parse("FAF9130A-8829-41F2-A4D5-6A2F6FA23D5E"), "Jane", "Doe", "JD2@gmail.com"),
                new Customer(Guid.Parse("24B2D0B0-0F86-4C1C-B04B-DA08E7E632EB"), "Jack", "Doe", "JD3@gmail.com")
            };

            var reserves = new List<Reservation>
            {
                new Reservation(Guid.NewGuid(), Guid.Parse("192468C6-901C-4B24-BC66-4B11730ADD9C"),
                    Guid.Parse("1278A6C0-3338-4C45-8222-9B19F01461F0"), DateTime.Now),
                new Reservation(Guid.NewGuid(), Guid.Parse("24B2D0B0-0F86-4C1C-B04B-DA08E7E632EB"),
                    Guid.Parse("942E5171-95DE-45CF-B951-C18D659EACB0"), DateTime.Now)
            };

            context.Customers.AddRange(customers);
            context.Books.AddRange(books);
            context.Reservations.AddRange(reserves);
            context.SaveChanges();
        }
    }
}