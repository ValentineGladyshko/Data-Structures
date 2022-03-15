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
	public class LeftLeaningRedBlackTree
	{
		private Node? root = null;
		class Node
		{
			public int Value { get; set; }
			public Color Color { get; set; }
			public Node? LeftNode { get; set; }
			public Node? RightNode { get; set; }

			public Node(int value)
			{
				Value = value;
				LeftNode = null;
				RightNode = null;
				Color = Color.Red;
			}
		}

		public void Insert(int value)
		{
			root = Insert(value, root);
			root.Color = Color.Black;
		}

		public void Remove(int value)
		{
			if (root == null)
			{
				return;
			}
			if (Find(value) == false)
			{
				return;
			}
			if (GetColor(root.LeftNode) == Color.Black && GetColor(root.RightNode) == Color.Black)
			{
				root.Color = Color.Red;
			}
			root = Remove(value, root);
			if (root != null)
			{
				root.Color = Color.Black;
			}

		}

		private Color GetColor(Node? node)
		{
			if (node == null)
			{
				return Color.Black;
			}
			else return node.Color;
		}

		private Node Insert(int value, Node? node)
		{
			if (node == null)
			{
				return node = new Node(value);
			}
			else if (value < node.Value)
			{
				node.LeftNode = Insert(value, node.LeftNode);
			}
			else if (value > node.Value)
			{
				node.RightNode = Insert(value, node.RightNode);
			}
			else return node;

			if (GetColor(node.RightNode) == Color.Red && GetColor(node.LeftNode) == Color.Black)
			{
				node = RotateLeft(node);
			}

			if (node.LeftNode != null)
			{
				if (GetColor(node.LeftNode.LeftNode) == Color.Red && GetColor(node.LeftNode) == Color.Red)
				{
					node = RotateRight(node);
				}
			}
			if (GetColor(node.RightNode) == Color.Red && GetColor(node.LeftNode) == Color.Red && node.RightNode != null && node.LeftNode != null)
			{
				node.Color = Color.Red;

				node.RightNode.Color = Color.Black;
				node.LeftNode.Color = Color.Black;
			}
			return node;
		}

		public bool Find(int value)
		{
			return Find(value, root);
		}

		private bool Find(int value, Node? node)
		{
			if (node == null)
			{
				return false;
			}
			if (node.Value == value)
			{
				return true;
			}
			else if (value < node.Value)
			{
				if (node.LeftNode == null)
					return false;
				else return Find(value, node.LeftNode);
			}
			else
			{
				if (node.RightNode == null)
					return false;
				else return Find(value, node.RightNode);
			}
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
			{
				node.Color = Color.Black;
			}
			else
			{
				node.Color = Color.Red;
			}
			if (node.RightNode != null)
			{
				if (node.RightNode.Color == Color.Red)
				{
					node.RightNode.Color = Color.Black;
				}
				else
				{
					node.RightNode.Color = Color.Red;
				}
			}
			if (node.LeftNode != null)
			{
				if (node.LeftNode.Color == Color.Red)
				{
					node.LeftNode.Color = Color.Black;
				}
				else
				{
					node.LeftNode.Color = Color.Red;
				}
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
			{
				node = RotateLeft(node);
			}
			if (node.LeftNode != null)
			{
				if (GetColor(node.LeftNode) == Color.Red && GetColor(node.LeftNode.LeftNode) == Color.Red)
				{
					node = RotateRight(node);
				}
			}
			if (GetColor(node.LeftNode) == Color.Red && GetColor(node.RightNode) == Color.Red)
			{
				SwapColors(node);
			}
			return node;
		}

		private Node FixUp(Node node)
		{
			if (GetColor(node.RightNode) == Color.Red)
			{
				node = RotateLeft(node);
			}
			if (node.LeftNode != null)
			{
				if (GetColor(node.LeftNode) == Color.Red && GetColor(node.LeftNode.LeftNode) == Color.Red)
				{
					node = RotateRight(node);
				}
			}
			if (GetColor(node.LeftNode) == Color.Red && GetColor(node.RightNode) == Color.Red)
			{
				SwapColors(node);
			}
			return node;
		}

		private Node? Remove(int value, Node node)
		{
			if (value < node.Value)
			{
				if (node.LeftNode != null)
				{
					if (GetColor(node.LeftNode) == Color.Black && GetColor(node.LeftNode.LeftNode) == Color.Black)
					{
						node = MoveRedLeft(node);
					}
				}
				if (node.LeftNode != null)
				{
					node.LeftNode = Remove(value, node.LeftNode);
				}
			}
			else
			{
				if (GetColor(node.LeftNode) == Color.Red)
				{
					node = RotateRight(node);
				}
				if (value == node.Value && (node.RightNode == null))
				{
					return null;
				}
				if (node.RightNode != null)
				{
					if (GetColor(node.RightNode) == Color.Black && GetColor(node.RightNode.LeftNode) == Color.Black)
					{
						node = MoveRedRight(node);
					}
				}
				if (value == node.Value)
				{
					int? temp = Minimum(node.RightNode);
					if (temp != null)
					{
						node.Value = (int)temp;
						node.RightNode = MinimumDelete(node.RightNode);
					}
				}
				else
				{
					if (node.RightNode == null)
					{
						return null;
					}
					node.RightNode = Remove(value, node.RightNode);
				}
			}
			return Balance(node);
		}

		public int? Minimum()
		{
			return Minimum(root);
		}

		private int? Minimum(Node? node)
		{
			if (node == null)
				return null;
			if (node.LeftNode != null)
			{
				return Minimum(node.LeftNode);
			}
			else
			{
				return node.Value;
			}
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

		public int? Maximum()
		{
			return Maximum(root);
		}

		private int? Maximum(Node? node)
		{
			if (node == null)
				return null;
			if (node.RightNode != null)
			{
				return Maximum(node.RightNode);
			}
			else
			{
				return node.Value;
			}
		}


		public List<int> InfixTraverse()
		{
			return InfixTraverse(root);
		}

		private List<int> InfixTraverse(Node? node)
		{
			List<int> result = new List<int>();

			if (node == null)
			{
				return result;
			}

			if (node.LeftNode != null)
			{
				result.AddRange(InfixTraverse(node.LeftNode));
			}

			result.Add(node.Value);

			if (node.RightNode != null)
			{
				result.AddRange(InfixTraverse(node.RightNode));
			}
			return result;
		}

		public List<int> PrefixTraverse()
		{
			return PrefixTraverse(root);
		}

		private List<int> PrefixTraverse(Node? node)
		{
			List<int> result = new List<int>();

			if (node == null)
			{
				return result;
			}

			result.Add(node.Value);

			if (node.LeftNode != null)
			{
				result.AddRange(InfixTraverse(node.LeftNode));
			}

			if (node.RightNode != null)
			{
				result.AddRange(InfixTraverse(node.RightNode));
			}
			return result;
		}

		public List<int> PostfixTraverse()
		{
			return PostfixTraverse(root);
		}

		private List<int> PostfixTraverse(Node? node)
		{
			List<int> result = new List<int>();
			if (node == null)
			{
				return result;
			}

			if (node.LeftNode != null)
			{
				result.AddRange(InfixTraverse(node.LeftNode));
			}

			if (node.RightNode != null)
			{
				result.AddRange(InfixTraverse(node.RightNode));
			}

			result.Add(node.Value);

			return result;
		}

		public void Traverse()
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
