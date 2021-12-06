using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day5Puzzle1
    {
        List<string> rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay5.txt").ToList();
        public Day5Puzzle1()
        {
            int[,] cheekyMatrix = new int[1000,1000];
            int overlapCounter = 0;
            foreach (var line in rawInput)
            {
                // We need to split the lines up "507,56 -> 507,840" - " -> " can be the delim chars
                // Once we have 2 strings, we create 2 lists of x and y values
                    // Split the 2 strings on "," and add [0] to x and [1] to y
                    // We need to exclude any that arent straight or horizontal
                // We need to loop over all the index values for both axis
                    // Get the count of loops we need to do by (x1 - x2) 
                    // If negative, xCount = -xCount;
                    // for(int x = 0; x < xCount; x++)
                        // Check the value at the matrix index [x, y]
                            // if [x, y] == 0; [x, y]++;
                            // if [x, y] == 1; [x, y]++; && overlapCounter++;
                
                string[] splitLines = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                List<int> xCoords = new();
                List<int> yCoords = new();

                foreach (var item in splitLines)
                {
                    int[] splitCoord = Array.ConvertAll(item.Split(","), int.Parse);
                    // Console.WriteLine(item);
                    xCoords.Add(splitCoord[0]);
                    yCoords.Add(splitCoord[1]);
                }
                
                int xCount = xCoords[0] - xCoords[1];
                int yCount = yCoords[0] - yCoords[1];
                int xLowIndex = 1;
                int xHighIndex = 0;
                int yLowIndex = 1;
                int yHighIndex = 0;
                if(xCount < 0)
                {
                    xCount = -xCount;
                    xLowIndex--;
                    xHighIndex++;
                }
                if(yCount < 0)
                {
                    yCount = -yCount;
                    yLowIndex--;
                    yHighIndex++;
                }


                // bool isStraight = false;
                // || (-(xCoords[0] - yCoords[0]) == xCoords[1] - yCoords[1])
                if((xCoords[0] == yCoords[0] && yCoords[1] == xCoords[1]) || (xCoords[0] - yCoords[0] == xCoords[1] - yCoords[1]))
                {
                    // Console.WriteLine($"X0 = {xCoords[0]}, Y0 = {yCoords[0]}, X1 = {xCoords[1]}, Y1 = {yCoords[1]}, xCount = {xCount}, yCount = {yCount}, DiagonalR");
                    for (int x = 0; x < xCount+1; x++)
                    {
                        // Console.WriteLine($"xCoord = {xCoords[xLowIndex] + x}, yCoord = {yCoords[yLowIndex]}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]}");
                        if(cheekyMatrix[yCoords[yLowIndex] + x, xCoords[xLowIndex] + x] == 0)
                        {
                            cheekyMatrix[yCoords[yLowIndex] + x, xCoords[xLowIndex] + x]++;
                        }
                        else if(cheekyMatrix[yCoords[yLowIndex] + x, xCoords[xLowIndex] + x] == 1)
                        {
                            cheekyMatrix[yCoords[yLowIndex] + x, xCoords[xLowIndex] + x]++;
                            overlapCounter++;
                        }
                        // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]);
                    }
                    // isStraight = true;
                }
                else if((xCoords[0] == yCoords[1] && yCoords[0] == xCoords[1]) || (xCoords[0] - xCoords[1] == yCoords[0] - yCoords[1]) || (-(xCoords[0] - xCoords[1]) == yCoords[0] - yCoords[1]))
                {
                    // Console.WriteLine($"X0 = {xCoords[0]}, X1 = {xCoords[1]}, Y0 = {yCoords[0]}, Y1 = {yCoords[1]}, xCount = {xCount}, yCount = {yCount}, DiagonalL");
                    for (int x = 0; x < xCount+1; x++)
                    {
                        // Console.WriteLine($"xCoord = {xCoords[xLowIndex] + x}, yCoord = {yCoords[yLowIndex]}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]}");
                        if(cheekyMatrix[yCoords[yHighIndex] - x, xCoords[xLowIndex] + x] == 0)
                        {
                            cheekyMatrix[yCoords[yHighIndex] - x, xCoords[xLowIndex] + x]++;
                        }
                        else if(cheekyMatrix[yCoords[yHighIndex] - x, xCoords[xLowIndex] + x] == 1)
                        {
                            cheekyMatrix[yCoords[yHighIndex] - x, xCoords[xLowIndex] + x]++;
                            overlapCounter++;
                        }
                        // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]);
                    }
                    // isStraight = true;
                }
                else if(xCoords[0] == xCoords[1] || yCoords[0] == yCoords[1])
                {
                    // Console.WriteLine($"X0 = {xCoords[0]}, X1 = {xCoords[1]}, Y0 = {yCoords[0]}, Y1 = {yCoords[1]}, xCount = {xCount}, yCount = {yCount}, Straight");
                    // isStraight = true;
                    for (int x = 0; x < xCount+1; x++)
                    {
                        // Console.WriteLine($"xCoord = {xCoords[xLowIndex] + x}, yCoord = {yCoords[yLowIndex]}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]}");
                        if(cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x] == 0)
                        {
                            cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x]++;
                        }
                        else if(cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x] == 1)
                        {
                            cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x]++;
                            overlapCounter++;
                        }
                        // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]);
                    }
                    for (int y = 1; y < yCount+1; y++)
                    {
                        // Console.WriteLine($"xCoord = {xCoords[xLowIndex]}, yCoord = {yCoords[yLowIndex] + y}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex], yCoords[yLowIndex] + y]}");
                        if(cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]] == 0)
                        {
                            cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]]++;
                        }
                        else if(cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]] == 1)
                        {
                            cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]]++;
                            overlapCounter++;
                        }
                        // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex], yCoords[yLowIndex] + y]);
                    }
                }

                // if(!isStraight)
                // {
                //     continue;
                // }

                // Console.WriteLine($"X Index 0 = {xCoords[0]}");
                // Console.WriteLine($"X Index 1 = {xCoords[1]}");
                // Console.WriteLine($"Lowest X Index = {xCoords[xLowIndex]}");
                // Console.WriteLine($"Y Index 0 = {yCoords[0]}");
                // Console.WriteLine($"Y Index 1 = {yCoords[1]}");
                // Console.WriteLine($"Lowest Y Index = {yCoords[yLowIndex]}");

                // for (int x = 0; x < xCount+1; x++)
                // {
                //     // Console.WriteLine($"xCoord = {xCoords[xLowIndex] + x}, yCoord = {yCoords[yLowIndex]}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]}");
                //     if(cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x] == 0)
                //     {
                //         cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x]++;
                //     }
                //     else if(cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x] == 1)
                //     {
                //         cheekyMatrix[yCoords[yLowIndex], xCoords[xLowIndex] + x]++;
                //         overlapCounter++;
                //     }
                //     // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex] + x, yCoords[yLowIndex]]);
                // }
                // for (int y = 1; y < yCount+1; y++)
                // {
                //     // Console.WriteLine($"xCoord = {xCoords[xLowIndex]}, yCoord = {yCoords[yLowIndex] + y}, Matrix Value = {cheekyMatrix[xCoords[xLowIndex], yCoords[yLowIndex] + y]}");
                //     if(cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]] == 0)
                //     {
                //         cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]]++;
                //     }
                //     else if(cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]] == 1)
                //     {
                //         cheekyMatrix[yCoords[yLowIndex] + y, xCoords[xLowIndex]]++;
                //         overlapCounter++;
                //     }
                //     // Console.WriteLine(cheekyMatrix[xCoords[xLowIndex], yCoords[yLowIndex] + y]);
                // }
            }
            Console.WriteLine($"Overlapping Count = {overlapCounter}");

            // for (int i = 0; i < cheekyMatrix.GetLength(0); i++)
            // {
            //     for (int j = 0; j < cheekyMatrix.GetLength(1); j++)
            //     {
            //         Console.Write(cheekyMatrix[i,j] + " ");
            //     }
            //     Console.WriteLine();
            // }
        }
    }
}
