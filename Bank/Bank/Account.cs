using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public delegate string  AccountStateHandler(string message);
    public class Account
    {

        AccountStateHandler _del;

        public void  RegisterHandler(AccountStateHandler del)
        {
            _del = del;
        }

        int sum; 

        public Account(int count)
        {
            sum = count;
        }

        public int CurrentSum
        {
            get { return sum; }
        }

        public void Put(int count)
        {
            sum += count;
            if (_del != null)
                _del($"Общая сумма счета {sum} ");
        }

        public void Withdraw(int count)
        {
            if (count<= sum)
            {
                sum -= count;

                if (_del != null)
                    _del($"Сумма {count} снята со счета");
            }
            else
            {
                if (_del != null)
                    _del("Недостаточно денег на счете");
            }
        }
    }
}

