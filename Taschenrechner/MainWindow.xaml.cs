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

namespace Taschenrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static double zahl1 = 0, zahl2 = 0;
        static string op = "";
        private void Input(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Output.Text += button.Content.ToString();
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == "qs") op = "qs";
            if (button.Content.ToString() == "!") op = "!";
            if (!double.TryParse(Output.Text.ToString(), out zahl2))
            {
                OutputRechnung.Text = "Fehlerhafte Eingabe";
                Output.Text = "";
            }
            else
            {
                Output.Text = "";
                OutputRechnung.Text += " " + zahl2.ToString();
                Output.Text = Maths.Basics(zahl1, zahl2, op);
            }
        }
        private void Operator(object sender, RoutedEventArgs e)
        {
            OutputRechnung.Text = "";
            Button button = (Button)sender;
            op = button.Content.ToString();
            OutPut(op);
        }
        private void OutPut(string op)
        {
            bool inputOK = double.TryParse(Output.Text.ToString(), out zahl1);
            if (inputOK)
            {
                OutputRechnung.Text = $"{Output.Text} {op}";
                Output.Text = "";
            }
            else
            {
                OutputRechnung.Text = "Fehlerhafte Eingabe";
                Output.Text = "";
            }
        }

        private void FakultaetCall(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Output.Text.ToString(), out zahl1))
            {
                OutputRechnung.Text += $"{Output.Text}!";
                Output.Text = Maths.Fakultaet(zahl1).ToString();
            }
        }
        private void qsCall(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Output.Text.ToString(), out zahl1))
            {
                OutputRechnung.Text += $"qs {Output.Text}";
                Output.Text = Maths.qs(zahl1.ToString()).ToString();
            }
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Output.Text.ToString()))
            {
                Button button = (Button)sender;
                if (button.Content.ToString() == "DEL")
                {
                    string oput = Output.Text.ToString();
                    Output.Text = oput.Remove(oput.Length - 1, 1);
                }
                else if (button.Content.ToString() == "C")
                {
                    Output.Text = "";
                }
                else
                {
                    Output.Text = "";
                    OutputRechnung.Text = "";
                }
            }
        }
        private void Gleitkomma(object sender, RoutedEventArgs e)
        {
            if (rb_Integer.IsChecked == true)
            {
                btn_Komma.IsEnabled = false;
            }
            else
            {
                btn_Komma.IsEnabled = true;
            }
        }
    }
}
