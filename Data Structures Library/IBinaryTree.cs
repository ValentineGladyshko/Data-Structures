using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IBinaryTree<T> where T : IComparable
    {
        public void Insert(T value);
        public bool Find(T value);
        public void Remove(T value);
        public T? Minimum();
        public T? Maximum();
        public List<IComparable> InfixTraverse();
        public List<IComparable> PrefixTraverse();
        public List<IComparable> PostfixTraverse();
        public void Traverse();
    }
}
