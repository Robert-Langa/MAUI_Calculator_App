using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    class MathUtil
    {
        public static double Add(double firstNumber, double secondNumber)
        { 
            return firstNumber + secondNumber; 
        }

        public static double Subtract(double firstNumber, double secondNumber)
        { 
            return firstNumber - secondNumber; 
        }

        public static double Divide(double firstNumber, double secondNumber)

        {
            if (secondNumber == 0)
               throw new DivideByZeroException($"You cannot divide by {secondNumber}");
            else
                return firstNumber / secondNumber;
        }

        public static double Multiply(double firstNumber, double secondNumber)
        { 
            return firstNumber * secondNumber; 
        }

        public static double Percentage(double firstNumber)
        { 
            return firstNumber / 100; 
        }

        public static double Negate(double firstNumber)
        { 
            return -firstNumber;  
        }

        internal static double Calculate(double firstNumber, object secondNumber, object mathOperator)
        {
            throw new NotImplementedException();
        }
    }
}
