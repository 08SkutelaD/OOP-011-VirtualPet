using System;
using System.Collections.Generic;

namespace OOP_011
{
    public abstract class Pet : IUpdate, IDisplay, IUseItem
    {
        protected string name;
        protected int health;
        protected int hunger;
        protected int mood;
        private bool isSick;
        private bool isHot;
        private bool isCold;
        protected decimal tempMin;
        protected decimal tempMax;
        protected List<string> compatableItems;
        public string species;

        public string Name
        {
            get { return this.name; }
        }
        public int Health
        {
            get { return this.health; }
        }
        public int Hunger
        {
            get { return this.hunger; }
        }
        public int Mood
        {
            get { return this.mood; }
        }
        public string IsSick
        {
            get
            {
                if(this.isSick == true)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }
        public string IsHot
        {
            get
            {
                if(this.isHot == true)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }
        public string IsCold
        {
            get
            {
                if(this.isCold == true)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }

        public Pet(string name)
        {
            this.name = name;
            this.health = 100;
            this.hunger = 100;
            this.mood = 100;
            this.isSick = false;
            this.isHot = false;
            this.isCold = false;
        }

        public void Update()
        {
            
        }
        public void Update(decimal roomTemp)
        {
            Random random = new Random();
            
            this.hunger -= 1;
            this.mood -= 1;

            int chance = 0;
            if(hunger < 50)
            {
                // 5% chance;
                chance = random.Next(1,21);
                if(chance == 20)
                {
                    this.isSick = true;
                }
            }
            else if(hunger < 25)
            {
                // 20% chance.
                chance = random.Next(1,5);
                if(chance == 5)
                {
                    this.isSick = true;
                }
            }
            else if(hunger < 10)
            {
                // 50% chance.
                chance = random.Next(1,3);
                if(chance == 2)
                {
                    this.isSick = true;
                }
            }

            if(this.tempMin <= roomTemp && roomTemp <= this.tempMax)
            {
                isCold = false;
                isHot = false;
            }
            else if(this.tempMax < roomTemp)
            {
                isCold = false;
                isHot = true;
            }
            else if(this.tempMin > roomTemp)
            {
                isCold = true;
                isHot = false;
            }

            if(roomTemp > this.tempMax)
            {
                chance = random.Next(1,5);
                if(chance == 5)
                {
                    this.isSick = true;
                }
            }
            else if(roomTemp < this.tempMin)
            {
                chance = random.Next(1,5);
                if(chance == 5)
                {
                    this.isSick = true;
                }
            }

            if(isSick)
            {
                this.health -= 1;
            }

            CheckValues();
        }

        public void Display()
        {
            Console.WriteLine(Name + " (" + species + ")");
            Console.WriteLine("Health: " + Health + ", Hunger: " + Hunger + ", Mood: " + Mood);
            Console.WriteLine("Is Hot? " + IsHot + ", Is Cold? " + IsCold + ", Is Sick? " + IsSick);
        }

        public void UseItem(Item item)
        {
            switch(item.positiveStat)
            {
                case PetStat.Health:
                    this.health += item.positiveValue;
                    break;
                case PetStat.Hunger:
                    this.hunger += item.positiveValue;
                    break;
                case PetStat.Mood:
                    this.mood += item.positiveValue;
                    break;
            }
            switch(item.negativeStat)
            {
                case PetStat.Health:
                    this.health -= item.negativeValue;
                    break;
                case PetStat.Hunger:
                    this.hunger -= item.negativeValue;
                    break;
                case PetStat.Mood:
                    this.mood -= item.negativeValue;
                    break;
            }
        }

        public void CheckValues()
        {
            if(this.health > 100)
            {
                this.health = 100;
            }
            if(this.health < 0)
            {
                this.health = 0;
            }

            if(this.hunger > 100)
            {
                this.hunger = 100;
            }
            if(this.hunger < 0)
            {
                this.hunger = 0;
            }

            if(this.mood > 100)
            {
                this.mood = 100;
            }
            if(this.mood < 0)
            {
                this.mood = 0;
            }
        }
    }
}