using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class GumItem : VendingMachineItem
    {
        public GumItem(string itemName, decimal price, string noise) : base(itemName, price, noise)
        {
            Noise = "Chew Chew, Yum!";
        }
        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }
    }
}
