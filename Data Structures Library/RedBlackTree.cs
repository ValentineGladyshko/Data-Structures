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
    public class RedBlackTree<T, T1> : BinaryTree<T, T1>, IBinaryTree<T, T1> where T : IComparable
    {
        private Node<T, T1>? root = null;

        private bool left = false;
        private bool right = false;
        private bool leftRight = false;
        private bool rightLeft = false;

        class Node<T2, T3> : INode<T2, T3> where T2 : IComparable
        {
            public T2 Key { get; set; }
            public T3 Value { get; set; }
            public Color Color { get; set; }
            public Node<T2, T3>? ParentNode { get; set; }
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
                ParentNode = null;
                Color = Color.Red;
                Value = value;
            }
            public Node(T2 key, T3 value, Node<T2, T3> parentNode)
            {
                Key = key;
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = parentNode;
                Color = Color.Red;
            }
            public Node(T2 key, T3 value, Node<T2, T3> parentNode, Color color)
            {
                Key = key;
                Value = value;
                LeftNode = null;
                RightNode = null;
                ParentNode = parentNode;
                Color = color;
            }
            public Node(Node<T2, T3> node)
            {
                Key = node.Key;
                Value = node.Value;
                LeftNode = node.LeftNode;
                RightNode = node.RightNode;
                ParentNode = node.ParentNode;
                Color = node.Color;
            }
        }

        private Color GetColor(Node<T, T1>? node)
        {
            if (node == null)
                return Color.Black;
            else return node.Color;
        }

        private Node<T, T1>? GetSibling(Node<T, T1> node)
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

        private void RotateLeft(Node<T, T1> node)
        {
            if (node.RightNode != null)
            {
                Node<T, T1> temp = new Node<T, T1>(node);

                if (temp.RightNode != null)
                {
                    node.Key = temp.RightNode.Key;
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

        private void RotateRight(Node<T, T1> node)
        {
            if (node.LeftNode != null)
            {
                Node<T, T1> temp = new Node<T, T1>(node);

                if (temp.LeftNode != null)
                {
                    node.Key = temp.LeftNode.Key;
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

        public override void Insert(T key, T1 value)
        {
            if (root == null)
            {
                root = new Node<T, T1>(key, value);
                root.Color = Color.Black;
            }
            else
                root = Insert(key, value, root);
        }
        private Node<T, T1> Insert(T key, T1 value, Node<T, T1>? node)
        {
            bool redConflict = false;
            if (node == null)
                return new Node<T, T1>(key, value);
            else if (key.CompareTo(node.Key) < 0)
            {
                node.LeftNode = Insert(key, value, node.LeftNode);
                node.LeftNode.ParentNode = node;
                if (node != root)
                    if (GetColor(node) == Color.Red && GetColor(node.LeftNode) == Color.Red)
                        redConflict = true;
            }
            else if (key.CompareTo(node.Key) > 0)
            {
                node.RightNode = Insert(key, value, node.RightNode);
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
        private void isValidRedBlackTree(Node<T, T1>? node, ArrayList blackDepthList)
        {
            if (node != null)
            {
                if (node.LeftNode == null || node.RightNode == null)
                {
                    int blackDepth = 1;
                    Node<T, T1> temp = node;
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

        public override void Remove(T key)
        {
            Remove(key, root);
            if (root != null)
                root.Color = Color.Black;
        }
        private void Remove(T key, Node<T, T1>? node)
        {
            if (node == null)
                return;
            else if (key.CompareTo(node.Key) < 0)
                Remove(key, node.LeftNode);
            else if (key.CompareTo(node.Key) > 0)
                Remove(key, node.RightNode);
            else if (key.CompareTo(node.Key) == 0)
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
                    node.Key = node.LeftNode.Key;
                    node.Value = node.LeftNode.Value;
                    var color = node.LeftNode.Color;
                    node.RightNode = node.LeftNode.RightNode;
                    node.LeftNode = node.LeftNode.LeftNode;
                    if (node.LeftNode != null)
                        FixUp(node.LeftNode);
                    else
                        FixUp(new Node<T, T1>(node.Key, node.Value, node, color));
                }
                else if (node.LeftNode == null && node.RightNode != null)
                {
                    node.Key = node.RightNode.Key;
                    node.Value = node.RightNode.Value;
                    var color = node.RightNode.Color;
                    node.LeftNode = node.RightNode.LeftNode;
                    node.RightNode = node.RightNode.RightNode;
                    if (node.RightNode != null)
                        FixUp(node.RightNode);
                    else
                        FixUp(new Node<T, T1>(node.Key, node.Value, node, color));
                }
                else if (node.LeftNode != null && node.RightNode != null)
                {
                    if (node.RightNode.LeftNode == null)
                    {
                        node.Key = node.RightNode.Key;
                        node.Value = node.RightNode.Value;
                        var color = node.RightNode.Color;
                        node.RightNode = node.RightNode.RightNode;
                        if (node.RightNode != null)
                            FixUp(node.RightNode);
                        else
                            FixUp(new Node<T, T1>(node.Key, node.Value, node, color));
                    }
                    else
                    {
                        var temp = MaximumDelete(node.LeftNode, node);
                        node.Key = temp.Key;
                        node.Value = temp.Value;
                        FixUp(temp);
                }
            }
            }
        }

        private Node<T, T1> MaximumDelete(Node<T, T1> node, Node<T, T1> parentNode)
        {
            if (node.RightNode != null)
                return MaximumDelete(node.RightNode, node);
            else
            {
                parentNode.RightNode = node.LeftNode;
                return node;
            }
        }

        private void FixUp(Node<T, T1> node)
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

        public override bool Find(T key)
        {
            return Find(key, root);
        }

        public override void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node<T, T1>? node)
        {
            if (node == null)
            {
                return;
            }

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
            Console.Write("Color: ");
            Console.Write(node.Color);
            Console.Write(" ");
            if (node.Value != null)
            {
                Console.Write(node.Value.ToString());
                Console.Write(" ");
            }
            if (node.ParentNode != null)
            {
                Console.Write("parent: ");
                Console.Write(node.ParentNode.Key.ToString());
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