using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 递归与迭代
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new oper().digui(10));
            Console.WriteLine(new oper().diedai(10));
            Console.ReadKey();
        }
    }
    public class oper
    {
        public int digui(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            return digui(i - 1) + digui(i - 2);
        }
        public int diedai(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else
            {
                int index1 = 1;
                int index2 = 1;
                int result = 0;
                for (int j = 1; j < i - 1; j++)
                {
                    result = index1 + index2;
                    index1 = index2;
                    index2 = result;
                }
                return index2;
            }
        }
    }
}
