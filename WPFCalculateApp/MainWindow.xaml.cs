using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Threading;

namespace WPFCalculateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = string.Empty;
        private double currentValue = 0;
        private string currentOperation = string.Empty;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

           

            ButtonPlus.Click += Operator_Click;
            ButtonMinus.Click += Operator_Click;
            ButtonMultiply.Click += Operator_Click;
            ButtonDivide.Click += Operator_Click;

            ButtonEquals.Click += Equals_Click;

            // Set click handler for Clear button
            ButtonClear.Click += Clear_Click;

            // Set click handler for Decimal button
            ButtonDecimal.Click += Decimal_Click;

            ButtonClearLast.Click += ClearLast_Click;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            label.Content = DateTime.Now.ToString("HH:mm");
        }

       

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            string operatorText = (sender as Button)?.Content.ToString();
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentValue = double.Parse(currentInput);
                currentOperation = operatorText;
                currentInput = string.Empty;
                result.Text = currentInput;
            }
        }

      

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(currentOperation))
            {
                double secondValue = double.Parse(currentInput);
                switch (currentOperation)
                {
                    case "+":
                        currentValue += secondValue;
                        break;
                    case "-":
                        currentValue -= secondValue;
                        break;
                    case "*":
                        currentValue *= secondValue;
                        break;
                    case "/":
                        if (secondValue != 0)
                            currentValue /= secondValue;
                        else
                            result.Text = "Error"; // Handle division by zero
                        break;
                }
                result.Text = currentValue.ToString();
                currentInput = string.Empty;
                currentOperation = string.Empty;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = string.Empty;
            currentValue = 0;
            currentOperation = string.Empty;
            result.Text = "0";
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                result.Text = currentInput;
            }
        }

        private void ClearLast_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && currentInput.Length > 1)
            {
                currentInput = currentInput.Remove(currentInput.Length - 1);
                result.Text = currentInput;
            }
            else
            {
                currentInput = string.Empty;
                result.Text = "0";
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button)?.Content.ToString();

            if (currentInput == "0")
            {
                currentInput = number;
            }
            else
            {
                currentInput += number;
            }
            result.Text = currentInput;
        }
    }
}
