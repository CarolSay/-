using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程异步消息处理队列_发短信验证码
{


    class Program
    {
        static void Main(string[] args)
        {
            AsyncTaskProcess.addPhone("151xxxxx1");
            AsyncTaskProcess.addPhone("151xxxxx2");
            AsyncTaskProcess.addPhone("151xxxxx3");
            AsyncTaskProcess.addPhone("151xxxxx4");
            Thread.Sleep(5000);
            AsyncTaskProcess.addPhone("181xxxxx1");
            AsyncTaskProcess.addPhone("181xxxxx2");
            AsyncTaskProcess.addPhone("181xxxxx3");
            AsyncTaskProcess.addPhone("181xxxxx4");
            Thread.Sleep(5000);
            AsyncTaskProcess.addPhone("159xxxxx1");
            AsyncTaskProcess.addPhone("159xxxxx2");
            AsyncTaskProcess.addPhone("159xxxxx3");
            AsyncTaskProcess.addPhone("159xxxxx4");


            Console.ReadKey();
        }
    }




    public class AsyncTaskProcess
    {
        // 任务队列，存放需要发送的手机号
        static Queue<string> phoneQueue = new Queue<string>();
        // 信号器，通知处理新的任务
        static ManualResetEvent processNext = new ManualResetEvent(false);
        // 发送短信的Task
        static Task sendMsgTask;


        static AsyncTaskProcess()
        {
            sendMsgTask = new Task(send);
            sendMsgTask.Start();
        }
        static void send()
        {
            Console.WriteLine("--------短信任务发送开始--------");
            while (true)
            {
                // 先阻塞线程，当有set信号时关闭阻塞
                processNext.WaitOne();
                Process();
            }
        }


        static void Process()
        {
            if (phoneQueue.Count == 0)
            {
                Console.WriteLine("短信队列为空，先休息一会儿~");
                processNext.Reset();
            }
            else
            {
                //TODO 短信发送的代码
                Thread.Sleep(1000);
                Console.WriteLine(phoneQueue.Dequeue() + "验证码已发送，发送时间：" + DateTime.Now + "，队列剩余未发送手机号数量：" + phoneQueue.Count());
            }
        }


        // 用于向队列中添加手机号，外部调用
        public static void addPhone(string phone)
        {
            phoneQueue.Enqueue(phone);
            Console.WriteLine("手机号：" + phone + "已加入队列");
            //队列里任务数量为0时，处理线程是处于阻塞状态的，所以当队列里有新任务加入时，需要关闭阻塞，开始处理
            if (phoneQueue.Count() == 1)
            {
                processNext.Set();
            }
        }
    }
}
