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
        readonly ApplicationDbContext _context;

        public SpellRepository(ApplicationDbContext connection)
        {
            _context = connection;
        }

        public void AddSpellToCharacter(Spell characterSpell)
        {
            _context.Spells.Add(characterSpell);
            _context.SaveChanges();
        }

        public Spell GetSpellDetails(string spellurl)
        {
            var uri = new Uri(spellurl);

            var client = new RestClient(spellurl);
            var request = new RestRequest("");
            var restResponse = client.Get(request);

            //if (restResponse.StatusCode == HttpStatusCode.OK) yield return null;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            Spell spellDetailData = JsonConvert.DeserializeObject<Spell>(restResponse.Content, settings);

            return spellDetailData;
        }

        public IEnumerable<Result> GetSpells(string selectedClass, string selectedLevel)
        {
            var client = new RestClient("http://www.dnd5eapi.co/api/");
            var request = new RestRequest($"/spells/{selectedClass}/level/{selectedLevel}");

            var restResponse = client.Get<List<Spell>>(request);

            if (restResponse.StatusCode == HttpStatusCode.OK) yield return null;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            SpellList parseData = JsonConvert.DeserializeObject<SpellList>(restResponse.Content, settings);

            //yield return parseData;

            foreach (var spell in parseData.results)
            {
                var s = new Result
                {
                    //count = spell.count,
                    //results = spell.results
                    name = spell.name,
                    url = spell.url
                };

                yield return s;
            }

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
    }
}