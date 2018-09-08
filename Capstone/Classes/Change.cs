using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        
        public int ChangeQuarters { get; private set; } = 0;
        public int ChangeDimes { get; private set; } = 0;
        public int ChangeNickels { get; private set; } = 0;

        public Change (decimal amountInDollars)
        {
            int change = (int)(amountInDollars * 100);
            int quarters = 25;
            int dimes = 10;
            int nickels = 5;

            ChangeQuarters = change / quarters;
            ChangeDimes = ((change % quarters) / dimes);
            ChangeNickels = (((change % quarters) % dimes) / nickels);
        }
    }
}
