using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class RankedString
    {
        public string Key;
        public int Rank = 0;
        public bool IsDir = true;

        public RankedString(string s)
        {
            if (s.Contains('.')) { IsDir = false; }
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == 9)
                {
                    Rank++;
                }
            }
            Key = s.Replace("\t", string.Empty);
        }
    }

    internal class Length_Longest_Path : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            string input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
            var test1 = LengthLongestPath(input);
        }

        public int LengthLongestPath(string input)
        {
            // Split by nl into a list
            var rows = input.Split("\n").Select(s => new RankedString(s)).ToList();

            string maxResult = string.Empty;

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].IsDir) { continue; }
                // Walk backwards
                int rank = rows[i].Rank;
                int j = i - 1;
                string result = rows[i].Key;

                // Grab prevs
                while (rank > 0 && j >= 0)
                {
                    if (rows[j].IsDir && rows[j].Rank < rank)
                    {
                        result += "/";
                        result += rows[j].Key;
                        rank--;
                    }
                    j--;
                }
                if (result.Length > maxResult.Length) { maxResult = result; }
            }

            return maxResult.Length;
        }


    }
}
