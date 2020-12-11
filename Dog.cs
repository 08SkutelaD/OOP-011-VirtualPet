using System;
using System.Collections.Generic;

namespace OOP_011
{
    public class Dog : Pet
    {
        public Dog(string name) : base(name)
        {
            this.tempMax = 30m;
            this.tempMin = 10m;
            this.compatableItems = new List<string>{"Ball", "Rope"};
            this.species = "Dog";
        }
    }
}