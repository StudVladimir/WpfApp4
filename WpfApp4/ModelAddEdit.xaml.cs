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
    /// Логика взаимодействия для ModelAddEdit.xaml
    /// </summary>
    public partial class ModelAddEdit : Page
    {
        private Model _currentModel = new Model();
        public ModelAddEdit(Model selectedModel)
        {
            InitializeComponent();
            if (selectedModel != null)
                _currentModel = selectedModel;
            DataContext = _currentModel;
            EngineTypeCB.ItemsSource = AutoCenterEntities.GetContext().EngineType.ToList();
        }

        private void BtnSave_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentModel.Mark))
                errors.AppendLine("Уажите Марку");
            if (string.IsNullOrWhiteSpace(_currentModel.Width))
                errors.AppendLine("Уажите Ширину авто");
            if (string.IsNullOrWhiteSpace(_currentModel.Height))
                errors.AppendLine("Уажите Высоту авто");
            if (string.IsNullOrWhiteSpace(_currentModel.Length))
                errors.AppendLine("Уажите Длинну авто");
            if (string.IsNullOrWhiteSpace(_currentModel.Complectation))
                errors.AppendLine("Уажите Комплектацию");
            if (string.IsNullOrWhiteSpace(_currentModel.HorsePower))
                errors.AppendLine("Уажите ЛС");
            if (string.IsNullOrWhiteSpace(_currentModel.EngineVolume))
                errors.AppendLine("Уажите Объем двигателя");
            if (string.IsNullOrWhiteSpace(_currentModel.Places))
                errors.AppendLine("Уажите Колличество мест");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            AutoCenterEntities.GetContext().Model.Add(_currentModel);

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
