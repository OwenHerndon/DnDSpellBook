using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDSpellBook.Models;

namespace DnDSpellBook.DAL
{
    public class CharacterRepository : ICharacterRepository
    {
        readonly ApplicationDbContext _context;

        public CharacterRepository(ApplicationDbContext connection)
        {
            _context = connection;
        }

        public IEnumerable<Character> GetCharacters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Spell> GetCharactersSpells()
        {
            throw new NotImplementedException();
        }
    }
}