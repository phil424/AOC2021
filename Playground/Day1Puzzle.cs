using System;
using System.IO;

namespace Playground
{
    class Day1Puzzle1
    {
        private int _counter = 0;
        public Day1Puzzle1()
        {
            string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay1.txt");
            int? lastNum = null;

            foreach (string item in rawInput)
            {
                int currentNum = Convert.ToInt32(item);

                if(lastNum is null)
                {
                    lastNum = currentNum;
                    continue;
                }

                if(currentNum > lastNum)
                {
                    _counter++;
                }

                lastNum = currentNum;
            }

            Console.WriteLine(_counter);
        }
    }

    class Day1Puzzle2
    {
        private int _counter = 0;
        public Day1Puzzle2()
        {
            string[] rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay1.txt");
            int? lastSum = null;

            for (int i = 0; i < rawInput.Length - 2; i++)
            {
                int A = Convert.ToInt32(rawInput[i]);
                int B = Convert.ToInt32(rawInput[i+1]);
                int C = Convert.ToInt32(rawInput[i+2]);

                int currentSum = A + B + C;

                if(lastSum is null)
                {
                    lastSum = currentSum;
                    continue;
                }

                if(currentSum > lastSum)
                {
                    _counter++;
                }

                lastSum = currentSum;
            }

            Console.WriteLine(_counter);
        }
    }
}