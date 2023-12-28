using System;
using System.Collections.Generic;

class DisjointSet
{
    private int[] parent;
    private int[] rank;

    public DisjointSet(int n)
    {
        parent = new int[n];
        rank = new int[n];

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int x)
    {
        if (x != parent[x])
        {
            x = Find(parent[x]);
        }
        return x;
    }

    public void Union(int x, int y)
    {
        int rx = Find(x);
        int ry = Find(y);

        if (rx == ry)
        {
            return;
        }
        else if (rank[rx] > rank[ry])
        {
            parent[ry] = rx;
        }
        else if (rank[rx] < rank[ry])
        {
            parent[rx] = ry;
        }
        else
        {
            parent[rx] = ry;
            rank[ry]++;
        }
    }
}

class Solution
{
    static void Main(string[] args)
    {
        DisjointSet dj = new DisjointSet(9);

    }
}
