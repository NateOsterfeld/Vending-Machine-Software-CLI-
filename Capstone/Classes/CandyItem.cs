﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class CandyItem : VendingMachineItem
    {
        public CandyItem(string itemName, decimal price, string noise):base(itemName, price, noise)
        {
            Noise = "Munch Munch, Yum!";
        }
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
