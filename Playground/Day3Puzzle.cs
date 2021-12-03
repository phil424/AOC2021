using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day3Puzzle1
    {
        string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay3.txt");
        string gammaRate = "";
        string epsilonRate = "";

        public Day3Puzzle1()
        {
            for (int i = 0; i < rawInput.FirstOrDefault().Length; i++)
            {
                int counter = 0;
                foreach (var item in rawInput)
                {
                    counter += Convert.ToInt32(Char.GetNumericValue(item[i]));
                }
                IEnumerable<char> gamma = counter > rawInput.Length / 2 ? gammaRate += "1" : gammaRate += "0";
                IEnumerable<char> epsilon = counter > rawInput.Length / 2 ? epsilonRate += "0" : epsilonRate += "1";
            }
            Console.WriteLine($"Power Consumption = {Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)}");
        }
    }

    class Day3Puzzle2
    {
        string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay3.txt");

        public Day3Puzzle2()
        {
            List<string> oxygenGeneratorRating = rawInput.ToList();
            List<string> co2ScrubberRating = rawInput.ToList();

            for (int i = 0; i < rawInput.FirstOrDefault().Length; i++)
            {
                List<string> o2zeroList = new();
                List<string> o2oneList = new();
                List<string> co2zeroList = new();
                List<string> co2oneList = new();

                foreach (var item in oxygenGeneratorRating)
                {
                    if(item[i] == '1') o2oneList.Add(item); else o2zeroList.Add(item);
                }

                foreach (var item in co2ScrubberRating)
                {
                    if(item[i] == '1') co2oneList.Add(item); else co2zeroList.Add(item);
                }

                if(oxygenGeneratorRating.Count > 1)
                {
                    if(o2oneList.Count >= o2zeroList.Count)
                    {
                        oxygenGeneratorRating.RemoveAll(x => x[i] != o2oneList.FirstOrDefault()[i]);
                    }
                    else
                    {
                        oxygenGeneratorRating.RemoveAll(x => x[i] != o2zeroList.FirstOrDefault()[i]);
                    }
                }

                if(co2ScrubberRating.Count > 1)
                {
                    if(co2zeroList.Count <= co2oneList.Count)
                    {
                        co2ScrubberRating.RemoveAll(x => x[i] != co2zeroList.FirstOrDefault()[i]);
                    }
                    else
                    {
                        co2ScrubberRating.RemoveAll(x => x[i] != co2oneList.FirstOrDefault()[i]);
                    }
                }
            }
            Console.WriteLine($"Life Support = {Convert.ToInt32(oxygenGeneratorRating.First(), 2) * Convert.ToInt32(co2ScrubberRating.First(), 2)}");
        }
    }
}