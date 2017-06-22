using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DnDSpellBook.Models
{
    public class Spell
    {
        [Key]
        public int Id { get; set; }
        public string _id { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public List<string> desc { get; set; }
        public string page { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }
        public string material { get; set; }
        public string ritual { get; set; }
        public string duration { get; set; }
        public string concentration { get; set; }
        public string casting_time { get; set; }
        public string level { get; set; }
        //public School school { get; set; }
        //public List<Class> classes { get; set; }
        //public List<Subclass> subclasses { get; set; }
        public string url { get; set; }

        public int Character_Id { get; set; }

        [ForeignKey("Character_Id")]
        [JsonIgnore]
        public virtual Character Character { get; set; }
    }

    //public class School
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string url { get; set; }
    //    public string name { get; set; }
    //}

    //public class Class
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class Subclass
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string url { get; set; }
    //    public string name { get; set; }
    //}
}