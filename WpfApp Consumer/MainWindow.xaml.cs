using System.Net.Http;
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
using WpfApp_Consumer.Models;

namespace WpfApp_Consumer
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res= await httpClient.GetAsync("http://localhost:5037/api/Department");
            if (res.IsSuccessStatusCode)
            {
                string msg=await res.Content.ReadAsStringAsync();
                List<Department> departments = JsonSerializer.Deserialize<List<Department>>(msg)??new List<Department>();
                DeptList.ItemsSource = departments;
            }
            else
            {
                MessageBox.Show("TRY AGAIN");
            } 
                
        }
    }
}