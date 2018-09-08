using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class InventoryItem
    {
        //property
        public int Qty { get; set; } = 5;
        public VendingMachineItem Item { get; }

        //constructor
        public InventoryItem(VendingMachineItem item)
        {
            Item = item;
        }
    }
}
