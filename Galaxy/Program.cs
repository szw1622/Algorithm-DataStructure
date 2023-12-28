using System;
using System.Collections.Generic;

class Star
{
    public long x;
    public long y;

    public Star(long x, long y)
    {
        this.x = x;
        this.y = y;
    }
}

class Galaxy
{
    public Star center;
    public List<Star> stars = new List<Star>();

    public Galaxy(Star center)
    {
        this.center = center;
        stars.Add(center);
    }

    public void AddStar(Star star)
    {
        stars.Add(star);
    }
}

class Solution
{
    static long d;
    static Star[] stars;
    static List<Galaxy> galaxies = new List<Galaxy>();

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        d = long.Parse(input[0]);

        long n = long.Parse(input[1]);
        stars = new Star[n];

        for (long i = 0; i < n; i++)
        {
            input = Console.ReadLine().Split();
            long x = long.Parse(input[0]);
            long y = long.Parse(input[1]);
            stars[i] = new Star(x, y);
        }

        for (int i = 0; i < n; i++)
        {
            bool found = false;
            for (int j = 0; j < galaxies.Count; j++)
            {
                if (InGalaxy(stars[i], galaxies[j].center))
                {
                    found = true;
                    galaxies[j].AddStar(stars[i]);
                    break;
                }
            }
            if (!found)
            {
                Galaxy galaxy = new Galaxy(stars[i]);
                galaxies.Add(galaxy);
            }
        }

        int maxStars = 0;
        int maxGalaxy = 0;
        for (int i = 0; i < galaxies.Count; i++)
        {
            if (galaxies[i].stars.Count > maxStars)
            {
                maxStars = galaxies[i].stars.Count;
                maxGalaxy = i;
            }
        }

        if (maxStars > n / 2)
        {
            Console.WriteLine(maxStars);
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    static bool InGalaxy(Star a, Star b)
    {
        long dx = a.x - b.x;
        long dy = a.y - b.y;
        return dx * dx + dy * dy <= d * d;
    }
}
