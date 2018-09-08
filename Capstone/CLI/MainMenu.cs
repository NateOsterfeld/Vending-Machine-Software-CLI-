using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.CLI
{
    public class MainMenu
    {
        public VendingMachine _vm = null;
                
        //constructor
        public MainMenu(VendingMachine vendingMachine)
        {
            _vm = vendingMachine;
        }
        // methods
        public void Display()
        {
            char input = ' ';
            while (input != 'q')
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Vendo-Matic 500!");
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("\n(1)\tDisplay Vending Machine Items\n(2)\tPurchase\n(Q)\tQuit");
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    DisplayInventory();
                    Console.ReadKey();
                }
                else if (input == '2')
                {
                    PurchaseMenu();
                }
            }
        }
        #region DisplayInventory
        private void DisplayInventory()
        {
            char input = ' ';
            while (input != 'b')
            {
                Console.Clear();
                _vm.DisplayMenuItems();
                Console.WriteLine("Press B to return to Main Menu");
                input = Console.ReadKey().KeyChar;                
            }
        }
        #endregion
        #region PurchaseMenu
        private void PurchaseMenu()
        {
            bool timeToExit = false;
            while (!timeToExit)
            {
                Console.Clear();
                Console.WriteLine("\n(1)\tFeed Money\n(2)\tSelect Product\n(3)\tFinish Transaction");
                Console.WriteLine($"{_vm.Money.ToString("c")}");
                char secondInput = Console.ReadKey().KeyChar;

                if (secondInput == '1')
                {
                    FeedMoney();
                }
                else if (secondInput == '2')
                {
                    Console.Clear();
                    string desiredLocation = "";
                    Console.WriteLine("Please enter the location of the item you want to purchase");
                    _vm.DisplayMenuItems();
                    Console.WriteLine();
                    Console.WriteLine("Or press any key to return...");
                    desiredLocation = Console.ReadLine().ToUpper();
                    if (!_vm.Inventory.ContainsKey(desiredLocation))
                    {
                        Console.WriteLine("That item slot does not exist please try again..");
                    }
                    else if (_vm.Inventory.ContainsKey(desiredLocation))
                    {
                        if ((_vm.Money < _vm.Inventory[desiredLocation].Item.Price) || (_vm.Inventory[desiredLocation].Qty==0))
                        {
                            Console.WriteLine("Not enough money, or product is sold out.");
                            Console.ReadKey();
                        }
                        else
                        {
                            string selectedProduct = _vm.Inventory[desiredLocation].Item.ItemName + " " +
                                                     _vm.Inventory[desiredLocation].Item.Price.ToString("c");
                            _vm.Purchase(desiredLocation);
                            Console.WriteLine();
                            Console.WriteLine($"You purchased {selectedProduct}.");
                            Console.WriteLine("Press any key to return.");
                            Console.ReadKey();                            
                        }
                    }
                }
                else if (secondInput == '3')
                {
                    Console.Clear();
                    Console.WriteLine($"Your change is {_vm.Money.ToString("c")}");
                    Change change = _vm.FinishTransaction();                    
                    Console.WriteLine($"Quarters: {change.ChangeQuarters}");
                    Console.WriteLine($"Dimes: {change.ChangeDimes}");
                    Console.WriteLine($"Nickels: {change.ChangeNickels}");
                    foreach(var item in _vm.Purchases)
                    {
                        Console.WriteLine(item.Item.Consume());
                    }
                    _vm.Purchases.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to main menu..");
                    Console.ReadKey();
                    Display();                                    
                }
            }
        }
        #endregion
        #region FeedMoney
        private void FeedMoney()
        {
            char input = ' ';
            while (input != 'f')
            {
                Console.Clear();
                Console.WriteLine("Please enter your money");
                Console.WriteLine("1) $1");
                Console.WriteLine("2) $2");
                Console.WriteLine("3) $5");
                Console.WriteLine("4) $10");
                Console.WriteLine("f) Finish");

                Console.WriteLine($"Current money provided: {_vm.Money.ToString("c")}");
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {   
                    _vm.AddMoney(1.0M);
                }
                else if (input == '2')
                {   
                    _vm.AddMoney(2.0M);
                }
                else if (input == '3')
                {   
                    _vm.AddMoney(5.0M);
                }
                if (input == '4')
                {   
                    _vm.AddMoney(10.0M);
                }                
            }
        }
        #endregion
    }
}
