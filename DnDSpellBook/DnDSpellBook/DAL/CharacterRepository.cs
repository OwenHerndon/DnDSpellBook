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

        public IEnumerable<Spell> GetCharactersSpells(int Id)
        {
            //returns all spells
            //return _context.Spells;

            //returns null spells
            //var character = _context.Characters.Find(Id);
            //return character.Spells;

            return _context.Spells.Where(x => x.Character_Id == Id);

            //var spell = dataContext.dbset.Where(x => x.CustomerID == your_key).FirstOrDefault();
            //var spells = _context.Characters.Include(c => c.Spells).Where(x => x.Character_Id == Id).FirstOrDefault(); ;
            //return spells;

            //var characerSpells = _context.Characters.First(s => s.Id == Id);
            //Spell spellList = characerSpells.Spells.Character_Id;
        }
        
        public void DeleteCharacter(int Id)
        {
            _context.Characters.Remove(_context.Characters.Find(Id));
            _context.SaveChanges();

        }
    }
}