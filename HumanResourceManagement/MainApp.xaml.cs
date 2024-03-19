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
using System.Runtime.Remoting.Messaging;


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
            if(_nhanVienCurrent.GioiTinh == true)
            {
                BitmapImage newImage = new BitmapImage(new Uri("/Assent/Picture/newUserNam.png", UriKind.Relative));
                
            }
        }

        private void GetDuLieuTuBangKhac(string query, TextBox txtB)
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
        private void GetDuLieuTuBangKhac_Phu(string query, TextBlock txtB)
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
            gridNhanh3_ThongTinCaNhan.Visibility = Visibility.Visible;
            gridNhanh3_LuongCaNhan.Visibility = Visibility.Hidden; 
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;


            if (_nhanVienCurrent.GioiTinh == true)
            {
                BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNam.png", UriKind.Relative));
                imgPersonal.Fill = new ImageBrush { ImageSource = newImage };
            }
            else
            {
                BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNu.png", UriKind.Relative));
                imgPersonal.Fill = new ImageBrush { ImageSource = newImage };
            }

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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;
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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;


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
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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
                        command.Parameters.AddWithValue("@gioiTinh", true); 
                         _nhanVienCurrent.GioiTinh = true;
                    }
                    else if (rbNuUpdatePersonal.IsChecked == true)
                    {
                        command.Parameters.AddWithValue("@gioiTinh", false);
                        _nhanVienCurrent.GioiTinh = false;
                    }
                    command.Parameters.AddWithValue("@tenNV", txtBETENNV.Text);
                    command.Parameters.AddWithValue("@dienThoai", txtBESDT.Text);
                    command.Parameters.AddWithValue("@diaChi", txtBEDC.Text);
                    command.Parameters.AddWithValue("@ngaySinh", ngaySinhUpdatePersonal.SelectedDate);
                    command.Parameters.AddWithValue("@maPB", ((ComboBoxItem)cbPhongBanUpdatePersonal.SelectedItem).Tag.ToString());
                    command.Parameters.AddWithValue("@maCV", ((ComboBoxItem)cbChucVuUpdatePersonal.SelectedItem).Tag.ToString());
                    command.Parameters.AddWithValue("@maQuyen", _nhanVienCurrent.MaQuyen);
                    command.Parameters.AddWithValue("@maNV", _nhanVienCurrent.MaNV);
                    _nhanVienCurrent.TenNV = txtBETENNV.Text;
                    _nhanVienCurrent.DienThoai = txtBESDT.Text;
                    _nhanVienCurrent.NgaySinh = ngaySinhUpdatePersonal.SelectedDate.Value.ToString("dd/MM/yyyy");
                    _nhanVienCurrent.DiaChi = txtBEDC.Text;
                    _nhanVienCurrent.MaCV = int.Parse(((ComboBoxItem)cbChucVuUpdatePersonal.SelectedItem).Tag.ToString());
                    _nhanVienCurrent.MaPB = int.Parse(((ComboBoxItem)cbPhongBanUpdatePersonal.SelectedItem).Tag.ToString());
                   

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật nhân viên thành công !");
                    conn.Close();
                }
            }

            if (_nhanVienCurrent.GioiTinh == true)
            {
                BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNam.png", UriKind.Relative));
                imgPersonal.Fill = new ImageBrush { ImageSource = newImage };
            }
            else
            {
                BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNu.png", UriKind.Relative));
                imgPersonal.Fill = new ImageBrush { ImageSource = newImage };
            }

            txtBMaNV.Text = _nhanVienCurrent.MaNV.ToString();
            txtBTenNV.Text = _nhanVienCurrent.TenNV.ToString();
            string query1 = "SELECT p.TENPB " +
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_PHONGBAN p ON n.MAPB = p.MAPB " +
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query1, txtBPB);
            string query2 = "SELECT p.TENCV " + 
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_CHUCVU p ON n.MACV = p.MACV " +
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query2, txtBCV);
            string query3 = "SELECT p.TENQUYEN " + 
                            "FROM tb_NHANVIEN n " +
                            "JOIN tb_QUYEN p ON n.MAQUYEN = p.MAQUYEN " +
                            "WHERE n.MANV = '" + _nhanVienCurrent.MaNV + "'";
            GetDuLieuTuBangKhac(query3, txtBQuyen);
            if (_nhanVienCurrent.GioiTinh == false) { txtBGT.Text = "Nữ"; } else { txtBGT.Text = "Nam"; }
            txtBDC.Text = _nhanVienCurrent.DiaChi;
            txtBSDT.Text = _nhanVienCurrent.DienThoai;
            txtBNS.Text = _nhanVienCurrent.NgaySinh;

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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;

            txtBEMANV.Text = _nhanVienCurrent.MaNV.ToString();
            txtBETENNV.Text = _nhanVienCurrent.TenNV.ToString();

            if (_nhanVienCurrent.GioiTinh == true) { rbNamUpdatePersonal.IsChecked = true; } else { rbNuUpdatePersonal.IsChecked = true; }
            txtBEDC.Text = _nhanVienCurrent.DiaChi;
            txtBESDT.Text = _nhanVienCurrent.DienThoai;
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbPhongBanUpdatePersonal.Items.Clear();
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
            cbChucVuUpdatePersonal.Items.Clear();
            if (cbChucVuUpdatePersonal.Items.Count == 0)
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
            if(_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên !");
                return;
            }


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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;    
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbPhongBan.Items.Clear();
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
            
            cbChucVu.Items.Clear();
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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;
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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;
        }

        // xem thông tin của nhân viên khác 
        private void Button_Click_10(object sender, RoutedEventArgs e, int maNV)
        {

            if (_nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không thể xem nhân viên khác!");
                return;
            }

            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Visible;
            gridNhanh6_LuongNV.Visibility = Visibility.Hidden;
            gridNhanh6_ThongTinNV.Visibility = Visibility.Visible;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;

            buttonEditOrderNV.Tag = maNV;
            buttonLuongNV.Tag = maNV;
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
                        if (bool.Parse(reader["GIOITINH"].ToString()) == false) 
                        { 
                            txtBGTO.Text = "Nữ";
                            BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNu.png", UriKind.Relative));
                            imgPersonalUser.Fill = new ImageBrush { ImageSource = newImage, TileMode = TileMode.Tile };

                        }
                        else
                        { 
                            txtBGTO.Text = "Nam";
                            BitmapImage newImage = new BitmapImage(new Uri("Assent/Picture/userNam.png", UriKind.Relative));
                            imgPersonalUser.Fill = new ImageBrush { ImageSource = newImage, TileMode = TileMode.Tile };
                        }
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
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có xóa nhân viên !");
                return;
            }

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
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;
        }

        // nút hiện nhánh 7  Cập nhật thông tin cho nhân viên khác
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyền cập nhật nhân viên !");
                return;
            }

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
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;


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

            cbPhongBanUpdateOrder.Items.Clear();
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
            cbChucVuUpdateOrder.Items.Clear();
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

        // nút xác nhật cập nhật nhân viên
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

        // danh sách phân quyền 
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH PHÂN QUYỀN";

            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Visible;
            gridNhanh8_1.Visibility = Visibility.Visible;
            gridNhanh8_3.Visibility = Visibility.Visible;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;

            conn.Open();
            string sql = "SELECT * FROM tb_QUYEN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Quyen> sqlValues = new List<Quyen>();

            while (reader.Read())
            {
                

                Quyen newQuyen = new Quyen();
                newQuyen.MaQuyen = int.Parse(reader["MAQUYEN"].ToString());
                newQuyen.TenQuyen = reader["TENQUYEN"].ToString();
                sqlValues.Add(newQuyen);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (Quyen quyen in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = quyen.MaQuyen,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = quyen.TenQuyen,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
               
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataQuyen.Content = wrapPanel;
            conn.Close();

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            // thêm quyền vào combox
            string query3 = "SELECT TENQUYEN, MAQUYEN FROM tb_QUYEN";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query3, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = command.ExecuteReader();

                    cbPhanQuyen.Items.Clear();

                    while (reader1.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = reader1["TENQUYEN"].ToString(),
                            Tag = reader1["MAQUYEN"].ToString()
                        };
                        cbPhanQuyen.Items.Add(item);
                    }

                    conn.Close();
                }
            }

            //Thêm nhân viên vào combox
            string query4 = "SELECT TENNV, MANV FROM tb_NHANVIEN";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query4, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = command.ExecuteReader();

                    cbPhanQuyenNV.Items.Clear();

                    while (reader1.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = reader1["TENNV"].ToString(),
                            Tag = reader1["MANV"].ToString()
                        };
                        cbPhanQuyenNV.Items.Add(item);
                    }

                    conn.Close();
                }
            }


        }

        // danh sách chức vụ
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH CHỨC VỤ";

            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Visible;
            gridNhanh9_1.Visibility = Visibility.Visible;
            gridNhanh9_3.Visibility = Visibility.Visible;
            gridNhanh10_0.Visibility = Visibility.Hidden;
            gridNhanh10_1.Visibility = Visibility.Hidden;
            gridNhanh10_3.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";

            cbUpdateSelectCV.Items.Clear();
            if (cbUpdateSelectCV.Items.Count == 0)
            {
                string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENCV"].ToString(),
                                Tag = reader1["MACV"].ToString()
                            };
                            cbUpdateSelectCV.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }

            conn.Open();
            string sql = "SELECT * FROM tb_CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ChucVu> sqlValues = new List<ChucVu>();

            while (reader.Read())
            {
                ChucVu newChucVu = new ChucVu();
                newChucVu.MaCV = int.Parse(reader["MACV"].ToString());
                newChucVu.TenCV = reader["TENCV"].ToString();
                sqlValues.Add(newChucVu);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (ChucVu newChucVu in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 711,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = newChucVu.MaCV,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                
                Label label1 = new Label
                {
                    Content = newChucVu.TenCV,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };


                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_21(sender, e, newChucVu.MaCV);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataChucVu.Content = wrapPanel;
            conn.Close();

            string query2 = "SELECT TENCV, MACV FROM tb_CHUCVU";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = command.ExecuteReader();

                    cbUpdateSelectCV.Items.Clear();

                    while (reader1.Read())
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = reader1["TENCV"].ToString(),
                            Tag = reader1["MACV"].ToString()
                        };
                        cbUpdateSelectCV.Items.Add(item);
                    }

                    conn.Close();
                }
            }

        }

        // danh sách phòng ban
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            txtMainTitle.Content = "DANH SÁCH PHÒNG BAN";

            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Hidden;
            gridNhanh4.Visibility = Visibility.Hidden;
            gridNhanh5.Visibility = Visibility.Hidden;
            gridNhanh6.Visibility = Visibility.Hidden;
            gridNhanh7.Visibility = Visibility.Hidden;
            gridNhanh8_0.Visibility = Visibility.Hidden;
            gridNhanh8_1.Visibility = Visibility.Hidden;
            gridNhanh8_3.Visibility = Visibility.Hidden;
            gridNhanh9_0.Visibility = Visibility.Hidden;
            gridNhanh9_1.Visibility = Visibility.Hidden;
            gridNhanh9_3.Visibility = Visibility.Hidden;
            gridNhanh10_0.Visibility = Visibility.Visible;
            gridNhanh10_1.Visibility = Visibility.Visible;
            gridNhanh10_3.Visibility = Visibility.Visible;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbUpdateSelectPB.Items.Clear();
            if (cbUpdateSelectPB.Items.Count == 0)
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
                                Content = reader1["TENPB"].ToString(),
                                Tag = reader1["MAPB"].ToString()
                            };

                            cbUpdateSelectPB.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }

            conn.Open();
            string sql = "SELECT * FROM tb_PHONGBAN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<PhongBan> sqlValues = new List<PhongBan>();

            while (reader.Read())
            {
                PhongBan newPhongBan = new PhongBan();
                newPhongBan.MaPB = int.Parse(reader["MAPB"].ToString());
                newPhongBan.TenPB = reader["TENPB"].ToString();
                sqlValues.Add(newPhongBan); 
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (PhongBan phongBan in sqlValues)
            {   
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = phongBan.MaPB,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = phongBan.TenPB,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

           

                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_24(sender, e, phongBan.MaPB);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataPhongBan.Content = wrapPanel;
            conn.Close();
        }
 
        //xác nhận chỉnh sửa chức vụ
        private void Button_Click_20_1(object sender, RoutedEventArgs e) 
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không quyền chỉnh sửa chức vụ !");
                return;
            }

            ComboBoxItem selectedCV = (ComboBoxItem)cbUpdateSelectCV.SelectedItem;
            int maCV = int.Parse(selectedCV.Tag.ToString());


            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "UPDATE tb_CHUCVU SET TENCV = @tenCV WHERE MACV = @maCV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("maCV", maCV);
                    command.Parameters.AddWithValue("@tenCV", txtUPDATECV.Text);

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công !");
                    conn.Close();
                }
            }
            conn.Open();
            string sql = "SELECT * FROM tb_CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ChucVu> sqlValues = new List<ChucVu>();

            while (reader.Read())
            {
                ChucVu newChucVu = new ChucVu();
                newChucVu.MaCV = int.Parse(reader["MACV"].ToString());
                newChucVu.TenCV = reader["TENCV"].ToString();
                sqlValues.Add(newChucVu);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (ChucVu newChucVu in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 711,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = newChucVu.MaCV,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };


                Label label1 = new Label
                {
                    Content = newChucVu.TenCV,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };


                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_21(sender, e, newChucVu.MaCV);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataChucVu.Content = wrapPanel;
            conn.Close();

            cbUpdateSelectCV.Items.Clear();
            string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
            if (cbUpdateSelectCV.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENCV"].ToString(),
                                Tag = reader1["MACV"].ToString()
                            };

                            cbUpdateSelectCV.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }

        }
        // Hủy chỉnh sửa chức vụ
        private void Button_Click_20_2(object sender,  RoutedEventArgs e)
        {
            txtUPDATECV.Text = "Vui lòng nhập thông tin";
        }

        // button xóa chức vụ
        private void Button_Click_21(object sender, RoutedEventArgs e, int maCV)
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyền xóa chức vụ !");
                return;
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "DELETE FROM tb_CHUCVU WHERE MACV = @maCV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maCV", maCV);

                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn xóa chứ", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        string updateQuery = "UPDATE tb_NHANVIEN SET MACV = @newChucVu WHERE MACV = @oldChucVu";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                        {
                            updateCommand.Parameters.AddWithValue("@newChucVu", 5); // newChucVu là mã chức vụ mới bạn muốn gán cho nhân viên
                            updateCommand.Parameters.AddWithValue("@oldChucVu", maCV); // oldChucVu là mã chức vụ bạn muốn xóa

                            conn.Open();
                            updateCommand.ExecuteNonQuery();
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }


            conn.Open();
            string sql = "SELECT * FROM tb_CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ChucVu> sqlValues = new List<ChucVu>();

            while (reader.Read())
            {
                ChucVu newChucVu = new ChucVu();
                newChucVu.MaCV = int.Parse(reader["MACV"].ToString());
                newChucVu.TenCV = reader["TENCV"].ToString();
                sqlValues.Add(newChucVu);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (ChucVu newChucVu in sqlValues)
            {
                Border border = new Border
                {
                    Width = 711,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
                    Margin = new Thickness(0, 20, 0, 0),
                    CornerRadius = new CornerRadius(10),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center
                };

                StackPanel stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Orientation = Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(27, 0, 0, 0),
                    Width = 991
                };

                Label label = new Label
                {
                    Content = newChucVu.MaCV,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = newChucVu.TenCV,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_21(sender, e, newChucVu.MaCV);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataChucVu.Content = wrapPanel;
            conn.Close();

            cbUpdateSelectCV.Items.Clear();
            string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
            if (cbUpdateSelectCV.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENCV"].ToString(),
                                Tag = reader1["MACV"].ToString()
                            };

                            cbUpdateSelectCV.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
        }
        // Xác nhận thêm chức vụ
        private void Button_Click_22_1(object sender, RoutedEventArgs e)
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyèn thêm chức vụ !");
                return;
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "INSERT INTO tb_CHUCVU (TENCV) VALUES (@tenCV)";

            if (txtADDCV.Text == "Vui lòng nhập thông tin")
            {
                erroInputAddCV.Visibility = Visibility.Visible;
            }
            else
            {
                erroInputAddCV.Visibility = Visibility.Hidden;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@tenCV", txtADDCV.Text);
   
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm chức vụ thành công !");
                        conn.Close();
                    }
                }
                conn.Open();
                string sql = "SELECT * FROM tb_CHUCVU";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                List<ChucVu> sqlValues = new List<ChucVu>();

                while (reader.Read())
                {
                    ChucVu newChucVu = new ChucVu();
                    newChucVu.MaCV = int.Parse(reader["MACV"].ToString());
                    newChucVu.TenCV = reader["TENCV"].ToString();
                    sqlValues.Add(newChucVu);
                }
                // Tạo một WrapPanel
                WrapPanel wrapPanel = new WrapPanel();

                foreach (ChucVu newChucVu in sqlValues)
                {
                    // Tạo một Border mới
                    Border border = new Border
                    {
                        Width = 711,
                        Height = 60,
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                        Content = newChucVu.MaCV,
                        Foreground = Brushes.White,
                        Width = 231,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontFamily = new FontFamily("Bahnschrift"),
                        FontSize = 14
                    };


                    Label label1 = new Label
                    {
                        Content = newChucVu.TenCV,
                        Foreground = Brushes.White,
                        Width = 201,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontFamily = new FontFamily("Bahnschrift"),
                        FontSize = 14
                    };


                    Button button2 = new Button
                    {
                        Content = "Xóa",
                        Width = 60,
                    };
                    button2.Click += (s1, args1) => Button_Click_21(sender, e, newChucVu.MaCV);
                    // Thêm Label vào StackPanel
                    stackPanel.Children.Add(label);
                    stackPanel.Children.Add(label1);
                    stackPanel.Children.Add(button2);
                    // Thêm StackPanel vào Border
                    border.Child = stackPanel;

                    // Thêm Border vào WrapPanel
                    wrapPanel.Children.Add(border);
                }

                // Thêm WrapPanel vào ScrollViewer
                scrollViewDataChucVu.Content = wrapPanel;
                conn.Close();
            }

            cbUpdateSelectCV.Items.Clear();
            string query1 = "SELECT TENCV, MACV FROM tb_CHUCVU";
            if (cbUpdateSelectCV.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENCV"].ToString(),
                                Tag = reader1["MACV"].ToString()
                            };

                            cbUpdateSelectCV.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }

        }
       
        // hủy thêm chức vụ
        private void Button_Click_22_2(object sender, RoutedEventArgs e)
        {
            txtADDCV.Text = "Vui lòng nhập thông tin";
        }

        //nút xác nhận chỉnh sửa phòng ban
        private void Button_Click_23_1(object sender, RoutedEventArgs e) 
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không quyền có chỉnh sửa phòng ban !");
                return;
            }

            ComboBoxItem selectedPB = (ComboBoxItem)cbUpdateSelectPB.SelectedItem;
            int maPB = int.Parse(selectedPB.Tag.ToString());
            

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "UPDATE tb_PHONGBAN SET TENPB = @tenPB WHERE MAPB = @maPB";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("maPB", maPB);
                    command.Parameters.AddWithValue("@tenPB", txtUPDATEPB.Text);

                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công !");
                    conn.Close();
                }
            }

            conn.Open();
            string sql = "SELECT * FROM tb_PHONGBAN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<PhongBan> sqlValues = new List<PhongBan>();

            while (reader.Read())
            {
                PhongBan newPhongBan = new PhongBan();
                newPhongBan.MaPB = int.Parse(reader["MAPB"].ToString());
                newPhongBan.TenPB = reader["TENPB"].ToString();
                sqlValues.Add(newPhongBan);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (PhongBan phongBan in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = phongBan.MaPB,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = phongBan.TenPB,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };



                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_24(sender, e, phongBan.MaPB);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataPhongBan.Content = wrapPanel;
            conn.Close();

            string query1 = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbUpdateSelectPB.Items.Clear();
            if (cbUpdateSelectPB.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENPB"].ToString(),
                                Tag = reader1["MAPB"].ToString()
                            };

                            cbUpdateSelectPB.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }

        }
        //nút hủy chỉnh sửa phòng ban
        private void Button_Click_23_2(object sender, RoutedEventArgs e) 
        {
            txtUPDATEPB.Text = "Vui lòng nhập thông tin";
        }
        //nút xóa phòng ban
        private void Button_Click_24(object sender, RoutedEventArgs e, int maPB) 
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyền xóa phòng ban !");
                return;
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "DELETE FROM tb_PHONGBAN WHERE MAPB = @maPB";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@maPB", maPB);

                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn xóa chứ", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        string updateQuery = "UPDATE tb_NHANVIEN SET MAPB = @newPhongBan WHERE MAPB = @oldPhongBan";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                        {
                            updateCommand.Parameters.AddWithValue("@newPhongBan", 3); // newChucVu là mã chức vụ mới bạn muốn gán cho nhân viên
                            updateCommand.Parameters.AddWithValue("@oldPhongBan", maPB); // oldChucVu là mã chức vụ bạn muốn xóa

                            conn.Open();
                            updateCommand.ExecuteNonQuery();
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }

            conn.Open();
            string sql = "SELECT * FROM tb_PHONGBAN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<PhongBan> sqlValues = new List<PhongBan>();

            while (reader.Read())
            {
                PhongBan newPhongBan = new PhongBan();
                newPhongBan.MaPB = int.Parse(reader["MAPB"].ToString());
                newPhongBan.TenPB = reader["TENPB"].ToString();
                sqlValues.Add(newPhongBan);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (PhongBan phongBan in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = phongBan.MaPB,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = phongBan.TenPB,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_24(sender, e, phongBan.MaPB);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataPhongBan.Content = wrapPanel;
            conn.Close();

            string query1 = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbUpdateSelectPB.Items.Clear();
            if (cbUpdateSelectPB.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENPB"].ToString(),
                                Tag = reader1["MAPB"].ToString()
                            };

                            cbUpdateSelectPB.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
        }

        //nút xác nhân thêm phòng ban
        private void Button_Click_25_1(object sender, RoutedEventArgs e)
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4)
            {
                MessageBox.Show("Bạn không có quyền thêm phòng ban !");
                return;
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "INSERT INTO tb_PHONGBAN (TENPB) VALUES (@tenPB)";

            if (txtADDPB.Text == "Vui lòng nhập thông tin")
            {
                erroInputAddPB.Visibility = Visibility.Visible;
            }
            else
            {
                erroInputAddPB.Visibility = Visibility.Hidden;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@tenPB", txtADDPB.Text);

                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm phòng ban thành công !");
                        conn.Close();
                    }
                }

            }

            conn.Open();
            string sql = "SELECT * FROM tb_PHONGBAN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<PhongBan> sqlValues = new List<PhongBan>();

            while (reader.Read())
            {
                PhongBan newPhongBan = new PhongBan();
                newPhongBan.MaPB = int.Parse(reader["MAPB"].ToString());
                newPhongBan.TenPB = reader["TENPB"].ToString();
                sqlValues.Add(newPhongBan);
            }
            // Tạo một WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            foreach (PhongBan phongBan in sqlValues)
            {
                // Tạo một Border mới
                Border border = new Border
                {
                    Width = 1050,
                    Height = 60,
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF104A43")),
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

                    Content = phongBan.MaPB,
                    Foreground = Brushes.White,
                    Width = 231,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };

                Label label1 = new Label
                {
                    Content = phongBan.TenPB,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };



                Button button2 = new Button
                {
                    Content = "Xóa",
                    Width = 60,
                };
                button2.Click += (s1, args1) => Button_Click_24(sender, e, phongBan.MaPB);
                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(button2);
                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewDataPhongBan.Content = wrapPanel;
            conn.Close();

            string query1 = "SELECT TENPB, MAPB FROM tb_PHONGBAN";

            cbUpdateSelectPB.Items.Clear();
            if (cbUpdateSelectPB.Items.Count == 0)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Content = reader1["TENPB"].ToString(),
                                Tag = reader1["MAPB"].ToString()
                            };

                            cbUpdateSelectPB.Items.Add(item);
                        }

                        conn.Close();
                    }
                }
            }
        }
        //nút hủy thêm phòng ban
        private void Button_Click_25_2(object sender, RoutedEventArgs e) 
        {
            txtADDPB.Text = "Vui long nhập thông tin";
        }

        // nút phân quyền 
        private void Button_Click_26_1(object sender, RoutedEventArgs e)
        {
            if (_nhanVienCurrent.MaQuyen == 3 || _nhanVienCurrent.MaQuyen == 4 || _nhanVienCurrent.MaQuyen == 2)
            {
                MessageBox.Show("Bạn không thể phân quyền !");
                return;
            }

            int maNV = int.Parse(((ComboBoxItem)cbPhanQuyenNV.SelectedItem).Tag.ToString());
            int maQuyen = int.Parse(((ComboBoxItem)cbPhanQuyen.SelectedItem).Tag.ToString());

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            string query = "UPDATE tb_NHANVIEN SET MAQUYEN = @maQuyen WHERE MANV = @maNV";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    command.Parameters.AddWithValue("@maNV", maNV);
                    command.Parameters.AddWithValue("@maQuyen", maQuyen);
                    _nhanVienCurrent.MaQuyen = maQuyen;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Phân quyền nhân viên thành công !");
                    conn.Close();
                }
            }
        }
        
        // nút hủy cho phân quyền
        private void Button_Click_26_2(object sender, RoutedEventArgs e)
        {
            cbPhanQuyen.SelectedIndex = -1;
            cbPhanQuyenNV.SelectedIndex = -1;
        }

        // nút đăng xuất tài khoản
        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        // nút lương cá nhân 

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            gridNhanh3_LuongCaNhan.Visibility = Visibility.Visible;
            gridNhanh3_ThongTinCaNhan.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                int maNV = _nhanVienCurrent.MaNV;
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtBLCB.Text = reader.GetInt64(1).ToString("N0") + " Đồng";
                            txtBPC.Text = reader.GetInt64(2).ToString("N0") + " Đồng";
                            long tong = reader.GetInt64(1) + reader.GetInt64(2);
                            txtBTN.Text = tong.ToString("N0") + " Đồng";
                        }
                    }
                }
                conn.Close();
            }
        }

        // Thông tin cá nhân nút chuyển sang thông tin cá nhân
        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            gridNhanh3_LuongCaNhan.Visibility = Visibility.Hidden;
            gridNhanh3_ThongTinCaNhan.Visibility = Visibility.Visible;
        }
        
        //Thông tin nhân viên khác chuyển sang thông tin nhan viên
        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            gridNhanh6_LuongNV.Visibility = Visibility.Hidden;
            gridNhanh6_ThongTinNV.Visibility = Visibility.Visible;
        }

        //Thông tin nhân viên khác chuyển sang lương nhân viên khác
        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            gridNhanh6_LuongNV.Visibility = Visibility.Visible;
            gridNhanh6_ThongTinNV.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";

                
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                int maNV = int.Parse(buttonLuongNV.Tag.ToString());
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtBLCBO.Text = reader.GetInt64(1).ToString("N0") + " Đồng";
                                txtBPCO.Text = reader.GetInt64(2).ToString("N0") + " Đồng";
                                long tong = reader.GetInt64(1) + reader.GetInt64(2);
                                txtBTNO.Text = tong.ToString("N0") + " Đồng";
                            }
                        }
                        else
                        {
                            txtBLCBO.Text = "Chưa phân lương";
                            txtBPCO.Text = "Chưa phân lương";
                            txtBTNO.Text = "Chưa phân lương";
                        }
                    }
                }
                conn.Close();
            }
        }

        // xử lý nhập text
        private void txtBETENNVADD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Focus_Text1(object sender, RoutedEventArgs e)
        {
            if(txtBETENNVADD.Text == "Vui lòng nhập thông tin")
            {
                txtBETENNVADD.Text = "";
            }
        }

        private void Lost_Focus_Text1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBETENNVADD.Text))
            {
                txtBETENNVADD.Text = "Vui lòng nhập thông tin";
            }

        }

        private void Focus_Text2(object sender, RoutedEventArgs e)
        {

            if (txtBESDTADD.Text == "Vui lòng nhập thông tin")
            {
                txtBESDTADD.Text = "";
            }

        }

        private void Lost_Focus_Text2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBESDTADD.Text))
            {
                txtBESDTADD.Text = "Vui lòng nhập thông tin";
            }

        }
        private void Focus_Text3(object sender, RoutedEventArgs e)
        {

            if (txtBEDCADD.Text == "Vui lòng nhập thông tin")
            {
                txtBEDCADD.Text = "";
            }
        }

        private void Lost_Focus_Text3(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBEDCADD.Text))
            {
                txtBEDCADD.Text = "Vui lòng nhập thông tin";
            }
        }

        private void Focus_Text4(object sender, RoutedEventArgs e)
        {

            if (txtADDCV.Text == "Vui lòng nhập thông tin")
            {
                txtADDCV.Text = "";
            }
        }

        private void Lost_Focus_Text4(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtADDCV.Text))
            {
                txtADDCV.Text = "Vui lòng nhập thông tin";
            }
        }
        private void Focus_Text5(object sender, RoutedEventArgs e)
        {

            if (txtUPDATECV.Text == "Vui lòng nhập thông tin")
            {
                txtUPDATECV.Text = "";
            }
        }

        private void Lost_Focus_Text5(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUPDATECV.Text))
            {
                txtUPDATECV.Text = "Vui lòng nhập thông tin";
            }
        }
        private void Focus_Text6(object sender, RoutedEventArgs e)
        {

            if (txtADDPB.Text == "Vui lòng nhập thông tin")
            {
                txtADDPB.Text = "";
            }
        }

        private void Lost_Focus_Text6(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtADDPB.Text))
            {
                txtADDPB.Text = "Vui lòng nhập thông tin";
            }
        }
        private void Focus_Text7(object sender, RoutedEventArgs e)
        {

            if (txtUPDATEPB.Text == "Vui lòng nhập thông tin")
            {
                txtUPDATEPB.Text = "";
            }
        }

        private void Lost_Focus_Text7(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUPDATEPB.Text))
            {
                txtUPDATEPB.Text = "Vui lòng nhập thông tin";
            }
        }

        private void Focus_Text8(object sender, RoutedEventArgs e)
        {
            if(txtBLCBOS.Text == "Chưa phân lương")
            {
                txtBLCBOS.Text = "";
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                int maNV = int.Parse(buttonLuongNV.Tag.ToString());
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (txtBLCBOS.Text == reader.GetInt64(1).ToString())
                            {
                                txtBLCBOS.Text = "";
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void Lost_Focus_Text8(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBLCBOS.Text))
            {
                txtBLCBOS.Text = "Vui lòng nhập thông tin";
            }
        }

        private void Focus_Text9(object sender, RoutedEventArgs e)
        {
            if (txtBPCOS.Text == "Chưa phân lương")
            {
                txtBPCOS.Text = "";
            }
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                int maNV = int.Parse(buttonLuongNV.Tag.ToString());
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (txtBPCOS.Text == reader.GetInt64(2).ToString())
                            {
                                txtBPCOS.Text = "";
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void Lost_Focus_Text9(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBPCOS.Text))
            {
                txtBPCOS.Text = "Vui lòng nhập thông tin";
            }
        }

        // hiệu ứng nút
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.BorderBrush = new SolidColorBrush(Colors.Green);
            button.Background = new SolidColorBrush(Colors.Green);
            button.BorderThickness = new Thickness(2);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.BorderBrush = null;
            button.Background = null; 
        }

        // hủy sửa lương
        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            gridNhanh6_SuaLuongNV.Visibility = Visibility.Hidden;
            gridNhanh6_LuongNV.Visibility = Visibility.Visible;
        }

        // button Xong sửa lương
        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            if (_nhanVienCurrent.MaQuyen == 2 || _nhanVienCurrent.MaQuyen == 4 )
            {
                MessageBox.Show("Bạn không có quyền sửa lương nhân viên !");
                return;
            }

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";
            int maNV = int.Parse(buttonLuongNV.Tag.ToString());


            if (txtBLCBOS.Text == "Vui lòng nhập thông tin" || txtBPCOS.Text == "Vui lòng nhập thông tin" )
            {
                errorThieuThongTin.Visibility = Visibility.Visible;
                return;
            }
            if (!int.TryParse(txtBLCBOS.Text, out _) || !int.TryParse(txtBPCOS.Text, out _))
            {
                errorSaiThongTin.Visibility = Visibility.Visible;
                return;
            }
            gridNhanh6_SuaLuongNV.Visibility = Visibility.Hidden;
            gridNhanh6_LuongNV.Visibility = Visibility.Visible;


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE tb_BANGLUONG SET LCOBAN = @lCoBan, PHUCAP = @phuCap WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    long lCoBan = long.Parse(txtBLCBOS.Text.Replace(".", ""));
                    long phuCap = long.Parse(txtBPCOS.Text.Replace(".", ""));

                    command.Parameters.AddWithValue("@maNV", maNV);
                    command.Parameters.AddWithValue("@lCoBan", lCoBan);
                    command.Parameters.AddWithValue("@phuCap", phuCap);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        string insertSql = "INSERT INTO tb_BANGLUONG (LCOBAN, PHUCAP, MANV) VALUES (@lCoBan, @phuCap, @maNV)";
                        using (SqlCommand insertCommand = new SqlCommand(insertSql, conn))
                        {
                            // Thay thế giá trị thực tế cho @luongCoBan, @phuCap, và @maNV
                            insertCommand.Parameters.AddWithValue("@lCoBan", lCoBan);
                            insertCommand.Parameters.AddWithValue("@phuCap", phuCap);
                            insertCommand.Parameters.AddWithValue("@maNV", maNV);

                            // Thực hiện thêm bản ghi
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            errorThieuThongTin.Visibility = Visibility.Hidden;
            errorSaiThongTin.Visibility = Visibility.Hidden;
            MessageBox.Show("Cập nhật thành công !");
           
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtBLCBO.Text = reader.GetInt64(1).ToString("N0") + " Đồng";
                                txtBPCO.Text = reader.GetInt64(2).ToString("N0") + " Đồng";
                                long tong = reader.GetInt64(1) + reader.GetInt64(2);
                                txtBTNO.Text = tong.ToString("N0") + " Đồng";
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        // chỗ sửa lương
        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            gridNhanh6_SuaLuongNV.Visibility = Visibility.Visible;
            gridNhanh6_LuongNV.Visibility = Visibility.Hidden;
            errorThieuThongTin.Visibility = Visibility.Hidden;
            errorSaiThongTin.Visibility = Visibility.Hidden;

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyNhanSu;Integrated Security=True;Encrypt=False";

                
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                int maNV = int.Parse(buttonLuongNV.Tag.ToString());
                string sql = "SELECT * FROM tb_BANGLUONG WHERE MANV = @maNV";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@maNV", maNV);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                txtBLCBOS.Text = reader.GetInt64(1).ToString();
                                txtBPCOS.Text = reader.GetInt64(2).ToString();
                            }
                        }
                        else
                        {
                            txtBLCBOS.Text = "Chưa phân lương";
                            txtBPCOS.Text = "Chưa phân lương";
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}
