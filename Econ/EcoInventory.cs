using Econ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoInventory
{
    class Inventory
    {
        public int selectedSlot = 0;
        public int maxSlots = 30;
        public List<EconInventorySlot> Slots = new List<EconInventorySlot>(30); 

        public void selectSlot(int SlotIndex)
        {
            if (SlotIndex <= maxSlots)
            {
                Slots[SlotIndex].selected = true;
                selectedSlot = SlotIndex;
            }
        }

        public void addItem(EconGameItem GameItem)
        {
            EconInventorySlot EmptySlot = getNextFreeSlot();
            //EmptySlot.Slot = GameItem;
            EmptySlot.stackAmount = 1;
        }

        internal void addItem(EconGameItem GameItem, int Amount)
        {
            EconInventorySlot EmptySlot = getNextFreeSlot();
            //EmptySlot.Slot = GameItem;
            EmptySlot.stackAmount = Amount;
        }

        internal void addItem(int SlotIndex, EconGameItem GameItem)
        {
            EconInventorySlot Slot = Slots[SlotIndex];
            //Slot.Slot = GameItem;
            Slot.stackAmount = 1;
        }

        internal void addItem(int SlotIndex, EconGameItem GameItem, int Amount)
        {
            EconInventorySlot Slot = Slots[SlotIndex];
            //Slot.Slot = GameItem;
            Slot.stackAmount = Amount;
        }

        public EconInventorySlot getNextFreeSlot()
        {
            foreach (EconInventorySlot Slot in Slots)
            {
                if (Slot.Slot.Count == 0){ return Slot; }
            }
            return null;
        }
    }
}
