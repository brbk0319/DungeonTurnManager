using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTurnManager
{
    public class Hero
    {

        public string Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }

        public Hero() { }
        public Hero(string name, string heroClass)
        {
            Name = name;
            Class = heroClass;
        }

        public string TakeTurn()
        {
            int damage = new Random().Next(1,100);
            string action = $"{Name} the {Class} attacked! {damage} damage.";
            Console.WriteLine(action);
            return action;
        }
    }
}
