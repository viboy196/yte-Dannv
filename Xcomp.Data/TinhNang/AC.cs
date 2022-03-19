using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Data.TinhNang
{
    public static class AC
    {
        public static AC_HeThong HeThong ;
        public static AC_NguoiDung NguoiDung;
        public static AC_ThongBao ThongBao;
        public static AC_Log Log;

        public static AC_LoaiToChuc LoaiToChuc;
        public static AC_LoaiSan LoaiSan;
        public static AC_LoaiTienIch LoaiTienIch;
        public static AC_LoaiPhongBan LoaiPhongBan;
        public static AC_LoaiGiaiPhap LoaiGiaiPhap;
        public static AC_LoaiCongViec LoaiCongViec;
        public static AC_LoaiDichVu LoaiDichVu;
        public static AC_LoaiHangHoa LoaiHangHoa;
        public static AC_LoaiMauWeb LoaiMauWeb;
        public static AC_LoaiMauTrang LoaiMauTrang;
        public static AC_LoaiBanTin LoaiBanTin;
        public static AC_LoaiDoiTuong LoaiDoiTuong;
        public static AC_LoaiTinHieu LoaiTinHieu;

        public static AC_San San;
        public static AC_ToChuc ToChuc;
        public static AC_PhongBan PhongBan;
        public static AC_GiaiPhap GiaiPhap;
        public static AC_PhanSu PhanSu;
        public static AC_NhanVien NhanVien;
        public static AC_CongViec CongViec;
        public static AC_Nhom Nhom;
        public static AC_Lich Lich;
        public static AC_Mes Mes;
        public static AC_Forum Forum;
        public static AC_HangHoa HangHoa;
        public static AC_TienIch TienIch;
        public static AC_DichVu DichVu;
        public static AC_Trang Trang;
        public static AC_BanTin BanTin;
        public static AC_ThanhToan ThanhToan;
        public static AC_GiaoDich GiaoDich;
        public static AC_DoiTuong DoiTuong;
        public static AC_TinHieu TinHieu;

        //Y tế --------------------
        public static AC_LoaiCa LoaiCa;
        public static AC_LoaiKeHoach LoaiKeHoach;
        public static AC_LoaiViec LoaiViec;                
        public static AC_Viec Viec;
        public static AC_Ca Ca;
        public static AC_KeHoach KeHoach;
        //public static AC_BenhNhan BenhNhan;


        //Máy tự phục vụ ------------------------------
        public static AC_MayTuPhucVu MayTuPhucVu;
        public static AC_DongMayTuPhucVu DongMayTuPhucVu;
        public static AC_LoaiMayTuPhucVu LoaiMayTuPhucVu;
        public static AC_LoaiTinhNangMayTuPhucVu LoaiTinhNangMayTuPhucVu;
        public static AC_LoaiThietBiMayTuPhucVu LoaiThietBiMayTuPhucVu;
        public static AC_ThietBiMayTuPhucVu ThietBiMayTuPhucVu;
        public static AC_TinhNangMayTuPhucVu TinhNangMayTuPhucVu;
        public static AC_NhomModuleQuyTrinh NhomModuleQuyTrinh; 
        public static AC_ModuleQuyTrinh ModuleQuyTrinh;

        //Ẩm thực ---------------------------------
        public static AC_LoaiCamNang LoaiCamNang;
        public static AC_CamNang CamNang;
        public static AC_ChuongCamNang ChuongCamNang;
        public static AC_MonAn MonAn;
        public static AC_CongThuc CongThuc;
        public static AC_LoaiNguyenLieu LoaiNguyenLieu;
        public static AC_NguyenLieu NguyenLieu;
        public static AC_BoPhanNguyenLieu BoPhanNguyenLieu;
        public static AC_GiongNguyenLieu GiongNguyenLieu;

        //An Ninh --------------------------------
        //public static AC_LoaiYeuNhan LoaiYeuNhan;
        //public static AC_YeuNhan YeuNhan;


        public static void InitAC(IServiceProvider services)
        {
            HeThong = new AC_HeThong(services);
            NguoiDung = new AC_NguoiDung(services);
            ThongBao = new AC_ThongBao(services);
            Log = new AC_Log(services);
            LoaiToChuc = new AC_LoaiToChuc(services);
            LoaiSan = new AC_LoaiSan(services);
            LoaiTienIch = new AC_LoaiTienIch(services);
            LoaiPhongBan = new AC_LoaiPhongBan(services);
            LoaiGiaiPhap = new AC_LoaiGiaiPhap(services);
            LoaiCongViec = new AC_LoaiCongViec(services);
            LoaiDichVu = new AC_LoaiDichVu(services);
            LoaiHangHoa = new AC_LoaiHangHoa(services);           
            LoaiMauWeb = new AC_LoaiMauWeb(services);
            LoaiMauTrang = new AC_LoaiMauTrang(services);
            LoaiBanTin = new AC_LoaiBanTin(services);
            LoaiDoiTuong = new AC_LoaiDoiTuong(services);
            LoaiTinHieu = new AC_LoaiTinHieu(services);

            San = new AC_San(services);
            ToChuc = new AC_ToChuc(services);
            PhongBan = new AC_PhongBan(services);
            GiaiPhap = new AC_GiaiPhap(services);
            PhanSu = new AC_PhanSu(services);
            NhanVien = new AC_NhanVien(services);
            CongViec = new AC_CongViec(services);
            Nhom = new AC_Nhom(services);
            Lich = new AC_Lich(services);
            Mes = new AC_Mes(services);
            Forum = new AC_Forum(services);
            HangHoa = new AC_HangHoa(services);
            TienIch = new AC_TienIch(services);
            DichVu = new AC_DichVu(services);
            Trang = new AC_Trang(services);
            BanTin = new AC_BanTin(services);
            ThanhToan = new AC_ThanhToan(services);
            GiaoDich = new AC_GiaoDich(services);
            DoiTuong = new AC_DoiTuong(services);
            TinHieu = new AC_TinHieu(services);

            //--------------------
            LoaiCa = new AC_LoaiCa(services);
            LoaiKeHoach = new AC_LoaiKeHoach(services);
            LoaiViec = new AC_LoaiViec(services);
            //BenhNhan = new AC_BenhNhan(services);
            Ca = new AC_Ca(services);
            Viec = new AC_Viec(services);
            KeHoach = new AC_KeHoach(services);

            //-------------------------------------
            MayTuPhucVu = new AC_MayTuPhucVu(services);
            DongMayTuPhucVu = new AC_DongMayTuPhucVu(services);
            LoaiMayTuPhucVu = new AC_LoaiMayTuPhucVu(services);
            LoaiTinhNangMayTuPhucVu = new AC_LoaiTinhNangMayTuPhucVu(services);
            LoaiThietBiMayTuPhucVu = new AC_LoaiThietBiMayTuPhucVu(services);
            TinhNangMayTuPhucVu = new AC_TinhNangMayTuPhucVu(services);
            ThietBiMayTuPhucVu = new AC_ThietBiMayTuPhucVu(services);
            ModuleQuyTrinh = new AC_ModuleQuyTrinh(services);
            NhomModuleQuyTrinh = new AC_NhomModuleQuyTrinh(services);

            //Ẩm thực -------------------------
            LoaiCamNang = new AC_LoaiCamNang(services);
            CamNang = new AC_CamNang(services);
            ChuongCamNang = new AC_ChuongCamNang(services);
            MonAn = new AC_MonAn(services);
            CongThuc = new AC_CongThuc(services);
            LoaiNguyenLieu = new AC_LoaiNguyenLieu(services);
            NguyenLieu = new AC_NguyenLieu(services); 
            GiongNguyenLieu = new AC_GiongNguyenLieu(services); 
            BoPhanNguyenLieu = new AC_BoPhanNguyenLieu(services);

            //An Ninh --------------------------
            //LoaiYeuNhan = new AC_LoaiYeuNhan(services);
            //YeuNhan = new AC_YeuNhan(services);

        }
    }
}
