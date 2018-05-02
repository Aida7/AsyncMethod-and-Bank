using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum,sum1;
            int mainThredId = Thread.CurrentThread.ManagedThreadId;

            Account account = new Account(200); 
            account.RegisterHandler(new AccountStateHandler(Show_Message));

            AccountStateHandler handler = new AccountStateHandler(Show_Message);

            IAsyncResult result = handler.BeginInvoke("начало операции",
              new AsyncCallback((incomingResult) =>
              Console.WriteLine(handler.EndInvoke(incomingResult))), null);

            Console.WriteLine("введите сумму");
            int.TryParse(Console.ReadLine(), out sum);
            account.Put(sum);

            Console.WriteLine("введите сумму для снятие суммы");
            int.TryParse(Console.ReadLine(), out sum1);
            account.Withdraw(sum1);


            Console.ReadLine();
        }
        private static string Show_Message(String message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
}
