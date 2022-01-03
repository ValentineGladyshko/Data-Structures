using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();


Stopwatch stopwatch = Stopwatch.StartNew();
Parallel.For(0, 10000, i =>
{
    BinaryTree binaryTree = new BinaryTree();

    for (int j = 0; j < 10000; j++)
    {
        binaryTree.Insert(random.Next());
    }
    //Console.WriteLine(arrayOperator.IsSorted(binaryTree.InfixTraverse()));
});
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);
stopwatch = Stopwatch.StartNew();
for (int i = 0; i < 10000; i++)
{
    BinaryTree binaryTree = new BinaryTree();

    for (int j = 0; j < 10000; j++)
    {
        binaryTree.Insert(random.Next());
    }
    //Console.WriteLine(arrayOperator.IsSorted(binaryTree.InfixTraverse()));
}
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);