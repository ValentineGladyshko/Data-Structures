using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
	public class AVLTree
	{
		public AVLTree()
		{
			Height = 0;
		}
		public AVLTree(int value)
		{
			Value = value;
			Height = 1;
		}

		public AVLTree(AVLTree AVLTree)
		{
			Value = AVLTree.Value;
			Height = AVLTree.Height;
			LeftNode = AVLTree.LeftNode;
			RightNode = AVLTree.RightNode;
		}
		public int Height { get; set; }
		public int? Value { get; set; }
		public AVLTree? LeftNode { get; set; }
		public AVLTree? RightNode { get; set; }


		public int BalanceFactor()
		{
			if (RightNode != null && LeftNode != null)
			{
				return RightNode.Height - LeftNode.Height;
			}
			else if (RightNode != null && LeftNode == null)
			{
				return RightNode.Height;
			}
			else if (RightNode == null && LeftNode != null)
			{
				return -LeftNode.Height;
			}
			else return 0;
		}

		public void FixHeight()
		{
			if (LeftNode != null && RightNode != null)
			{
				Height = (LeftNode.Height > RightNode.Height ? LeftNode.Height : RightNode.Height) + 1;
			}
			else if (LeftNode == null && RightNode != null)
			{
				Height = RightNode.Height + 1;
			}
			else if (LeftNode != null && RightNode == null)
			{
				Height = LeftNode.Height + 1;
			}
			else
			{
				Height = 1;
			}
		}

		public void RotateLeft()
		{
			if (RightNode != null)
			{
				AVLTree temp = new AVLTree(this);

				if (temp.RightNode != null)
				{
					Value = temp.RightNode.Value;
					RightNode = temp.RightNode.RightNode;
					temp.RightNode = temp.RightNode.LeftNode;
					LeftNode = temp;
					LeftNode.FixHeight();
					FixHeight();
				}
			}
		}

		public void RotateRight()
		{
			if (LeftNode != null)
			{
				AVLTree temp = new AVLTree(this);

				if (temp.LeftNode != null)
				{
					Value = temp.LeftNode.Value;
					LeftNode = temp.LeftNode.LeftNode;
					temp.LeftNode = temp.LeftNode.RightNode;
					RightNode = temp;
					RightNode.FixHeight();
					FixHeight();
				}
			}
		}

		public void Balance()
		{
			FixHeight();
			if (BalanceFactor() == 2 && RightNode != null)
			{
				if (RightNode.BalanceFactor() < 0)
					RightNode.RotateRight();
				RotateLeft();
			}

			if (BalanceFactor() == -2 && LeftNode != null)
			{
				if (LeftNode.BalanceFactor() > 0)
					LeftNode.RotateLeft();
				RotateRight();
			}
		}

		public void Insert(int value)
		{
			if (Value == null)
			{
				Value = value;
			}
			else if (value < Value)
			{
				if (LeftNode == null)
				{
					LeftNode = new AVLTree(value);
				}
				else
				{
					LeftNode.Insert(value);
				}
			}
			else if (value > Value)
			{
				if (RightNode == null)
				{
					RightNode = new AVLTree(value);
				}
				else
				{
					RightNode.Insert(value);
				}
			}
			Balance();
		}

		public bool Remove(int value)
		{
			return Remove(value, this);
		}

		public bool Remove(int value, AVLTree parentNode)
		{
			if (Value == null)
			{
				return false;
			}
			else if (value < Value)
			{
				if (LeftNode == null)
					return false;
				else
				{
					bool result = LeftNode.Remove(value, this);
					Balance();
					return result;
				}
			}
			else if (value > Value)
			{
				if (RightNode == null)
					return false;
				else
				{
					bool result = RightNode.Remove(value, this);
					Balance();
					return result;
				}
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
					Balance();
					return true;
				}
				else if (LeftNode == null && RightNode != null)
				{
					Value = RightNode.Value;
					LeftNode = RightNode.LeftNode;
					RightNode = RightNode.RightNode;
					Balance();
					return true;
				}
				else if (LeftNode != null && RightNode != null)
				{
					if (RightNode.LeftNode == null)
					{
						Value = RightNode.Value;
						RightNode = RightNode.RightNode;
						Balance();
						return true;
					}
					else
					{
						Value = RightNode.MinimumDelete(this);
						RightNode.Balance();
						Balance();
						return true;
					}
				}
			}
			return false;
		}

		public int? MinimumDelete(AVLTree parentNode)
		{
			if (LeftNode != null)
			{
				int? result = LeftNode.MinimumDelete(this);				
				Balance();
				return result;
			}
			else
			{
				parentNode.LeftNode = RightNode;
				return Value;
			}
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
			Console.Write("height: ");
			Console.Write(Height);
			Console.Write(" ");
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