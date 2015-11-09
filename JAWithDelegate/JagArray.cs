using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAWithDelegate
{

    public delegate int Comparer(int[] a, int[] b);
    public class JagArray
    {



        public static void ArraySort(int[][] jaggedArray, Comparer comparer)
        {

            if (jaggedArray == null)
                throw new ArgumentNullException("NULL");
            if (comparer == null)
                throw new ArgumentNullException("No comparer");
            if (jaggedArray.Length == 0)
                throw new ArgumentException("No elements");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i] == null)
                    throw new ArgumentException("Null raws");
            }


            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1; j++)
                {
                    if (comparer(jaggedArray[j], jaggedArray[j + 1]) == 1)
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }

        }


        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
    }



}
