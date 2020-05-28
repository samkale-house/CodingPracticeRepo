using System;
/// <summary>
/// Func is a built in delegate type,which always represent a method that returns value.
/// Func<T,T>: always last parameter in func is the out parameter i.e what method returns.
/// use: Func is a of Delegate type,so multiple methods can be registered with it.
/// On one call a bigoperation with multiple calls to other methods in synchronous way can be done.
/// 
/// Action:  It is also a built in delegate like Func to invoke the methods that doesn't return any value.
/// 
/// </summary>
namespace FuncDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            //Let's register method with OperateTwoNum func
            Func<int, int, int> OperateTwoNum = AddTwoNum;


            Console.WriteLine("Adding 5,6:" + OperateTwoNum(5, 6));

            //register multiply method with same func.
            OperateTwoNum = MultiplyTwoNum;
            Console.WriteLine("Multiplying 5,6:" + OperateTwoNum(5, 6));

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Call Multiple methods for one operation\n");
            Console.WriteLine("--------------------------------------");

            Func<bool> DoDeposit = CheckForValidUser;
            DoDeposit += CheckForValidAccount;
            DoDeposit += DepositCash;
            DoDeposit += MessageCustomer;

            Console.WriteLine("Doing Deposit Transaction operation\n");
            DoDeposit();
            //methods will be called int the order they are registered with Func.


            Console.WriteLine("----------------Action Demo--------------------");
            Action<int,int> printAction=PrintSum;
            PrintSum(6,6);
            printAction-=PrintSum;
            printAction=(int num1,int num2)=>{Console.WriteLine($"From Anonymous method:{num1+num2}");};
            PrintSum(7,7);            

        }
        static void PrintSum(int num1,int num2)
        {
            Console.WriteLine($"From Method PrintSum:Total is:{num1+num2}");
        }

        static int AddTwoNum(int num1, int num2)
        {
            return num1 + num2;
        }
        static int MultiplyTwoNum(int num1, int num2)
        {
            return num1 * num2;
        }

        static bool CheckForValidUser()
        {
            Console.WriteLine("Checking for user validity");
            //do code to check if user is valid and update validuser flag in model
            return true;
        }

        private static bool CheckForValidAccount()
        {
            Console.WriteLine("Checking for valid account");
            //do code to check if account valid do set validaccountflag to true or false
            return true;
        }

        private static bool DepositCash()
        {
            Console.WriteLine("adding amount to your balance");
            //do code to add amount from model to balance and update balance set depositedflag true/false
            return true;
        }



        static bool MessageCustomer()
        {
            Console.WriteLine("informing customer by mail");
            //do code to check if user is valid and update validuser flag in model
            return true;
        }


    }
}
