using System;
using System.Collections.Generic;
using System.IO;
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
using LibMas;

namespace project._13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix<int> matrix;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void IsToolPanelEnable_Checked(object sender, RoutedEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Visible;
        }

        private void IsToolPanelEnable_Unchecked(object sender, RoutedEventArgs e)
        {
            ToolPanel.Visibility = Visibility.Hidden;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int result = matrix.FindColumn();
            Results.Text = "Больше всего одинаковых элементов в столбце № " + result.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult userAnswer = MessageBox.Show("Вы действительно хотите сохранить таблицу?", "Сохранить", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (userAnswer == MessageBoxResult.Yes)
            {
                matrix.Save();
            }
            else MessageBox.Show("Сохранение отменено", "Сохранить", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Matrix<int> tempMatrix;
            tempMatrix = matrix.Open();
            Table.ItemsSource = tempMatrix.ToDataTable().DefaultView;
            tempMatrix = null;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Погодина В.\nПрактическая работа 13, вариант 8.\n " +
                "Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов," +
                "\nсодержащих максимальное количество одинаковых элементов.");
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader streamReader = new("config1.ini");
                using (streamReader)
                {
                    int rowCount = Convert.ToInt32(streamReader.ReadLine());
                    int columnCount = Convert.ToInt32(streamReader.ReadLine());
                    matrix = new Matrix<int>(rowCount, columnCount);
                    matrix.Fill(rowCount, columnCount);
                    Table.ItemsSource = matrix.ToDataTable().DefaultView;
                    tbTableInfo.Text = "Таблица размером " + rowCount + "х" + columnCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

      

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Password password = new Password();
            password.Owner = this;
            password.ShowDialog();
        }

        private void SettingsB_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new();
            settings.Owner = this;
            settings.ShowDialog();

        }
    }
}
