using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

Random random = new Random();
ArrayOperator arrayOperator = new ArrayOperator();

LeftLeaningRedBlackTree leftLeaningRedBlackTree = new LeftLeaningRedBlackTree();
leftLeaningRedBlackTree.Insert(24);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(5);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(1);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(15);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(3);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(8);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(7);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(4);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();
leftLeaningRedBlackTree.Insert(13);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine();


Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));
leftLeaningRedBlackTree.Remove(5);
leftLeaningRedBlackTree.Traverse();
Console.WriteLine(arrayOperator.ToString(leftLeaningRedBlackTree.InfixTraverse()));