namespace DataStructures
{
    public interface IBinaryTree<T, T1> where T : IComparable
    {
        public void Insert(T key, T1 value);
        public bool Find(T key);
        public void Remove(T key);
        public T1? Get(T key);
        public (T, T1)? Minimum();
        public (T, T1)? Maximum();
        public List<IComparable> InfixTraverse();
        public List<IComparable> PrefixTraverse();
        public List<IComparable> PostfixTraverse();
        public List<T1> InfixTraverseValues();
        public List<T1> PrefixTraverseValues();
        public List<T1> PostfixTraverseValues();
        public void Traverse();
    }
}
