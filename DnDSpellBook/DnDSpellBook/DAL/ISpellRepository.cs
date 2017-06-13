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
        IEnumerable<SpellList> GetSpells(string selectedClass, string selectedLevel);
    }
}
