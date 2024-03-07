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
}
