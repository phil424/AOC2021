using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day2Puzzle1
    {
        string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay2.txt");
        int horizontalPos = 0;
        int depth = 0;

        public Day2Puzzle1()
        {
            int[] forward = rawInput.Where(y => y.Contains("forward")).Select(x => Convert.ToInt32(x.Replace("forward ", ""))).ToArray();
            int[] up = rawInput.Where(y => y.Contains("up")).Select(x => Convert.ToInt32(x.Replace("up ", ""))).ToArray();
            int[] down = rawInput.Where(y => y.Contains("down")).Select(x => Convert.ToInt32(x.Replace("down ", ""))).ToArray();

            horizontalPos = forward.Sum();
            depth = down.Sum() - up.Sum();
            Console.WriteLine($"Horizontal Pos = {horizontalPos}");
            Console.WriteLine($"Depth = {depth}");
            Console.WriteLine($"{horizontalPos * depth}");
        }
        // public Day2Puzzle1()
        // {
        //     Console.WriteLine($"{rawInput.Where(y => y.Contains("forward")).Select(x => Convert.ToInt32(x.Replace("forward ", ""))).ToArray().Sum() * (rawInput.Where(y => y.Contains("down")).Select(x => Convert.ToInt32(x.Replace("down ", ""))).ToArray().Sum() - rawInput.Where(y => y.Contains("up")).Select(x => Convert.ToInt32(x.Replace("up ", ""))).ToArray().Sum())}");
        // }
    }
    class Day2Puzzle2
    {
        string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay2.txt");
        int horizontalPos = 0;
        int depth = 0;
        int aim = 0;
        public Day2Puzzle2()
        {
            foreach (string line in rawInput)
            {
                string[] currentLog = line.Split(" ");
                string action = currentLog[0];
                int value = Convert.ToInt32(currentLog[1]);

                switch (action)
                {
                    case("forward"):
                        horizontalPos += value;
                        if(aim > 0)
                        {
                            depth += value * aim;
                        }
                        break;
                    case("up"):
                        aim -= value;
                        break;
                    case("down"):
                        aim += value;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Horizontal Pos = {horizontalPos}");
            Console.WriteLine($"Depth = {depth}");
            Console.WriteLine($"{horizontalPos * depth}");
        }
    }
}