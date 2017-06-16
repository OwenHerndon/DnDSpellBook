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
        readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository CharacterRepository)
        {
            _characterRepository = CharacterRepository;
        }

        [HttpGet, Route("api/characters")]
        public IEnumerable<Character> GetCharacters()
        {
            return _characterRepository.GetCharacters();
        }

        //gets spells list of selected character
        [HttpGet, Route("api/characters/spells")]
        public IEnumerable<Spell> GetSpells()
        {
            return _characterRepository.GetCharactersSpells();
        }

        [HttpDelete, Route("api/character/delete/{selectedCharacterId}")]
        public void DeleteCharacter(int selectedCharacterId)
        {
            _characterRepository.DeleteCharacter(selectedCharacterId);
        }
        
        //deletes spell from list

        //deletes character from db
    }
}
