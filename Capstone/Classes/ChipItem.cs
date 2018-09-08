using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class ChipItem : VendingMachineItem
    {
        public ChipItem(string itemName, decimal price, string noise) : base(itemName, price, noise)
        {
            Noise = "Crunch Crunch, Yum!";
        }
        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
