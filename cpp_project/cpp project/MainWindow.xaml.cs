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

namespace cpp_project
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            string uzytkownik = this.login.Text;
            string haslo = this.password.Password;

            if (SprawdzNazweiHaslo(uzytkownik, haslo))
            {
                MessageBox.Show("Jest w systemie", "Zaalogowano");
            }
            else
            {
                MessageBox.Show("Niepoprawna nazwa użytkownika lub hasło", "Błąd logowania");
                return;
            }
        }
        public bool SprawdzNazweiHaslo(string uzytkownik, string haslo)
        {
            if (uzytkownik == "Wiktoria Woronowicz" & haslo == "password")
                return true;
            else
                return false;

        }
    }
}
