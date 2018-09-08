using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using Capstone.CLI;

namespace Capstone
{
    public class Program
    {
       // C:\Workspace\team\team6-c-week4-pair-exercises\c#-capstone\etc\vendingmachine.csv
        static void Main(string[] args)
        {
            VendingMachine instance = new VendingMachine();
            
            MainMenu menu = new MainMenu(instance);
            menu.Display();
        }
    }
}
