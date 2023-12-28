using System;
using System.Collections.Generic;
using System.Linq;

class Bank
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int allCustomersNum = int.Parse(input[0]);
        int remainTime_T = int.Parse(input[1]);

        List<Customer> customers = new List<Customer>();

        for (int i = 0; i < allCustomersNum; i++)
        {
            string[] data = Console.ReadLine().Split();
            int savingMoney = int.Parse(data[0]);
            int leavingTime = int.Parse(data[1]);
            customers.Add(new Customer(savingMoney, leavingTime));
        }

        customers.Sort(new CustomerComparer());

        bool[] served = new bool[remainTime_T];
        int totalMoney = 0;

        foreach (var customer in customers)
        {
            int money = customer.SavingMoney;
            int deadline = customer.LeavingTime;

            for (int i = deadline; i >= 0; i--)
            {
                if (!served[i])
                {
                    served[i] = true;
                    totalMoney += money;
                    break;
                }
            }
        }

        Console.WriteLine(totalMoney);
    }

    class Customer
    {
        public int SavingMoney { get; }
        public int LeavingTime { get; }

        public Customer(int savingMoney, int leavingTime)
        {
            SavingMoney = savingMoney;
            LeavingTime = leavingTime;
        }
    }

    class CustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            int result = y.SavingMoney.CompareTo(x.SavingMoney);
            if (result == 0)
            {
                result = x.LeavingTime.CompareTo(y.LeavingTime);
            }
            return result;
        }
    }
}
