﻿using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

RedBlackTree<int, int> leftLeaningRedBlackTree = new RedBlackTree<int, int>();
//leftLeaningRedBlackTree.Insert(24);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(5);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(1);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(15);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(3);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(8);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(7);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(4);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();
//leftLeaningRedBlackTree.Insert(13);
//leftLeaningRedBlackTree.Traverse();
//Console.WriteLine();

leftLeaningRedBlackTree.Insert(16, 0);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(12, 1);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(11, 2);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(14, 3);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(13, 4);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(15, 5);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(10, 6);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(25, 7);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(28, 8);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(20, 9);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(22, 10);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(21, 11);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(23, 12);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));
Console.WriteLine(leftLeaningRedBlackTree.InfixTraverse().Count);
Console.WriteLine(leftLeaningRedBlackTree.isValidRedBlackTree());
leftLeaningRedBlackTree.Remove(14);
Console.WriteLine(leftLeaningRedBlackTree.isValidRedBlackTree());
Console.WriteLine(leftLeaningRedBlackTree.InfixTraverse().Count);
Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));
leftLeaningRedBlackTree.Traverse();
