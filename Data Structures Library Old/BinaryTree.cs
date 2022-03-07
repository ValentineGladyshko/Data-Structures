using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BinaryTree
	{
		public BinaryTree()
		{ }
		public BinaryTree(int value)
		{
			Value = value;
		}
		public int? Value { get; set; }
		public BinaryTree LeftNode { get; set; }
		public BinaryTree RightNode { get; set; }

		public void Insert(int value)
		{
			if (Value == null)
			{
				Value = value;
			}
			else if (value < Value)
			{
				if (LeftNode == null)
					LeftNode = new BinaryTree(value);
				else LeftNode.Insert(value);
			}
			else if (value > Value)
			{
				if (RightNode == null)
					RightNode = new BinaryTree(value);
				else RightNode.Insert(value);
			}
			else
			{ }
		}

		public bool Find(int value)
		{
			if (Value == null)
			{
				return false;
			}
			if (Value == value)
			{
				return true;
			}
			else if (value < Value)
			{
				if (LeftNode == null)
					return false;
				else return LeftNode.Find(value);
			}
			else
			{
				if (RightNode == null)
					return false;
				else return RightNode.Find(value);
			}
		}

		public bool Remove(int value)
		{
			return Remove(value, this);
		}

		public bool Remove(int value, BinaryTree parentNode)
		{
			if (Value == null)
			{
				return false;
			}
			else if (value < Value)
			{
				if (LeftNode == null)
					return false;
				else return LeftNode.Remove(value, this);
			}
			else if (value > Value)
			{
				if (RightNode == null)
					return false;
				else return RightNode.Remove(value, this);
			}
			else if (value == Value)
			{
				if (LeftNode == null && RightNode == null)
				{
					if (parentNode.LeftNode == this)
					{
						parentNode.LeftNode = null;
					}
					if (parentNode.RightNode == this)
					{
						parentNode.RightNode = null;
					}
					Value = null;
					return true;
				}
				else if (LeftNode != null && RightNode == null)
				{
					Value = LeftNode.Value;
					RightNode = LeftNode.RightNode;
					LeftNode = LeftNode.LeftNode;
					return true;
				}
				else if (LeftNode == null && RightNode != null)
				{
					Value = RightNode.Value;
					LeftNode = RightNode.LeftNode;
					RightNode = RightNode.RightNode;					
					return true;
				}
				else if (LeftNode != null && RightNode != null)
				{
					if (RightNode.LeftNode == null)
					{
						Value = RightNode.Value;
						RightNode = RightNode.RightNode;
						return true;
					}
					else
					{
						Value = RightNode.MinimumDelete(this);
						return true;
					}
				}
			}
			return false;
		}

		public int? MinimumDelete(BinaryTree parentNode)
		{
			if (LeftNode != null)
			{
				return LeftNode.MinimumDelete(this);
			}
			else
			{
				parentNode.LeftNode = RightNode;
				return Value;
			}
		}

		public int? Minimum()
		{
			if (LeftNode != null)
			{
				return LeftNode.Minimum();
			}
			else
			{
				return Value;
			}
		}
		public int? Maximum()
		{
			if (RightNode != null)
			{
				return RightNode.Maximum();
			}
			else
			{
				return Value;
			}
		}

		public List<int> InfixTraverse()
		{
			List<int> result = new List<int>();
			if (Value == null)
			{
				return result;
			}

			if (LeftNode != null)
			{
				result.AddRange(LeftNode.InfixTraverse());
			}

			result.Add((int)Value);

			if (RightNode != null)
			{
				result.AddRange(RightNode.InfixTraverse());
			}
			return result;
		}

		public List<int> PrefixTraverse()
		{
			List<int> result = new List<int>();
			if (Value == null)
			{
				return result;
			}

			result.Add((int)Value);

			if (LeftNode != null)
			{
				result.AddRange(LeftNode.PrefixTraverse());
			}

			if (RightNode != null)
			{
				result.AddRange(RightNode.PrefixTraverse());
			}
			return result;
		}

		public List<int> PostfixTraverse()
		{
			List<int> result = new List<int>();
			if (Value == null)
			{
				return result;
			}

			if (LeftNode != null)
			{
				result.AddRange(LeftNode.PostfixTraverse());
			}

			if (RightNode != null)
			{
				result.AddRange(RightNode.PostfixTraverse());
			}

			result.Add((int)Value);

			return result;
		}

		public void Traverse()
		{
			if (Value == null)
			{
				return;
			}

			Console.Write(Value);
			Console.Write(" ");
			if (LeftNode != null)
			{
				Console.Write("left: ");
				Console.Write(LeftNode.Value);
				Console.Write(" ");
			}
			if (RightNode != null)
			{
				Console.Write("right: ");
				Console.Write(RightNode.Value);
				Console.Write(" ");
			}
			Console.WriteLine(" ");

			if (LeftNode != null)
			{
				LeftNode.Traverse();
			}

			if (RightNode != null)
			{
				RightNode.Traverse();
			}
		}
	}
}
