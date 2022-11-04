namespace DataStructures
{
    enum Color
    {
        Red,
        Black
    }
    public class LeftLeaningRedBlackTree<T, T1> : BinaryTree<T, T1>, IBinaryTree<T, T1> where T : IComparable
    {
        private Node<T, T1>? root = null;
        class Node<T2, T3> : INode<T2, T3> where T2 : IComparable
        {
            public T2 Key { get; set; }
            public T3 Value { get; set; }
            public Color Color { get; set; }
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
                Color = Color.Red;
            }
        }
        private Color GetColor(Node<T, T1>? node)
        {
            if (node == null)
                return Color.Black;
            else return node.Color;
        }

        private Node<T, T1> RotateLeft(Node<T, T1> node)
        {
            if (node.RightNode != null)
            {
                Node<T, T1> child = node.RightNode;

                node.RightNode = child.LeftNode;
                child.LeftNode = node;

                child.Color = child.LeftNode.Color;
                child.LeftNode.Color = Color.Red;

                return child;
            }
            return node;


        }

        private Node<T, T1> RotateRight(Node<T, T1> node)
        {
            if (node.LeftNode != null)
            {
                Node<T, T1> child = node.LeftNode;

                node.LeftNode = child.RightNode;
                child.RightNode = node;

                child.Color = child.RightNode.Color;
                child.RightNode.Color = Color.Red;

                return child;
            }
            return node;
        }

        private void SwapColors(Node<T, T1> node)
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

        private Node<T, T1> MoveRedLeft(Node<T, T1> node)
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

        private Node<T, T1> MoveRedRight(Node<T, T1> node)
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

        private Node<T, T1> Balance(Node<T, T1> node)
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

        private Node<T, T1> FixUp(Node<T, T1> node)
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

        public override void Insert(T key, T1 value)
        {
            root = Insert(key, value, root);
            root.Color = Color.Black;
        }
        private Node<T, T1> Insert(T key, T1 value, Node<T, T1>? node)
        {
            if (node == null)
                return node = new Node<T, T1>(key, value);
            else if (key.CompareTo(node.Key) < 0)
                node.LeftNode = Insert(key, value, node.LeftNode);
            else if (key.CompareTo(node.Key) > 0)
                node.RightNode = Insert(key, value, node.RightNode);
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

        public override void Remove(T key)
        {
            if (root == null)
                return;
            if (Find(key) == false)
                return;
            if (GetColor(root.LeftNode) == Color.Black && GetColor(root.RightNode) == Color.Black)
                root.Color = Color.Red;
            root = Remove(key, root);
            if (root != null)
                root.Color = Color.Black;
        }
        private Node<T, T1>? Remove(T key, Node<T, T1> node)
        {
            if (key.CompareTo(node.Key) < 0)
            {
                if (node.LeftNode != null)
                {
                    if (GetColor(node.LeftNode) == Color.Black && GetColor(node.LeftNode.LeftNode) == Color.Black)
                        node = MoveRedLeft(node);
                }
                if (node.LeftNode != null)
                    node.LeftNode = Remove(key, node.LeftNode);
            }
            else
            {
                if (GetColor(node.LeftNode) == Color.Red)
                    node = RotateRight(node);
                if (key.CompareTo(node.Key) == 0 && (node.RightNode == null))
                    return null;
                if (node.RightNode != null)
                {
                    if (GetColor(node.RightNode) == Color.Black && GetColor(node.RightNode.LeftNode) == Color.Black)
                        node = MoveRedRight(node);
                }
                if (key.CompareTo(node.Key) == 0)
                {
                    var temp = Minimum(node.RightNode);
                    if (temp != null)
                    {
                        node.Key = temp.Value.Item1;
                        node.Value = temp.Value.Item2;
                        node.RightNode = MinimumDelete(node.RightNode);
                    }
                }
                else
                {
                    if (node.RightNode == null)
                        return null;
                    node.RightNode = Remove(key, node.RightNode);
                }
            }
            return Balance(node);
        }

        private Node<T, T1>? MinimumDelete(Node<T, T1>? node)
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

        public override bool Find(T key)
        {
            return Find(key, root);
        }

        public override T1? Get(T key)
        {
            return Get(key, root);
        }

        public override (T, T1)? Minimum()
        {
            return Minimum(root);
        }

        public override (T, T1)? Maximum()
        {
            return Maximum(root);
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

        public override List<T1> InfixTraverseValues()
        {
            return InfixTraverseValues(root);
        }

        public override List<T1> PrefixTraverseValues()
        {
            return PrefixTraverseValues(root);
        }

        public override List<T1> PostfixTraverseValues()
        {
            return PostfixTraverseValues(root);
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
            if (node.Value != null)
            {
                Console.Write(node.Value.ToString());
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
