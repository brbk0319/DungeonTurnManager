using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonTurnManager;

class Program
{

    static Queue<Hero> heroQueue = new Queue<Hero>();
    static Stack<string> actionHistory = new Stack<string>();

    static void Main(string[] args)
    {
        Hero bob = new Hero("Bob", "Bard");
        Hero lily = new Hero("Lily", "Alchemist");
        Hero randalf = new Hero("Randalf", "Wizard");

        heroQueue.Enqueue(bob);
        heroQueue.Enqueue(lily);
        heroQueue.Enqueue(randalf);

        int rounds = 1;

        Console.WriteLine("~~~~~~ BATTLE IS BEGUN ~~~~~~");

        while (rounds <= 7)
        {
            Hero currentHero = heroQueue.Dequeue();
            Console.WriteLine($"\n{currentHero.Name}'s turn.");

            string log = currentHero.TakeTurn();
            actionHistory.Push(log);

            heroQueue.Enqueue(currentHero);

            Console.WriteLine("\nPress ENTER to continue, or type 'undo' to undo last action:");
            string answer = Console.ReadLine().ToLower();
            if (answer == "undo")
            {
                if (actionHistory.Count > 0)
                {
                    string lastAction = actionHistory.Pop();
                    Console.WriteLine($"Undoing: {lastAction}");
                }
                else
                {
                    Console.WriteLine("Nothing to undo :)");
                }
            }

            rounds++;
        }

        Console.WriteLine("\n~~~~~~ BATTLE COMPLETE ~~~~~~");
    }
}