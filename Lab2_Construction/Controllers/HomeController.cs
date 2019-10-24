using Lab2_Construction.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab2_Construction.Controllers
{
    public class HomeController : Controller
    {
        LibraryContext db = new LibraryContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            return View(books);
        }

        public ActionResult ReadersList()
        {
            IEnumerable<LibraryCard> cards = db.LibraryCards;
            return View(cards);
        }

        public ActionResult PartialReadersBookList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LibraryCard card = db.LibraryCards.Find(id);

            if (card == null)
            {
                return HttpNotFound();
            }

            List<Book> ReadersBooks = new List<Book>();

            foreach(var book in db.Books)
            {
                if(book.ReaderID == id)
                ReadersBooks.Add(book);
            }

            return PartialView(ReadersBooks);
        }

        public ActionResult RegisterNewCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewCard(LibraryCard newCard)
        {
            if (ModelState.IsValid)
            {
                newCard.ID = db.LibraryCards.ToList().Count;
                db.LibraryCards.Add(newCard);
                db.SaveChanges();
                ViewData["Success"] = "Reader " + newCard.LastName + " " + newCard.FirstName + " was registered successfully.";
                return RedirectToAction("Index"); 
            }
            return View(newCard);
        }
        
        //public ActionResult ReserveBook(int? id)
        //{
        //if(id == null)
        //{
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}
        //Book book = db.Books.Find(id);
        //if(book == null)
        //{
        //    return HttpNotFound();
        //}
        //return View(book);
        //}

        public ActionResult ReserveBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryCard card = db.LibraryCards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        [HttpPost]
        public ActionResult ReserveBook(LibraryCard libraryCard)
        {
            bool check = true;
            for (int i = 0; i < db.LibraryCards.ToList().Count; i++)
            {
                if (db.LibraryCards.Find(i) != null && db.LibraryCards.Find(i).reservedBook == libraryCard.reservedBook)
                    check = false;
            }
            if (check != false)
            {
                db.Books.Find(libraryCard.reservedBook).ReaderID = libraryCard.ID;

                db.Books.Find(libraryCard.reservedBook).Availabe = false;

                db.Entry(db.Books.Find(
                    libraryCard.reservedBook)).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(libraryCard);
        }

        public ActionResult SearchReader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchReader(int ID)
        {
            LibraryCard card = db.LibraryCards.Find(ID);

            return View(card);
        }

        public ActionResult ReceptionBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryCard card = db.LibraryCards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        [HttpPost]
        public ActionResult ReceptionBook(LibraryCard Card)
        {
            if (ModelState.IsValid)
            {
                db.Books.Find(Card.ID).ReaderID = 0;

                db.Books.Find(Card.reservedBook).Availabe = true;

                db.Entry(db.Books.Find(Card.reservedBook)).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Card);
        }
    }
}