using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Largest_Palindrome : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var test1 = LongestPalindrome("abadc");
            Assert.AreEqual(test1, "aba");
            var test2 = LongestPalindrome("cbbd");
            Assert.AreEqual(test2, "bb");
             var test3 = LongestPalindrome("nn");
            Assert.AreEqual(test3, "nn");
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1) { return s; }

            string largestPalindrome = s[0].ToString();

            int next = FindNextPalindromicCenter(0, s);

            while (next != -1)
            {
                string candidate = ExtractPalindrome(next, s);
                if (candidate.Length > largestPalindrome.Length)
                {
                    largestPalindrome = candidate;
                }
                next = FindNextPalindromicCenter(next, s);
            }
            return largestPalindrome;
        }

        public int FindNextPalindromicCenter(int start, string s)
        {
            int cur = start + 1;
            if(cur > s.Length - 1) { return -1; }
            else if (s[cur] == s[cur - 1]) { return cur; }
            if (cur < s.Length - 1 && s[cur] == s[cur + 1]) { return cur + 1; }
            while (cur < s.Length - 1)
            {
                if (s[cur - 1] == s[cur + 1]) { return cur; }
                else { cur++; }
            }
            return -1;
        }

        // We should have an extension component
        // that deals with continuously repeating
        // strings.
        public string ExtractPalindrome(int location, string s)
        {
            int left = location;
            int right = location;
            // Check for double starts
            if(left > 0 && s[location] == s[left - 1])
            {
                left = Math.Max(0,left-1);
            }
            if(right < s.Length -1 && s[location] == s[right +1])
            {
                right = Math.Min(s.Length -1, right+1);
            }
            while (left >= 0 && right < s.Length)
            {
                char l = s[left];
                char r = s[right];
                if (l != r)
                {
                    break;
                }
                left--;
                right++;
            }
            return s.Substring(left + 1, (right - left - 1));
        }
    }
}
