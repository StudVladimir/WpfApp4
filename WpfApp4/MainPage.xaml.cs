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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnClient_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void BtnService_click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTestDrive_click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAuto_click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnModels_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ModelsPage());
        }
    }
}
