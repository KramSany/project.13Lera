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
using System.Windows.Shapes;

namespace project._13
{
    /// <summary>
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Password == "123")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Пароль неверный. Повторите попытку.");
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
        }
    }
}
