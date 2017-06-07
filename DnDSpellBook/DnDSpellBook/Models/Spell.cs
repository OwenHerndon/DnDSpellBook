using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnDSpellBook.Models
{
    public class Spell
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HigherLevel { get; set; }
        public int Range { get; set; }
        public List<string> Components { get; set; }
        public string Material { get; set; }
        public string Ritual { get; set; }
        public string CastTime { get; set; }
        public int Level { get; set; }
    }
}