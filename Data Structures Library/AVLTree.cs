using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class AVLTree<T, T1> : BinaryTree<T, T1>, IBinaryTree<T, T1> where T : IComparable
    {
        private Node<T, T1>? root = null;
        class Node<T2, T3> : INode<T2, T3> where T2 : IComparable
        {
            public T2 Key { get; set; }
            public T3 Value { get; set; }
            public int Height { get; set; }
            public Node<T2, T3>? LeftNode { get; set; }
            public Node<T2, T3>? RightNode { get; set; }
            INode<T2, T3>? INode<T2, T3>.LeftNode { get => LeftNode; set => LeftNode = (Node<T2, T3>?)value; }
            INode<T2, T3>? INode<T2, T3>.RightNode { get => RightNode; set => RightNode = (Node<T2, T3>?)value; }

            public Node(T2 key, T3 value)
            {
                Key = key;
                Value = value;
                Height = 1;
                LeftNode = null;
                RightNode = null;
            }
            public Node(Node<T2, T3> node)
            {
                Key = node.Key;
                Value = node.Value;
                Height = node.Height;
                LeftNode = node.LeftNode;
                RightNode = node.RightNode;
            }
        }       

        private int BalanceFactor(Node<T, T1> node)
        {
            if (node.RightNode != null && node.LeftNode != null)
                return node.RightNode.Height - node.LeftNode.Height;
            else if (node.RightNode != null && node.LeftNode == null)
                return node.RightNode.Height;
            else if (node.RightNode == null && node.LeftNode != null)
                return -node.LeftNode.Height;
            else return 0;
        }

        private void FixHeight(Node<T, T1> node)
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

        private void RotateLeft(Node<T, T1> node)
        {
            if (node.RightNode != null)
            {
                Node<T, T1> temp = new Node<T, T1>(node);

                if (temp.RightNode != null)
                {
                    node.Key = temp.RightNode.Key;
                    node.Value = temp.RightNode.Value;
                    node.RightNode = temp.RightNode.RightNode;
                    temp.RightNode = temp.RightNode.LeftNode;
                    node.LeftNode = temp;
                    FixHeight(node.LeftNode);
                    FixHeight(node);
                }
            }
        }

        private void RotateRight(Node<T, T1> node)
        {
            if (node.LeftNode != null)
            {
                Node<T, T1> temp = new Node<T, T1>(node);

                if (temp.LeftNode != null)
                {
                    node.Key = temp.LeftNode.Key;
                    node.Value = temp.LeftNode.Value;
                    node.LeftNode = temp.LeftNode.LeftNode;
                    temp.LeftNode = temp.LeftNode.RightNode;
                    node.RightNode = temp;
                    FixHeight(node.RightNode);
                    FixHeight(node);
                }
            }
        }

        private void Balance(Node<T, T1> node)
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

        public override void Insert(T key, T1 value)
        {
            Insert(key, value, root);
        }
        private void Insert(T key, T1 value, Node<T, T1>? node)
        {
            if (root == null)
                root = new Node<T, T1>(key, value);
            if (node == null)
                node = new Node<T, T1>(key, value);
            else if (key.CompareTo(node.Key) < 0)
            {
                if (node.LeftNode == null)                
                    node.LeftNode = new Node<T, T1>(key, value);               
                else Insert(key, value, node.LeftNode);
            }
            else if (key.CompareTo(node.Key) > 0)
            {
                if (node.RightNode == null)
                    node.RightNode = new Node<T, T1>(key, value);
                else Insert(key, value, node.RightNode);
            }
            Balance(node);
        }

        public override void Remove(T key)
        {
            root = Remove(key, root);
        }
        private Node<T, T1>? Remove(T key, Node<T, T1>? node)
        {
            if (node == null)
                return null;
            else if (key.CompareTo(node.Key) < 0)
            {
                if (node.LeftNode == null)
                    return node;
                else
                {
                    node.LeftNode = Remove(key, node.LeftNode);
                    Balance(node);
                    return node;
                }
            }
            else if (key.CompareTo(node.Key) > 0)
            {
                if (node.RightNode == null)
                    return node;
                else
                {
                    node.RightNode = Remove(key, node.RightNode);
                    Balance(node);
                    return node;
                }
            }
            else if (key.CompareTo(node.Key) == 0)
            {
                if (node.LeftNode == null && node.RightNode == null)
                    return null;
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node.Key = node.LeftNode.Key;
                    node.Value = node.LeftNode.Value;
                    node.RightNode = node.LeftNode.RightNode;
                    node.LeftNode = node.LeftNode.LeftNode;
                    Balance(node);
                    return node;
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Key = node.RightNode.Key;
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
                        node.Key = node.LeftNode.Key;
                        node.Value = node.LeftNode.Value;
                        node.LeftNode = node.LeftNode.LeftNode;
                        Balance(node);
                        return node;
                    }
                    else
                    {
                        var temp = MaximumDelete(node.LeftNode, node);
                        node.Key = temp.Item1;
                        node.Value = temp.Item2;
                        Balance(node.LeftNode);
                        Balance(node);
                        return node;
                    }
                }
            }
            return node;
        }

        private (T, T1) MinimumDelete(Node<T, T1> node, Node<T, T1> parentNode)
        {
            if (node.LeftNode != null)
                return MinimumDelete(node.LeftNode, node);
            else
            {
                parentNode.LeftNode = node.RightNode;
                return (node.Key, node.Value);
            }
        }

        private (T, T1) MaximumDelete(Node<T, T1> node, Node<T, T1> parentNode)
        {
            if (node.RightNode != null)
                return MaximumDelete(node.RightNode, node);
            else
            {
                parentNode.RightNode = node.LeftNode;
                return (node.Key, node.Value);
            }
        }

        public override bool Find(T key)
        {
            return Find(key, root);
        }

        public override List<IComparable> InfixTraverse()
        {
            return InfixTraverse(root);
        }

        public override List<IComparable> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }

        public override List<IComparable> PostfixTraverse()
        {
            return PostfixTraverse(root);
        }

        public override void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node<T, T1>? node)
        {
            if (node == null)
                return;

            Console.Write(node.Key.ToString());
            Console.Write(" ");
            if (node.LeftNode != null)
            {
                Console.Write("left: ");
                Console.Write(node.LeftNode.Key.ToString());
                Console.Write(" ");
            }
            if (node.RightNode != null)
            {
                Console.Write("right: ");
                Console.Write(node.RightNode.Key.ToString());
                Console.Write(" ");
            }
            if (node.Value != null)
            {
                Console.Write(node.Value.ToString());
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