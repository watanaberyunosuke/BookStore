using System;
using System.Data.Entity;

namespace BookStore.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerLastName { get; set; }
        public String Email { get; set; }
        
            // Constructors
            public Customer()
            {
            
            }

            public Customer(Guid id, String name, String lastName, String email)
            {
                CustomerId = id;
                CustomerName = name;
                CustomerLastName = lastName;
                Email = email;
            }
    }
    
    // DB Context
    public class BookStoreCustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
    
}