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
		public BinaryTree? RightNode { get; set; }
		public BinaryTree? LeftNode { get; set; }

		public void Insert(int value)
		{
			if (Value == null)
			{
				Value = value;
			}
			else if (value < Value)
			{
				if (RightNode == null)
					RightNode = new BinaryTree(value);
				else RightNode.Insert(value);
			}
			else if (value > Value)
			{
				if (LeftNode == null)
					LeftNode = new BinaryTree(value);
				else LeftNode.Insert(value);
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
				if (RightNode == null)
					return false;
				else RightNode.Find(value);
			}
			else
			{
				if (LeftNode == null)
					return false;
				else LeftNode.Find(value);
			}
			return false;
		}

		public void InfixTraverse()
		{
			if (Value == null)
			{
				return;
			}

			if (RightNode != null)
			{
				RightNode.InfixTraverse();
			}	

			Console.Write(Value);
			Console.Write(" ");

			if (LeftNode != null)
			{
				LeftNode.InfixTraverse();
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

			if (RightNode != null)
			{
				RightNode.PrefixTraverse();
			}		

			if (LeftNode != null)
			{
				LeftNode.PrefixTraverse();
			}
		}

		public void PostfixTraverse()
		{
			if (Value == null)
			{
				return;
			}

			if (RightNode != null)
			{
				RightNode.PostfixTraverse();
			}

			if (LeftNode != null)
			{
				LeftNode.PostfixTraverse();
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
			if (RightNode != null)
			{
				Console.Write("right: ");
				Console.Write(RightNode.Value);
				Console.Write(" ");
			}
			if (LeftNode != null)
			{
				Console.Write("left: ");
				Console.Write(LeftNode.Value);
				Console.Write(" ");
			}
			Console.WriteLine(" ");

			if (RightNode != null)
			{
				RightNode.Traverse();
			}

			if (LeftNode != null)
			{
				LeftNode.Traverse();
			}

			
		}

	}
}
