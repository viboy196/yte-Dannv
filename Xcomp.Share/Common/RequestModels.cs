using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Common
{
    public class ViecRequest
    {
        public string IdCongViec { get; set; }

        public string IdBenhNhan { get; set; }

        public string IdCa { get; set; }

        public string IdKeHoach { get; set; }

        public string IdViec { get; set; }

        //--------------------------------

        public string STT { get; set; }

        public string ThoiGian { get; set; }

        public string IdLoaiViec { get; set; }

        public string DanDo { get; set; }


    }

    public class CaRequest
    {
        public string IdCongViec { get; set; }

        public string IdDoiTuong { get; set; }


        public string IdNguoiTao { get; set; }

        public string Id { get; set; }

        //--------------------------------

        public string IdLoaiCa { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiHoSo TrangThai { get; set; } = TrangThaiHoSo.DangHoatDong;



    }

    public class TienIchRequest
    {
        public string IdCongViec { get; set; }

        public string IdDoiTuong { get; set; }


        public string IdNguoiTao { get; set; }

        public string Id { get; set; }

        //--------------------------------

        public string IdLoaiTienIch { get; set; }

        public string Ten { get; set; }

        public string VaiTro { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiHoSo TrangThai { get; set; } = TrangThaiHoSo.DangHoatDong;



    }

    public class DoiTuongRequest
    {
        public string IdCongViec { get; set; }

        public string IdNguoiTao { get; set; }

        public string Id { get; set; }

        //--------------------------------
        public string CodeLoaiDoiTuong { get; set; }

        public string Ten { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiHoSo TrangThai { get; set; } = TrangThaiHoSo.DangHoatDong;

    }

    public class BenhNhanRequest
    {
        public string IdCongViec { get; set; }

        public string IdNguoiTao { get; set; }

        public string Id { get; set; }

        //--------------------------------

        public string Ten { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiHoSo TrangThai { get; set; } = TrangThaiHoSo.DangHoatDong;

    }

    public class YeuNhanRequest
    {
        public string IdCongViec { get; set; }

        public string IdNguoiTao { get; set; }

        public string Id { get; set; }

        //--------------------------------

        public string Ten { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiThieu { get; set; }

        public string CodeLoaiYeuNhan { get; set; }

        public TrangThaiHoSo TrangThai { get; set; } = TrangThaiHoSo.DangHoatDong;

    }

    public class ToChucRequest
    {
        public string Id { get; set; }

        public string Ten { get; set; }

        public string IdLoaiToChuc { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiToChuc TrangThai { get; set; }

        public string IdToChucMe { get; set; }

        public string IdNguoiTao { get; set; }

        public string IdCongViec { get; set; }

    }

    public class PhongBanRequest
    {
        public string Id { get; set; }

        public string Ten { get; set; }

        public string IdLoaiPhongBan { get; set; }

        public string LoaiPhongBan { get; set; }

        public string GioiThieu { get; set; }

        public string IdToChuc { get; set; }

        public string IdNguoiTao { get; set; }

        public string IdPhongBanMe { get; set; }

        public string IdCongViec { get; set; }

        public TrangThaiPhongBan TrangThai { get; set; }

    }

    public class NhanVienRequest
    {
        public string Id { get; set; }

        public string Ten { get; set; }

        public string SoDienThoai { get; set; }

        public string GioiThieu { get; set; }

        public string IdToChuc { get; set; }

        public string IdNguoiDung { get; set; }

        public string IdNguoiTao { get; set; }

        public string IdHeThong { get; set; }

        public string IdPhongBan { get; set; }

        public string IdCongViec { get; set; }


        public string VaiTro { get; set; }

        public TrangThaiNhanVien TrangThai { get; set; }

        public TrangThaiNhanVien_NhanVienLamViec TrangThaiNhanVienLamViec { get; set; }

        public TrangThaiNhanVien_NhanVienTraLoi TrangThaiNhanVienTraLoi { get; set; }


    }



    public class NhomRequest
    {
        public string Id { get; set; }

        public string Ten { get; set; }

        public string GioiThieu { get; set; }

        public string IdToChuc { get; set; }

        public string IdNguoiTao { get; set; }

        public string IdPhongBan { get; set; }

        public string IdCongViec { get; set; }

        public TrangThaiNhom TrangThai { get; set; }


    }


    public class CongViecRequest
    {
        public string Id { get; set; }

        public string IdLoaiCongViec { get; set; }

        public string IdNhanVien { get; set; }

        public string IdToChuc { get; set; }

        public string IdPhongBan { get; set; }

        public string IdVaiTro { get; set; }

        public string IdNguoiTao { get; set; }

        public string IdGiaiPhap { get; set; }

        public string IdHeThong { get; set; }

        public string IdCongViec { get; set; }

        public TrangThaiCongViec TrangThai { get; set; }
        public TrangThaiNhanVien_NhanVienLamViec TrangThaiNhanVienLamViec { get; set; }

        public TrangThaiNhanVien_NhanVienTraLoi TrangThaiNhanVienTraLoi { get; set; }

    }

    public class PhanSuRequest
    {
        public string IdNhanVien { get; set; }

        public string IdNhom{ get; set; }


        public string IdPhanSu { get; set; }


        public string IdCongViec { get; set; }



    }
}
