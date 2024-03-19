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
                                int manv = dataReader.GetInt32(3);
      
                                dataReader.Close();

                                string query1 = "SELECT * FROM tb_NHANVIEN WHERE MANV = @maNV";
                                using (SqlCommand command1 = new SqlCommand(query1, conn))
                                {
                                    command1.Parameters.AddWithValue("@maNV", manv);
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

        private void TextBox_GotFocus_Username_DK(object sender, RoutedEventArgs e)
        {
            if (txtUsernameInput.Text == "Tên đăng nhập")
            {
                txtUsernameInput.Text = "";
            }
        }

        private void TextBox_LostFocus_Username_DK(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsernameInput.Text))
            {
                txtUsernameInput.Text = "Tên đăng nhập";
            }
        }
        private void TextBox_GotFocus_Password_DK(object sender, RoutedEventArgs e)
        {
            if (txtPasswordInput.Text == "Mật khẩu")
            {
                txtPasswordInput.Text = "";
            }
        }

        private void TextBox_LostFocus_Password_DK(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordInput.Text))
            {
                txtPasswordInput.Text = "Mật khẩu";
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
            gridDangNhap.Visibility = Visibility.Visible;
            gridDangKy.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridDangKy.Visibility=Visibility.Visible;
            gridDangNhap.Visibility=Visibility.Hidden;
            txtErroInput.Visibility = Visibility.Hidden;
            txtErroIncorrect.Visibility = Visibility.Hidden;
            txtErroInputUser.Visibility = Visibility.Hidden;
            txtErroInputPass.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";

            cbListNV.Items.Clear();
            string query = "SELECT TENNV, MANV FROM tb_NHANVIEN WHERE MANV NOT IN (SELECT MANV FROM tb_DANGNHAP)";
            if (cbListNV.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENNV"].ToString(),
                                Tag = reader1["MANV"].ToString()
                            };
                             
                            cbListNV.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "INSERT INTO tb_DANGNHAP (USERNAME, PASSWORD, MANV) VALUES (@userName, @passWord, @maNV)";

            if (txtUsernameInput.Text == "Tên đăng nhập" ||
                txtPasswordInput.Text == "Mật khẩu"  || cbListNV.SelectedItem == null)
            {
                txtErroInputDK.Visibility = Visibility.Visible;
            }
            else
            {
                ComboBoxItem selectedCV = (ComboBoxItem)cbListNV.SelectedItem;
                int maNV = int.Parse(selectedCV.Tag.ToString());

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@userName", txtUsernameInput.Text);
                        command.Parameters.AddWithValue("@passWord", txtPasswordInput.Text);
                        command.Parameters.AddWithValue("@maNV", maNV);
                       
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm tài khoản thành công !");
                        conn.Close();
                    }
                }
            }
        }
    }
}
