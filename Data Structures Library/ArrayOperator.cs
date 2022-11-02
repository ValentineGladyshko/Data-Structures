using System;

namespace DataStructures
{
    public class ArrayOperator
    {
        public ArrayOperator()
        { }
        public bool IsSorted(List<IComparable> array)
        {
            for (int i = 0; i < (array.Count - 1); i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public string ToString(List<IComparable> array)
        {
            string result = "";
            foreach (IComparable i in array)
            {
                result += i.ToString();
                result += " ";
            }
            return result;
        }
    }
}
