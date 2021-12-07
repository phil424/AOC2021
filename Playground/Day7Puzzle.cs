using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day7Puzzle1
    {
        List<int> crabList = Array.ConvertAll(File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay7.txt")[0].Split(","), int.Parse).ToList();
        public Day7Puzzle1()
        {
            int maxPos = crabList.Max(t => t);
            int lowestFuelCost = 0;
            for (int horzontalPos = 0; horzontalPos < maxPos; horzontalPos++)
            {
                int fuelCost = 0;
                foreach (var crab in crabList)
                {
                    if(crab < horzontalPos)
                    {
                        fuelCost += (horzontalPos - crab);
                    }
                    else
                    {
                        fuelCost += (crab - horzontalPos);
                    }
                }

                if(lowestFuelCost == 0)
                {
                    lowestFuelCost = fuelCost;
                }
                else if(lowestFuelCost > fuelCost)
                {
                    lowestFuelCost = fuelCost;
                }
                Console.WriteLine($"Lowest Fuel Cost = {lowestFuelCost}");
            }
        }
    }
    class Day7Puzzle2
    {
        List<int> crabList = Array.ConvertAll(File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay7.txt")[0].Split(","), int.Parse).ToList();
        public Day7Puzzle2()
        {
            int maxPos = crabList.Max(t => t);
            int lowestFuelCost = 0;
            for (int horzontalPos = 0; horzontalPos < maxPos; horzontalPos++)
            {
                int fuelCost = 0;
                foreach (var crab in crabList)
                {
                    if(crab < horzontalPos)
                    {
                        fuelCost += sumOf(horzontalPos - crab);
                    }
                    else
                    {
                        fuelCost += sumOf(crab - horzontalPos);
                    }
                }

                if(lowestFuelCost == 0)
                {
                    lowestFuelCost = fuelCost;
                }
                else if(lowestFuelCost > fuelCost)
                {
                    lowestFuelCost = fuelCost;
                }
            }
            Console.WriteLine($"Lowest Fuel Cost = {lowestFuelCost}");
        }
        private int sumOf(int n)
        {
            int result = 0;

            for (int x = 0; x <= n; x++)
            {
                result += x;
            }

            return result;
        }
    }
}