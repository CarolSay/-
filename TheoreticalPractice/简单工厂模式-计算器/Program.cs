using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式_计算器
{
    /// <summary>
    /// 计算器类（抽象类，由子类重写）
    /// </summary>
    public abstract class Calculator
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public Calculator() { }
        public Calculator(double a, double b)
        {
            this.Number1 = a;
            this.Number2 = b;
        }
        /// <summary>
        /// 计算
        /// </summary>
        /// <returns></returns>
        public abstract double jsuan();
    }
    /// <summary>
    /// 加法类
    /// </summary>
    public class jiafaDll : Calculator //子类拥有父类除私有之外的所有属性字段和方法
    {
        public jiafaDll() { }
        public jiafaDll(double a, double b)
          : base(a, b)  //调用父类带两个参数的构造函数，来初始化Number1 和Number2 （注意：因为jianfaDll类继承了Calculator，所以jianfaDll类是有Number1，和Number2两个属性的）
        { }
        /// <summary>
        /// 重写父类的jsuan方法
        /// </summary>
        /// <returns></returns>
        public override double jsuan()
        {
            return Number1 + Number2;
        }
    }
    /// <summary>
    /// 减法类
    /// </summary>
    public class jianfaDll : Calculator
    {
        public jianfaDll()
        { }
        public jianfaDll(double a, double b)
          : base(a, b)
        { }
        public override double jsuan()
        {
            return Number1 - Number2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数");
            double number1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入一个操作符");
            string caozuofu = Console.ReadLine();
            Console.WriteLine("请输入第二个数");
            double number2 = Convert.ToDouble(Console.ReadLine());
            Calculator c = null;
            switch (caozuofu)
            {
                case "+":
                    c = new jiafaDll(number1, number2);
                    break;
                case "-":
                    c = new jianfaDll(number1, number2);
                    break;
            }
            double i = c.jsuan();
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
