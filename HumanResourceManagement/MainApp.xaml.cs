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
using HumanResourceManagement.ClassStore;
using System.Security.Cryptography;
using System.Globalization;


namespace HumanResourceManagement
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    /// 

    public partial class MainApp : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False");
        NhanVien _nhanVienCurrent = new NhanVien();
        public MainApp(NhanVien nhanVienCurrent)
        {
            InitializeComponent();
            txtNhanVienCurrent.Content = nhanVienCurrent.TenNV;
            _nhanVienCurrent = nhanVienCurrent;
            txtMainTitle.Content = "TRANG CHÍNH";
        }

        private void GetDuLieuTuBangKhac(string query, TextBlock txtB)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            txtB.Text = dataReader.GetString(0);
                        }
                    }
                }
                conn.Close();
            }
        }
        private void GetDuLieuTuBangKhac1(string query, ref string a)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            a = dataReader.GetString(0);
                        }
                    }
                }
                conn.Close();
            }
        }
        private void GetDuLieuTuBangKhac3(string query, TextBox txtB)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            txtB.Text = dataReader.GetString(0);
                        }
                    }
                }
                conn.Close();
            }
        }

        // nút xem thông tin cá nhân
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Visible;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;

            txtBMaNV.Text = _nhanVienCurrent.MaNV.ToString();
            txtBTenNV.Text = _nhanVienCurrent.TenNV.ToString();
            string query = "SELECT p.TENPB " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_PHONGBAN p ON n.MAPB = p.MAPB " +// Kết nối hai bảng dựa trên cột MAPB
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query, txtBPB);
            string query1 = "SELECT p.TENCV " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_CHUCVU p ON n.MACV = p.MACV " +// Kết nối hai bảng dựa trên cột MAPB
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query1, txtBCV);
            string query2 = "SELECT p.TENQUYEN " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_QUYEN p ON n.MAQUYEN = p.MAQUYEN " +// Kết nối hai bảng dựa trên cột MAPB
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query2, txtBQuyen);
            if (_nhanVienCurrent.GioiTinh == false) { txtBGT.Text = "Nữ"; } else { txtBGT.Text = "Nam"; }
            txtBDC.Text = _nhanVienCurrent.DiaChi;
            txtBSDT.Text = _nhanVienCurrent.DienThoai;
            txtBNS.Text = _nhanVienCurrent.NgaySinh;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Visible;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            txtMainTitle.Content = "TRANG CHÍNH";
        }

        // nút tạo ra danh sách nhân viên
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH NHÂN VIÊN";
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Visible;
            gridNhanh2_1.Visibility = Visibility.Visible;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;


            conn.Open();
            string sql = "SELECT * FROM tb_NhanVien";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<NhanVien> sqlValues = new List<NhanVien>();

            while (reader.Read())
            {
                // Thêm giá trị từ cột bạn quan tâm vào danh sách
                // Ví dụ: giả sử bạn muốn lấy giá trị từ cột "TenNhanVien"
                NhanVien newNhanVien = new NhanVien();
                newNhanVien.MaNV = int.Parse(reader["MANV"].ToString());
                newNhanVien.TenNV = reader["TENNV"].ToString();
                newNhanVien.MaPB = int.Parse(reader["MAPB"].ToString());
                newNhanVien.MaCV = int.Parse(reader["MACV"].ToString());
                newNhanVien.MaQuyen = int.Parse(reader["MAQUYEN"].ToString());
                sqlValues.Add(newNhanVien);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (NhanVien nhanVien in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush(Color.FromRgb(236, 21, 21)),
                    Margin = new Thickness(0, 20, 0, 0),
                    CornerRadius = new CornerRadius(10),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Tạo một StackPanel mới
                StackPanel stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Orientation = Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(27, 0, 0, 0),
                    Width = 991
                };


                // Tạo một Label mới và gán giá trị từ SQL vào Content

                Label label = new Label
                {

                    Content = nhanVien.TenNV,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                string query1 = "SELECT p.TENPB " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                           "FROM tb_NHANVIEN n " +
                           "JOIN tb_PHONGBAN p ON n.MAPB = p.MAPB " +// Kết nối hai bảng dựa trên cột MAPB
                           "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                string labelString1 = "";
                GetDuLieuTuBangKhac1(query1, ref labelString1);

                Label label1 = new Label
                {
                    Content = labelString1,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                string query2 = "SELECT p.TENCV " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                           "FROM tb_NHANVIEN n " +
                           "JOIN tb_CHUCVU p ON n.MACV = p.MACV " +// Kết nối hai bảng dựa trên cột MAPB
                           "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                string labelString2 = "";
                GetDuLieuTuBangKhac1(query2, ref labelString2);
                Label label2 = new Label
                {
                    Content = labelString2,
                    Foreground = Brushes.White,
                    Width = 214,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };
                string query3 = "SELECT p.TENQUYEN " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                           "FROM tb_NHANVIEN n " +
                           "JOIN tb_QUYEN p ON n.MAQUYEN = p.MAQUYEN " +// Kết nối hai bảng dựa trên cột MAPB
                           "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                string labelString3 = "";
                GetDuLieuTuBangKhac1(query3, ref labelString3);
                Label label3 = new Label
                {
                    Content = labelString3,
                    Foreground = Brushes.White,
                    Width = 217,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };
                Button button1 = new Button
                {
                    Content = "Chỉnh sửa",
                    Width = 70,
                };
                button1.Click += (s, args) => Button_Click_10(sender, e, nhanVien.MaNV);
                
                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_11(sender, e, nhanVien.MaNV);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(button1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewData.Content = wrapPanel;
            conn.Close();
        }

        // nút cập nhật thông tin trong nhánh 4 cập nhật thông tin cá nhân
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "UPDATE tb_NHANVIEN SET TENNV = @tenNV, GIOITINH = @gioiTinh, NGAYSINH = @ngaySinh, DIENTHOAI = @dienThoai, DIACHI = @diaChi, MAPB = @maPB, MAQUYEN = @maQuyen, MACV = @maCV WHERE MaNV = @maNV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    if (rbNamUpdatePersonal.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@gioiTinh", true); // Nam
                    }
                    else if (rbNuUpdatePersonal.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@gioiTinh", false);
                    }
                    command.Parameters.AddWithValue("@tenNV", txtBETENNV.Text);
                    command.Parameters.AddWithValue("@dienThoai", txtBESDT.Text);
                    command.Parameters.AddWithValue("@diaChi", txtBEDC.Text);
                    command.Parameters.AddWithValue("@ngaySinh", ngaySinhUpdatePersonal.SelectedDate);
                    command.Parameters.AddWithValue("@maPB", ((ComboBoxItem)cbPhongBanUpdatePersonal.SelectedItem).Tag.ToString());
                    command.Parameters.AddWithValue("@maCV", ((ComboBoxItem)cbChucVuUpdatePersonal.SelectedItem).Tag.ToString());
                    command.Parameters.AddWithValue("@maQuyen", _nhanVienCurrent.MaQuyen);
                    command.Parameters.AddWithValue("@maNV", _nhanVienCurrent.MaNV);

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật nhân viên thành công !");
                    conn.Close();
                }
            }
        }

        // nút vào nhánh cập nhật thông tin cá nhân
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Visible;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;

            txtBEMANV.Text = _nhanVienCurrent.MaNV.ToString();
            txtBETENNV.Text = _nhanVienCurrent.TenNV.ToString();

            if (_nhanVienCurrent.GioiTinh == true) { rbNamUpdatePersonal.IsChecked = true; } else { rbNuUpdatePersonal.IsChecked = true; }
            txtBEDC.Text = _nhanVienCurrent.DiaChi;
            txtBESDT.Text = _nhanVienCurrent.DienThoai;
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT TENPB, MAPB FROM tb_PHONGBAN";


            if (cbPhongBanUpdatePersonal.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENPB"].ToString(),
                                Tag = reader["MAPB"].ToString()
                            };

                            cbPhongBanUpdatePersonal.Items.Add(item);
                        }
                        foreach (ComboBoxItem item in cbPhongBanUpdatePersonal.Items)
                        {
                            if (item.Tag.ToString() == _nhanVienCurrent.MaCV.ToString())
                            {
                                cbPhongBanUpdatePersonal.SelectedItem = item;
                                break;
                            }
                        }
                        conn.Close();
                    }
                }

            }
            if(cbChucVuUpdatePersonal.Items.Count == 0)
            {
                string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENCV"].ToString(),
                                Tag = reader["MACV"].ToString()
                            };
                            cbChucVuUpdatePersonal.Items.Add(item);
                        }
                        foreach (ComboBoxItem item in cbChucVuUpdatePersonal.Items)
                        {
                            if (item.Tag.ToString() == _nhanVienCurrent.MaCV.ToString())
                            {
                                cbChucVuUpdatePersonal.SelectedItem = item;
                                break;
                            }
                        }
                        conn.Close();
                    }
                }
            }
            DateTime dt = DateTime.ParseExact(_nhanVienCurrent.NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ngaySinhUpdatePersonal.SelectedDate = dt;
        }

        // nút xác nhận thêm nhân viên
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "INSERT INTO tb_NHANVIEN (TENNV, GIOITINH, NGAYSINH, DIENTHOAI, DIACHI, MAPB, MAQUYEN, MACV) VALUES (@tenNV, @gioiTinh,@ngaySinh, @dienThoai, @diaChi, @maPB,@maQuyen,@maCV)";

            if (txtBETENNVADD.Text == "Vui lòng nhập thông tin" ||
                txtBESDTADD.Text == "Vui lòng nhập thông tin" ||
                ngaySinhNV.SelectedDate == null ||
                txtBEDCADD.Text == "Vui lòng nhập thông tin" ||
                cbPhongBan.SelectedItem == null || cbChucVu.SelectedItem == null
                )
            {
                erroInputAdd.Visibility = Visibility.Visible;
            }
            else
            {
                erroInputAdd.Visibility = Visibility.Hidden;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        if (rbNam.IsChecked == true)
                        {
                            command.Parameters.AddWithValue("@gioiTinh", true); // Nam
                        }
                        else if (rbNu.IsChecked == true)
                        {
                            command.Parameters.AddWithValue("@gioiTinh", false);
                        }
                        command.Parameters.AddWithValue("@tenNV", txtBETENNVADD.Text);
                        command.Parameters.AddWithValue("@dienThoai", txtBESDTADD.Text);
                        command.Parameters.AddWithValue("@diaChi", txtBEDCADD.Text);
                        command.Parameters.AddWithValue("@ngaySinh", ngaySinhNV.SelectedDate);
                        command.Parameters.AddWithValue("@maPB", ((ComboBoxItem)cbPhongBan.SelectedItem).Tag.ToString());
                        command.Parameters.AddWithValue("@maCV", ((ComboBoxItem)cbChucVu.SelectedItem).Tag.ToString());
                        command.Parameters.AddWithValue("@maQuyen", 4);



                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm nhân viên thành công !");
                        conn.Close();
                    }
                }
            }
        }

        // nút thêm nhân viên trong nhánh 2
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Visible;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            if (cbPhongBan.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENPB"].ToString(),
                                Tag = reader["MAPB"].ToString()
                            };

                            cbPhongBan.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
            
            if(cbChucVu.Items.Count == 0)
            {
                string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENCV"].ToString(),
                                Tag = reader["MACV"].ToString()
                            };
                            cbChucVu.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
        }

        // nút hủy cho nhánh 5 thêm nhân viên
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Visible;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
        }

        // nút hủy cho nhánh 4 cập nhận thông tin cá nhân
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Visible;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Visible;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
        }

        // xem thông tin của nhân viên khác 
        private void Button_Click_10(object sender, RoutedEventArgs e, int maNV)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Visible;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;

            buttonEditOrderNV.Tag = maNV;
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT * FROM tb_NHANVIEN WHERE MANV = @maNV";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        txtBMaNVO.Text = reader["MANV"].ToString();
                        txtBTenNVO.Text = reader["TENNV"].ToString();
                        string query1 = "SELECT p.TENPB " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                        "FROM tb_NHANVIEN n " +
                                        "JOIN tb_PHONGBAN p ON n.MAPB = p.MAPB " +// Kết nối hai bảng dựa trên cột MAPB
                                        "WHERE n.MANV = '" + maNV + "'";
                        GetDuLieuTuBangKhac(query1, txtBPBO);
                        string query2 = "SELECT p.TENCV " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                        "FROM tb_NHANVIEN n " +
                                        "JOIN tb_CHUCVU p ON n.MACV = p.MACV " +// Kết nối hai bảng dựa trên cột MAPB
                                        "WHERE n.MANV = '" + maNV + "'";
                        GetDuLieuTuBangKhac(query2, txtBCVO);
                        string query3 = "SELECT p.TENQUYEN " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                        "FROM tb_NHANVIEN n " +
                                        "JOIN tb_QUYEN p ON n.MAQUYEN = p.MAQUYEN " +// Kết nối hai bảng dựa trên cột MAPB
                                        "WHERE n.MANV = '" + maNV + "'";
                        GetDuLieuTuBangKhac(query3, txtBQuyenO);
                        if (bool.Parse(reader["GIOITINH"].ToString()) == false) { txtBGTO.Text = "Nữ"; } else { txtBGTO.Text = "Nam"; }
                        txtBDCO.Text = reader["DIACHI"].ToString();
                        txtBSDTO.Text = reader["DIENTHOAI"].ToString();
                        txtBNSO.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    }
                    conn.Close();
                }
            }
        }

        // nút xóa nhân viên và tải lại danh sách cho nhân viên
        private void Button_Click_11(object sender, RoutedEventArgs e, int maNV)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "DELETE FROM tb_NHANVIEN WHERE MANV = @maNV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);

                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn xóa chứ", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Open();
                        string sql = "SELECT * FROM tb_NhanVien";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader reader = cmd.ExecuteReader();

                        List<NhanVien> sqlValues = new List<NhanVien>();

                        while (reader.Read())
                        {
                            // Thêm giá trị từ cột bạn quan tâm vào danh sách
                            // Ví dụ: giả sử bạn muốn lấy giá trị từ cột "TenNhanVien"
                            NhanVien newNhanVien = new NhanVien();
                            newNhanVien.MaNV = int.Parse(reader["MANV"].ToString());
                            newNhanVien.TenNV = reader["TENNV"].ToString();
                            newNhanVien.MaPB = int.Parse(reader["MAPB"].ToString());
                            newNhanVien.MaCV = int.Parse(reader["MACV"].ToString());
                            newNhanVien.MaQuyen = int.Parse(reader["MAQUYEN"].ToString());
                            sqlValues.Add(newNhanVien);
                        }
                        // Tạo một WrapPanel
                        WrapPanel wrapPanel = new WrapPanel();

                        foreach (NhanVien nhanVien in sqlValues)
                        {
                            // Tạo một Border mới
                            Border border = new Border
                            {
                                Width = 1050,
                                Height = 60,
                                Background = new SolidColorBrush(Color.FromRgb(236, 21, 21)),
                                Margin = new Thickness(0, 20, 0, 0),
                                CornerRadius = new CornerRadius(10),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Center
                            };

                            // Tạo một StackPanel mới
                            StackPanel stackPanel = new StackPanel
                            {
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Orientation = Orientation.Horizontal,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(27, 0, 0, 0),
                                Width = 991
                            };


                            // Tạo một Label mới và gán giá trị từ SQL vào Content

                            Label label = new Label
                            {

                                Content = nhanVien.TenNV,
                                Foreground = Brushes.White,
                                Width = 231,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontFamily = new FontFamily("Bahnschrift"),
                                FontSize = 14
                            };

                            string query1 = "SELECT p.TENPB " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                       "FROM tb_NHANVIEN n " +
                                       "JOIN tb_PHONGBAN p ON n.MAPB = p.MAPB " +// Kết nối hai bảng dựa trên cột MAPB
                                       "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                            string labelString1 = "";
                            GetDuLieuTuBangKhac1(query1, ref labelString1);

                            Label label1 = new Label
                            {
                                Content = labelString1,
                                Foreground = Brushes.White,
                                Width = 201,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontFamily = new FontFamily("Bahnschrift"),
                                FontSize = 14
                            };

                            string query2 = "SELECT p.TENCV " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                       "FROM tb_NHANVIEN n " +
                                       "JOIN tb_CHUCVU p ON n.MACV = p.MACV " +// Kết nối hai bảng dựa trên cột MAPB
                                       "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                            string labelString2 = "";
                            GetDuLieuTuBangKhac1(query2, ref labelString2);
                            Label label2 = new Label
                            {
                                Content = labelString2,
                                Foreground = Brushes.White,
                                Width = 214,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontFamily = new FontFamily("Bahnschrift"),
                                FontSize = 14
                            };
                            string query3 = "SELECT p.TENQUYEN " + // Chọn cột TENPB từ bảng tb_PHONGBAN
                                       "FROM tb_NHANVIEN n " +
                                       "JOIN tb_QUYEN p ON n.MAQUYEN = p.MAQUYEN " +// Kết nối hai bảng dựa trên cột MAPB
                                       "WHERE n.MANV = '" + nhanVien.MaNV + "'";
                            string labelString3 = "";
                            GetDuLieuTuBangKhac1(query3, ref labelString3);
                            Label label3 = new Label
                            {
                                Content = labelString3,
                                Foreground = Brushes.White,
                                Width = 217,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontFamily = new FontFamily("Bahnschrift"),
                                FontSize = 14
                            };
                            Button button1 = new Button
                            {
                                Content = "Chi tiết",
                                Width = 70,
                            };
                            button1.Click += (s, args) => Button_Click_10(sender, e, nhanVien.MaNV);
                            
                            Button button2 = new Button
                            {
                                Content = "Xóa",
                                Width = 60,
                            };
                            button2.Click += (s1, args1) => Button_Click_11(sender, e, nhanVien.MaNV);
                            // Thêm Label vào StackPanel
                            stackPanel.Children.Add(label);
                            stackPanel.Children.Add(label1);
                            stackPanel.Children.Add(label2);
                            stackPanel.Children.Add(label3);
                            stackPanel.Children.Add(button1);
                            stackPanel.Children.Add(button2);
                            // Thêm StackPanel vào Border
                            border.Child = stackPanel;

                            // Thêm Border vào WrapPanel
                            wrapPanel.Children.Add(border);
                        }

                        // Thêm WrapPanel vào ScrollViewer
                        scrollViewData.Content = wrapPanel;
                        conn.Close();
                    }
                    else
                    {
                        return;
                    }

                }
            }

        }

        // nút minimized cho app
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // nút hiện danh sách nhân viên
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Visible;
            gridNhanh2_1.Visibility = Visibility.Visible;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
        }


        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Visible;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;


            int maNV = (int)buttonEditOrderNV.Tag;
            string maPB_NV ="", maCV_NV ="";
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT * FROM tb_NHANVIEN WHERE MANV = @maNV";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        txtBETENNVO.Text = reader["TENNV"].ToString();

                        if (reader["GIOITINH"].Equals(true)) { rbNamUpdatelOrder.IsChecked = true; } else { rbNuUpdateOrder.IsChecked = true; }
                        txtBEDCO.Text = reader["DIACHI"].ToString();
                        txtBESDTO.Text = reader["DIENTHOAI"].ToString();
                        maPB_NV = reader["MAPB"].ToString();
                        maCV_NV = reader["MACV"].ToString();
                        ngaySinhUpdateOrder.SelectedDate = reader.GetDateTime(3);
                        buttonUpdateOrder.Tag = maNV;
                    }
                    conn.Close();
                }
            }
            

            if (cbPhongBanUpdateOrder.Items.Count == 0)
            {
                string query1 = "SELECT TENPB, MAPB FROM tb_PHONGBAN";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENPB"].ToString(),
                                Tag = reader["MAPB"].ToString()
                            };

                            cbPhongBanUpdateOrder.Items.Add(item);
                        }
                        foreach (ComboBoxItem item in cbPhongBanUpdateOrder.Items)
                        {
                            if (item.Tag.ToString() == maPB_NV)
                            {
                                cbPhongBanUpdateOrder.SelectedItem = item;
                                break;
                            }
                        }
                        conn.Close();
                    }
                }

            }
            if (cbChucVuUpdateOrder.Items.Count == 0)
            {
                string query2 = "SELECT TENCV, MACV FROM tb_CHUCVU";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query2, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader["TENCV"].ToString(),
                                Tag = reader["MACV"].ToString()
                            };
                            cbChucVuUpdateOrder.Items.Add(item);
                        }
                        foreach (ComboBoxItem item in cbChucVuUpdateOrder.Items)
                        {
                            if (item.Tag.ToString() == maCV_NV)
                            {
                                cbChucVuUpdateOrder.SelectedItem = item;
                                break;
                            }
                        }
                        conn.Close();
                    }
                }
            }
            
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            int maNV = (int)buttonUpdateOrder.Tag;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "UPDATE tb_NHANVIEN SET TENNV = @tenNV, GIOITINH = @gioiTinh, NGAYSINH = @ngaySinh, DIENTHOAI = @dienThoai, DIACHI = @diaChi, MAPB = @maPB, MACV = @maCV WHERE MANV = @maNV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@maNV", maNV);
                    if (rbNamUpdatelOrder.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@gioiTinh", true); // Nam
                    }
                    else if (rbNuUpdateOrder.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@gioiTinh", false);
                    }
                    command.Parameters.AddWithValue("@tenNV", txtBETENNVO.Text);
                    command.Parameters.AddWithValue("@dienThoai", txtBESDTO.Text);
                    command.Parameters.AddWithValue("@diaChi", txtBEDCO.Text);
                    command.Parameters.AddWithValue("@ngaySinh", ngaySinhUpdateOrder.SelectedDate);
                    command.Parameters.AddWithValue("@maPB", ((ComboBoxItem)cbPhongBanUpdateOrder.SelectedItem).Tag.ToString());
                    command.Parameters.AddWithValue("@maCV", ((ComboBoxItem)cbChucVuUpdateOrder.SelectedItem).Tag.ToString());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật nhân viên thành công !");
                    conn.Close();
                }
            }

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH PHÂN QUYỀN";

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH CHỨC VỤ";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH PHÒNG BAN";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "CHẤM CÔNG";
        }
    }
}
