using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

BinaryTree<int, int> binaryTree = new BinaryTree<int, int>();
binaryTree.Insert(16, 0);
binaryTree.Insert(12, 1);
binaryTree.Insert(11, 2);
binaryTree.Insert(14, 3);
binaryTree.Insert(13, 4);
binaryTree.Insert(15, 5);
binaryTree.Insert(10, 6);
binaryTree.Insert(25, 7);
binaryTree.Insert(28, 8);
binaryTree.Insert(20, 9);
binaryTree.Insert(22, 10);
binaryTree.Insert(21, 11);
binaryTree.Insert(23, 12);

//binaryTree.Insert(14);
//binaryTree.Insert(9);
//binaryTree.Insert(20);
//binaryTree.Insert(16);
//binaryTree.Insert(24);
//binaryTree.Insert(15);

binaryTree.Traverse();
Console.WriteLine(arrayOperator.ToString(binaryTree.InfixTraverse()));
binaryTree.Remove(16);
binaryTree.Traverse();
Console.WriteLine(arrayOperator.ToString(binaryTree.InfixTraverse()));