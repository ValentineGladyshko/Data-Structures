using System;
using DataStructures;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Red_Black_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ArrayOperator arrayOperator = new ArrayOperator();

            LeftLeaningRedBlackTree leftLeaningRedBlackTree = new LeftLeaningRedBlackTree();
            leftLeaningRedBlackTree.Insert(24);
            leftLeaningRedBlackTree.Traverse();
        }
    }
}
