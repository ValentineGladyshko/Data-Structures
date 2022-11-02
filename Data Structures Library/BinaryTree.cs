using System;
using System.Collections;
using System.Data.SqlTypes;

namespace DataStructures
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        private Node? root = null;
        class Node : INode
        {
            public IComparable Value { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(T value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
            }
        }

        public virtual void Insert(T value)
        {
            Insert(value, root);
        }
        private void Insert(T value, Node? node)
        {
            if (root == null)
                root = new Node(value);
            if (node == null)
                node = new Node(value);
            else if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                    node.LeftNode = new Node(value);
                else Insert(value, node.LeftNode);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                if (node.RightNode == null)
                    node.RightNode = new Node(value);
                else Insert(value, node.RightNode);
            }
        }

        public virtual bool Find(T value)
        {
            return Find(value, root);
        }
        protected bool Find(T value, INode? node)
        {
            if (node == null)
                return false;
            if (value.CompareTo(node.Value) == 0)
                return true;
            else if (value.CompareTo(node.Value) < 0)
                return Find(value, node.LeftNode);
            else
                return Find(value, node.RightNode);
        }

        public virtual void Remove(T value)
        {
            root = Remove(value, root);
        }
        private Node? Remove(T value, Node? node)
        {
            if (node == null)
                return null;
            else if (value.CompareTo(node.Value) < 0)
                node.LeftNode = Remove(value, node.LeftNode);
            else if (value.CompareTo(node.Value) > 0)
                node.RightNode = Remove(value, node.RightNode);
            else if (value.CompareTo(node.Value) == 0)
            {
                if (node.LeftNode == null && node.RightNode == null)
                    return null;
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node.Value = node.LeftNode.Value;
                    node.RightNode = node.LeftNode.RightNode;
                    node.LeftNode = node.LeftNode.LeftNode;
                    return node;
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Value = node.RightNode.Value;
                    node.LeftNode = node.RightNode.LeftNode;
                    node.RightNode = node.RightNode.RightNode;
                    return node;
                }
                else if (node.LeftNode != null && node.RightNode != null)
                {
                    if (node.RightNode.LeftNode == null)
                    {
                        node.Value = node.RightNode.Value;
                        node.RightNode = node.RightNode.RightNode;
                        return node;
                    }
                    else
                    {
                        node.Value = MinimumDelete(node.RightNode, node);
                        return node;
                    }
                }
            }
            return node;
        }

        private IComparable MinimumDelete(Node node, Node parentNode)
        {
            if (node.LeftNode != null)
                return MinimumDelete(node.LeftNode, node);
            else
            {
                parentNode.LeftNode = node.RightNode;
                return node.Value;
            }
        }

        public virtual T? Minimum()
        {
            return (T?)Minimum(root);
        }
        protected IComparable? Minimum(INode? node)
        {
            if (node == null)
                return null;
            if (node.LeftNode != null)
                return Minimum(node.LeftNode);
            else
                return node.Value;
        }

        public virtual T? Maximum()
        {
            return (T?)Maximum(root);
        }
        protected IComparable? Maximum(INode? node)
        {
            if (node == null)
                return null;
            if (node.RightNode != null)
                return Maximum(node.RightNode);
            else
                return node.Value;
        }

        public virtual List<IComparable> InfixTraverse()
        {
            return InfixTraverse(root);
        }
        protected List<IComparable> InfixTraverse(INode? node)
        {
            List<IComparable> result = new List<IComparable>();

            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverse(node.LeftNode));
            result.Add((T)node.Value);
            if (node.RightNode != null)
                result.AddRange(InfixTraverse(node.RightNode));
            return result;
        }

        public virtual List<IComparable> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }
        protected List<IComparable> PrefixTraverse(INode? node)
        {
            List<IComparable> result = new List<IComparable>();

            if (node == null)
                return result;

            result.Add(node.Value);
            if (node.LeftNode != null)
                result.AddRange(PrefixTraverse(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(PrefixTraverse(node.RightNode));

            return result;
        }

        public virtual List<IComparable> PostfixTraverse()
        {
            return PostfixTraverse(root);
        }
        protected List<IComparable> PostfixTraverse(INode? node)
        {
            List<IComparable> result = new List<IComparable>();
            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(PostfixTraverse(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(PostfixTraverse(node.RightNode));
            result.Add(node.Value);

            return result;
        }

        public virtual void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node? node)
        {
            if (node == null)
                return;

            Console.Write(node.Value.ToString());
            Console.Write(" ");
            if (node.LeftNode != null)
            {
                Console.Write("left: ");
                Console.Write(node.LeftNode.Value.ToString());
                Console.Write(" ");
            }
            if (node.RightNode != null)
            {
                Console.Write("right: ");
                Console.Write(node.RightNode.Value.ToString());
                Console.Write(" ");
            }
            Console.WriteLine(" ");

            if (node.LeftNode != null)
                Traverse(node.LeftNode);

            if (node.RightNode != null)
                Traverse(node.RightNode);
        }
    }
}
