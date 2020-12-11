using System;

namespace OOP_011
{
    public class Room : IUpdate, IDisplay
    {
        public string roomName;
        public Pet pet;
        private decimal currentTemp;
        private decimal ambientTemp;

        public Room(string roomName, Pet pet)
        {
            this.roomName = roomName;
            this.pet = pet;
            currentTemp = 24m;
            ambientTemp = 5m;
        }

        public void Update()
        {
            if(currentTemp > ambientTemp)
            {
                currentTemp -= 1m;
            }
            else if(currentTemp < ambientTemp)
            {
                currentTemp += 1m;
            }

            pet.Update(currentTemp);
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Simulating (Room: " + roomName + ")");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Current Room Temperature: " + currentTemp);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pet Stats:");
            pet.Display();
            Console.WriteLine("---------------------------------");
        }

        private void HeatRoom()
        {
            currentTemp += 5m;
        }
        
        private void CoolRoom()
        {
            currentTemp -= 5m;
        }

        public bool ChangeTemperature()
        {
            Console.Clear();
            Console.WriteLine("Temperature Settings");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1) Heat Room");
            Console.WriteLine("2) Cool Room");
            Console.WriteLine("3) Cancel");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("NOTE: Heating or Cooling a room changes it by 5 degrees and costs 2 coins.");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            switch(userChoice)
            {
                case ConsoleKey.D1:
                    HeatRoom();
                    return true;
                case ConsoleKey.D2:
                    CoolRoom();
                    return true;
                case ConsoleKey.D3:
                    return false;;
                default:
                    return false;
            }
        }
    }
}