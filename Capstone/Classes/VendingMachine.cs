using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //public SalesReport report = new SalesReport();
        
        
        public List<InventoryItem> Purchases { get; set; } = new List<InventoryItem>();
        
        
        //properties
        public Dictionary<string, InventoryItem> Inventory { get; } = new Dictionary<string, InventoryItem>();
        public decimal Money { get; private set; } = 0.0M;
            
                
        //method
        public void AddMoney(decimal amount)
        {
            string logPath = @"C:\Workspace\Team(git)\(4)team6-c-week4-pair-exercises(Dan)\c#-capstone\etc\Log.txt";
            Money += amount;
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine("{0, -25}{1, -15}{2, -20}{3, -10}", DateTime.Now, "Money Added:", amount.ToString("c"), Money.ToString("c"));
            }
        }

        public void Purchase(string desiredLocation)
        {
            InventoryItem tempItem = Inventory[desiredLocation];
            string logPath = @"C:\Workspace\Team(git)\(4)team6-c-week4-pair-exercises(Dan)\c#-capstone\etc\Log.txt";
            tempItem.Qty--;
            Money -= tempItem.Item.Price;
            Purchases.Add(tempItem);
            //Noise = Inventory[desiredLocation].Item.Noise;
            //Noises.Add(Noise);
            //itemsBought.Add(Inventory[desiredLocation].Item.ItemName, Inventory[desiredLocation].Item.Price);
            //itemsPurchased[Inventory[desiredLocation].Item.ItemName] = (5 - (Inventory[desiredLocation].Qty)).ToString();
            //itemsPurchased.Add((5 - (Inventory[desiredLocation].Qty)).ToString());
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine("{0, -25}{1, -15}{2, -20}{3, -10}", DateTime.Now, "Purchased:", Inventory[desiredLocation].Item.ItemName,
                                                                 Inventory[desiredLocation].Item.Price, Money.ToString("c"));
            }
        }

        public Change FinishTransaction()
        {
            Change change = new Change(Money);
            //report.GenerateReportFile(itemsBought, itemsPurchased);
            if (Money>0)
            { 
                string logPath = @"C:\Workspace\Team(git)\(4)team6-c-week4-pair-exercises(Dan)\c#-capstone\etc\Log.txt";
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine("{0, -25}{1, -15}{2, -20}", DateTime.Now, "Change Given:", Money.ToString("c"));
                }
            
            }
            Money = 0;
            return change;

        }   
        
        public void DisplayMenuItems()
        {
            foreach (KeyValuePair<string, InventoryItem> item in Inventory)
            {
                Console.WriteLine("{0, -5}{1, -20}{2, -8}", item.Key, item.Value.Item.ItemName, item.Value.Item.Price.ToString());
            }
        }
        
        
        public VendingMachine()
        {
            ReadFile();
        }

        private void ReadFile()
        {
            string fullPath = @"C:\Workspace\Team(git)\(4)team6-c-week4-pair-exercises(Dan)\c#-capstone\etc\vendingmachine.csv";

            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] pipeSplit = line.Split('|');
                    if (pipeSplit[3] == "Candy")
                    {
                        CandyItem candyItem = new CandyItem(pipeSplit[1], decimal.Parse(pipeSplit[2]), "Munch Munch, Yum!");
                        InventoryItem inventoryItem = new InventoryItem(candyItem);
                        Inventory.Add(pipeSplit[0], inventoryItem);
                    }
                    else if (pipeSplit[3] == "Chip")
                    {
                        ChipItem chipItem = new ChipItem(pipeSplit[1], decimal.Parse(pipeSplit[2]), "Crunch Crunch, Yum!");
                        InventoryItem inventoryItem = new InventoryItem(chipItem);
                        Inventory.Add(pipeSplit[0], inventoryItem);
                    }
                    else if (pipeSplit[3] == "Gum")
                    {
                        GumItem gumItem = new GumItem(pipeSplit[1], decimal.Parse(pipeSplit[2]), "Chew Chew, Yum!");
                        InventoryItem inventoryItem = new InventoryItem(gumItem);
                        Inventory.Add(pipeSplit[0], inventoryItem);
                    }
                    else if (pipeSplit[3] == "Drink")
                    {
                        BeverageItem beverageItem = new BeverageItem(pipeSplit[1], decimal.Parse(pipeSplit[2]), "Glug Glug, Yum!");
                        InventoryItem inventoryItem = new InventoryItem(beverageItem);
                        Inventory.Add(pipeSplit[0], inventoryItem);
                    }
                }
            }   
        }       
    }
}
