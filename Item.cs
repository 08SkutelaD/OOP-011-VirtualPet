using System;

namespace OOP_011
{
    public class Item : IDisplay
    {
        public string itemName;
        public int itemCost;
        public PetStat positiveStat;
        public int positiveValue;
        public PetStat negativeStat;
        public int negativeValue;

        public Item(string itemName, int itemCost, PetStat positiveStat, int positiveValue, PetStat negativeStat, int negativeValue)
        {
            this.itemName = itemName;
            this.itemCost = itemCost;
            this.positiveStat = positiveStat;
            this.positiveValue = positiveValue;
            this.negativeStat = negativeStat;
            this.negativeValue = negativeValue;
        }

        public void Display()
        {
            Console.WriteLine(this.itemName + " (" + this.positiveStat.ToString() + " +" + this.positiveValue.ToString() + ", " + this.negativeStat.ToString() + " -" + this.negativeValue + ")");
        }
    }
}