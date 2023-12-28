using System;
using System.Collections.Generic;
using System.Linq;

class Rumor
{
    static void Main()
    {
        // Read the number of students
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> friends = new Dictionary<string, List<string>>();
        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine();
            friends[name] = new List<string>();
        }

        // Read the number of friend pairs
        int f = int.Parse(Console.ReadLine());
        for (int i = 0; i < f; i++)
        {
            string[] cp = Console.ReadLine().Split();
            friends[cp[0]].Add(cp[1]);
            friends[cp[1]].Add(cp[0]);
        }

        // Read the number of rumors to spread
        int r = int.Parse(Console.ReadLine());

        // For each rumor, perform a breadth-first search starting from the given student
        for (int i = 0; i < r; i++)
        {
            string start = Console.ReadLine();
            Dictionary<string, int> dist = new Dictionary<string, int>();

            // Initialize the distances to infinity for all students
            foreach (string student in friends.Keys)
            {
                dist.Add(student, int.MaxValue);
            }

            // Set the distance of the starting student to 0
            dist[start] = 0;

            // Create a queue to perform the breadth-first search
            Queue<string> bfs = new Queue<string>();
            bfs.Enqueue(start);

            while (bfs.Count != 0)
            {
                string student = bfs.Dequeue();

                // For each of the student's friends, update their distance if it is greater than the current distance + 1
                foreach (string friend in friends[student])
                {
                    if (dist[friend] == int.MaxValue)
                    {
                        bfs.Enqueue(friend);
                        dist[friend] = dist[student] + 1;
                    }
                }
            }

            // Sort the distances by increasing order of distance and then by name
            var orderedDist = dist.OrderBy(pair => pair.Key).OrderBy(pair => pair.Value);

            // Print the names of the students in the order specified by the sorted distances
            foreach (var student in orderedDist)
            {
                Console.Write(student.Key + " ");
            }
            Console.WriteLine();
        }
    }
}
