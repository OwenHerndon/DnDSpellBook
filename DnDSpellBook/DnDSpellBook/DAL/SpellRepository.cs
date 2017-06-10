using DnDSpellBook.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace DnDSpellBook.DAL
{
    public class SpellRepository : ISpellRepository
    {

        public IEnumerable<Spell> GetSpells(string selectedClass, string selectedLevel)
        {
            var client = new RestClient("http://www.dnd5eapi.co/api/");
            var request = new RestRequest($"/spells/{selectedClass}/level/{selectedLevel}");
            //var request = new RestRequest($"spells/Paladin/level/2");

            var restResponse = client.Get<List<Spell>>(request);

            if (restResponse.StatusCode == HttpStatusCode.OK) yield return null;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            RootObject parseData = JsonConvert.DeserializeObject<RootObject>(restResponse.Content, settings);

            
            //foreach (var spell in parseData)
            //{
            //    var s = new Spell
            //    {
            //        Name = spell.Name,
            //        Description = spell.Description,
            //        HigherLevel = spell.HigherLevel,
            //        Range = spell.Range,
            //        Components = spell.Components,
            //        Material = spell.Material,
            //        Ritual = spell.Ritual,
            //        CastTime = spell.CastTime,
            //        Level = spell.Level
            //    };

             //   yield return s;
            //}
        }

        public class SpellList
        {
            public List<Spell> Spells { get; set; }
        }

        public class ApiSpell
        {
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

        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class RootObject
        {
            public int count { get; set; }
            public List<Result> results { get; set; }
        }
    }
}