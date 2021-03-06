﻿using DnDSpellBook.DAL;
using DnDSpellBook.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DnDSpellBook.Controllers
{
    public class SpellbookController : ApiController
    {
        readonly ISpellRepository _spellRepository;


        public SpellbookController(ISpellRepository spellRepository)
        {
            _spellRepository = spellRepository;
        }

        [Route("api/spells/{selectedClass}/{selectedLevel}")]
        public IEnumerable<Result> GetSpells(string selectedClass, string selectedLevel)
        {
            return _spellRepository.GetSpells(selectedClass, selectedLevel);
        }

        [Route("api/spells/")]
        public Spell GetSpellsDetails(string spellurl)
        {
            return _spellRepository.GetSpellDetails(spellurl);
        }


        [HttpPost, Route("api/spells/addspelltocharacter/{selectedCharacter}")]
        public void PostSpellToCharacter(int selectedCharacter, Spell spell)
        {
            _spellRepository.AddSpellToCharacter(selectedCharacter, spell);
        }

    }
}
