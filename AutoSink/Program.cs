using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, int> cityIndices = new Dictionary<string, int>();
        int[] tolls = new int[n];
        for (int i = 0; i < n; i++)
        {
            string[] cityData = Console.ReadLine().Split();
            cityIndices[cityData[0]] = i;
            tolls[i] = int.Parse(cityData[1]);
        }
        int h = int.Parse(Console.ReadLine());
        int[,] graph = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = int.MaxValue;
            }
        }
        for (int i = 0; i < h; i++)
        {
            string[] highwayData = Console.ReadLine().Split();
            int startIndex = cityIndices[highwayData[0]];
            int endIndex = cityIndices[highwayData[1]];
            graph[startIndex, endIndex] = tolls[endIndex];
        }
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string[] tripData = Console.ReadLine().Split();
            int startIndex = cityIndices[tripData[0]];
            int endIndex = cityIndices[tripData[1]];
            int[] distances = new int[n];
            bool[] visited = new bool[n];
            for (int j = 0; j < n; j++)
            {
                distances[j] = int.MaxValue;
                visited[j] = false;
            }
            distances[startIndex] = 0;
            for (int j = 0; j < n; j++)
            {
                int minIndex = -1;
                int minDistance = int.MaxValue;
                for (int k = 0; k < n; k++)
                {
                    if (!visited[k] && distances[k] < minDistance)
                    {
                        minIndex = k;
                        minDistance = distances[k];
                    }
                }
                if (minIndex == -1)
                {
                    break;
                }
                visited[minIndex] = true;
                for (int k = 0; k < n; k++)
                {
                    if (graph[minIndex, k] != int.MaxValue && distances[k] > distances[minIndex] + graph[minIndex, k])
                    {
                        distances[k] = distances[minIndex] + graph[minIndex, k];
                    }
                }
            }
            if (distances[endIndex] != int.MaxValue)
            {
                Console.WriteLine(distances[endIndex]);
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}


