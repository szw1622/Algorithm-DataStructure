using System;
using System.Collections.Generic;
using System.Linq;

class Spiderman
{
    static void Main(string[] args)
    {
        int buildingNum = int.Parse(Console.ReadLine());

        // Iterate over each building.
        for (int i = 0; i < buildingNum; i++)
        {
            int climbTimes = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(' ');
            int[] building = moves.Select(int.Parse).ToArray();

            // Check if Spiderman can successfully climb the building and get the result as a string.
            String result = CheckBuilding(building, climbTimes);
            Console.WriteLine(result);
        }
    }

    // Method to check if Spiderman can climb the building.
    public static String CheckBuilding(int[] building, int climbTimes)
    {
        int sum = building.Sum();
        if (sum % 2 != 0)
            return "IMPOSSIBLE";

        int[,] cache = new int[climbTimes, sum + 1];
        int[,] choice = new int[climbTimes, sum + 1];

        for (int i = 0; i < climbTimes; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                cache[i, j] = int.MaxValue;
            }
        }

        cache[0, building[0]] = building[0];
        choice[0, building[0]] = 1;

        for (int i = 1; i < climbTimes; i++)
        {
            for (int h = 0; h <= sum; h++)
            {
                if (cache[i - 1, h] != int.MaxValue)
                {
                    if (h >= building[i])
                    {
                        if (cache[i, h - building[i]] > cache[i - 1, h])
                        {
                            choice[i, h - building[i]] = -1;
                            cache[i, h - building[i]] = cache[i - 1, h];
                        }
                    }

                    int temp = Math.Max(cache[i - 1, h], h + building[i]);
                    if (cache[i, h + building[i]] > temp)
                    {
                        choice[i, h + building[i]] = 1;
                        cache[i, h + building[i]] = temp;
                    }
                }
            }
        }

        if (cache[climbTimes - 1, 0] == int.MaxValue)
            return "IMPOSSIBLE";

        int height = 0;
        string result = "";
        for (int i = climbTimes - 1; i >= 0; i--)
        {
            if (choice[i, height] == 1)
            {
                height -= building[i];
                result = "U" + result;
            }
            else
            {
                height += building[i];
                result = "D" + result;
            }
        }

        return result;
    }
}
