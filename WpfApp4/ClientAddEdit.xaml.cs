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
    /// Логика взаимодействия для ClientAddEdit.xaml
    /// </summary>
    public partial class ClientAddEdit : Page
    {
        private Clients _currentClient = new Clients();
        public ClientAddEdit( Clients selectedClient)
        {
            InitializeComponent();

            if(selectedClient!= null)
            {
                _currentClient = selectedClient;
            }
            DataContext = _currentClient;
        }

        private void BtnSave_clcik(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClient.Name))
                errors.AppendLine("Уажите Имя");
            if (string.IsNullOrWhiteSpace(_currentClient.Surname))
                errors.AppendLine("Уажите Фамилию");
            if (string.IsNullOrWhiteSpace(_currentClient.Patronymic))
                errors.AppendLine("Уажите Отчество");
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
                errors.AppendLine("Уажите Телефон");
            if (string.IsNullOrWhiteSpace(_currentClient.Email))
                errors.AppendLine("Уажите Email");
            if (_currentClient.BirthDate == null)
                errors.AppendLine("Укажите Дату рождения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            AutoCenterEntities.GetContext().Clients.Add(_currentClient);

            try
            {
                AutoCenterEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
            
        }
    }
}
