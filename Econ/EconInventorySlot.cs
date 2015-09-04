using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econ
{
    class EconInventorySlot
    {
        public bool selected = false;
        public List<EconGameItem> Slot = new List<EconGameItem>(1);
        public int stackAmount = 0;
    }
}
