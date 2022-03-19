using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Common
{

    public class CheckFormat
    {
        public static string KhoangThoiGian(DateTime tg)
        {
            var k = DateTime.Now - tg.ToLocalTime();
            if (k.Days > 0) return k.Days.ToString() + " ngày";
            if (k.Hours > 0) return k.Hours.ToString() + " giờ";
            if (k.Minutes > 0) return k.Minutes.ToString() + " phút";
            return "bây giờ";
        }

       

        public static string TenTrangThaiCongViec(TrangThaiCongViec tt)
        {
            if (tt == TrangThaiCongViec.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiCongViec.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiCongViec.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiHoSo(TrangThaiHoSo tt)
        {
            if (tt == TrangThaiHoSo.KhoiTao)
                return "Khởi tạo";
            if (tt == TrangThaiHoSo.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiHoSo.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiHoSo.KetThuc)
                return "Kết thúc";
            if (tt == TrangThaiHoSo.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiNhanVien(TrangThaiNhanVien tt)
        {
            if (tt == TrangThaiNhanVien.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiNhanVien.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiNhanVien.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiNhanVien_LamViec(TrangThaiNhanVien_NhanVienLamViec tt)
        {
            if (tt == TrangThaiNhanVien_NhanVienLamViec.DangLamViec)
                return "Đang làm việc";
            if (tt == TrangThaiNhanVien_NhanVienLamViec.KetThuc)
                return "Kết thúc";
            if (tt == TrangThaiNhanVien_NhanVienLamViec.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiNhanVien_NhanVienLamViec.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiNhanVien_TraLoi(TrangThaiNhanVien_NhanVienTraLoi tt)
        {
            if (tt == TrangThaiNhanVien_NhanVienTraLoi.ChapNhan)
                return "Chấp nhận";
            if (tt == TrangThaiNhanVien_NhanVienTraLoi.ChuaTraLoi)
                return "Chưa trả lời";
            if (tt == TrangThaiNhanVien_NhanVienTraLoi.TuChoi)
                return "Từ chối";
            return "";
        }

        public static string TenTrangThaiToChuc(TrangThaiToChuc tt)
        {
            if (tt == TrangThaiToChuc.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiToChuc.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiToChuc.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiPhongBan(TrangThaiPhongBan tt)
        {
            if (tt == TrangThaiPhongBan.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiPhongBan.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiPhongBan.Xoa)
                return "Xóa";
            return "";
        }

        public static string TenTrangThaiNhom(TrangThaiNhom tt)
        {
            if (tt == TrangThaiNhom.DangHoatDong)
                return "Đang hoạt động";
            if (tt == TrangThaiNhom.TamDung)
                return "Tạm dừng";
            if (tt == TrangThaiNhom.Xoa)
                return "Xóa";
            return "";
        }
    }

}
