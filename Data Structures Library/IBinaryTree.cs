using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IBinaryTree
    {
        public void Insert(int value);
        public bool Find(int value);
        public void Remove(int value);
        public int? Minimum();
        public int? Maximum();
        public List<int> InfixTraverse();
        public List<int> PrefixTraverse();
        public List<int> PostfixTraverse();
        public void Traverse();
    }
}
