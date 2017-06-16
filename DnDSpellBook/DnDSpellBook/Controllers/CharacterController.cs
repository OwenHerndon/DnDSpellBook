using DnDSpellBook.DAL;
using DnDSpellBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DnDSpellBook.Controllers
{
    public class CharacterController : ApiController
    {
        //gets list of characters of logged in user
        readonly ICharacterRepository _CharacterRepository;

        //public CharacterController()
        //{
        //    _CharacterRepository = new CharacterRepository();
        //}

        public CharacterController(ICharacterRepository CharacterRepository)
        {
            _CharacterRepository = CharacterRepository;
        }

        [HttpGet, Route("api/characters")]
        public IEnumerable<Character> GetCharacters()
        {
            return _CharacterRepository.GetCharacters();
        }

        //gets spells list of selected character
        [HttpGet, Route("api/characters/spells")]
        public IEnumerable<Spell> GetSpells()
        {
            return _CharacterRepository.GetCharactersSpells();
        }
        
        //deletes spell from list

        //deletes character from db
    }
}
