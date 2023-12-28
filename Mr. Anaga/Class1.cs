using System;
using System.Collections.Generic;

class Star
{
    internal long x, y;

    public Star(long x, long y)
    {
        this.x = x;
        this.y = y;
    }
}

class Program
{
    static long d;
    static Star[] stars;
    static long n;
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        d = long.Parse(input[0]);

        n = long.Parse(input[1]);
        stars = new Star[n];

        for (long i = 0; i < n; i++)
        {
            input = Console.ReadLine().Split();
            long x = long.Parse(input[0]);
            long y = long.Parse(input[1]);
            stars[i] = new Star(x, y);
        }

        Star majority = FindMajority(stars);

        if (majority == null)
        {
            Console.WriteLine("NO");
        }
        else
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (InGalaxy(majority, stars[i]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
        Console.ReadLine();
    }

    static Star FindMajority(Star[] stars)
    {
        int count = 0;
        Star candidate = null;

        for (int i = 0; i < n; i++)
        {
            if (count == 0)
            {
                candidate = stars[i];
                count = 1;
            }
            else
            {
                if (InGalaxy(candidate, stars[i]))
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
        }

        count = 0;
        for (int i = 0; i < n; i++)
        {
            if (InGalaxy(candidate, stars[i]))
            {
                count++;
            }
        }

        if (count > n / 2)
        {
            return candidate;
        }
        else
        {
            return null;
        }
    }

    static bool InGalaxy(Star star1, Star star2)
    {
        long a = (star1.x - star2.x);
        long b = (star1.y - star2.y);

        return ((a * a) + (b * b) <= d * d);
    }

}
