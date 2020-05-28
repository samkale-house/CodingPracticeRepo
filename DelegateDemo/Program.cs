using System;

namespace DelegateDemo
{
    /// <summary>
    /// Delegate: It's a reference type, which is not class.It is a pointer to point to methods.
    /// </summary>
    class Program
    {
        //define delegate refernce type
        public delegate void TransactionDelegate(string message);
        static void Main(string[] args)
        {
            //create object of our custom delegate and attach methods
            TransactionDelegate transactionDel = TransactionProcess.informBank;
            transactionDel += TransactionProcess.informStore;
            transactionDel += TransactionProcess.informPerson;

            //call multiple methods using one delegate call.
            transactionDel.Invoke("Transaction : $70");

            Console.WriteLine("------------------------------------");
            Console.WriteLine("Pass delegate as parameter to a method");
            //Pass delegate as parameter to a method
            PrintMessages(transactionDel);


            Console.WriteLine("------------------------------------");
            Console.WriteLine("delegate can even point to anonymous methods using lambda");
            //delegate can even point to anonymous methods using lambda
            TransactionDelegate del = (string msg) => { Console.WriteLine($"Lambda epxression can give message:{msg}"); };
            del("Hello Sam");

        }
        static void PrintMessages(TransactionDelegate tdel)
        {
            Console.WriteLine("From method that takes delegate as a parameter");
            tdel("Transaction :$60");
        }
    }
}
