using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Playground
{
    class Day4Puzzle1
    {
        List<string> rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay4.txt").ToList();
        public Day4Puzzle1()
        {
            Dictionary<int, List<List<string>>> cards = new();
            string[] drawnNumbers = rawInput[0].Split(",");
            rawInput.RemoveAt(0);
            rawInput.RemoveAt(0);
            int cardIndex = 0;

            bool weWon = false;
            string winningNumber = string.Empty;
            int winningCard = 0;

            foreach (string line in rawInput)
            {
                if(line == string.Empty)
                {
                    cardIndex++;
                    continue;
                }

                if(cards.ContainsKey(cardIndex))
                {
                    cards[cardIndex].Add(line.Split(" ").ToList());
                }
                else
                {
                    cards.Add(cardIndex, new() {line.Split(" ").ToList()});
                }
            }

            foreach (var number in drawnNumbers)
            {
                if(weWon)
                {
                    break;
                }
                winningNumber = number;

                foreach (var card in cards)
                {
                    if(weWon)
                    {
                        break;
                    }
                    for (int x = 0; x < card.Value.Count; x++)
                    {
                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[x][y] == winningNumber)
                            {
                                card.Value[x][y] = "--";
                            }
                        }
                    }

                    for (int x = 0; x < card.Value.Count; x++)
                    {
                        int horizontalCounter = 0;
                        int veritcalCounter = 0;
                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[x][y] == "--")
                            {
                                horizontalCounter++;
                            }
                        }

                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[y][x] == "--")
                            {
                                veritcalCounter++;
                            }
                        }

                        if(veritcalCounter == 5 || horizontalCounter == 5)
                        {
                            weWon = true;
                            winningCard = card.Key;
                            break;
                        }
                    }
                }
            }

            int winningSum = 0;
            foreach (var row in cards[winningCard])
            {
                foreach (var number in row)
                {
                    if(number == "--")
                    {
                        continue;
                    }
                    winningSum += Convert.ToInt32(number);
                }
            }
            Console.WriteLine(winningSum * Convert.ToInt32(winningNumber));
        }
    }

    class Day4Puzzle2
    {
        List<string> rawInput = File.ReadAllLines(@"C:\Users\Phil\Desktop\C#\Playground\Assets\inputDay4.txt").ToList();
        public Day4Puzzle2()
        {
            Dictionary<int, List<List<string>>> cards = new();
            string[] drawnNumbers = rawInput[0].Split(",");
            rawInput.RemoveAt(0);
            rawInput.RemoveAt(0);
            int cardIndex = 0;

            bool weWon = false;
            string winningNumber = string.Empty;
            int winningCard = 0;

            foreach (string line in rawInput)
            {
                if(line == string.Empty)
                {
                    cardIndex++;
                    continue;
                }

                if(cards.ContainsKey(cardIndex))
                {
                    cards[cardIndex].Add(line.Split(" ").ToList());
                }
                else
                {
                    cards.Add(cardIndex, new() {line.Split(" ").ToList()});
                }
            }

            foreach (var number in drawnNumbers)
            {
                if(weWon)
                {
                    break;
                }
                winningNumber = number;

                foreach (var card in cards)
                {
                    if(weWon)
                    {
                        break;
                    }
                    for (int x = 0; x < card.Value.Count; x++)
                    {
                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[x][y] == winningNumber)
                            {
                                card.Value[x][y] = "--";
                            }
                        }
                    }

                    for (int x = 0; x < card.Value.Count; x++)
                    {
                        int horizontalCounter = 0;
                        int veritcalCounter = 0;
                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[x][y] == "--")
                            {
                                horizontalCounter++;
                            }
                        }

                        for (int y = 0; y < card.Value.Count; y++)
                        {
                            if(card.Value[y][x] == "--")
                            {
                                veritcalCounter++;
                            }
                        }

                        if(veritcalCounter == 5 || horizontalCounter == 5)
                        {
                            if(cards.Count == 1)
                            {
                                winningCard = card.Key;
                                weWon = true;
                                break;
                            }

                            cards.Remove(card.Key);
                        }
                    }
                }
            }

            int winningSum = 0;
            foreach (var row in cards[winningCard])
            {
                foreach (var number in row)
                {
                    if(number == "--")
                    {
                        continue;
                    }
                    winningSum += Convert.ToInt32(number);
                }
            }
            Console.WriteLine(winningSum * Convert.ToInt32(winningNumber));
        }
    }
}