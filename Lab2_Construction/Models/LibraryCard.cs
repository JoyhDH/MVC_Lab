﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Construction.Models
{
    public class LibraryCard
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int reservedBook { get; set; }

        public LibraryCard(int ID)
        {
            this.ID = ID;
        }

        public LibraryCard()
        {

        }

    }
}