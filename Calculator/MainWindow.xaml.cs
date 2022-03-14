using System;
using System.Data;
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
    public partial class MainWindow : Window
    {

        private double x = 0;
        private double y = 0;
        private string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if(button.Content.ToString() == "+/-")
            {
                if(display.Text.Contains("-"))
                {
                    display.Text = display.Text.Replace("-","");
                }
                else
                {
                    display.Text = "-" + display.Text;
                }
                return;
            }

            if (!display.Text.Contains(".") && button.Content.ToString() == ",")
            {
                display.Text += ".";
                return;
            }
            else if(button.Content.ToString()==",")
            {
                MessageBox.Show("Nie można dodać dwóch przecinków.");
                return;
            }

            display.Text += button.Content.ToString();
        }

        private void Aritmetic_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (display.Text!="")
            {
                operation += "(" + display.Text + ")" + button.Content.ToString();
            }
            display.Text = "";
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            if(display.Text != "")
            {
                operation += "(" + display.Text + ")";
                var v = dt.Compute(operation,"");
                display.Text = v.ToString();
                if (display.Text.Contains(","))
                {
                    display.Text = display.Text.Replace(",", ".");
                }
            }
        operation = "";
        }
    }
}
