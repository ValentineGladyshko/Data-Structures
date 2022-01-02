using System;
using DataStructures;

BinaryTree binaryTree = new BinaryTree();
Random random = new Random();
for (int i = 0; i < 100; i++)
{
    binaryTree.Insert(random.Next(100));
}
binaryTree.Traverse();
Console.WriteLine();
binaryTree.InfixTraverse();
Console.WriteLine();   
binaryTree.PrefixTraverse();
Console.WriteLine();
binaryTree.PostfixTraverse();
