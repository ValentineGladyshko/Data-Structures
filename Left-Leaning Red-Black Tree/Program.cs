﻿using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

RedBlackTree<int> leftLeaningRedBlackTree = new RedBlackTree<int>();
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

leftLeaningRedBlackTree.Insert(16);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(12);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(11);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(14);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(13);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(15);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(10);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(25);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(28);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(20);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(22);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(21);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(23);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));
Console.WriteLine(leftLeaningRedBlackTree.InfixTraverse().Count);
Console.WriteLine(leftLeaningRedBlackTree.isValidRedBlackTree());
leftLeaningRedBlackTree.Remove(16);
Console.WriteLine(leftLeaningRedBlackTree.isValidRedBlackTree());
Console.WriteLine(leftLeaningRedBlackTree.InfixTraverse().Count);
Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));
leftLeaningRedBlackTree.Traverse();
