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
            return _context.Characters;
        }

        public IEnumerable<Spell> GetCharactersSpells()
        {
            throw new NotImplementedException();
        }
        
        public void DeleteCharacter(int Id)
        {
            _context.Characters.Remove(_context.Characters.Find(Id));
            _context.SaveChanges();

        }
    }
}