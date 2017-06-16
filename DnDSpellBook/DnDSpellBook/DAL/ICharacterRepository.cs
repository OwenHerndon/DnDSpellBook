using DnDSpellBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellBook.DAL
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetCharacters();

        IEnumerable<Spell> GetCharactersSpells();
    }
}
