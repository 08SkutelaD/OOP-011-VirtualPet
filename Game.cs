using System;
using System.Collections.Generic;
using System.Threading;

namespace OOP_011
{
    public class Game : IUpdate, IDisplay
    {
        Inventory userInventory;
        Shop itemShop;
        List<Room> listOfRooms = new List<Room>{};
        private Room activeRoom;
        private int activeRoomIndex;
        private int coinsPerTurn;
        private int turnTimer;
        private bool gameRunning;

        public Game(Inventory inventory, Shop shop)
        {
            this.userInventory = inventory;
            this.itemShop = shop;
            this.coinsPerTurn = 1;
            this.turnTimer = 1000;
        }

        public void Run()
        {
            Console.CursorVisible = false;
            while(true)
            {
                MainMenu();
            }
        }

        public void Display()
        {
            activeRoom.Display();
            Console.WriteLine("Simulation Menu");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Use Item");
            Console.WriteLine("2) View Inventory");
            Console.WriteLine("3) Go Shopping");
            Console.WriteLine("4) Heat/Cool Room");
            Console.WriteLine("5) Exit Simulation");
            Console.WriteLine("---------------------------------");
        }

        public void Update()
        {
            userInventory.Update();
            activeRoom.Update();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Pet Simulator Main Menu");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Run Simulation");
            Console.WriteLine("2) Profile Information");
            Console.WriteLine("3) Settings");
            Console.WriteLine("4) Program Information");
            Console.WriteLine("5) Exit");
            Console.WriteLine("---------------------------------");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            switch(userChoice)
            {
                case ConsoleKey.D1:
                    RunSimulation();
                    break;
                case ConsoleKey.D2:
                    if(activeRoom == null)
                    {
                        Console.Clear();
                        Console.WriteLine("There is no current active room to display.");
                        Console.WriteLine("Please run the simulation, create a new room and try again.");
                    }
                    else
                    {
                        Display();
                        Console.WriteLine("Note: This is a snapshot of the current game state.");
                        Console.WriteLine("Please press any key to return to main menu.");
                        Console.WriteLine("---------------------------------");
                    }
                    Console.ReadKey(true);
                    break;
                case ConsoleKey.D3:
                    Settings();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("About Program");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("This program simulates a virtual pet.");
                    Console.WriteLine("The user is required to manage the pets condition.");
                    Console.WriteLine("Every game tick the user gains one coin which can be used to purchase items to look after the pet.");
                    Console.WriteLine("Coins per tick and tick rate can be changed in the settings.");
                    Console.WriteLine("Profile information displays the state of the current game.");
                    Console.WriteLine("Create a new game by choosing Run Simulation.");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Press any key to return.");
                    Console.ReadKey(true);
                    break;
                case ConsoleKey.D5:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void Settings()
        {
            bool editingSettings = true;
            while(editingSettings)
            {
                Console.Clear();
                Console.WriteLine("Settings");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1) Change Coins per Turn (Currently: " + coinsPerTurn + ")");
                Console.WriteLine("2) Change Turn Speed (Currently: " + turnTimer + " milliseconds)");
                Console.WriteLine("3) Return to Main Menu");
                Console.WriteLine("---------------------------------");
                ConsoleKey userChoice = Console.ReadKey(true).Key;
                switch(userChoice)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Settings");
                        Console.WriteLine("---------------------------------");
                        Console.Write("Enter new coins per turn:");
                        int newCoins;
                        int.TryParse(Console.ReadLine(), out newCoins);
                        this.coinsPerTurn = newCoins;
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Settings");
                        Console.WriteLine("---------------------------------");
                        Console.Write("Enter new turn speed: ");
                        int newSpeed;
                        int.TryParse(Console.ReadLine(), out newSpeed);
                        this.turnTimer = newSpeed;
                        break;
                    case ConsoleKey.D3:
                        editingSettings = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void RunSimulation()
        {
            gameRunning = true;
            SetupRoom();
            RoomSelection();
            while(gameRunning)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    switch(userChoice)
                    {
                        case ConsoleKey.D1:
                            UseItem();
                            break;
                        case ConsoleKey.D2:
                            userInventory.ViewInventory();
                            break;
                        case ConsoleKey.D3:
                            List<Item> shopping = itemShop.UseShop();
                            userInventory.UnpackShopping(shopping);
                            break;
                        case ConsoleKey.D4:
                            bool tempChange = activeRoom.ChangeTemperature();
                            if(tempChange == true)
                            {
                                userInventory.Coins -= 2;
                            }
                            break;
                        case ConsoleKey.D5:
                            gameRunning = false;
                            break;
                    }
                }
                else
                {
                    Update();
                    Display();
                    Thread.Sleep(turnTimer);
                }
            }
            listOfRooms[activeRoomIndex] = activeRoom;
        }

        public void RoomSelection()
        {
            bool selectingRoom = true;
            while(selectingRoom)
            {
                Console.Clear();
                if(listOfRooms.Count == 0)
                {
                    Console.WriteLine("No rooms found. Please create a room and try again.");
                    Console.WriteLine("Please press any key to continue.");
                    Console.ReadKey(true);
                    selectingRoom = false;
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Room Selection");
                    Console.WriteLine("---------------------------------");
                    int counter = 0;
                    foreach(Room r in listOfRooms)
                    {
                        counter++;
                        Console.WriteLine(counter + ") " + r.roomName);
                    }
                    Console.Write("Please enter the number of the room you would like to simulate: ");
                    int roomChoice = -1;
                    try
                    {
                        roomChoice = int.Parse(Console.ReadLine());
                        if(roomChoice <= listOfRooms.Count && roomChoice > 0)
                        {
                            activeRoom = listOfRooms[(roomChoice - 1)];
                            activeRoomIndex = (roomChoice - 1);
                            selectingRoom = false;
                        }
                        else
                        {
                            Console.WriteLine("Couldn't find that room. Please try again.");
                            Console.ReadKey(true);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Something went wrong: " + ex.Message);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey(true);
                    }    
                }
                
                
            }
        }
    
        public void SetupRoom()
        {
            Console.Clear();
            Console.WriteLine("Room Selection");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Create New Room");
            Console.WriteLine("2) Use Existing Room");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            switch(userChoice)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Room Creation");
                    Console.WriteLine("---------------------------------");
                    Console.Write("Enter Room Name: ");
                    string roomName = Console.ReadLine();
                    Console.Write("Enter Pet Name: ");
                    string petName = Console.ReadLine();
                    Console.WriteLine("Choose Pet Type:");
                    Console.WriteLine("1) Dog");
                    Console.WriteLine("2) Cat");
                    Console.WriteLine("3) Fish");
                    ConsoleKey petChoice = Console.ReadKey(true).Key;
                    Pet newPet;
                    switch(petChoice)
                    {
                        case ConsoleKey.D1:
                            newPet = new Dog(petName);
                            listOfRooms.Add(new Room(roomName, newPet));
                            break;
                        case ConsoleKey.D2:
                            newPet = new Cat(petName);
                            listOfRooms.Add(new Room(roomName, newPet));
                            break;
                        case ConsoleKey.D3:
                            newPet = new Fish(petName);
                            listOfRooms.Add(new Room(roomName, newPet));
                            break;
                        default:
                            break;
                    }
                    break;
                case ConsoleKey.D2:
                    break;
            }
        }

        public void UseItem()
        {
            Console.Clear();
            Console.WriteLine("Using Item");
            Console.WriteLine("---------------------------------");
            int counter = 0;
            foreach(Item i in userInventory.InventoryList)
            {
                counter++;
                Console.Write(counter + ") ");
                i.Display();
            }
            Console.WriteLine("---------------------------------");
            Console.Write("Please enter the number of the item you wish to use: ");
            int itemChoice;
            int.TryParse(Console.ReadLine(), out itemChoice);
            if(itemChoice <= userInventory.InventoryList.Count)
            {
                activeRoom.pet.UseItem(userInventory.InventoryList[(itemChoice - 1)]);
                userInventory.UseItem(userInventory.InventoryList[(itemChoice - 1)]);
            }
            else
            {
                Console.WriteLine("Couldn't find that item. Please try again.");
                Console.ReadKey(true);
            }
        }
    }
}