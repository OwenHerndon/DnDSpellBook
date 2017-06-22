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
        [HttpGet, Route("api/characters/spells/{selectedCharacterId}")]
        public IEnumerable<Spell> GetSpells(int selectedCharacterId)
        {
            return _characterRepository.GetCharactersSpells(selectedCharacterId);
        }

        [HttpDelete, Route("api/character/delete/{selectedCharacterId}")]
        public void DeleteCharacter(int selectedCharacterId)
        {
            _characterRepository.DeleteCharacter(selectedCharacterId);
        }
        
        [HttpDelete, Route("api/character/spell/delete/{spellName}/{characterId}")]
        public void DeleteSpell(string spellName, int characterId)
        {
            _characterRepository.DeleteSpell(spellName, characterId);
        }
        //deletes spell from list

        //deletes character from db
    }
}
