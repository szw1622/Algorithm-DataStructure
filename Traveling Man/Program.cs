using System;
using System.Linq;

class HamiltonianCycle
{
    private static int n;
    private static int[,] graph;
    private static int[,] cache;

    private static int allVisited;

    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        graph = new int[n, n];
        cache = new int[n, 1 << n];
        allVisited = (1 << n) - 1;

        for (int i = 0; i < n; i++)
        {
            int[] weights = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = weights[j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= allVisited; j++)
            {
                cache[i, j] = -1;
            }
        }

        Console.WriteLine(TSP(0, 1));
    }

    private static int TSP(int pos, int visited)
    {
        if (visited == allVisited)
        {
            return graph[pos, 0];
        }

        int checkPoint = cache[pos, visited];
        if (checkPoint != -1)
        {
            return checkPoint;
        }

        int ans = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            int graphWeight = graph[pos, i];
            int nextVisited = visited | (1 << i);
            int isVisited = (visited >> i) & 1;

            if (isVisited == 0)
            {
                ans = Math.Min(ans, graphWeight + TSP(i, nextVisited));
            }

        }

        cache[pos, visited] = ans;
        return ans;
    }
}
