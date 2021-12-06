using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day6Puzzle1
    {
        List<int> fishList = Array.ConvertAll(File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay6.txt")[0].Split(","), int.Parse).ToList();
        public Day6Puzzle1()
        {
            int dayCounter = 0;
            while (dayCounter < 80)
            {
                List<int> newFishList = new(fishList);
                int fishIndex = 0;
                int newFishCounter = 0;
                foreach (int fishTimer in fishList)
                {
                    if(fishTimer == 0)
                    {
                        newFishList[fishIndex] = 6;
                        newFishCounter++;
                    }
                    else
                    {
                        newFishList[fishIndex]--;
                    }
                    fishIndex++;
                }
                for (int i = 1; i <= newFishCounter; i++)
                {
                    newFishList.Add(8);
                }
                fishList = new(newFishList);
                dayCounter++;
            }
            Console.WriteLine(fishList.Count);
        }
    }

    class Day6Puzzle2
    {
        List<int> fishList = Array.ConvertAll(File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay6.txt")[0].Split(","), int.Parse).ToList();
        public Day6Puzzle2()
        {
            Dictionary<string, long> fishGroups = new() {
                {"Day0", 0},
                {"Day1", 0},
                {"Day2", 0},
                {"Day3", 0},
                {"Day4", 0},
                {"Day5", 0},
                {"Day6", 0},
                {"Day7", 0},
                {"Day8", 0},
                {"Day9", 0},
            };

            foreach (int fishTimer in fishList)
            {
                switch (fishTimer)
                {
                    case(0):
                        fishGroups["Day0"]++;
                        break;
                    case(1):
                        fishGroups["Day1"]++;
                        break;
                    case(2):
                        fishGroups["Day2"]++;
                        break;
                    case(3):
                        fishGroups["Day3"]++;
                        break;
                    case(4):
                        fishGroups["Day4"]++;
                        break;
                    case(5):
                        fishGroups["Day5"]++;
                        break;
                    case(6):
                        fishGroups["Day6"]++;
                        break;
                    case(7):
                        fishGroups["Day7"]++;
                        break;
                    case(8):
                        fishGroups["Day8"]++;
                        break;
                }
            }

            for (int day = 1; day <= 256; day++)
            {
                for (int groupIndex = 0; groupIndex < fishGroups.Count; groupIndex++)
                {
                    fishGroups["Day9"] = fishGroups["Day0"];
                    fishGroups["Day0"] = fishGroups["Day1"];
                    fishGroups["Day1"] = fishGroups["Day2"];
                    fishGroups["Day2"] = fishGroups["Day3"];
                    fishGroups["Day3"] = fishGroups["Day4"];
                    fishGroups["Day4"] = fishGroups["Day5"];
                    fishGroups["Day5"] = fishGroups["Day6"];
                    fishGroups["Day6"] = fishGroups["Day7"];
                    fishGroups["Day7"] = fishGroups["Day8"];
                    fishGroups["Day8"] = fishGroups["Day9"];
                    fishGroups["Day9"] = 0;
                }
                fishGroups["Day6"] += fishGroups["Day8"];
            }
            Console.WriteLine(fishGroups["Day0"] + fishGroups["Day1"] + fishGroups["Day2"] + fishGroups["Day3"] + fishGroups["Day4"] + fishGroups["Day5"] + fishGroups["Day6"] + fishGroups["Day7"] + fishGroups["Day8"]);
        }
    }
}