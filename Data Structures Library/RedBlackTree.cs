using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class RedBlackTree : BinaryTree, IBinaryTree
    {
        private Node? root = null;

        private bool left = false;
        private bool right = false;
        private bool leftRight = false;
        private bool rightLeft = false;

        class Node : INode
        {
            public int Value { get; set; }
            public Color Color { get; set; }
            public Node? ParentNode { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(int value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = null;
                Color = Color.Red;
            }
            public Node(int value, Node parentNode)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = parentNode;
                Color = Color.Red;
            }
            public Node(Node node)
            {
                Value = node.Value;
                LeftNode = node.LeftNode;
                RightNode = node.RightNode;
                ParentNode = node.ParentNode;
                Color = node.Color;
            }
        }

        private Color GetColor(Node? node)
        {
            if (node == null)
                return Color.Black;
            else return node.Color;
        }

        private Node? GetGrandparent(Node? node)
        {
            if (node != null)
                if (node.ParentNode != null)
                    return node.ParentNode.ParentNode;
            return null;
        }

        private Node? GetUncle(Node? node)
        {
            Node? Grandparent = GetGrandparent(node);
            if (Grandparent != null && node != null)
                if (node.ParentNode == Grandparent.LeftNode)
                    return Grandparent.RightNode;
                else return Grandparent.LeftNode;
            return null;
        }

        private void RotateLeft(Node node)
        {
            if (node.RightNode != null)
            {
                Node temp = new Node(node);

                if (temp.RightNode != null)
                {
                    node.Value = temp.RightNode.Value;
                    node.Color = temp.RightNode.Color;
                    node.RightNode = temp.RightNode.RightNode;
                    temp.RightNode = temp.RightNode.LeftNode;
                    node.LeftNode = temp;

                    if (node.RightNode != null)
                    {
                        node.RightNode.ParentNode = node;
                    }
                    if (node.LeftNode != null)
                    {
                        node.LeftNode.ParentNode = node;
                    }
                    if (temp.RightNode != null)
                    {
                        temp.RightNode.ParentNode = temp;
                    }
                    if (temp.LeftNode != null)
                    {
                        temp.LeftNode.ParentNode = temp;
                    }
                }
            }
        }

        private void RotateRight(Node node)
        {
            if (node.LeftNode != null)
            {
                Node temp = new Node(node);

                if (temp.LeftNode != null)
                {
                    node.Value = temp.LeftNode.Value;
                    node.Color = temp.LeftNode.Color;
                    node.LeftNode = temp.LeftNode.LeftNode;
                    temp.LeftNode = temp.LeftNode.RightNode;
                    node.RightNode = temp;

                    if (node.RightNode != null)
                    {
                        node.RightNode.ParentNode = node;
                    }
                    if (node.LeftNode != null)
                    {
                        node.LeftNode.ParentNode = node;
                    }
                    if (temp.RightNode != null)
                    {
                        temp.RightNode.ParentNode = temp;
                    }
                    if (temp.LeftNode != null)
                    {
                        temp.LeftNode.ParentNode = temp;
                    }
                }
            }
        }

        public override void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                root.Color = Color.Black;
            }
            else
                root = Insert(value, root);
        }
        private Node Insert(int value, Node? node)
        {

            //return null;
            bool redConflict = false;
            if (node == null)
                return new Node(value);
            else if (value < node.Value)
            {
                node.LeftNode = Insert(value, node.LeftNode);
                node.LeftNode.ParentNode = node;
                if (node != root)
                    if (GetColor(node) == Color.Red && GetColor(node.LeftNode) == Color.Red)
                        redConflict = true;
            }
            else if (value > node.Value)
            {
                node.RightNode = Insert(value, node.RightNode);
                node.RightNode.ParentNode = node;
                if (node != root)
                {
                    if (GetColor(node) == Color.Red && GetColor(node.RightNode) == Color.Red)
                    {
                        redConflict = true;
                    }
                }
            }

            if (left)
            {
                RotateLeft(node);
                node.Color = Color.Black;
                if (node.LeftNode != null)
                    node.LeftNode.Color = Color.Red;
                left = false;
            }
            else if (right)
            {
                RotateRight(node);
                node.Color = Color.Black;
                if (node.RightNode != null)
                    node.RightNode.Color = Color.Red;
                right = false;
            }
            else if (rightLeft)
            {
                if (node.RightNode != null)
                {
                    RotateRight(node.RightNode);
                    RotateLeft(node);
                    node.Color = Color.Black;
                    if (node.LeftNode != null)
                        node.LeftNode.Color = Color.Red;
                    rightLeft = false;
                }
            }
            else if (leftRight)
            {
                if (node.LeftNode != null)
                {
                    RotateLeft(node.LeftNode);
                    RotateRight(node);
                    node.Color = Color.Black;
                    if (node.RightNode != null)
                        node.RightNode.Color = Color.Red;
                    leftRight = false;
                }
            }

            if (redConflict)
            {
                if (node.ParentNode != null)
                {
                    if (node.ParentNode.RightNode == node)
                    {
                        if (GetColor(node.ParentNode.LeftNode) == Color.Black)
                        {
                            if (node.LeftNode != null && node.LeftNode.Color == Color.Red)
                                rightLeft = true;
                            else if (node.RightNode != null && node.RightNode.Color == Color.Red)
                                left = true;
                        }
                        else
                        {
                            if (node.ParentNode.LeftNode != null)
                                node.ParentNode.LeftNode.Color = Color.Black;
                            node.Color = Color.Black;
                            if (node.ParentNode != root)
                                node.ParentNode.Color = Color.Red;
                        }
                    }
                    else
                    {
                        if (GetColor(node.ParentNode.RightNode) == Color.Black)
                        {
                            if (node.LeftNode != null && node.LeftNode.Color == Color.Red)
                                right = true;
                            else if (node.RightNode != null && node.RightNode.Color == Color.Red)
                                leftRight = true;
                        }
                        else
                        {
                            if (node.ParentNode.RightNode != null)
                                node.ParentNode.RightNode.Color = Color.Black;
                            node.Color = Color.Black;
                            if (node.ParentNode != root)
                                node.ParentNode.Color = Color.Red;
                        }
                    }
                }
                redConflict = false;
            }
            return node;
        }

        public bool isValidRedBlackTree()
        {
            ArrayList blackDepthList = new();
            isValidRedBlackTree(root, blackDepthList);

            var depth = blackDepthList[0];
            if (depth == null)
                return true;

            foreach (int blackDepth in blackDepthList)
            {
                if (blackDepth != (int)depth)
                    return false;
            }

            return true;
        }
        private void isValidRedBlackTree(Node? node, ArrayList blackDepthList)
        {
            if (node != null)
            {
                if (node.LeftNode == null || node.RightNode == null)
                {
                    int blackDepth = 1;
                    Node temp = node;
                    while (temp.ParentNode != null)
                    {
                        if (GetColor(temp) == Color.Black)
                            blackDepth++;
                        temp = temp.ParentNode;
                    }
                    blackDepthList.Add(blackDepth);

                }
                if (node.LeftNode != null)
                    isValidRedBlackTree(node.LeftNode, blackDepthList);

                if (node.RightNode != null)
                    isValidRedBlackTree(node.RightNode, blackDepthList);
            }

        }
        public override void Remove(int value)
        {
        }

        public override bool Find(int value)
        {
            return Find(value, root);
        }

        public override int? Minimum()
        {
            return Minimum(root);
        }

        public override int? Maximum()
        {
            return Maximum(root);
        }

        public override List<int> InfixTraverse()
        {
            return InfixTraverse(root);
        }

        public override List<int> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }

        public override List<int> PostfixTraverse()
        {
            return PostfixTraverse(root);
        }

        public override void Traverse()
        {
            Traverse(root);
        }

        private void Traverse(Node? node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.Value);
            Console.Write(" ");
            if (node.LeftNode != null)
            {
                Console.Write("left: ");
                Console.Write(node.LeftNode.Value);
                Console.Write(" ");
            }
            if (node.RightNode != null)
            {
                Console.Write("right: ");
                Console.Write(node.RightNode.Value);
                Console.Write(" ");
            }
            Console.Write("Color: ");
            Console.Write(node.Color);
            Console.Write(" ");
            if (node.ParentNode != null)
            {
                Console.Write("parent: ");
                Console.Write(node.ParentNode.Value);
                Console.Write(" ");
            }
            Console.WriteLine(" ");

            if (node.LeftNode != null)
            {
                Traverse(node.LeftNode);
            }

            if (node.RightNode != null)
            {
                Traverse(node.RightNode);
            }
        }
    }
}