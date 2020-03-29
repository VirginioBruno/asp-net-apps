using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsConsole
{
    public class TreeHash
    {
        public string treeResult { get; }

        public TreeHash(int n)
        {
            if(n > 4) {
                string result = string.Empty;

                for (int i = n; i > 0; i--)
                {
                    for (int d = i - 1; d > 0; d--)
                    {
                        result += " ";
                    }

                    for (int d = n - (i - 1); d > 0; d--)
                    {
                        result += "#";
                    }

                    result += "/n";
                }

                treeResult = result.Replace("/n", Environment.NewLine);
            }
            else
            {
                throw new Exception("The tree hash must have more than 4 lines");
            }
        }
    }
}
