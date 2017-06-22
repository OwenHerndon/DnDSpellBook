using DnDSpellBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellBook.DAL
{
    public interface ISpellRepository
    {
        void AddSpellToCharacter(int selectedCharacter, Spell characterSpell);

        IEnumerable<Result> GetSpells(string selectedClass, string selectedLevel);

        Spell GetSpellDetails(string spellurl);
    }
}
