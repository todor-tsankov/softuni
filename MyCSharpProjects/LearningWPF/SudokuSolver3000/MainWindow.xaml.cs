using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

using SudokuSolver.Core;
using SudokuSolver.Common;
using SudokuSolver.Core.Contracts;
using System.Windows.Documents;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TextBox[,] textBoxes;
        private IEngine engine;
        private readonly Validator validator;

        public MainWindow()
        {
            this.textBoxes = new TextBox[Constants.RowsCount, Constants.ColsCount];
            this.validator = new Validator();

            InitializeComponent();
            CreateTextBoxes();
        }


        private void CreateTextBoxes()
        {
            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    var currentTextBox = new TextBox();

                    SetTextBoxProperties(currentTextBox, row, col);
                    SetGridProperties(row + 1, col + 1, currentTextBox);

                    this.textBoxes[row, col] = currentTextBox;
                }
            }
        }

        private void SetGridProperties(int row, int col, TextBox currentTextBox)
        {
            Grid.SetColumn(currentTextBox, col);
            Grid.SetRow(currentTextBox, row);

            MainGrid.Children.Add(currentTextBox);
        }

        private static void SetTextBoxProperties(TextBox currentTextBox, int row, int col)
        {
            currentTextBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            currentTextBox.VerticalContentAlignment = VerticalAlignment.Center;

            currentTextBox.FontSize = 20;
            currentTextBox.FontWeight = FontWeights.Bold;
            currentTextBox.Foreground = Brushes.Coral;
            currentTextBox.BorderBrush = Brushes.Gray;

            currentTextBox.MaxLength = 1;

            const double outsideBorderThickness = 3.5;
            const double insideBorderThickness = 2;
            const double defaultThickness = 0.75;

            double top = defaultThickness;
            double down = defaultThickness;

            double left = defaultThickness;
            double right = defaultThickness;


            if (row == Constants.MinRow)
            {
                top = outsideBorderThickness;
            }

            if (row == Constants.MaxRow)
            {
                down = outsideBorderThickness;
            }

            if (col == Constants.MinCol)
            {
                left = outsideBorderThickness;
            }

            if (col == Constants.MaxCol)
            {
                right = outsideBorderThickness;
            }

            if (row == Constants.MinRow + 2
                || row == Constants.MinRow + 5)
            {
                down = insideBorderThickness;
            }

            if (col == Constants.MinCol + 2
                || col == Constants.MinCol + 5)
            {
                right = insideBorderThickness;
            }

            currentTextBox.BorderThickness = new Thickness(left, top, right, down);
        }

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            this.engine = new SudokuEngine();

            var matrix = this.ParseTextBoxes();
            var valid = this.validator.ValidateMatrix(matrix);

            if (!valid)
            {
                return;
            }

            this.engine.Solve(matrix, Constants.MinRow, Constants.MinCol);
            var solved = this.engine.Matrix;

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    this.textBoxes[row, col].Text = solved[row, col].ToString();
                }
            }
        }

        private int[,] ParseTextBoxes()
        {
            var matrix = new int[Constants.RowsCount, Constants.ColsCount];

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    var digitStr = this.textBoxes[row, col].Text;

                    var digit = 0;

                    if (digitStr != string.Empty)
                    {
                        var success = int.TryParse(digitStr, out digit);

                        if (!success)
                        {
                            return null;
                        }
                    }

                    matrix[row, col] = digit;
                }
            }

            return matrix;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    this.textBoxes[row, col].Text = "";
                }
            }
        }
    }
}
