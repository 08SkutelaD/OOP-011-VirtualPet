using System;
using System.Collections.Generic;

namespace OOP_011
{
    public class Inventory : IUpdate, IDisplay, IUseItem
    {
        private List<Item> listOfItems;
        private int coins;

        public List<Item> InventoryList
        {
            get { return listOfItems; }
        }
        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }
        
        public Inventory()
        {
            this.coins = 0;
            this.listOfItems = new List<Item>{};
        }

        public void Update()
        {
            coins += 1;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Inventory");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Coins: " + Coins);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Items:");
            foreach(Item i in listOfItems)
            {
                i.Display();
            }
            Console.WriteLine("---------------------------------");
        }

        public void UseItem(Item item)
        {
            listOfItems.Remove(item);
        }

        public void UnpackShopping(List<Item> shopping)
        {
            foreach(Item i in shopping)
            {
                if(i.itemCost > coins)
                {
                    Console.WriteLine(i.itemName + " could not be purchased due to lack of coins.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey(true);
                }
                else
                {
                    listOfItems.Add(i);
                    coins -= i.itemCost; 
                }
                
            }
        }

        public void ViewInventory()
        {
            Display();
            Console.WriteLine("Press any key to return.");
            Console.ReadKey(true);
        }
    }
}