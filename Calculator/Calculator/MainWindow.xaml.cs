using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, result;
        SelectedFunction SelectedFunction;

        public MainWindow()
        {

            InitializeComponent();

            clearButton.Click += ClearButton_Click;
            negationButton.Click += NegationButton_Click;

        }

        private void EqButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch (SelectedFunction)
                {
                    case SelectedFunction.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedFunction.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedFunction.Multiplication:
                        result = SimpleMath.Mult(lastNumber, newNumber);
                        break;
                    case SelectedFunction.Division:
                        result = SimpleMath.Div(lastNumber, newNumber);
                        break;

                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;
                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
               
            }
        }

        private void NegationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = pressedButton.Content;
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{pressedButton.Content}";
            }
        }

        private void DecButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(".")) {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {

                resultLabel.Content = "0";

            }

            if (sender == multButton)
            {
                SelectedFunction = SelectedFunction.Multiplication;
            }
            if (sender == divButton)
            {
                SelectedFunction = SelectedFunction.Division;
            }
            if (sender == addButton)
            {
                SelectedFunction = SelectedFunction.Addition;
            }
            if (sender == subButton)
            {
                SelectedFunction = SelectedFunction.Subtraction;
            }
        }
    }

    public enum SelectedFunction
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;           
        }
        public static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static double Mult(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static double Div(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                MessageBox.Show("Division by zero not valid", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return firstNumber / secondNumber;
        }
    }
    

    
}
