using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardValidator.Utility
{
    public static class UserValidator
    {
        public static ValueTuple<bool,long> isNumber(string userInput)
        {            
            long longCCnum;
            bool result = (Int64.TryParse(userInput, out longCCnum));

            ValueTuple<bool,long> resultTuple=(result,longCCnum);
            
            return  resultTuple;
        }
    }
}