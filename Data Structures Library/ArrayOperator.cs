using System;

namespace DataStructures
{
    public class ArrayOperator
    {
        public ArrayOperator()
        { }
        public bool IsSorted(List<int> array)
        {
            for (int i = 0; i < (array.Count - 1); i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public string ToString(List<int> array)
        {
            string result = "";
            foreach (int i in array)
            {
                result += i;
                result += " ";
            }
            return result;
        }
    }
}
