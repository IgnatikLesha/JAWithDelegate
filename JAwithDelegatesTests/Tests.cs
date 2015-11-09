using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAWithDelegate;
using NUnit.Framework;

namespace JAwithDelegatesTests
{
    public class Methods
    {
        public static int CompareByMax(int[] a, int[] b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException();

            if (a.Max() > b.Max())
                return 1;
            else if (a.Max() < b.Max())
                return -1;
            else
                return 0;
        }
    }

    [TestFixture]
    public class JADTests
    {
        [Test, TestCaseSource(typeof (Data), "SortArrayByMaxValue")]
        public int[][] SorByMaxValue(int[][] array, Comparer comparer)
        {
            JagArray.ArraySort(array, comparer);
            return array;
        }

    }

    public class Data
    {
        public IEnumerable<TestCaseData> SortArrayByMaxValue
        {
            get
            {
                int[][] arr0 = new int[0][];

                int[][] arr1 = new int[3][];
                arr1[0] = new int[] { -5, 0, 9, 4 };
                arr1[1] = new int[] { -14, 11, 7 };
                arr1[2] = new int[] { 3, 4, -20, 4, 1, 2 };

                int[][] resultarr1 = new int[3][];
                resultarr1[0] = new int[] { 3, 4, -20, 4, 1, 2 };
                resultarr1[1] = new int[] { -5, 0, 9, 4 };
                resultarr1[2] = new int[] { -14, 11, 7 };

                Comparer del1 = Methods.CompareByMax;

                yield return new TestCaseData(arr1, del1).Returns(resultarr1);
                yield return new TestCaseData(arr0, del1).Throws(typeof (ArgumentException));
                yield return new TestCaseData(arr1, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(null, del1).Throws(typeof(ArgumentNullException));
            }
        }
    }
}
