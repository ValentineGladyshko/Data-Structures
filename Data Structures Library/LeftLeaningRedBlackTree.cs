using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    enum Color
    {
        Red,
        Black
    }
    public class LeftLeaningRedBlackTree<T> : BinaryTree<T>, IBinaryTree<T> where T : IComparable
    {
        private Node? root = null;
        class Node : INode
        {
            public IComparable Value { get; set; }
            public Color Color { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(T value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                Color = Color.Red;
            }
        }
        private Color GetColor(Node? node)
        {
            if (node == null)
                return Color.Black;
            else return node.Color;
        }

        private Node RotateLeft(Node node)
        {
            if (node.RightNode != null)
            {
                Node child = node.RightNode;

                node.RightNode = child.LeftNode;
                child.LeftNode = node;

                child.Color = child.LeftNode.Color;
                child.LeftNode.Color = Color.Red;

                return child;
            }
            return node;


        }

        private Node RotateRight(Node node)
        {
            if (node.LeftNode != null)
            {
                Node child = node.LeftNode;

                node.LeftNode = child.RightNode;
                child.RightNode = node;

                child.Color = child.RightNode.Color;
                child.RightNode.Color = Color.Red;

                return child;
            }
            return node;
        }

        private void SwapColors(Node node)
        {
            if (node.Color == Color.Red)
                node.Color = Color.Black;
            else
                node.Color = Color.Red;
            if (node.RightNode != null)
            {
                if (node.RightNode.Color == Color.Red)
                    node.RightNode.Color = Color.Black;
                else
                    node.RightNode.Color = Color.Red;
            }
            if (node.LeftNode != null)
            {
                if (node.LeftNode.Color == Color.Red)
                    node.LeftNode.Color = Color.Black;
                else
                    node.LeftNode.Color = Color.Red;
            }
        }

        private Node MoveRedLeft(Node node)
        {
            SwapColors(node);
            if (node.RightNode != null)
            {
                if (GetColor(node.RightNode.LeftNode) == Color.Red)
                {
                    node.RightNode = RotateRight(node.RightNode);
                    node = RotateLeft(node);
                    SwapColors(node);
                }
            }
            return node;
        }

        private Node MoveRedRight(Node node)
        {
            SwapColors(node);
            if (node.LeftNode != null)
            {
                if (GetColor(node.LeftNode.LeftNode) == Color.Red)
                {
                    node = RotateRight(node);
                    SwapColors(node);
                }
            }
            return node;
        }

        private Node Balance(Node node)
        {
            if (GetColor(node.RightNode) == Color.Red && GetColor(node.LeftNode) == Color.Black)
                node = RotateLeft(node);
            if (node.LeftNode != null)
            {
                if (GetColor(node.LeftNode) == Color.Red && GetColor(node.LeftNode.LeftNode) == Color.Red)
                    node = RotateRight(node);
            }
            if (GetColor(node.LeftNode) == Color.Red && GetColor(node.RightNode) == Color.Red)
                SwapColors(node);
            return node;
        }

        private Node FixUp(Node node)
        {
            if (GetColor(node.RightNode) == Color.Red)
                node = RotateLeft(node);
            if (node.LeftNode != null)
            {
                if (GetColor(node.LeftNode) == Color.Red && GetColor(node.LeftNode.LeftNode) == Color.Red)
                    node = RotateRight(node);
            }
            if (GetColor(node.LeftNode) == Color.Red && GetColor(node.RightNode) == Color.Red)
                SwapColors(node);
            return node;
        }

        public override void Insert(T value)
        {
            root = Insert(value, root);
            root.Color = Color.Black;
        }
        private Node Insert(T value, Node? node)
        {
            if (node == null)
                return node = new Node(value);
            else if (value.CompareTo(node.Value) < 0)
                node.LeftNode = Insert(value, node.LeftNode);
            else if (value.CompareTo(node.Value) > 0)
                node.RightNode = Insert(value, node.RightNode);
            else return node;

            if (GetColor(node.RightNode) == Color.Red && GetColor(node.LeftNode) == Color.Black)
                node = RotateLeft(node);

            if (node.LeftNode != null)
            {
                if (GetColor(node.LeftNode.LeftNode) == Color.Red && GetColor(node.LeftNode) == Color.Red)
                    node = RotateRight(node);
            }
            if (GetColor(node.RightNode) == Color.Red && GetColor(node.LeftNode) == Color.Red && node.RightNode != null && node.LeftNode != null)
            {
                node.Color = Color.Red;

                node.RightNode.Color = Color.Black;
                node.LeftNode.Color = Color.Black;
            }
            return node;
        }

        public override void Remove(T value)
        {
            if (root == null)
                return;
            if (Find(value) == false)
                return;
            if (GetColor(root.LeftNode) == Color.Black && GetColor(root.RightNode) == Color.Black)
                root.Color = Color.Red;
            root = Remove(value, root);
            if (root != null)
                root.Color = Color.Black;
        }
        private Node? Remove(T value, Node node)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode != null)
                {
                    if (GetColor(node.LeftNode) == Color.Black && GetColor(node.LeftNode.LeftNode) == Color.Black)
                        node = MoveRedLeft(node);
                }
                if (node.LeftNode != null)
                    node.LeftNode = Remove(value, node.LeftNode);
            }
            else
            {
                if (GetColor(node.LeftNode) == Color.Red)
                    node = RotateRight(node);
                if (value.CompareTo(node.Value) == 0 && (node.RightNode == null))
                    return null;
                if (node.RightNode != null)
                {
                    if (GetColor(node.RightNode) == Color.Black && GetColor(node.RightNode.LeftNode) == Color.Black)
                        node = MoveRedRight(node);
                }
                if (value.CompareTo(node.Value) == 0)
                {
                    IComparable? temp = Minimum(node.RightNode);
                    if (temp != null)
                    {
                        node.Value = temp;
                        node.RightNode = MinimumDelete(node.RightNode);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                        return null;
                    node.RightNode = Remove(value, node.RightNode);
                }
            }
            return Balance(node);
        }

        public void MinimumDelete()
        {
            root = MinimumDelete(root);
            if (root != null)
            {
                root.Color = Color.Black;
            }
        }
        private Node? MinimumDelete(Node? node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.LeftNode == null)
            {
                return null;
            }
            if (GetColor(node.LeftNode) == Color.Black && GetColor(node.LeftNode.LeftNode) == Color.Black)
            {
                node = MoveRedLeft(node);
            }
            node.LeftNode = MinimumDelete(node.LeftNode);
            return FixUp(node);
        }

        public override bool Find(T value)
        {
            return Find(value, root);
        }

        public override T? Minimum()
        {
            return (T?)Minimum(root);
        }        

        public override T? Maximum()
        {
            return (T?)Maximum(root);
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
        private void Traverse(Node? node)
        {
            if (node == null)
            {
                return;
            }

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
            Console.Write("Color: ");
            Console.Write(node.Color);
            Console.Write(" ");
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
