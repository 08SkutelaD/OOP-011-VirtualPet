using System;

namespace OOP_011
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Inventory inventory = new Inventory();
            Game game = new Game(inventory, shop);
            game.Run();
        }
    }
}
