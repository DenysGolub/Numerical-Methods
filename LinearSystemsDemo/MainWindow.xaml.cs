using Gu.Wpf.DataGrid2D;
using NumericalMethods;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[,] coeff_matrix = new double[0, 0];
        public MainWindow()
        {
            InitializeComponent();
            matrix.SetArray2D(coeff_matrix);
        }

        private void myUpDownControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            int value = int.Parse(myUpDownControl.Value.ToString());

            coeff_matrix = new double[value, value + 1];
            matrix.SetArray2D(coeff_matrix);

            List<string> headers = new List<string>();


            for (int i = 1; i <= value; i++)
            {
                headers.Add($"x{i}");
            }

            headers.Add("b");

            matrix.SetColumnHeadersSource(headers);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, double> item = null;
            Dictionary<string, double> solutions=null;
            LinearSystem linearSystem = null;
            if((bool)Zeidel.IsChecked)
            {
                linearSystem = new Zeidel();
            }
            else if((bool)SI.IsChecked)
            {
                linearSystem = new SimpleIteration();
            }
            else if((bool)LU.IsChecked)
            {
                linearSystem = new LU();
            }
            else if((bool)Relaxation.IsChecked)
            {
                linearSystem = new Relaxation();
            }

            linearSystem.Epsilon = double.Parse(Eps.Text.Replace(".",","));
            solutions = linearSystem.Solve(coeff_matrix);

            coreni.Clear();
            approx.Clear();
            foreach(var v in solutions)
            {
                coreni.Text += $"{v.Key}={v.Value}\n";
            }

            for (int i = 0; i < coeff_matrix.GetLength(0); i++)
            {
                double equation = 0;
                for (int j = 0; j < coeff_matrix.GetLength(1) - 1; j++)
                {
                    equation += coeff_matrix[i, j] * solutions[$"x{j + 1}"];
                }
                approx.Text += equation.ToString() + "\n";

            }
            coreni.ScrollToEnd();
        }
    }
}