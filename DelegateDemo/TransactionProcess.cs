using System;
namespace DelegateDemo
{
    public class TransactionProcess
    {
        public static void informBank(string message)
        {
            //do something
            Console.WriteLine($"{message} debited from bank");
        }
        public static void informStore(string message)
        {
            //do something
            Console.WriteLine($"{message} deposited to Store Account");
        }
        public static void informPerson(string message)
        {
            Console.WriteLine($"{message} done from your Account");
        }

    }
}