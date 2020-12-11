using System;
using System.Collections.Generic;

namespace OOP_011
{
    public class Shop : IUpdate, IDisplay
    {
        private List<Item> stockList;
        private List<Item> shoppingCart;

        public Shop()
        {
            stockList = new List<Item>{};
            shoppingCart = new List<Item>{};
            stockList.Add(new Item("Standard Food", 5, PetStat.Hunger, 10, PetStat.Mood, 5));
            stockList.Add(new Item("Premium Food", 10, PetStat.Hunger, 20, PetStat.Mood, 10));
            stockList.Add(new Item("Standard Medicine", 5, PetStat.Health, 10, PetStat.Hunger, 5));
            stockList.Add(new Item("Premium Medicine", 10, PetStat.Health, 20, PetStat.Hunger, 10));
            stockList.Add(new Item("Ball", 5, PetStat.Mood, 10, PetStat.Hunger, 5));
            stockList.Add(new Item("Rope", 10, PetStat.Mood, 20, PetStat.Hunger, 10));
            stockList.Add(new Item("Toy Mouse", 5, PetStat.Mood, 10, PetStat.Hunger, 5));
            stockList.Add(new Item("Laser Pointer", 10, PetStat.Mood, 20, PetStat.Hunger, 10));
            stockList.Add(new Item("Log", 5, PetStat.Mood, 10, PetStat.Hunger, 5));
            stockList.Add(new Item("Coral", 10, PetStat.Mood, 20, PetStat.Hunger, 10));
        }

        public void Update()
        {
            
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Shop!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Numbers 1 - 0: Select Items, Escape: Exit, Delete: Clear Basket, Enter: Purchase Basket");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Stock List:");
            int counter = 0;
            foreach(Item i in stockList)
            {
                counter++;
                if(counter == 10)
                {
                    counter = 0;
                }
                Console.Write(counter + ") ");
                i.Display();
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Shopping Basket");
            Console.WriteLine("---------------------------------");
            int totalCost = 0;
            foreach(Item i in shoppingCart)
            {
                totalCost += i.itemCost;
                i.Display();
            }
            Console.WriteLine("Total Cost: " + totalCost);
            Console.WriteLine("---------------------------------");
        }
        
        public List<Item> UseShop()
        {
            shoppingCart.Clear();
            bool shopping = true;
            while(shopping)
            {
                Display();
                ConsoleKey userChoice = Console.ReadKey(true).Key;
                switch(userChoice)
                {
                    case ConsoleKey.D1:
                        shoppingCart.Add(stockList[0]);
                        break;
                    case ConsoleKey.D2:
                        shoppingCart.Add(stockList[1]);
                        break;
                    case ConsoleKey.D3:
                        shoppingCart.Add(stockList[2]);
                        break;
                    case ConsoleKey.D4:
                        shoppingCart.Add(stockList[3]);
                        break;
                    case ConsoleKey.D5:
                        shoppingCart.Add(stockList[4]);
                        break;
                    case ConsoleKey.D6:
                        shoppingCart.Add(stockList[5]);
                        break;
                    case ConsoleKey.D7:
                        shoppingCart.Add(stockList[6]);
                        break;
                    case ConsoleKey.D8:
                        shoppingCart.Add(stockList[7]);
                        break;
                    case ConsoleKey.D9:
                        shoppingCart.Add(stockList[8]);
                        break;
                    case ConsoleKey.D0:
                        shoppingCart.Add(stockList[9]);
                        break;
                    case ConsoleKey.Enter:
                        shopping = false;
                        break;
                    case ConsoleKey.Delete:
                        shoppingCart.Clear();
                        break;
                    case ConsoleKey.Escape:
                        shoppingCart.Clear();
                        shopping = false;
                        break;
                    default:
                        break;
                }

            }
            return shoppingCart;
        }
    }
}