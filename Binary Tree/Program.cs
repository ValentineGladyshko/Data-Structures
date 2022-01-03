using System;
using DataStructures;
using System.Threading.Tasks;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

Parallel.For(0, 10000, i =>
{
    BinaryTree binaryTree = new BinaryTree();

    for (int j = 0; j < 10000; j++)
    {
        binaryTree.Insert(random.Next());
    }
    Console.WriteLine(arrayOperator.IsSorted(binaryTree.InfixTraverse()));
});