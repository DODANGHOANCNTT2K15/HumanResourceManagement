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
using System.Data.SqlClient;
using System.Data;


namespace HumanResourceManagement
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class MainApp : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False");

        public MainApp()
        {
            InitializeComponent();
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đây là nút hình tròn!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void LoadData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_NHANVIEN", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataNHANVIEN.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
