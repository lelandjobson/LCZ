using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Josephus : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var test1 = GetJosephus(10, 1);
            var test2 = GetJosephus(12, 3);
        }

        public int GetJosephus(int num, int interval)
        {
            if(num == 1) { return 1; }
            var Josephus = GetJosephus(num - 1, interval);
            var result = (Josephus + interval - 1) % num + 1;
            Console.WriteLine($"({Josephus} + {interval} - 1) % {num} + 1");
            Console.WriteLine(result);
            return result;
        }
    }
}
