using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourceManagement.ClassStore
{
    public class NhanVien
    {
        int maNV;
        string tenNV;
        bool gioiTinh;
        string ngaySinh;
        string dienThoai;
        string diaChi;
        string hinhAnh;
        int maPB;
        int maQuyen;
        int maCV;

        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string HinhAnh { get; set; }
        public int MaPB { get; set; }
        public int MaQuyen { get; set; }
        public int MaCV { get; set; }

        public NhanVien() { }

        public NhanVien(int maNV, string tenNV, bool gioiTinh, string ngaySinh, string dienThoai, string diaChi, string hinhAnh, int maPB, int maQuyen, int maCV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.GioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.dienThoai = dienThoai;
            this.diaChi = diaChi;
            this.hinhAnh = hinhAnh;
            this.maPB = maPB;
            this.maQuyen = maQuyen;
            this.maCV = maCV;
        }
        public NhanVien(int maNV, string tenNV, bool gioiTinh, string ngaySinh, string dienThoai, string diaChi, int maPB, int maQuyen, int maCV)
        {
            MaNV = maNV;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DienThoai = dienThoai;
            DiaChi = diaChi;
            MaPB = maPB;
            MaQuyen = maQuyen;
            MaCV = maCV;
        }
    }

    public class PhongBan
    {
        int maPB;
        string tenPB;

        public int MaPB { get; set; }
        public string TenPB { get; set; }

        public PhongBan() { }

        public PhongBan(int maPB, string tenPB)
        {
            MaPB = maPB;
            TenPB = tenPB; 
        }
    }

    public class ChucVu
    {
        int maCV;
        string tenCV;

        public int MaCV { get; set; }
        public string TenCV { get; set; }

        public ChucVu() { }
        
        public ChucVu(int maCV, string tenCV)
        {
            MaCV = maCV;
            TenCV = tenCV;
        }
    }

    public class Quyen
    {
        int maQuyen;
        string tenQuyen;

        public int MaQuyen { get; set;}
        public string TenQuyen { get; set; }
        public Quyen() { }

        public Quyen(int maQuyen, string tenQuyen)
        {
            MaQuyen = maQuyen;
            TenQuyen = tenQuyen;
        }
    }

}
