using System;
using System.Collections.Generic;

namespace OOP_011
{
    public class Fish : Pet
    {
        public Fish(string name) : base(name)
        {
            this.tempMax = 25m;
            this.tempMin = 15m;
            this.compatableItems = new List<string>{"Log", "Coral"};
            this.species = "Fish";
        }
    }
}