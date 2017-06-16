using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnDSpellBook.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Spell> Spells { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}