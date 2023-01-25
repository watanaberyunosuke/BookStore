
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookStore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.DAL.BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    } 
}