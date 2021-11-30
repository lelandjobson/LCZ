# LCZ
Problems &amp; Solutions for LeetCoding Practice (C#)

Maybe you'll get some help from this!

Simply run the console app. Edit Main() to run the problems you want.
Will make this more sophisticated in the future, maybe.

Problems implement the IProbemAndSolution interface. Execute() runs the solution against test data. Property data on the instance provides additional data on the problem / solution. 

```
static void Main(string[] args)
{
    Console.WriteLine("Welcome to my leetcoding zone!");

    //var test = new Largest_Component_Size_Common_Factor();
    //var test = new IsPerfectSquare();
    //var test = new Largest_Palindrome();
    //var test = new LongestIncreasingSubsequence();
    //var test = new IntervalIntersection();
    //var test = new Josephus();
    //var test = new ZigZagConversion();
    //var test = new Partition_Equal_Subset_Sum();
    //var test = new Cherry_Pickup_II();
    //var test = new Playground();
    //var test = new Graph_Cycle_Detection();
    //var test = new Largest_Rectangle_Area();

    var test = new Maximal_Rectangle();


    test.Execute();
    Console.ReadKey();
}
```
