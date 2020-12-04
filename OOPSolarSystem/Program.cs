using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace OOPSolarSystem
{
    class Program
    {
        public class Item
        {
            string name;
            int mass;

            public Item(string _name, int _mass)
            {
                name = _name;
                mass = _mass;
            }

            public string Name { get { return name; } }

            public int Mass { get { return mass; } }
        }

        public static void WriteInnerPlanetList()
        {
            List<string> innerPlanetList = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter inner planet: ");
                string planet = Console.ReadLine();
                Console.WriteLine("Enter planet mass: ");
                string mass = Console.ReadLine();

                string line = $"{planet}${mass}";
                innerPlanetList.Add(line);

                string filePath = @"C:\Users\opilane\Samples";
                string fileName = @"innerPlanets.txt";
                File.WriteAllLines(Path.Combine(filePath, fileName), innerPlanetList);

            }
        }

        public static void WriteOuterPlanetList()
        {
            List<string> outerPlanetList = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter outer planet: ");
                string planet = Console.ReadLine();
                Console.WriteLine("Enter planet mass: ");
                string mass = Console.ReadLine();

                string line = $"{planet}${mass}";
                outerPlanetList.Add(line);

                string filePath = @"C:\Users\opilane\Samples";
                string fileName = @"outerPlanets.txt";
                File.WriteAllLines(Path.Combine(filePath, fileName), outerPlanetList);

            }
        }

        static void Main(string[] args)
        {
            WriteInnerPlanetList();
            WriteOuterPlanetList();
            int total = ReadFromInnerPlanetList() + ReadFromOuterPlanetList();
            Console.WriteLine($"Total mass of planets: {total}");
        }

        public static int ReadFromInnerPlanetList()
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"innerPlanets.txt";

            List<Item> innerPlanets = new List<Item>();

            List<string> linesFromFile = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();

            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                Item newItem = new Item(tempArray[0], Int32.Parse(tempArray[1]));
                innerPlanets.Add(newItem);
            }

            int totalInner = 0;

            foreach (Item item in innerPlanets)
            {
                Console.WriteLine($"Planet: {item.Name}\n Mass: {item.Mass}");
                totalInner += item.Mass;
            }

            Console.WriteLine($"Total mass of inner planets: {totalInner}");
            return totalInner;
        }

        public static int ReadFromOuterPlanetList()
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"outerPlanets.txt";

            List<Item> outerPlanets = new List<Item>();

            List<string> linesFromFile = File.ReadAllLines(Path.Combine(filePath, fileName)).ToList();

            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                Item newItem = new Item(tempArray[0], Int32.Parse(tempArray[1]));
                outerPlanets.Add(newItem);
            }

            int totalOuter = 0;

            foreach (Item item in outerPlanets)
            {
                Console.WriteLine($"Planet: {item.Name}\n Mass: {item.Mass}");
                totalOuter += item.Mass;
            }

            Console.WriteLine($"Total mass of outer planets: {totalOuter}");
            return totalOuter;
        }
    }
}
