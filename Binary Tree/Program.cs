using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

BinaryTree<int> binaryTree = new BinaryTree<int>();
binaryTree.Insert(16);
binaryTree.Insert(12);
binaryTree.Insert(11);
binaryTree.Insert(14);
binaryTree.Insert(13);
binaryTree.Insert(15);
binaryTree.Insert(10);
binaryTree.Insert(25);
binaryTree.Insert(28);
binaryTree.Insert(20);
binaryTree.Insert(22);
binaryTree.Insert(21);
binaryTree.Insert(23);

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