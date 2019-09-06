using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEvent和ManualResetEvent
{
    class Program
    {
        const int count = 10;
        //赋值为false也就是没有信号
        static AutoResetEvent myResetEvent = new AutoResetEvent(false);
        static int number;
        static void Main(string[] args)
        {
            Thread thread = new Thread(funThread);
            thread.Name = "QQ";
            thread.Start();
            for (int i = 1; i < count; i++)
            {
                Console.WriteLine("first number: {0}", i);
                number = i;
                //这里是设置为有信号
                myResetEvent.Set();
                Thread.Sleep(2000);
            }
            thread.Abort();
        }

        static void funThread()
        {
            while (true)
            {
                //执行到这个地方时，会等待set调用后改变了信号才接着执行
                myResetEvent.WaitOne();
                Console.WriteLine("end {0} number: {1}", Thread.CurrentThread.Name, number);
            }
        }

    }
}
