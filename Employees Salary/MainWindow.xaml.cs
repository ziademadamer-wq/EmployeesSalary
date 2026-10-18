using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Employees_Salary.BL;
using Employees_Salary.DAL;
using Employees_Salary.DAL.Converters;
using Employees_Salary.Domains;
namespace Employees_Salary
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //select storage type to use for data storage (Json or Database)
            StorageType storageType = StorageType.Database; 

            BusinessLayer BL = new BusinessLayer(storageType);

            var lstemployees = BL.GetAll(out string message);
            
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }
        
            //6. show employees' names and salarys on the screen
            grdEmployees.ItemsSource = lstemployees;
        }
    }
}