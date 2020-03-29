using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsConsole
{
    class ReverseArray
    {
        public int[] reverseArray { get; }
        public ReverseArray(int[] a)
        {
            List<int> result = new List<int>();
            for (var i = a.Length - 1; i > 0; i--)
            {
                result.Add(a[i]);
            }

            reverseArray = result.ToArray();
        }
    }
}
