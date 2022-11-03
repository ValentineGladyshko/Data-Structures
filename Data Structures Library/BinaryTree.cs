using System;
using System.Collections;
using System.Data.SqlTypes;

namespace DataStructures
{
    public class BinaryTree<T, T1> : IBinaryTree<T, T1> where T : IComparable
    {
        private Node<T, T1>? root = null;
        class Node<T2, T3> : INode<T2, T3> where T2 : IComparable
        {
            public T2 Key { get; set; }
            public T3 Value { get; set; }
            public Node<T2, T3>? LeftNode { get; set; }
            public Node<T2, T3>? RightNode { get; set; }
            INode<T2, T3>? INode<T2, T3>.LeftNode { get => LeftNode; set => LeftNode = (Node<T2, T3>?)value; }
            INode<T2, T3>? INode<T2, T3>.RightNode { get => RightNode; set => RightNode = (Node<T2, T3>?)value; }

            public Node(T2 key, T3 value)
            {
                Key = key;
                Value = value;
                LeftNode = null;
                RightNode = null;
            }
        }

        public virtual void Insert(T key, T1 value)
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
        }

        public virtual bool Find(T key)
        {
            return Find(key, root);
        }
        protected bool Find(T key, INode<T, T1>? node)
        {
            if (node == null)
                return false;
            if (key.CompareTo(node.Key) == 0)
                return true;
            else if (key.CompareTo(node.Key) < 0)
                return Find(key, node.LeftNode);
            else
                return Find(key, node.RightNode);
        }

        public virtual void Remove(T key)
        {
            root = Remove(key, root);
        }
        private Node<T, T1>? Remove(T key, Node<T, T1>? node)
        {
            if (node == null)
                return null;
            else if (key.CompareTo(node.Key) < 0)
                node.LeftNode = Remove(key, node.LeftNode);
            else if (key.CompareTo(node.Key) > 0)
                node.RightNode = Remove(key, node.RightNode);
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
                    return node;
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Key = node.RightNode.Key;
                    node.Value = node.RightNode.Value;
                    node.LeftNode = node.RightNode.LeftNode;
                    node.RightNode = node.RightNode.RightNode;
                    return node;
                }
                else if (node.LeftNode != null && node.RightNode != null)
                {
                    if (node.RightNode.LeftNode == null)
                    {
                        node.Key = node.RightNode.Key;
                        node.Value = node.RightNode.Value;
                        node.RightNode = node.RightNode.RightNode;
                        return node;
                    }
                    else
                    {
                        var temp = MinimumDelete(node.RightNode, node);
                        node.Key = temp.Item1;
                        node.Value = temp.Item2;
                        return node;
                    }
                }
            }
            return node;
        }

        public virtual T1? Get(T key)
        {
            return Get(key, root);
        }
        protected T1? Get(T key, INode<T, T1>? node)
        {
            if (node == null)
                return default;
            if (key.CompareTo(node.Key) == 0)
                return node.Value;
            else if (key.CompareTo(node.Key) < 0)
                return Get(key, node.LeftNode);
            else
                return Get(key, node.RightNode);
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

        public virtual (T, T1)? Minimum()
        {
            return Minimum(root);
        }
        protected (T, T1)? Minimum(INode<T, T1>? node)
        {
            if (node == null)
                return null;
            if (node.LeftNode != null)
                return Minimum(node.LeftNode);
            else
                return (node.Key, node.Value);
        }

        public virtual (T, T1)? Maximum()
        {
            return Maximum(root);
        }
        protected (T, T1)? Maximum(INode<T, T1>? node)
        {
            if (node == null)
                return null;
            if (node.RightNode != null)
                return Maximum(node.RightNode);
            else
                return (node.Key, node.Value);
        }

        public virtual List<IComparable> InfixTraverse()
        {
            return InfixTraverse(root);
        }
        protected List<IComparable> InfixTraverse(INode<T, T1>? node)
        {
            List<IComparable> result = new List<IComparable>();

            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverse(node.LeftNode));
            result.Add(node.Key);
            if (node.RightNode != null)
                result.AddRange(InfixTraverse(node.RightNode));

            return result;
        }

        public virtual List<IComparable> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }
        protected List<IComparable> PrefixTraverse(INode<T, T1>? node)
        {
            List<IComparable> result = new List<IComparable>();

            if (node == null)
                return result;

            result.Add(node.Key);
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
        protected List<IComparable> PostfixTraverse(INode<T, T1>? node)
        {
            List<IComparable> result = new List<IComparable>();
            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(PostfixTraverse(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(PostfixTraverse(node.RightNode));
            result.Add(node.Key);

            return result;
        }

        public virtual List<T1> InfixTraverseValues()
        {
            return InfixTraverseValues(root);
        }
        protected List<T1> InfixTraverseValues(INode<T, T1>? node)
        {
            List<T1> result = new List<T1>();

            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverseValues(node.LeftNode));
            result.Add(node.Value);
            if (node.RightNode != null)
                result.AddRange(InfixTraverseValues(node.RightNode));

            return result;
        }

        public virtual List<T1> PrefixTraverseValues()
        {
            return PrefixTraverseValues(root);
        }
        protected List<T1> PrefixTraverseValues(INode<T, T1>? node)
        {
            List<T1> result = new List<T1>();

            if (node == null)
                return result;

            result.Add(node.Value);
            if (node.LeftNode != null)
                result.AddRange(InfixTraverseValues(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(InfixTraverseValues(node.RightNode));
            return result;
        }

        public virtual List<T1> PostfixTraverseValues()
        {
            return PostfixTraverseValues(root);
        }
        protected List<T1> PostfixTraverseValues(INode<T, T1>? node)
        {
            List<T1> result = new List<T1>();

            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverseValues(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(InfixTraverseValues(node.RightNode));
            result.Add(node.Value);

            return result;
        }

        public virtual void Traverse()
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
            Console.WriteLine(" ");

            if (node.LeftNode != null)
                Traverse(node.LeftNode);

            if (node.RightNode != null)
                Traverse(node.RightNode);
        }
    }
}
