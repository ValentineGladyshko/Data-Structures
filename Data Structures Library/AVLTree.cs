using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class AVLTree : BinaryTree, IBinaryTree
    {
        private Node? root = null;
        class Node : INode
        {
            public int Value { get; set; }
            public int Height { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(int value)
            {
                Value = value;
                Height = 1;
                LeftNode = null;
                RightNode = null;
            }
            public Node(Node node)
            {
                Value = node.Value;
                Height = node.Height;
                LeftNode = node.LeftNode;
                RightNode = node.RightNode;
            }
        }       

        private int BalanceFactor(Node node)
        {
            if (node.RightNode != null && node.LeftNode != null)
                return node.RightNode.Height - node.LeftNode.Height;
            else if (node.RightNode != null && node.LeftNode == null)
                return node.RightNode.Height;
            else if (node.RightNode == null && node.LeftNode != null)
                return -node.LeftNode.Height;
            else return 0;
        }

        private void FixHeight(Node node)
        {
            if (node.LeftNode != null && node.RightNode != null)
                node.Height = (node.LeftNode.Height > node.RightNode.Height ? node.LeftNode.Height : node.RightNode.Height) + 1;
            else if (node.LeftNode == null && node.RightNode != null)
                node.Height = node.RightNode.Height + 1;
            else if (node.LeftNode != null && node.RightNode == null)
                node.Height = node.LeftNode.Height + 1;
            else
                node.Height = 1;
        }

        private void RotateLeft(Node node)
        {
            if (node.RightNode != null)
            {
                Node temp = new Node(node);

                if (temp.RightNode != null)
                {
                    node.Value = temp.RightNode.Value;
                    node.RightNode = temp.RightNode.RightNode;
                    temp.RightNode = temp.RightNode.LeftNode;
                    node.LeftNode = temp;
                    FixHeight(node.LeftNode);
                    FixHeight(node);
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
                    node.LeftNode = temp.LeftNode.LeftNode;
                    temp.LeftNode = temp.LeftNode.RightNode;
                    node.RightNode = temp;
                    FixHeight(node.RightNode);
                    FixHeight(node);
                }
            }
        }

        private void Balance(Node node)
        {
            FixHeight(node);
            if (BalanceFactor(node) == 2 && node.RightNode != null)
            {
                if (BalanceFactor(node.RightNode) < 0)
                    RotateRight(node.RightNode);
                RotateLeft(node);
            }

            if (BalanceFactor(node) == -2 && node.LeftNode != null)
            {
                if (BalanceFactor(node.LeftNode) > 0)
                    RotateLeft(node.LeftNode);
                RotateRight(node);
            }
        }

        public override void Insert(int value)
        {
            Insert(value, root);
        }
        private void Insert(int value, Node? node)
        {
            if (root == null)
                root = new Node(value);
            if (node == null)
                node = new Node(value);
            else if (value < node.Value)
            {
                if (node.LeftNode == null)                
                    node.LeftNode = new Node(value);               
                else Insert(value, node.LeftNode);
            }
            else if (value > node.Value)
            {
                if (node.RightNode == null)
                    node.RightNode = new Node(value);
                else Insert(value, node.RightNode);
            }
            Balance(node);
        }

        public override void Remove(int value)
        {
            root = Remove(value, root);
        }
        private Node? Remove(int value, Node? node)
        {
            if (node == null)
                return null;
            else if (value < node.Value)
            {
                if (node.LeftNode == null)
                    return node;
                else
                {
                    node.LeftNode = Remove(value, node.LeftNode);
                    Balance(node);
                    return node;
                }
            }
            else if (value > node.Value)
            {
                if (node.RightNode == null)
                    return node;
                else
                {
                    node.RightNode = Remove(value, node.RightNode);
                    Balance(node);
                    return node;
                }
            }
            else if (value == node.Value)
            {
                if (node.LeftNode == null && node.RightNode == null)
                    return null;
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node.Value = node.LeftNode.Value;
                    node.RightNode = node.LeftNode.RightNode;
                    node.LeftNode = node.LeftNode.LeftNode;
                    Balance(node);
                    return node;
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Value = node.RightNode.Value;
                    node.LeftNode = node.RightNode.LeftNode;
                    node.RightNode = node.RightNode.RightNode;
                    Balance(node);
                    return node;
                }
                else if (node.LeftNode != null && node.RightNode != null)
                {
                    if (node.LeftNode.RightNode == null)
                    {
                        node.Value = node.LeftNode.Value;
                        node.LeftNode = node.LeftNode.LeftNode;
                        Balance(node);
                        return node;
                    }
                    else
                    {
                        node.Value = MaximumDelete(node.LeftNode, node);
                        Balance(node.LeftNode);
                        Balance(node);
                        return node;
                    }
                }
            }
            return node;
        }

        private int MinimumDelete(Node node, Node parentNode)
        {
            if (node.LeftNode != null)
                return MinimumDelete(node.LeftNode, node);
            else
            {
                parentNode.LeftNode = node.RightNode;
                return node.Value;
            }
        }

        private int MaximumDelete(Node node, Node parentNode)
        {
            if (node.RightNode != null)
                return MaximumDelete(node.RightNode, node);
            else
            {
                parentNode.RightNode = node.LeftNode;
                return node.Value;
            }
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
                return;

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
            Console.Write("height: ");
            Console.Write(node.Height);
            Console.Write(" ");
            Console.WriteLine(" ");

            if (node.LeftNode != null)
                Traverse(node.LeftNode);

            if (node.RightNode != null)
                Traverse(node.RightNode);
        }
    }
}