using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardValidator.Sevices
{
    /*
    The Luhn Formula:
1.Drop the last digit from the number. The last digit is what we want to check against
2.Reverse the numbers
3.Multiply the digits in odd positions (1, 3, 5, etc.) by 2 and subtract 9 to all any result higher than 9
4.Add all the numbers together
5.The check digit (the last number of the card) is the amount that you would need to add to get a multiple of 10 (Modulo 10)
    */
    public class CreditCardService
    {
        public bool isValidCreditCard(long creditCardNumber)
        {
            bool result = false;
            string strcreditCardNumber = creditCardNumber.ToString();
            char[] charArrCCNum = strcreditCardNumber.ToArray();
            int[] intArrCCNum = new int[strcreditCardNumber.Length];


            //get Last digit
            int LastDigit = getLastDigit(creditCardNumber);

            //Drop the last digit from the number. The last digit is what we want to check against
            //get intarray from long
            intArrCCNum=getNumbersArray(creditCardNumber);            

            //Reverse array
            intArrCCNum = intArrCCNum.Reverse().ToArray();
            
            //Multiply the digits in odd positions (1, 3, 5, etc.) by 2 and subtract 9 to all any result higher than 9
            intArrCCNum=getArrByRule3(intArrCCNum);

            //match last digit with sum%10            
            intArrCCNum[0] = 0;
            int sum = intArrCCNum.Sum(); Console.WriteLine($"sum of digits:{sum}");
            if (sum % 10 == LastDigit)
                result = true;


            return result;


        }

        private int[] getArrByRule3(int[] intArrCCNum)
        {
            
            for (int i = 1; i < intArrCCNum.Length; i++)//leave 1 number(lastdigit)
            {
                //iterate and modify odd positioned numbers
                if ((i) % 2 != 0)//odd position for intarr,start form index 1
                {
                    intArrCCNum[i] = (intArrCCNum[i] * 2) > 9 ? (intArrCCNum[i] * 2) - 9 : intArrCCNum[i] * 2;
                    Console.Write($"valueat{i}:{intArrCCNum[i]}");
                }
                else
                {                    
                    Console.Write($"valueat{i}:{intArrCCNum[i]}");
                }
            }
            return intArrCCNum;
        }

        private static int[] getNumbersArray(long creditCardNumber)
        {
            int[] intArrCCNum=new int[creditCardNumber.ToString().Length];
            char[] charArrCCNum = creditCardNumber.ToString().ToArray();
            for (int index = 0; index < charArrCCNum.Length; index++)
            {
                intArrCCNum[index] = Int32.Parse(charArrCCNum[index].ToString());
                Console.WriteLine(intArrCCNum[index]);
            }
            return intArrCCNum;
        }

        private static int getLastDigit(long creditCardNumber)
        {
            string strcreditCardNumber = creditCardNumber.ToString();
            return strcreditCardNumber.ToArray().Last();
        }
    }
}