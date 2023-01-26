using System;
using System.Data.Entity;

namespace BookStore.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ReservationDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }

        
        // Constructors
        public Reservation()
        {
            
        }

        public Reservation(Guid reservationId, Guid customerId, Guid bookId, DateTime reservationDate)
        {
            ReservationId = reservationId;
            CustomerId = customerId;
            BookId = bookId;
            ReservationDate = reservationDate;
        }
    }

    public class BookStoreReservationContext: DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
    }
    

}