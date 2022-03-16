using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface INode
    {
        public int Value { get; set; }
        public INode? LeftNode { get; set; }
        public INode? RightNode { get; set; }
    }
}
