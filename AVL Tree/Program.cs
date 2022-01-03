using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();


Stopwatch stopwatch = Stopwatch.StartNew();
AVLTree AVLTree = new AVLTree();
AVLTree.Insert(6);
AVLTree.Insert(3);
AVLTree.Insert(15);
AVLTree.Insert(1);
AVLTree.Insert(4);
AVLTree.Insert(10);
AVLTree.Insert(20);
AVLTree.Insert(17);
AVLTree.Insert(18);
AVLTree.Insert(16);
AVLTree.Insert(21);

AVLTree.Traverse();
Console.WriteLine();
Console.WriteLine(arrayOperator.ToString(AVLTree.InfixTraverse()));
Console.WriteLine();
AVLTree.RotateRight();
AVLTree.Traverse();
Console.WriteLine(arrayOperator.ToString(AVLTree.InfixTraverse()));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000.0);
