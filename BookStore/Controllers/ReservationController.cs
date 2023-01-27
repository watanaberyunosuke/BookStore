using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.DAL;
using BookStore.Models;
using BookStoreContext = BookStore.DAL.BookStoreContext;

namespace BookStore.Controllers
{
    public class ReservationController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: Reservation
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Book).Include(r => r.Customer);
            return View(reservations.ToList());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,CustomerId,BookId,ReservationDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.ReservationId = Guid.NewGuid();
                db.Reservations.Add(reservation);
                db.Books.Find(reservation.BookId).Reserved = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", reservation.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", reservation.CustomerId);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", reservation.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", reservation.CustomerId);
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,CustomerId,BookId,ReservationDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", reservation.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", reservation.CustomerId);
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.Books.Find(reservation.BookId).Reserved = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
