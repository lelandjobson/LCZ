using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    public interface IProblemAndSolution
    {
        Complexity SpaceComplexity { get; }
        Complexity TimeComplexity { get; }

        /// <summary>
        /// Gets the test data used
        /// </summary>
        dynamic TestData { get; }

        /// <summary>
        /// Data structures or helper classes
        /// used to solve this
        /// </summary>
        List<Type> StructuresUsed { get; }

        /// <summary>
        /// Runs the problem with the correct solution
        /// </summary>
        void Execute();
    }
}
