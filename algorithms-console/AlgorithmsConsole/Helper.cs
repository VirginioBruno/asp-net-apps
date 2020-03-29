using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsConsole
{
    class Helper
    {
        public int[] RandomArray()
        {
            List<int> randomList = new List<int>();
            Random random = new Random();
            var i = random.Next(1, 1000);

            for (var d = 0; d < i; d++)
            {
                randomList.Add(random.Next(1, 1000));
            }

            return randomList.ToArray();
        }

        public int MaxSumOfHourGlass(int[,] arr)
        {
            int sum = 0;
            int column = 0;
            int row = 0;
            List<int> sums = new List<int>();
            List<int> finalSums = new List<int>();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var d = 0; d < arr.GetLength(1); d++)
                {
                    if (column <= 2)
                    {
                        if (row == 0 || row == 2)
                        {
                            sum += arr[i, d];
                        }

                        if (row == 1 && column == 1)
                        {
                            sum += arr[i, d];
                        }

                        column++;

                        if (column == 3)
                        {
                            sums.Add(sum);
                            column = 0;
                            sum = 0;
                        }
                    }
                }

                row++;

                if (row == 3)
                {
                    row = 0;
                    finalSums.Add(sums.Sum(x => x));
                    sums.Clear();
                }
            }

            return finalSums.Max();
        }
    }
}
