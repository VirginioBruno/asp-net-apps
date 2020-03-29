using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeHash treeHash = new TreeHash(30);
            Helper helper = new Helper();
            ReverseArray reverseArray = new ReverseArray(helper.RandomArray());
        }
    }
}
