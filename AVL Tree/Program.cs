using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();


Stopwatch stopwatch = Stopwatch.StartNew();
int notSorted = 0;
int notBalanced = 0;

Parallel.For(0, 1000, i =>
{
    AVLTree AVLTree = new AVLTree();

    for (int j = 0; j < 10000; j++)
    {
        AVLTree.Insert(random.Next());
    }
    if (!arrayOperator.IsSorted(AVLTree.InfixTraverse()))
        notSorted++;
    if (AVLTree.BalanceFactor() > 1 || AVLTree.BalanceFactor() < -1)
    {
        notBalanced++;
        Console.WriteLine(AVLTree.BalanceFactor());
    }
});

Console.WriteLine("Not sorted: " + notSorted);
Console.WriteLine("Not balanced: " + notBalanced);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);
