using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2_Construction.Models
{
    public class LibraryDbInitializer : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            db.Books.Add(new Book { ID = 1, Title = "Война и мир", Author = "Лев Толстой", Availabe = false, ReaderID = 1 });
            db.Books.Add(new Book { ID = 2, Title = "Intermezzo", Author = "Kotscubinkiy", Availabe = true });
            db.Books.Add(new Book { ID = 3, Title = "World Encyclopedia", Author = "Co-op authors", Availabe = true });
            db.Books.Add(new Book { ID = 4, Title = "WEB tutorial", Author = "Co-op authors", Availabe = true });
            db.Books.Add(new Book { ID = 5, Title = "Roadside Picnic", Author = "Arkady Strugatsky", Availabe = true });
            db.LibraryCards.Add(new LibraryCard { ID = 1, FirstName = "Galina", LastName = "Turish" });
            base.Seed(db);
        }
    }
}