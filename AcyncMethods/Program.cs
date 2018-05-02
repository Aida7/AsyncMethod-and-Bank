using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcyncMethods
{
    class Program
    {
        private delegate double SumDelegate(double first, double second);
        static void Main(string[] args)
        {

            Console.WriteLine("запуск приилож");
            int mainThredId= Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Поток-- {0}...", mainThredId);

            SumDelegate sumDelegate = new SumDelegate(Sum);

            // sumDelegate.Invoke(2.3, 5.6);
            //IAsyncResult  result= sumDelegate.BeginInvoke(2.3, 5.6, null, null);

            IAsyncResult result = sumDelegate.BeginInvoke(2.3, 5.6,
                new AsyncCallback((incomingResult)=>
                Console.WriteLine(sumDelegate.EndInvoke(incomingResult))), null);

            Console.WriteLine("Завершение работы");
            Console.ReadLine();
        }
        static double Sum(double x, double y)
        {
            Console.WriteLine("запуск метода сум");

            int workThredId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Поток--{0}...", workThredId);

            Console.WriteLine("Имитация длительной работы");
            Thread.Sleep(5000);
            Console.WriteLine("Длительная работа завершина,результат");
            return x + y;
        }
    }
}
