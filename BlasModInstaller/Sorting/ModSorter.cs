using BlasModInstaller.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlasModInstaller.Sorting
{
    internal class ModSorter : ISorter
    {
        private readonly IEnumerable<Mod> _mods;

        public ModSorter(IEnumerable<Mod> mods)
        {
            _mods = mods;
        }

        public void Sort()
        {

        }
    }
}
