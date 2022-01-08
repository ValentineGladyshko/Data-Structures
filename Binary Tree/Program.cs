using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

BinaryTree binaryTree = new BinaryTree();
binaryTree.Insert(16);
binaryTree.Insert(12);
binaryTree.Insert(11);
binaryTree.Insert(14);
binaryTree.Insert(13);
binaryTree.Insert(15);
binaryTree.Insert(25);
binaryTree.Insert(28);
binaryTree.Insert(20);
binaryTree.Insert(22);
binaryTree.Insert(21);
binaryTree.Insert(23);

//binaryTree.Traverse();
Console.WriteLine(arrayOperator.ToString(binaryTree.InfixTraverse()));
binaryTree.Remove(25);
//binaryTree.Traverse();
Console.WriteLine(arrayOperator.ToString(binaryTree.InfixTraverse()));


//Stopwatch stopwatch = Stopwatch.StartNew();
//Parallel.For(0, 10000, i =>
//{
//    BinaryTree binaryTree = new BinaryTree();

//    for (int j = 0; j < 10000; j++)
//    {
//        binaryTree.Insert(random.Next());
//    }
//    Console.WriteLine(arrayOperator.IsSorted(binaryTree.InfixTraverse()));
//});
//stopwatch.Stop();
//Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);
//stopwatch = Stopwatch.StartNew();
//for (int i = 0; i < 10000; i++)
//{
//    BinaryTree binaryTree = new BinaryTree();

//    for (int j = 0; j < 10000; j++)
//    {
//        binaryTree.Insert(random.Next());
//    }
//    Console.WriteLine(arrayOperator.IsSorted(binaryTree.InfixTraverse()));
//}
//Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);