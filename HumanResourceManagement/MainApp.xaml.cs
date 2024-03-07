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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Hidden;
            gridNhanh2_1.Visibility = Visibility.Hidden;
            gridNhanh3.Visibility = Visibility.Visible;
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
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridNhanh1.Visibility = Visibility.Hidden;
            gridNhanh2_0.Visibility = Visibility.Visible;
            gridNhanh2_1.Visibility = Visibility.Visible;
            gridNhanh3.Visibility = Visibility.Hidden;
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
                Label label1 = new Label
                {
                    Content = nhanVien.MaPB,
                    Foreground = Brushes.White,
                    Width = 201,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };
                Label label2 = new Label
                {
                    Content = nhanVien.MaCV,
                    Foreground = Brushes.White,
                    Width = 214,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };
                Label label3 = new Label
                {
                    Content = nhanVien.MaQuyen,
                    Foreground = Brushes.White,
                    Width = 217,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontFamily = new FontFamily("Bahnschrift"),
                    FontSize = 14
                };
                Button button1 = new Button
                {
                    Content = "clickme",
                    Width = 129,
                };

                // Thêm Label vào StackPanel
                stackPanel.Children.Add(label);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(button1);

                // Thêm StackPanel vào Border
                border.Child = stackPanel;

                // Thêm Border vào WrapPanel
                wrapPanel.Children.Add(border);
            }

            // Thêm WrapPanel vào ScrollViewer
            scrollViewData.Content = wrapPanel;
            conn.Close();
        }
    }
}
