using System;
using DataStructures;

Random random = new Random();

BinaryTree binaryTree = new BinaryTree();

for (int i = 0; i < 100; i++)
{
    binaryTree.Insert(random.Next(70));
}

Console.WriteLine();
Console.WriteLine(binaryTree.Remove(45));
Console.WriteLine(binaryTree.Minimum());
Console.WriteLine(binaryTree.Maximum());

binaryTree.InfixTraverse();
Console.WriteLine();   
binaryTree.PrefixTraverse();
Console.WriteLine();
binaryTree.PostfixTraverse();
