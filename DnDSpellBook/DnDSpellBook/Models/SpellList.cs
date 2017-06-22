using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnDSpellBook.Models
{
    public class SpellList
    {
        [Key]
        public int Id { get; set; }
        public int count { get; set; }
        public List<Result> results { get; set; }
    }

    public class Result
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}