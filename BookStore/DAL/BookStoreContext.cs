using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookStore.Models;

namespace BookStore.DAL
{
    public class BookStoreContext : DbContext
    {

        protected readonly Microsoft.Extensions.Configuration.IConfiguration Configuration;
        public BookStoreContext() : base("BookStoreContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookStoreContext>());
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}