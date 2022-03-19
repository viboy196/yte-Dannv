using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Domain;
using System.Security.Cryptography;

namespace Xcomp.Share.Common
{
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }

    public enum TrangThaiGiaoDich
    {
        DatHang = 1, // Lập trình viện chạy tại máy
        ThucHienDonHang = 2, // Lập trình viên deploy lên hệ thống test bed
        HuyDatHang = 3, // Hệ thống chạy thật
        HuyGiaoDich = 4,
        HoanThanhGiaoDich = 5// Hệ thống chạy thật
    }

    public enum TrangThaiSan
    {
        DangXayDung = 1, // Lập trình viện chạy tại máy
        ChuanBi = 2, // Lập trình viên deploy lên hệ thống test bed
        HoatDong = 3, // Hệ thống chạy thật
        TamDung = 4, // Hệ thống chạy thật
        NgungHoatDong = 5, // Hệ thống chạy thật
    }

    public enum TrangThaiToChuc
    {
        DangHoatDong = 1, // Lập trình viện chạy tại máy
        TamDung = 2, // Lập trình viên deploy lên hệ thống test bed
        Xoa = 3 // Hệ thống chạy thật
    }

    public enum MauWebToChuc
    {
        TieuChuan = 1, // Lập trình viện chạy tại máy
    }

    public enum MauWebSan
    {
        TieuChuan = 1, // Lập trình viện chạy tại máy

    }

    public enum TrangThaiHoSo
    {
        KhoiTao = 0,
        DangHoatDong = 1,
        TamDung = 2,
        KetThuc = 3,
        Xoa = 4,
    }

    public enum KieuForum
    {
        forum_ca_chamsocnguoibenh_nhanvien_nguoibenh = 1,
        forum_ca_chamsocnguoibenh_nhanvien = 2,
    }

    public enum KieuMes
    {
        Text = 1,
        Anh = 2,
    }
    public enum LoaiLich
    {
        TrucPhongChamSoc = 1,
        TrucKhoa = 2,
    }
    public enum CodeHeThong
    {
        YTeMoi = 1, // Lập trình viện chạy tại máy
        VaoLop = 2, // Lập trình viên deploy lên hệ thống test bed
        LamBep = 3, // Hệ thống chạy thật
        CuaPhat = 4, // Hệ thống chạy thật
        Xcomp = 5, // Hệ thống chạy thật
        BaoHiem = 6,
        IoT = 7,
        Kachiusa = 8,
        PhongChayChuaChay = 9,
        NongNghiep = 10,
        DuLich = 11,
        AnNinh = 12
    }

    public enum LoaiLog
    {
        Tao_NguoiDung = 0,
        Tao_ToChuc = 1,
        Tao_PhongBan = 2,
        Tao_NhanVien = 3,
        Tao_CongViec = 4,
        Tao_BenhNhan = 5,
        Tao_TienIch = 6,
        Tao_Ca = 7,
        Tao_YeuNhan = 8,

        Update_ToChuc = 101,
        Update_NhanVien = 103,
        Update_BenhNhan = 105,
        Update_TienIch = 106,
        Update_Ca = 107,
        Update_YeuNhan = 108

    }
    //public enum LoaiThongBao
    //{
    //    ThongBaoThuong = 0,
    //    Tao_NhanVien = 1,
    //    Tao_CongViec = 2,
    //}
    public enum DuLieu
    {
        TaoMoi = 1, // Lập trình viện chạy tại máy
        SinhThem = 2, // Lập trình viên deploy lên hệ thống test bed
        BoQua = 3 // Hệ thống chạy thật
    }
    public enum RunMode
    {
        Dev = 1, // Lập trình viện chạy tại máy
        Test = 2, // Lập trình viên deploy lên hệ thống test bed
        GoLive = 3 // Hệ thống chạy thật
    }
    public enum SystemType
    {
        HeThong = 1, 
        Kios = 2,
        San = 3,
        ToChuc = 4,
    }

    public enum TrangThaiNhanVien
    {
        DangHoatDong = 1, // Lập trình viện chạy tại máy
        TamDung = 2, // Lập trình viên deploy lên hệ thống test bed
        Xoa = 3 // Hệ thống chạy thật
    }

    public enum TrangThaiNhanVien_NhanVienTraLoi
    {
        ChuaTraLoi = 1, // Lập trình viện chạy tại máy
        ChapNhan = 2, // Lập trình viên deploy lên hệ thống test bed
        TuChoi = 3, // Hệ thống chạy thật

    }

    public enum TrangThaiNhanVien_NhanVienLamViec
    {
        DangLamViec = 1,
        TamDung = 2,
        KetThuc = 3,
        Xoa = 4
    }
    public enum TrangThaiPhongBan
    {
        DangHoatDong = 1, // Lập trình viện chạy tại máy
        TamDung = 2, // Lập trình viên deploy lên hệ thống test bed
        Xoa = 3 // Hệ thống chạy thật
    }

    public enum TrangThaiNhom
    {
        DangHoatDong = 1, // Lập trình viện chạy tại máy
        TamDung = 2, // Lập trình viên deploy lên hệ thống test bed
        Xoa = 3 // Hệ thống chạy thật
    }

    public enum TrangThaiCongViec
    {
        DangHoatDong = 1, // Lập trình viện chạy tại máy
        TamDung = 2, // Lập trình viên deploy lên hệ thống test bed
        Xoa = 3 // Hệ thống chạy thật
    }

    public enum TypeData
    {
        ToChuc = 1, // Lập trình viện chạy tại máy
        PhongBan = 2, 
    }

    public enum LoaiThongBao
    {
        ThongBaoThuong = 0,
        Tao_NhanVien = 1,
        Tao_CongViec = 2,
    }

    

    public static class SystemInfo
    {
        public static CodeHeThong CodeHeThong = CodeHeThong.YTeMoi;
        public static HeThong HeThong = new HeThong() ;
        public static HeThong HeThongAnNinh = new HeThong() ;

        public static DuLieu DuLieu = DuLieu.BoQua;
        public static RunMode Mode = RunMode.Dev;
        public static SystemType SystemType = SystemType.HeThong;

        //public static string ConnectionString
        //{
        //    get
        //    {

        //        if (SystemType == SystemType.HeThong)
        //        {
        //            if (Mode == RunMode.Dev)
        //                return "mongodb://127.0.0.1:27017/xcomp_dev_sys";
        //            else
        //            if (Mode == RunMode.Test)
        //                return "mongodb://minhlbh:tdvbAemRCMUh7Zip@cluster0-shard-00-00-kvz8t.mongodb.net:27017,cluster0-shard-00-01-kvz8t.mongodb.net:27017,cluster0-shard-00-02-kvz8t.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true/xcomp_test_sys";
        //            else
        //            if (Mode == RunMode.GoLive)
        //                return "mongodb://minhlbh:tdvbAemRCMUh7Zip@cluster0-shard-00-00-kvz8t.mongodb.net:27017,cluster0-shard-00-01-kvz8t.mongodb.net:27017,cluster0-shard-00-02-kvz8t.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true/xcomp_golive_sys";

        //        }


        //        return "";

        //    }
        //    set { }
        //}

        public static string ConnectionString
        {
            get
            {


                if (Mode == RunMode.Dev)
                    return "mongodb://127.0.0.1:27017/";
                else
                    if (Mode == RunMode.Test)
                    return "mongodb://minhlbh:tdvbAemRCMUh7Zip@cluster0-shard-00-00-kvz8t.mongodb.net:27017,cluster0-shard-00-01-kvz8t.mongodb.net:27017,cluster0-shard-00-02-kvz8t.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";
                else
                    if (Mode == RunMode.GoLive)
                    return "mongodb://minhlbh:tdvbAemRCMUh7Zip@cluster0-shard-00-00-kvz8t.mongodb.net:27017,cluster0-shard-00-01-kvz8t.mongodb.net:27017,cluster0-shard-00-02-kvz8t.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";


                return "";

            }
            set { }
        }
        public static string NameDb
        {
            get
            {

                if (Mode == RunMode.Dev)
                    return "xcomp_dev_sys";
                else
                if (Mode == RunMode.Test)
                    return "xcomp_test_sys";
                else
                if (Mode == RunMode.GoLive)
                    return "xcomp_golive_sys";


                return "";
            }
            set { }
        }

        public static int SoTinTrenModal = 5;
    }
}
