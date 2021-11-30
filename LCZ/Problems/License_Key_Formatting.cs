using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class License_Key_Formatting : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            string s = string.Empty;
            var test1 = LicenseKeyFormatting("---", 3);
            var test2 = LicenseKeyFormatting("wgk-as-vvs-sw-a-a", 3);
        }


        public string LicenseKeyFormatting(string s, int k)
        {
            // Iterate backwards through the string creating groups
            List<char> output = new List<char>();
            int cur = 0;
            for (int pos = s.Length - 1; pos >= 0; pos--)
            {
                char curChar = s[pos];
                if (curChar.Equals('-')) { continue; }
                output.Add(curChar);
                cur++;
                if (cur == k && pos > 0)
                {
                    // Add a dash
                    output.Add('-');

                    // Reset
                    cur = 0;
                }
            }
            if (output.Count == 0) { return string.Empty; }
            if (output.Last() == '-') { output.RemoveAt(output.Count - 1); }
            output.Reverse();
            return string.Join(string.Empty, output).ToUpper();
        }

    }
}
