﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnDSpellBook.Models
{
    public class SpellList
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}