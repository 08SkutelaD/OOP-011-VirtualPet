using System;
using System.Collections.Generic;

namespace OOP_011
{
    public class Cat : Pet
    {
        public Cat(string name) : base(name)
        {
            this.tempMax = 30m;
            this.tempMin = 10m;
            this.compatableItems = new List<string>{"Laser Pointer", "Toy Mouse"};
            this.species = "Cat";
        }
    }
}