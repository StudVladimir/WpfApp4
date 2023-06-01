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
    /// Логика взаимодействия для ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        public ModelsPage()
        {
            InitializeComponent();
            DGridModels.ItemsSource = AutoCenterEntities.GetContext().Model.ToList();
        }

        private void BtnAdd_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ModelAddEdit(null));
        }

        private void BtnDelete_click(object sender, RoutedEventArgs e)
        {
            var modelforremoving = DGridModels.SelectedItems.Cast<Model>().ToList();

            if (MessageBox.Show("Вы точно хотите удалить эти элементы", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    AutoCenterEntities.GetContext().Model.RemoveRange(modelforremoving);
                    AutoCenterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridModels.ItemsSource = AutoCenterEntities.GetContext().Model.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
            }
        }

        private void BtnEdit_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ModelAddEdit((sender as Button).DataContext as Model));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
                if (Visibility == Visibility.Visible)
                {
                    AutoCenterEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridModels.ItemsSource = AutoCenterEntities.GetContext().Model.ToList();
                }
            
        }
    }
}
