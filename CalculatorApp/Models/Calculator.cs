using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    //A calculator class was created to manage the following properties: FirstNumber,SecondNumber,MathOperator,Result,Equation and CurrentState
    internal class Calculator
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string MathOperator { get; set; }
        public string Result {  get; set; }

        public string Equation { get; set; }

        public CurrentState CurrentState {  get; set; }
        //Current state was made to be just the first and the second number and we will switch betweem them to avoid confusion
        public enum CurrentState
        {
            FirstNumber,
            SecondNumber
        }

        //After having defined the properties a Calulator constructor was created with variables/field :firstNumber,secondNumber,mathOperator
        //results and currentState with their respective return types.
        public Calculator(double firstNumber, double secondNumber, string mathOperator, string results, string equation, currentState) 
        { 
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            MathOperator = mathOperator;
            Result = results;
            Equation = equation;
            CurrentState = currentState;
        }

        public Calculator()
        {
        }




        public void ClearAll()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Result = 0;
            Equation = "";
            MathOperator = "";
            CurrentState = CurrentState.FirstNumber;
        }

        public void ClearEverything()
        {
            Result = "";
        }

        public List<double> Numbers = new List<double>();
        public List<string> MathOperators = new List<string>();


        public void AddNumber(double number)
        {
            try
            {
                Numbers.Add(number);
                CurrentState currentState = CurrentState.FirstNumber; ;
            }

            catch (Exception)
            {
                Equation = "Error";
            }
        }
        

        public void AddOperators(string mathOperators)
        {
            try
            {
                MathOperator = mathOperators;
                MathOperators.Add(MathOperator);

                Equation += $"{Numbers[Numbers.Count - 1]} {MathOperator}";

                CurrentState currentState = CurrentState.SecondNumber;
            }

            catch (Exception)
            {
                Equation = "Error";
            }
        }

        public string Calculate()
        {
            try
            {
                Equation += $"{Numbers[Numbers.Count - 1]} =";

                double result = Numbers[0];

                for (int i = 1; i < Numbers.Count; i++)
                {
                    switch (MathOperators[i - 1])
                    {
                        case "+":
                            result = MathUtil.Add(result, Numbers[i]);
                            break;
                        case "-":
                            result = MathUtil.Subtract(result, Numbers[i]);
                            break;
                        case "x":
                            result = MathUtil.Multiply(result, Numbers[i]);
                            break;
                        case "÷":
                            if (Numbers[i] == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            result = MathUtil.Divide(result, Numbers[i]);
                            break;

                    }
                }
                return result.ToString();
            }

            catch(DivideByZeroException)
            {
                return "You cannot divide by zero, try again";
            }

        }




    }
}
