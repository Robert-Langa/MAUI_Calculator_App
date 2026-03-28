using CalculatorApp;
using CalculatorApp.Models;
using static CalculatorApp.Models.Calculator;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorApp.Views;

public partial class CalculatorPage : ContentPage
{
	public CalculatorPage()
	{
		InitializeComponent();
	}
	public Calculator calculator = new();
	
	//We will create various methods for the UI to work.

	// This method will run when the numbers in the UI are clicked giving them functionality

	private void OnMultipleNumbersClicked(object sender, EventArgs e)
	{
        Button buttonClicked = (Button)sender;
        string buttonOutput = buttonClicked.Text;

        if (calculator.Result == "0" || calculator.CurrentState == CurrentState.SecondNumber)
		{
			calculator.Result = "";

			calculator.Result += buttonOutput;
			numbersLabel.Text = calculator.Result;
		}
    }

    private void OnMultipleOperatorsClicked(object sender, EventArgs e)
	{
        Button buttonClicked = (Button)sender;
        string buttonOperator = buttonClicked.Text;

		switch(buttonOperator)
		{
            //When the "=" sign is clicked a method called GetEquals() will be called.
            case "=":
				GetEquals();
				break;

            //Otherwise if not  method called GetOperators() will be called which is all the other operators except for "=".
            default:
				GetOperators(buttonOperator);
				break;

		}

    }

    private void GetOperators(string buttonOperator)
    {
        if (!double.TryParse(calculator.Result, out double number)) return;

        if (calculator.CurrentState == CurrentState.FirstNumber)
        {
            calculator.FirstNumber = number;
            calculator.MathOperator = buttonOperator;
            calculator.CurrentState = CurrentState.SecondNumber;
            calculator.Equation = $"{calculator.FirstNumber} {calculator.MathOperator}";
            calculator.Result = "0";
        }
        else
        {
            calculator.SecondNumber = number;
            double result = MathUtil.Calculate(calculator.FirstNumber, calculator.SecondNumber, calculator.MathOperator);
            calculator.FirstNumber = result;
            calculator.MathOperator = buttonOperator;
            calculator.Equation += $" {calculator.SecondNumber} {buttonOperator}";
            calculator.Result = "0";
            numbersLabel.Text = result.ToString();
        }

        equationLabel.Text = calculator.Equation;
    }
    




}