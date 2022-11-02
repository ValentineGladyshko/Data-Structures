using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class RedBlackTree<T> : BinaryTree<T>, IBinaryTree<T> where T : IComparable
    {
        private Node? root = null;

        private bool left = false;
        private bool right = false;
        private bool leftRight = false;
        private bool rightLeft = false;

        class Node : INode
        {
            public IComparable Value { get; set; }
            public Color Color { get; set; }
            public Node? ParentNode { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }
            INode? INode.LeftNode { get => LeftNode; set => LeftNode = (Node?)value; }
            INode? INode.RightNode { get => RightNode; set => RightNode = (Node?)value; }

            public Node(T value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = null;
                Color = Color.Red;
            }
            public Node(T value, Node parentNode)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = parentNode;
                Color = Color.Red;
            }
            public Node(T value, Node parentNode, Color color)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = parentNode;
                Color = color;
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

        private Node? GetSibling(Node node)
        {
            if (node.ParentNode == null)
                return null;
            else
            {
                if (node.ParentNode.LeftNode == node)
                    return node.ParentNode.RightNode;
                else if (node.ParentNode.RightNode == node)
                    return node.ParentNode.LeftNode;
                else if (node.ParentNode.LeftNode == null && node.ParentNode.RightNode != null)
                    return node.ParentNode.RightNode;
                else if (node.ParentNode.RightNode == null && node.ParentNode.LeftNode != null)
                    return node.ParentNode.LeftNode;
                else
                    return null;
            }
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

        public override void Insert(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                root.Color = Color.Black;
            }
            else
                root = Insert(value, root);
        }
        private Node Insert(T value, Node? node)
        {
            bool redConflict = false;
            if (node == null)
                return new Node(value);
            else if (value.CompareTo(node.Value) < 0)
            {
                node.LeftNode = Insert(value, node.LeftNode);
                node.LeftNode.ParentNode = node;
                if (node != root)
                    if (GetColor(node) == Color.Red && GetColor(node.LeftNode) == Color.Red)
                        redConflict = true;
            }
            else if (value.CompareTo(node.Value) > 0)
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

        public override void Remove(T value)
        {
            Remove(value, root);
            if (root != null)
                root.Color = Color.Black;
        }
        private void Remove(T value, Node? node)
        {
            if (node == null)
                return;
            else if (value.CompareTo(node.Value) < 0)
                Remove(value, node.LeftNode);
            else if (value.CompareTo(node.Value) > 0)
                Remove(value, node.RightNode);
            else if (value.CompareTo(node.Value) == 0)
            {
                if (node.LeftNode == null && node.RightNode == null)
                {
                    if (node.ParentNode != null)
                    {
                        if (node.ParentNode.LeftNode == node)
                            node.ParentNode.LeftNode = null;
                        else if (node.ParentNode.RightNode == node)
                            node.ParentNode.RightNode = null;

                        FixUp(node);
                    }
                }
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node.Value = node.LeftNode.Value;
                    var color = node.LeftNode.Color;
                    node.RightNode = node.LeftNode.RightNode;
                    node.LeftNode = node.LeftNode.LeftNode;
                    if (node.LeftNode != null)
                        FixUp(node.LeftNode);
                    else
                        FixUp(new Node((T)node.Value, node, color));
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Value = node.RightNode.Value;
                    var color = node.RightNode.Color;
                    node.LeftNode = node.RightNode.LeftNode;
                    node.RightNode = node.RightNode.RightNode;
                    if (node.RightNode != null)
                        FixUp(node.RightNode);
                    else
                        FixUp(new Node((T)node.Value, node, color));
                }
                else if (node.LeftNode != null && node.RightNode != null)
                {
                    if (node.RightNode.LeftNode == null)
                    {
                        node.Value = node.RightNode.Value;
                        var color = node.RightNode.Color;
                        node.RightNode = node.RightNode.RightNode;
                        if (node.RightNode != null)
                            FixUp(node.RightNode);
                        else
                            FixUp(new Node((T)node.Value, node, color));
                    }
                    else
                    {
                        var temp = MaximumDelete(node.LeftNode, node);
                        node.Value = temp.Value;
                        FixUp(temp);
                }
            }
            }
        }

        private Node MaximumDelete(Node node, Node parentNode)
        {
            if (node.RightNode != null)
                return MaximumDelete(node.RightNode, node);
            else
            {
                parentNode.RightNode = node.LeftNode;
                return node;
            }
        }

        private void FixUp(Node node)
        {
            if (GetColor(node) == Color.Red && node.RightNode == null && node.LeftNode == null)
                return;

            if (node == root)
            {
                return;
            }

            var sibling = GetSibling(node);
            if (GetColor(node) == Color.Black && sibling != null && GetColor(sibling) == Color.Black && GetColor(sibling.LeftNode) == Color.Black && GetColor(sibling.RightNode) == Color.Black)
            {
                sibling.Color = Color.Red;
                if (node.ParentNode != null)
                {
                    if (GetColor(node.ParentNode) == Color.Black)
                        FixUp(node.ParentNode);
                    else
                        node.ParentNode.Color = Color.Black;
                }
                return;
            }

            if (GetColor(node) == Color.Black && sibling != null && GetColor(sibling) == Color.Red)
            {
                if (node.ParentNode != null)
                {
                    sibling.Color = node.ParentNode.Color;
                    node.ParentNode.Color = Color.Black;
                    if (sibling == node.ParentNode.LeftNode)
                    {
                        RotateRight(node.ParentNode);
                        FixUp(node.ParentNode);
                    }
                    else
                    {
                        RotateLeft(node.ParentNode);
                        FixUp(node.ParentNode);
                    }
                }
                return;
            }
            if (GetColor(node) == Color.Black && sibling != null && GetColor(sibling) == Color.Black && GetColor(sibling.LeftNode) == Color.Black && GetColor(sibling.RightNode) == Color.Black)
            {
                return;
            }
            if (GetColor(node) == Color.Black && sibling != null && GetColor(sibling) == Color.Black)
            {
                if (node.ParentNode != null)
                {
                    if (sibling == node.ParentNode.LeftNode)
                    {
                        if (GetColor(sibling.LeftNode) == Color.Black && sibling.RightNode != null && GetColor(sibling.RightNode) == Color.Red)
                        {
                            sibling.RightNode.Color = sibling.Color;
                            sibling.Color = Color.Red;
                            RotateLeft(sibling);
                        }
                    }
                    else
                    {
                        if (GetColor(sibling.RightNode) == Color.Black && sibling.LeftNode != null && GetColor(sibling.LeftNode) == Color.Red)
                        {
                            sibling.LeftNode.Color = sibling.Color;
                            sibling.Color = Color.Red;
                            RotateRight(sibling);
                        }
                    }
                }
            }
            if (GetColor(node) == Color.Black && sibling != null && GetColor(sibling) == Color.Black)
            {
                if (node.ParentNode != null)
                {
                    if (sibling == node.ParentNode.LeftNode)
                    {
                        if (GetColor(sibling.LeftNode) == Color.Red)
                        {
                            var temp = sibling.LeftNode;
                            sibling.Color = node.ParentNode.Color;
                            node.ParentNode.Color = Color.Black;
                            RotateRight(node.ParentNode);
                            if (temp != null)
                                temp.Color = Color.Black;
                        }
                    }
                    else
                    {
                        if (GetColor(sibling.RightNode) == Color.Red)
                        {
                            var temp = sibling.RightNode;
                            sibling.Color = node.ParentNode.Color;
                            node.ParentNode.Color = Color.Black;
                            RotateLeft(node.ParentNode);
                            if (temp != null)
                                temp.Color = Color.Black;
                        }
                    }
                }
                return;
            }
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
            if (node.ParentNode != null)
            {
                Console.Write("parent: ");
                Console.Write(node.ParentNode.Value.ToString());
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