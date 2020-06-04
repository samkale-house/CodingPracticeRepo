using System;
using CreditCardValidator.Utility;
using CreditCardValidator.Models;
using CreditCardValidator.Sevices;

namespace CreditCardValidator
{
    class CreditCardController
    {
       
       
        static void Main(string[] args)
        {
            //Make a model
            CreditCard creditCard=new CreditCard();
            creditCard.CreditCardNumber=userInputView();

             CreditCardService _creditCardService=new CreditCardService();
            //validate
            creditCard.isValidCCNumber=_creditCardService.isValidCreditCard(creditCard.CreditCardNumber);

            //Reply to user  
            string msg=creditCard.isValidCCNumber?"valid credit card":"invalid credit card";
            Console.WriteLine(msg);

        }
        static long userInputView()
        {            
            Console.WriteLine("Enter Credit Card number to validate:");
            string CardNumString = "4556737586899855";//Console.ReadLine();
            long CardNum;

            //ask to enter again if not a number
            if (!UserValidator.isNumber(CardNumString).Item1)
            {
                Console.WriteLine("******Please Enter a Valid number*****");
                
                CardNum = userInputView();
            }
            //client validation
            CardNum=UserValidator.isNumber(CardNumString).Item2;
            return CardNum;
        }
    }
}
