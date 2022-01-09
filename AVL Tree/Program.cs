﻿using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

List<AVLTree> AVLTrees = new List<AVLTree>();
List<BinaryTree> binaryTrees = new List<BinaryTree>();


Parallel.For(0, 10000, i =>
{
    AVLTree AVLTree = new AVLTree();
    BinaryTree binaryTree = new BinaryTree();

    for (int j = 0; j < 100000; j++)
    {
        int temp = random.Next(100000);
        AVLTree.Insert(temp);
        binaryTree.Insert(temp);
    }
    AVLTrees.Add(AVLTree);
    binaryTrees.Add(binaryTree);
});

Stopwatch stopwatch = Stopwatch.StartNew();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.InfixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Infix traverse in AVL tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");

stopwatch.Restart();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.PrefixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Prefix traverse in AVL tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");

stopwatch.Restart();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.PostfixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Postfix traverse in AVL tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");

stopwatch.Restart();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.Insert(500000);
};
stopwatch.Stop();
Console.WriteLine("Insert in AVL tree: " + stopwatch.ElapsedMilliseconds + "ms");

stopwatch.Restart();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.Find(500000);
};
stopwatch.Stop();
Console.WriteLine("Find in AVL tree: " + stopwatch.ElapsedMilliseconds + "ms");

stopwatch.Restart();
foreach (var AVLTree in AVLTrees)
{
    AVLTree.Remove(500000);
};
stopwatch.Stop();
Console.WriteLine("Remove in AVL tree: " + stopwatch.ElapsedMilliseconds + "ms");

stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.InfixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Infix traverse in Binary tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");


stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.PrefixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Prefix traverse in Binary tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");

stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.PostfixTraverse();
};
stopwatch.Stop();
Console.WriteLine("Postfix traverse in Binary tree: " + stopwatch.ElapsedMilliseconds / 1000.0 + "s");

stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.Insert(500000);
};
stopwatch.Stop();
Console.WriteLine("Insert in Binary tree: " + stopwatch.ElapsedMilliseconds + "ms");

stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.Find(500000);
};
stopwatch.Stop();
Console.WriteLine("Find in Binary tree: " + stopwatch.ElapsedMilliseconds + "ms");

stopwatch.Restart();
foreach (var binaryTree in binaryTrees)
{
    binaryTree.Remove(500000);
};
stopwatch.Stop();
Console.WriteLine("Remove in Binary tree: " + stopwatch.ElapsedMilliseconds + "ms");