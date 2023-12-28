using System;
using System.Collections.Generic;
using System.Linq;

class ArtGallery
{
    static int[,] values;
    static Dictionary<string, int> cache;
    static int N;
    static int K;

    public static void Main(string[] args)
    {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            N = input[0];
            K = input[1];

            values = new int[N, 2];
            cache = new Dictionary<string, int>();

            for (int i = 0; i < N; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                values[i, 0] = row[0];
                values[i, 1] = row[1];
            }

            int result = maxValue(0, -1, K);
            Console.WriteLine(result);
    }

    static int maxValue(int r, int noCloseRoom, int k)
    {
        if (r >= N)
        {
            return 0;
        }

        string key = $"{r},{noCloseRoom},{k}";
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }

        int result;
        if (k == N - r)
        {
            if (noCloseRoom == 0)
            {
                result = values[r, 0] + maxValue(r + 1, 0, k - 1);
            }
            else if (noCloseRoom == 1)
            {
                result = values[r, 1] + maxValue(r + 1, 1, k - 1);
            }
            else
            {
                int a = values[r, 0] + maxValue(r + 1, 0, k - 1);
                int b = values[r, 1] + maxValue(r + 1, 1, k - 1);
                result = Math.Max(a, b);
            }
        }
        else
        {
            if (noCloseRoom == 0)
            {
                int a = values[r, 0] + maxValue(r + 1, 0, k - 1);
                int b = values[r, 0] + values[r, 1] + maxValue(r + 1, -1, k);
                result = Math.Max(a, b);
            }
            else if (noCloseRoom == 1)
            {
                int a = values[r, 1] + maxValue(r + 1, 1, k - 1);
                int b = values[r, 0] + values[r, 1] + maxValue(r + 1, -1, k);
                result = Math.Max(a, b);
            }
            else
            {
                int a = values[r, 0] + maxValue(r + 1, 0, k - 1);
                int b = values[r, 1] + maxValue(r + 1, 1, k - 1);
                int c = values[r, 0] + values[r, 1] + maxValue(r + 1, -1, k);
                result = Math.Max(Math.Max(a, b), c);
            }
        }
        cache[key] = result;
        return result;
    }
}
