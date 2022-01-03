using System;

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
		public BinaryTree? LeftNode { get; set; }
		public BinaryTree? RightNode { get; set; }

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
					LeftNode = LeftNode.LeftNode;
					return true;
				}
				else if (LeftNode == null && RightNode != null)
				{
					Value = RightNode.Value;
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
				parentNode.LeftNode = null;
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

		public void InfixTraverse()
		{
			if (Value == null)
			{
				return;
			}

			if (LeftNode != null)
			{
				LeftNode.InfixTraverse();
			}

			Console.Write(Value);
			Console.Write(" ");

			if (RightNode != null)
			{
				RightNode.InfixTraverse();
			}
		}

		public void PrefixTraverse()
		{
			if (Value == null)
			{
				return;
			}

			Console.Write(Value);
			Console.Write(" ");

			if (LeftNode != null)
			{
				LeftNode.PrefixTraverse();
			}

			if (RightNode != null)
			{
				RightNode.PrefixTraverse();
			}
		}

		public void PostfixTraverse()
		{
			if (Value == null)
			{
				return;
			}

			if (LeftNode != null)
			{
				LeftNode.PostfixTraverse();
			}

			if (RightNode != null)
			{
				RightNode.PostfixTraverse();
			}

			Console.Write(Value);
			Console.Write(" ");
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
