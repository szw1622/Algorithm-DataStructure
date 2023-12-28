using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrAnaga
{
    class MrAnaga
    {
        static void Main(string[] args)
        {
            // get the n and k, n is the number of words, and k is the length of words
            int n;
            string firstLine = Console.ReadLine();
            string[] nANDk = firstLine.Split(' ');
            n = Int32.Parse(nANDk[0]);

            /**
            * Read each line of the input.
            * Sort the reading word first. 
            * If the sorted word is not in the solution set yet, put it into the solution set.
            * If the sorted word is in the solution set, remove it and put it into the recjection set.
            * The length of final solution is the answar.
            */
            HashSet<string> solutions = new HashSet<string>();
            HashSet<string> rejections = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string sortedWord = String.Concat(Console.ReadLine().OrderBy(c => c));

                if (solutions.Contains(sortedWord))
                {
                    solutions.Remove(sortedWord);
                    rejections.Add(sortedWord);
                }
                else if(!rejections.Contains(sortedWord))
                    solutions.Add(sortedWord);
            }

            // Out put the length of final solution
            Console.WriteLine(solutions.Count);
        }
    }
}