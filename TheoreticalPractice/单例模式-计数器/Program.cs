using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;

namespace 简单工厂模式_计数器
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //单例模式的使用场景是一些全局不可变参数，可以放到单例中，比如从配置获取值，然后缓存到单例中，这才是我们应当使用单例的场景
            Au.Instance.Start();
            Au.Instance.Stop();
            Bu.Instance().Start();
            Bu.Instance().Stop();
            Console.ReadKey();

        }
    }
 

}
/// <summary>
/// 饿汉模式：饿汉模式的加载就是静态成员在定义的时候即初始化
/// </summary>
class Au
{
    //通过静态static实现单例模式
    private Au() { }//设为私有，防止外界调用
    private static readonly Au instance=new Au();

    public static Au Instance
    {
        get
        {
            return instance;
        }
    }

    public void Start()
    {
        Console.WriteLine("Au Start...");
    }

    public void Stop()
    {
        Console.WriteLine("Au Stop...");
    }
}

/// <summary>
/// 饱汉模式：单例模式主要是用来实现一个类的实例全局唯一，使用double check的形式来定义。
/// </summary>
class Bu
{
    //通过静态static实现单例模式
    private Bu() { }//设为私有，防止外界调用
    private static  Bu instance;
    private static readonly object _lock = new object();
    public static Bu Instance()
    {
      if(instance==null)
        {
            lock(_lock)
            {
                if(instance==null)
                {
                    instance = new Bu();
                }
            }
        }
        return instance;
    }

    public void Start()
    {
        Console.WriteLine("Bu Start...");
    }

    public void Stop()
    {
        Console.WriteLine("Bu Stop...");
    }
}



