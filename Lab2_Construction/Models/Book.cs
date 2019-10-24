using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Construction.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public bool Availabe { get; set; }

        public int ReaderID { get; set; }
    }
}