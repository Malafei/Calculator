using System;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Operation { NONE, SUM, SUB, MULT, DIV }

        Operation operation = Operation.NONE;
        decimal leftOperand = 0;
        bool Sleep = false;
        decimal result = 0;


        public decimal CurrentValue { get { return decimal.Parse(currentTextBox.Text); } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentTextBox.Text.Length == 1 && CurrentValue == 0)
                currentTextBox.Text = ((Button)sender).Content.ToString();
            else if (Sleep)
            {
                currentTextBox.Text = ((Button)sender).Content.ToString();
                Sleep = false;
            }
            else
                currentTextBox.Text += ((Button)sender).Content.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            currentTextBox.Text = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentTextBox.Text.Length > 0)
                currentTextBox.Text = currentTextBox.Text.Remove(currentTextBox.Text.Length - 1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentTextBox.Text.Length > 0
                && !currentTextBox.Text.Contains(","))
                currentTextBox.Text += ",";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            historyTextBox.Text = $"{ CurrentValue} + " ;
            Sleep = true;
            operation = Operation.SUM;
            leftOperand = CurrentValue;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            historyTextBox.Text = $"{ CurrentValue} - ";
            Sleep = true;
            operation = Operation.SUB;
            leftOperand = CurrentValue;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            historyTextBox.Text += $"{CurrentValue} = ";
            switch (operation)
            {
                case Operation.SUM:
                    result = (leftOperand + CurrentValue);
                    break;
                case Operation.SUB:
                    result = (leftOperand - CurrentValue);
                    break;
                case Operation.MULT:
                    result = (leftOperand * CurrentValue);
                    break;
                case Operation.DIV:
                    if (CurrentValue != 0)
                        result = (leftOperand / CurrentValue);
                    else
                    {
                        MessageBox.Show("На ноль не ділиться");
                        return;
                    }
                    break;

            }
            currentTextBox.Text = result.ToString();
            leftOperand = 0;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            currentTextBox.Text = "0";
            historyTextBox.Clear();

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            historyTextBox.Text = $"{ CurrentValue} / ";
            Sleep = true;
            operation = Operation.DIV;
            leftOperand = CurrentValue;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            historyTextBox.Text = $"{ CurrentValue} * ";
            Sleep = true;
            operation = Operation.MULT;
            leftOperand = CurrentValue;
        }
    }
}
