using System;
using System.Collections.Generic;
using System.Linq;

class Rainbow
{
    static int[] distance;
    static void Main(string[] args)
    {
        int hotelNum = int.Parse(Console.ReadLine());
        distance = new int[hotelNum + 1];

        for (int i = 0; i <= hotelNum; i++)
        {
            distance[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(penalty(0));
    }

    public static int penalty(int currHotel)
    {
        Dictionary<int, int> cache = new Dictionary<int, int>();
        return penalty(currHotel, cache);
    }

    public static int penalty(int currHotel, Dictionary<int, int> cache)
    {
        if (currHotel == distance.Length - 1) return 0;

        if (cache.ContainsKey(currHotel))
        {
            return cache[currHotel];
        }

        int shortest = int.MaxValue;
        for (int i = currHotel + 1; i < distance.Length; i++)
        {
            int distanceToNext = distance[i] - distance[currHotel];
            // if (distanceToNext > 400) break;

            int penaltyForDay = (400 - distanceToNext) * (400 - distanceToNext);
            int remainingPenalty = penalty(i, cache);
            int totalPenalty = penaltyForDay + remainingPenalty;

            shortest = Math.Min(totalPenalty, shortest);
        }

        cache[currHotel] = shortest;
        return shortest;
    }
}
