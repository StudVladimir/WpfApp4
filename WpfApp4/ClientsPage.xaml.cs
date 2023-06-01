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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            DGridClients.ItemsSource = AutoCenterEntities.GetContext().Clients.ToList();
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientAddEdit((sender as Button).DataContext as Clients));
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientAddEdit(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var clientsforremoving = DGridClients.SelectedItems.Cast<Clients>().ToList();

            if(MessageBox.Show("Вы точно хотите удалить эти элементы","Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    AutoCenterEntities.GetContext().Clients.RemoveRange(clientsforremoving);
                    AutoCenterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridClients.ItemsSource = AutoCenterEntities.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AutoCenterEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=>p.Reload());
                DGridClients.ItemsSource = AutoCenterEntities.GetContext().Clients.ToList();
            }
        }
    }
}
