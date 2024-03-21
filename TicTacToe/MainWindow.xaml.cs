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
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button(){ Content = "", FontSize = 40 };
                    button.Click += Button_Click;
                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    button.BorderThickness = new Thickness(1);
                    grid.Children.Add(button);
                }
        }

        bool xTurn = true;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (e.Source as Button);

            if (xTurn)
            {
                btn.Content = "X";
            }
            else
            {
                btn.Content = "O";
            }

            string res = CheckWin();
            if (!string.IsNullOrEmpty(res))
            {
                labelWhoWins.Content = $"{res} player wins";
                DisableAllButtons();
            }

            btn.IsEnabled = false;

            xTurn = !xTurn;
        }

        private string CheckWin()
        {
            int xCount = 0;
            int yCount = 0;
            string res = "";

            // Check horizontal lines
            for (int i = 0; i < 3; i++)
            {
                xCount = 0;
                yCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    Button btn = GetControlInGrid(i, j) as Button;
                    string txt = btn.Content.ToString();
                    if (txt == "X")
                        xCount++;
                    else if (txt == "O")
                        yCount++;
                }
                if (xCount == 3)
                {
                    return "X";
                }
                if (yCount == 3)
                {
                    return "O";
                }
            }

            // Check vertical lines
            for (int i = 0; i < 3; i++)
            {
                xCount = 0;
                yCount = 0;
                for (int j = 0; j < 3; j++)
                {
                    Button btn = GetControlInGrid(j, i) as Button;
                    string txt = btn.Content.ToString();
                    if (txt == "X")
                        xCount++;
                    else if (txt == "O")
                        yCount++;
                }
                if (xCount == 3)
                {
                    return "X";
                }
                if (yCount == 3)
                {
                    return "O";
                }
            }

            xCount = 0;
            yCount = 0;

            // Check diagonals
            for (int i = 0; i < 3; i++)
            {

                Button btn = GetControlInGrid(i, i) as Button;
                string txt = btn.Content.ToString();
                if (txt == "X")
                    xCount++;
                else if (txt == "O")
                    yCount++;

                if (xCount == 3)
                {
                    return "X";
                }
                if (yCount == 3)
                {
                    return "O";
                }
            }

            xCount = 0;
            yCount = 0;

            for (int i = 0; i < 3; i++)
            {
                Button btn = GetControlInGrid(i, 2-i) as Button;
                string txt = btn.Content.ToString();
                if (txt == "X")
                    xCount++;
                else if (txt == "O")
                    yCount++;

                if (xCount == 3)
                {
                    return "X";
                }
                if (yCount == 3)
                {
                    return "O";
                }
            }

            return res;
        }

        private UIElement GetControlInGrid(int row, int column)
        {
            foreach (UIElement element in grid.Children)
            {
                if (Grid.GetRow(element) == row && Grid.GetColumn(element) == column)
                {
                    return element;
                }
            }

            return null; // Control not found
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = GetControlInGrid(i, j) as Button;
                    btn.Content = "";
                    btn.IsEnabled = true;
                }
            }
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = GetControlInGrid(i, j) as Button;
                    btn.IsEnabled = false;
                }
            }
        }
    }
}