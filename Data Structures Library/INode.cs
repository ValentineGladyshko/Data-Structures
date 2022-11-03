using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface INode<T, T1> where T : IComparable
    {
        public T Key { get; set; }
        public T1 Value { get; set; }
        public INode<T, T1>? LeftNode { get; set; }
        public INode<T, T1>? RightNode { get; set; }
    }
}
