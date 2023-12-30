﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SceintificCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private string currentInput = "";
        private char currentOperator = ' ';
        private double currentResult = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string numberClicked = button.Content.ToString();

            // Append the clicked number to the current input
            currentInput += numberClicked;

            UpdateInputDisplay(); // Update the UI to display the new input
        }


        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            char newOperator = button.Content.ToString()[0];

            if (!string.IsNullOrEmpty(currentInput))
            {
                // If there's a pending operation, calculate it first
                if (currentOperator != ' ')
                {
                    double secondOperand = double.Parse(currentInput);
                    CalculateResult(secondOperand);
                }
                else
                {
                    currentResult = double.Parse(currentInput);
                }

                currentOperator = newOperator;
                currentInput = "";
            }
        }
        private void CalculateResult(double secondOperand)
        {
            switch (currentOperator)
            {
                case '+':
                    currentResult += secondOperand;
                    break;
                case '-':
                    currentResult -= secondOperand;
                    break;
                case '*':
                    currentResult *= secondOperand;
                    break;
                case '/':
                    if (secondOperand != 0) // Ensure division by zero isn't performed
                        currentResult /= secondOperand;
                    else
                        MessageBox.Show("Error: Division by zero");
                    break;
                // Add more cases for other operations as needed
                default:
                    // Handle invalid or unrecognized operators
                    MessageBox.Show("Error: Invalid Operator");
                    break;
            }

            currentInput = currentResult.ToString();
            UpdateInputDisplay(); // Update the UI with the new result
        }

        private void UpdateInputDisplay()
        {
            InputTextBox.Text = currentInput; // Assuming InputTextBox is the TextBox control in the UI
        }


        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a decimal point already exists in the current input
            if (!currentInput.Contains("."))
            {
                currentInput += "."; // Append a decimal point if it doesn't exist

                UpdateInputDisplay();
            }
        }


        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && currentOperator != ' ')
            {
                double secondOperand = double.Parse(currentInput);
                CalculateResult(secondOperand);
                currentOperator = ' '; // Reset the operator after calculation
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = ""; // Clear the current input
            currentResult = 0; // Reset the ongoing result
            currentOperator = ' '; // Reset the operator

            UpdateInputDisplay(); 
        }


        private void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = ""; // Clear the current input only

            UpdateInputDisplay();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1); // Remove the last character

                UpdateInputDisplay();
            }
        }


        private void SquareRootButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double number = double.Parse(currentInput);

                if (number >= 0) // Ensure square root of a negative number isn't calculated
                {
                    double result = Math.Sqrt(number);
                    currentInput = result.ToString();
                    UpdateInputDisplay();
                }
                else
                {
                    MessageBox.Show("Invalid input for square root"); // Show an error message for negative numbers
                }
            }
        }

        private void SinButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double degrees = double.Parse(currentInput);
                double radians = degrees * (Math.PI / 180); // Convert degrees to radians

                double result = Math.Sin(radians);
                currentInput = result.ToString();
                UpdateInputDisplay(); 
            }
        }

        private void CosButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double degrees = double.Parse(currentInput);
                double radians = degrees * (Math.PI / 180); // Convert degrees to radians

                double result = Math.Cos(radians);
                currentInput = result.ToString();
                UpdateInputDisplay(); // Update the UI with the cosine result
            }
        }

        private void TanButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double degrees = double.Parse(currentInput);
                double radians = degrees * (Math.PI / 180); // Convert degrees to radians

                double result = Math.Tan(radians);
                currentInput = result.ToString();
                UpdateInputDisplay(); // Update the UI with the tangent result
            }
        }

        private void CotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double degrees = double.Parse(currentInput);
                double radians = degrees * (Math.PI / 180); // Convert degrees to radians

                double tanValue = Math.Tan(radians);

                if (tanValue != 0) // Ensure cotangent isn't calculated for tangent = 0
                {
                    double result = 1 / tanValue; // Calculate cotangent as reciprocal of tangent
                    currentInput = result.ToString();
                    UpdateInputDisplay(); // Update the UI with the cotangent result
                }
                else
                {
                    MessageBox.Show("Invalid input for cotangent"); // Show error message for tangent = 0
                }
            }
        }

        private void PiButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = Math.PI.ToString();
            UpdateInputDisplay(); // Update the UI with the value of pi
        }

        private void SinhButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double value = double.Parse(currentInput);

                double result = Math.Sinh(value);
                currentInput = result.ToString();
                UpdateInputDisplay(); // Update the UI with the hyperbolic sine result
            }
        }

        private void CoshButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double value = double.Parse(currentInput);

                double result = Math.Cosh(value);
                currentInput = result.ToString();
                UpdateInputDisplay(); // Update the UI with the hyperbolic cosine result
            }
        }


        private void TanhButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double value = double.Parse(currentInput);

                double result = Math.Tanh(value);
                currentInput = result.ToString();
                UpdateInputDisplay(); // Update the UI with the hyperbolic tangent result
            }
        }

    }
}
