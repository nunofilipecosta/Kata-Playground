using System;
using System.Linq;

namespace KataPlayground.UnitTests.Multiples3And5
{
    public class Multiple3And5
    {
        public static int Sum(int value)
        {
            var sum = 0;
            for (int i = 0; i < value; i++)
            {
                if ((i % 3) == 0)
                {
                    sum += i;
                }
                else if ( (i % 5) == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }
    }

    public class Multiple3And5_2
    {
        public static int Sum(int value)
        {
            var sum = Enumerable.Range(0, value).Where(i => i % 3 == 0 || i % 5 == 0).Sum();

            return sum;
        }
    }
}
