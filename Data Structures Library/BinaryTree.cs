using System;

namespace DataStructures
{
    public class BinaryTree : IBinaryTree
    {
        private Node? root = null;
        class Node : INode
        {
            public int Value { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(int value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
            }
        }

        public virtual void Insert(int value)
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
        }

        public virtual bool Find(int value)
        {
            return Find(value, root);
        }
        protected bool Find(int value, INode? node)
        {
            if (node == null)
                return false;
            if (node.Value == value)
                return true;
            else if (value < node.Value)
                return Find(value, node.LeftNode);
            else
                return Find(value, node.RightNode);
        }

        public virtual void Remove(int value)
        {
            root = Remove(value, root);
        }
        private Node? Remove(int value, Node? node)
        {
            if (node == null)
                return null;
            else if (value < node.Value)
                node.LeftNode = Remove(value, node.LeftNode);
            else if (value > node.Value)
                node.RightNode = Remove(value, node.RightNode);
            else if (value == node.Value)
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

        public virtual int? Minimum()
        {
            return Minimum(root);
        }
        protected int? Minimum(INode? node)
        {
            if (node == null)
                return null;
            if (node.LeftNode != null)
                return Minimum(node.LeftNode);
            else
                return node.Value;
        }

        public virtual int? Maximum()
        {
            return Maximum(root);
        }
        protected int? Maximum(INode? node)
        {
            if (node == null)
                return null;
            if (node.RightNode != null)
                return Maximum(node.RightNode);
            else
                return node.Value;
        }

        public virtual List<int> InfixTraverse()
        {
            return InfixTraverse(root);
        }
        protected List<int> InfixTraverse(INode? node)
        {
            List<int> result = new List<int>();

            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverse(node.LeftNode));
            result.Add(node.Value);
            if (node.RightNode != null)
                result.AddRange(InfixTraverse(node.RightNode));
            return result;
        }

        public virtual List<int> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }
        protected List<int> PrefixTraverse(INode? node)
        {
            List<int> result = new List<int>();

            if (node == null)
                return result;

            result.Add(node.Value);
            if (node.LeftNode != null)
                result.AddRange(InfixTraverse(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(InfixTraverse(node.RightNode));

            return result;
        }

        public virtual List<int> PostfixTraverse()
        {
            return PostfixTraverse(root);
        }
        protected List<int> PostfixTraverse(INode? node)
        {
            List<int> result = new List<int>();
            if (node == null)
                return result;

            if (node.LeftNode != null)
                result.AddRange(InfixTraverse(node.LeftNode));
            if (node.RightNode != null)
                result.AddRange(InfixTraverse(node.RightNode));
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
            Console.WriteLine(" ");

            if (node.LeftNode != null)
                Traverse(node.LeftNode);

            if (node.RightNode != null)
                Traverse(node.RightNode);
        }
    }
}
