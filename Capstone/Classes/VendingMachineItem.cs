using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        //properties
        public string ItemName { get; }
        public decimal Price { get; }
        public string Noise { get; set; }

        ////methods
        public abstract string Consume();

        //constructor
        public VendingMachineItem(string itemName, decimal price, string noise)
        {
            Price = price;
            ItemName = itemName;
            Noise = noise;
        }    
    }
}
