using System;
using System.Collections.Generic;
using System.Linq;

struct Vertex : IComparable<Vertex>
{
    public int node;
    public double factor;

    public Vertex(int node, double factor)
    {
        this.node = node;
        this.factor = factor;
    }

    public int CompareTo(Vertex other)
    {
        return this.factor.CompareTo(other.factor);
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string[] line = Console.ReadLine().Split();
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);

            if (n == 0 && m == 0)
            {
                break;
            }

            double[][] map = new double[n][];
            for (int i = 0; i < n; i++)
            {
                map[i] = new double[n];
            }

            for (int i = 0; i < m; i++)
            {
                line = Console.ReadLine().Split();
                int src = int.Parse(line[0]);
                int dest = int.Parse(line[1]);
                double f = double.Parse(line[2]);

                map[src][dest] = f;
                map[dest][src] = f;
            }

            double[] distance = new double[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = double.MinValue;
            }

            Console.WriteLine("{0:F4}", Dijkstra(map, distance, 0, n));
        }
    }

    private static double Dijkstra(double[][] map, double[] distance, int src, int numOfNode)
    {
        PriorityQueue<Vertex> p = new PriorityQueue<Vertex>();
        p.Enqueue(new Vertex(src, 1));

        while (p.Count() > 0)
        {
            Vertex curr = p.Dequeue();

            for (int nei = 0; nei < numOfNode; nei++)
            {
                if (map[curr.node][nei] > 0)
                {
                    double f = curr.factor * map[curr.node][nei];
                    if (f > distance[nei])
                    {
                        distance[nei] = f;
                        p.Enqueue(new Vertex(nei, f));
                    }
                }
            }
        }

        return distance[distance.Length - 1];
    }
}

class PriorityQueue<T> where T : IComparable<T>
{
    private T[] data;
    private int count;

    public PriorityQueue()
    {
        this.data = new T[10000];
        this.count = 0;
    }

    public void Enqueue(T item)
    {
        if (this.count == this.data.Length)
        {
            throw new InvalidOperationException("Priority queue is full");
        }

        int i = this.count++;
        while (i > 0)
        {
            int j = (i - 1) / 2;
            if (item.CompareTo(this.data[j]) >= 0)
            {
                break;
            }
            this.data[i] = this.data[j];
            i = j;
        }
        this.data[i] = item;
    }

    public T Dequeue()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }

        T result = this.data[0];
        T x = this.data[--this.count];
        int i = 0;
        while (i * 2 + 1 < this.count)
        {
            int j = i * 2 + 1;
            if (j + 1 < this.count && this.data[j + 1].CompareTo(this.data[j]) < 0)
            {
                j++;
            }
            if (x.CompareTo(this.data[j]) <= 0)
            {
                break;
            }
            this.data[i] = this.data[j];
            i = j;
        }
        this.data[i] = x;
        return result;
    }

    public bool IsEmpty()
    {
        return this.count == 0;
    }

    public int Count()
    {
        return this.count;
    }
}
