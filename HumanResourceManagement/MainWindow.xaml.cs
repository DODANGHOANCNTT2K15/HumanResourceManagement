using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.SqlClient;
using System.Data;
using HumanResourceManagement.ClassStore;

namespace HumanResourceManagement
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usernameCheck = txtUsername.Text;
            string passwordCheck = txtPassword.Text;
            if (usernameCheck.Trim() == "Tên đăng nhập" && passwordCheck.Trim() == "Mật khẩu")
            {
                txtErroInput.Visibility = Visibility.Visible;
                txtErroIncorrect.Visibility = Visibility.Hidden;
                txtErroInputUser.Visibility = Visibility.Hidden;
                txtErroInputPass.Visibility = Visibility.Hidden;
            }
            else if (usernameCheck.Trim() != "Tên đăng nhập" && passwordCheck.Trim() == "Mật khẩu")
            {
                txtErroInput.Visibility = Visibility.Hidden;
                txtErroIncorrect.Visibility = Visibility.Hidden;
                txtErroInputUser.Visibility = Visibility.Hidden;
                txtErroInputPass.Visibility = Visibility.Visible;
            }else if(usernameCheck.Trim() == "Tên đăng nhập" && passwordCheck.Trim() != "Mật khẩu")
            {
                txtErroInput.Visibility = Visibility.Hidden;
                txtErroIncorrect.Visibility = Visibility.Hidden;
                txtErroInputUser.Visibility = Visibility.Visible;
                txtErroInputPass.Visibility = Visibility.Hidden;
            }

            else if (usernameCheck.Trim() != "Tên đăng nhập" && passwordCheck.Trim() != "Mật khẩu")
            {
                txtErroInput.Visibility = Visibility.Hidden;
                txtErroIncorrect.Visibility = Visibility.Hidden;
                txtErroInputUser.Visibility = Visibility.Hidden;
                txtErroInputPass.Visibility = Visibility.Hidden;
                using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False"))
                {
                    conn.Open();
                    string query = "SELECT * FROM tb_DANGNHAP WHERE USERNAME = '" + usernameCheck + "' AND PASSWORD = '" + passwordCheck + "'";
                   
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            bool point = true;
                            dataReader.Read();
                            if (!dataReader.HasRows)
                            {
                                txtErroIncorrect.Visibility = Visibility.Visible; ; return;
                            }
                           
                            if (usernameCheck.Trim() == dataReader.GetString(1) && passwordCheck.Trim() == dataReader.GetString(2))
                            {
                                point = false;
                                string manv = dataReader.GetInt32(0).ToString();
                                dataReader.Close();

                                string query1 = "SELECT * FROM tb_NHANVIEN WHERE MANV = '" + manv + "'";
                                using (SqlCommand command1 = new SqlCommand(query1, conn))
                                {
                                    using (SqlDataReader dataReader1 = command1.ExecuteReader())
                                    {
                                        if (dataReader1.Read()) // Kiểm tra xem có dữ liệu trả về không
                                        {
                                            NhanVien nhanVienCurrent = new NhanVien(
                                                dataReader1.GetInt32(0),
                                                dataReader1.GetString(1),
                                                dataReader1.GetBoolean(2),
                                                dataReader1.GetDateTime(3).ToString("dd/MM/yyyy"),
                                                dataReader1.GetString(4),
                                                dataReader1.GetString(5),
                                                dataReader1.GetInt32(7),
                                                dataReader1.GetInt32(8),
                                                dataReader1.GetInt32(9)
                                                );
                                            MainApp mainApp = new MainApp(nhanVienCurrent);
                                            mainApp.Show();
                                            conn.Close();
                                            this.Hide();
                                        }
                                    }
                                }
                            }
                            
                            if (point) { txtErroIncorrect.Visibility = Visibility.Visible; }
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void TextBox_GotFocus_Username(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Tên đăng nhập")
            {
                txtUsername.Text = "";
            }
        }

        private void TextBox_LostFocus_Username(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Tên đăng nhập";
            }
        }
        private void TextBox_GotFocus_Password(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = "";
            }
        }

        private void TextBox_LostFocus_Password(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Mật khẩu";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
