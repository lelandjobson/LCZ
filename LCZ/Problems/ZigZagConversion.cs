using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class ZigZagConversion : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var test1 = Convert("PAYPALISHIRING", 3);
            var test2 = Convert("PAYPALISHIRING", 4);
            var test3 = Convert("A", 4);
            var test4 = Convert("AB", 1);
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) { return s; }
            char[][] converted = new char[s.Length][];

            int row = 0;
            int column = 0;
            bool incr = true;
            converted[0] = new char[numRows];

            for(int i = 0; i<s.Length; i++)
            {
                converted[row][column] = s[i];
                if (!incr)
                {
                    column--;
                    row++;
                    converted[row] = new char[numRows];
                }
                else
                {
                    column++;
                }
                if(column == numRows - 1) { incr = false; }
                else if(column == 0) { incr = true; }
            }

            // Add together
            string output = string.Empty;
            for (int i = 0; i < converted[0].Length; i++)
            {
                for (int j = 0; j < converted.Length; j++)
                {
                    if (converted[j] == null) { break; }

                    char c = converted[j][i];
                    if (c == default(char)) { continue; }
                    else { output += c; }
                }
            }


            output = output.Replace(" ", string.Empty);
            return output;
        }
    }
}
