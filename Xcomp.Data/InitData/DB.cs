using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;
using Xcomp.Share.Ultils;

namespace Xcomp.Data.InitData
{
    public static class DB
    {
        private static async Task XoaBang()
        {
            await AC.HeThong.RemoveAll();
            await AC.NguoiDung.RemoveAll();
            await AC.ThongBao.RemoveAll();
            await AC.Log.RemoveAll();
            await AC.LoaiToChuc.RemoveAll();
            await AC.LoaiSan.RemoveAll();
            await AC.LoaiTienIch.RemoveAll();
            await AC.LoaiPhongBan.RemoveAll();
            await AC.LoaiGiaiPhap.RemoveAll();
            await AC.LoaiCongViec.RemoveAll();
            await AC.LoaiDichVu.RemoveAll();
            await AC.LoaiDoiTuong.RemoveAll();
            await AC.LoaiTinHieu.RemoveAll();


            await AC.San.RemoveAll();
            await AC.ToChuc.RemoveAll();
            await AC.PhongBan.RemoveAll();
            await AC.GiaiPhap.RemoveAll();
            await AC.PhanSu.RemoveAll();
            await AC.NhanVien.RemoveAll();
            await AC.CongViec.RemoveAll();
            await AC.Nhom.RemoveAll();
            await AC.Lich.RemoveAll();
            await AC.Mes.RemoveAll();
            await AC.Forum.RemoveAll();
            await AC.DichVu.RemoveAll();
            await AC.TienIch.RemoveAll();
            await AC.HangHoa.RemoveAll();
            await AC.Trang.RemoveAll();
            await AC.BanTin.RemoveAll();
            await AC.GiaoDich.RemoveAll();
            await AC.ThanhToan.RemoveAll();
            await AC.DoiTuong.RemoveAll();
            await AC.TinHieu.RemoveAll();

            //Y tế --------------------
            await AC.LoaiCa.RemoveAll();
            await AC.LoaiKeHoach.RemoveAll();
            await AC.Ca.RemoveAll();
            //await AC.BenhNhan.RemoveAll();
            await AC.LoaiViec.RemoveAll();
            await AC.KeHoach.RemoveAll();

            //Máy tự phục vụ ----------------            
            await AC.DongMayTuPhucVu.RemoveAll();
            await AC.LoaiMayTuPhucVu.RemoveAll();
            await AC.LoaiTinhNangMayTuPhucVu.RemoveAll();
            await AC.LoaiThietBiMayTuPhucVu.RemoveAll();
            await AC.MayTuPhucVu.RemoveAll();
            await AC.TinhNangMayTuPhucVu.RemoveAll();
            await AC.ThietBiMayTuPhucVu.RemoveAll();
            await AC.NhomModuleQuyTrinh.RemoveAll();
            await AC.ModuleQuyTrinh.RemoveAll();

            //Ẩm thực -------------------
            await AC.LoaiCamNang.RemoveAll();
            await AC.CamNang.RemoveAll();
            await AC.ChuongCamNang.RemoveAll();
            await AC.MonAn.RemoveAll();
            await AC.CongThuc.RemoveAll();
            await AC.LoaiNguyenLieu.RemoveAll();
            await AC.NguyenLieu.RemoveAll();
            await AC.BoPhanNguyenLieu.RemoveAll();
            await AC.GiongNguyenLieu.RemoveAll();

            //An Ninh ------------
            //await AC.LoaiYeuNhan.RemoveAll();
            //await AC.YeuNhan.RemoveAll();

        }

        public static async Task SinhThem()
        {
            
        }

        public static async Task TaoMoi()
        {
            await XoaBang();

            #region Temp

            #region --- Xcomp



            #endregion

            #region --- Y tế



            #endregion

            #region --- IoT



            #endregion

            #region --- Nông nghiệp



            #endregion

            #region --- Ẩm thực



            #endregion

            #region --- An ninh



            #endregion

            #region --- Giáo dục



            #endregion

            #region --- Bảo hiểm



            #endregion

            #region --- Phân loại sau

            #endregion

            #endregion

            #region Temp Nhà ---

            #region --- Loại tổ chức



            #endregion

            #region --- Tổ chức



            #endregion

            #region --- Loại phòng ban




            #endregion

            #region --- Loại giải pháp



            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            #endregion

            #region --- Giải pháp



            #endregion

            #endregion

            #region Hệ thống

            var ht_yte = await AC.HeThong.Create(new HeThong
            {
                Name = "Y tế mới",
                Code = "YTM",
                CodeHeThong = CodeHeThong.YTeMoi,
                LinhVuc = "Y tế",
                Url = "ytemoi.com",
                ThuongHieu = "Y TẾ MỚI",
                Logo = "https://storage.cloud.google.com/xcomp/Files/ytemoilogo.png"

            });

            var ht_amthuc = await AC.HeThong.Create(new HeThong
            {
                Name = "Làm bếp",
                Code = "LB",
                CodeHeThong = CodeHeThong.LamBep,
                LinhVuc = "Ẩm thực",
                Url = "lambep.net",
                ThuongHieu = "LÀM BẾP"

            });

            var ht_giaoduc = await AC.HeThong.Create(new HeThong
            {
                Name = "Vào lớp",
                Code = "VL",
                CodeHeThong = CodeHeThong.VaoLop,
                LinhVuc = "Giáo dục",
                Url = "vaolop.vn",
                ThuongHieu = "VÀO LỚP"

            });

            var ht_phatgiao = await AC.HeThong.Create(new HeThong
            {
                Name = "Cửa phật",
                Code = "CP",
                CodeHeThong = CodeHeThong.CuaPhat,
                LinhVuc = "Phật giáo",
                Url = "cuaphat.net",
                ThuongHieu = "CỬA PHẬT"

            });

            var ht_xcomp = await AC.HeThong.Create(new HeThong
            {
                Name = "Xcomp",
                Code = "XCOMP",
                CodeHeThong = CodeHeThong.Xcomp,
                LinhVuc = "Hạ tầng công ty số",
                Url = "xcomp.vn",
                ThuongHieu = "XCOMP",
                Logo = "https://storage.cloud.google.com/xcomp/Files/logo_xcomp.png"
            });

            var ht_baohiem = await AC.HeThong.Create(new HeThong
            {
                Name = "Bảo hiểm",
                Code = "BH",
                CodeHeThong = CodeHeThong.BaoHiem,
                LinhVuc = "Bảo hiểm",
                Url = "baohiem.ytemoi.com",
                ThuongHieu = "BẢO HIỂM MỚI"
            });

            var ht_iot = await AC.HeThong.Create(new HeThong
            {
                Name = "IoT",
                Code = "IoT",
                CodeHeThong = CodeHeThong.IoT,
                LinhVuc = "IoT",
                Url = "iotcen.com",
                ThuongHieu = "IoT CENTER"
            });

            var ht_kachiusa = await AC.HeThong.Create(new HeThong
            {
                Name = "Kachiusa",
                Code = "KCS",
                CodeHeThong = CodeHeThong.Kachiusa,
                LinhVuc = "Start Up",
                Url = "kachiusa.vn",
                ThuongHieu = "KACHIUSA"
            });

            var ht_pccc = await AC.HeThong.Create(new HeThong
            {
                Name = "Phòng cháy chữa cháy",
                Code = "PCCC",
                CodeHeThong = CodeHeThong.PhongChayChuaChay,
                LinhVuc = "Phòng cháy chữa cháy và cứu hộ cứu nạn",
                Url = "pccc.net.vn",
                ThuongHieu = "PHÒNG CHÁY CHỮA CHÁY"
            });

            var ht_nongnghiep = await AC.HeThong.Create(new HeThong
            {
                Name = "Nông nghiệp mới",
                Code = "NNM",
                CodeHeThong = CodeHeThong.NongNghiep,
                LinhVuc = "Nông nghiệp",
                Url = "nongnghiepmoi.org",
                ThuongHieu = "NÔNG NGHIỆP MỚI"
            });

            var ht_dulich = await AC.HeThong.Create(new HeThong
            {
                Name = "Du lịch mới",
                Code = "DLM",
                CodeHeThong = CodeHeThong.DuLich,
                LinhVuc = "Du lịch",
                Url = "dulich.kachiusa.vn",
                ThuongHieu = "DU LỊCH MỚI"
            });

            var ht_anninh = await AC.HeThong.Create(new HeThong
            {
                Name = "An ninh mới",
                Code = "ANM",
                CodeHeThong = CodeHeThong.AnNinh,
                LinhVuc = "An ninh",
                Url = "anninhmoi.com",
                ThuongHieu = "AN NINH MỚI"
            });

            #endregion

            #region Người dùng

            var byteSalt = PasswordHasher.GenerateSalt();
           
            var nd_lebahongminh = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Lê Bá Hồng Minh",
                Phone = "0981481527",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("1", byteSalt))
            });

            byteSalt = PasswordHasher.GenerateSalt();
            var nd_lebaanhduc = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Lê Bá Anh Đức",
                Phone = "0978721527",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("1", byteSalt))
            });

            byteSalt = PasswordHasher.GenerateSalt();
            var nd_nguyenthihang = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Nguyễn Thị Hằng",
                Phone = "0345781235",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("a", byteSalt))
            });

            byteSalt = PasswordHasher.GenerateSalt();
            var nd_nguyenthuy = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Nguyễn Thúy",
                Phone = "0392384598",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("a", byteSalt))
            });

            byteSalt = PasswordHasher.GenerateSalt();
            var nd_nguyendinhnam = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Nguyễn Đình Nam",
                Phone = "0384892305",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("a", byteSalt))
            });

            byteSalt = PasswordHasher.GenerateSalt();
            var nd_nguyenphuongnga = await AC.NguoiDung.Create(new NguoiDung
            {
                Name = "Nguyễn Phương Nga",
                Phone = "0989140168",
                PasswordSalt = Convert.ToBase64String(byteSalt),
                Password = Convert.ToBase64String(PasswordHasher.ComputeHash("a", byteSalt))
            });

            #endregion

            #region Loại sàn

            var ls_yte_khamchuabenh = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Khám chữa bệnh",
                Code = "ls_yte_cosoyte"
            });
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_yte_khamchuabenh,"Ban");
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_yte_khamchuabenh, "Mua");

            var ls_yte_chamsocnguoibenh = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Chăm sóc người bệnh",
                Code = "ls_yte_chamsocnguoibenh",
                Url ="chamsocnguoibenh.com" 
            });
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_yte_chamsocnguoibenh,"Ban");
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_yte_chamsocnguoibenh, "Mua");

            var ls_iot_yte_thietbiiot = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Thiết bị IoT y tế",
                Code = "ls_iot_yte_thietbiiot"
            });
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_iot_yte_thietbiiot,"Mua");
            await AC.HeThong.ThemLoaiSan(ht_iot, ls_iot_yte_thietbiiot,"Ban");

            var ls_iot_anninh_thietbiiot = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Thiết bị IoT an ninh",
                Code = "ls_iot_anninh_thietbiiot"
            });
            await AC.HeThong.ThemLoaiSan(ht_anninh, ls_iot_anninh_thietbiiot,"Mua");
            await AC.HeThong.ThemLoaiSan(ht_iot, ls_iot_anninh_thietbiiot,"Ban");

            var ls_anninh_dichvubaove = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Dịch vụ bảo vệ",
                Code = "ls_anninh_baove"
            });
            await AC.HeThong.ThemLoaiSan(ht_anninh, ls_anninh_dichvubaove,"Ban");
            await AC.HeThong.ThemLoaiSan(ht_anninh, ls_anninh_dichvubaove, "Mua");

            var ls_iot_nongngiep_thietbiiot = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Thiết bị IoT nông nghiệp",
                Code = "ls_iotpccc"
            });
            await AC.HeThong.ThemLoaiSan(ht_nongnghiep, ls_iot_nongngiep_thietbiiot,"Mua");
            await AC.HeThong.ThemLoaiSan(ht_iot, ls_iot_nongngiep_thietbiiot,"Ban");

            var ls_amthuc_yte_moanbaithuoc = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Món ăn bài thuốc",
                Code = "ls_amthuc_yte_monanbaithuoc"
            });
            await AC.HeThong.ThemLoaiSan(ht_yte, ls_amthuc_yte_moanbaithuoc,"Mua");
            await AC.HeThong.ThemLoaiSan(ht_amthuc, ls_amthuc_yte_moanbaithuoc,"Ban");

            var ls_nongnghiep_amthuc_nongsan = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Chợ nông sản",
                Code = "ls_nongnghiep_amthuc_chonongsan"
            });
            await AC.HeThong.ThemLoaiSan(ht_amthuc, ls_nongnghiep_amthuc_nongsan, "Mua");
            await AC.HeThong.ThemLoaiSan(ht_nongnghiep, ls_nongnghiep_amthuc_nongsan, "Ban");

            var ls_nongnghiep_choconngiong = await AC.LoaiSan.Create(new LoaiSan
            {
                Name = "Chợ con giống",
                Code = "ls_nongnghiep_chocongiong"
            });
            await AC.HeThong.ThemLoaiSan(ht_nongnghiep, ls_nongnghiep_choconngiong, "Mua");
            await AC.HeThong.ThemLoaiSan(ht_nongnghiep, ls_nongnghiep_choconngiong, "Ban");

            #endregion

            #region Sàn

            var san_yte_chamsocnguoibenhhanoi = await AC.San.Create(new San
            {
                Name = "Chăm sóc người bệnh tại Hà Nội",
                LoaiSan = ls_yte_chamsocnguoibenh.Name,
                CodeLoaiSan = ls_yte_chamsocnguoibenh.Code
            });

            var san_iot_thietbiiotyte = await AC.San.Create(new San
            {
                Name = "Thiết bị IoT y tế tại Hà Nội",
                LoaiSan = ls_iot_yte_thietbiiot.Name,
                CodeLoaiSan = ls_iot_yte_thietbiiot.Code
            });

            var san_amthuc_monanbaithuoc = await AC.San.Create(new San
            {
                Name = "Món ăn bài thuốc tại Hà Nội",
                LoaiSan = ls_amthuc_yte_moanbaithuoc.Name,
                CodeLoaiSan = ls_amthuc_yte_moanbaithuoc.Code
            });

            var san_yte_khamchuabenh = await AC.San.Create(new San
            {
                Name = "Khám chữa bệnh tại Hà Nội",
                LoaiSan = ls_yte_khamchuabenh.Name,
                CodeLoaiSan = ls_yte_khamchuabenh.Code
            });

            var san_iot_thietbiiotanninhhanoi = await AC.San.Create(new San
            {
                Name = "Thiết bị IoT an ninh tại Hà Nội",
                LoaiSan = ls_iot_anninh_thietbiiot.Name,
                CodeLoaiSan = ls_iot_anninh_thietbiiot.Code
            });

            var san_anninh_dichvubaovehanoi = await AC.San.Create(new San
            {
                Name = "Dịch vụ bảo vệ tại Hà Nội",
                LoaiSan = ls_anninh_dichvubaove.Name,
                CodeLoaiSan = ls_anninh_dichvubaove.Code
            });


            #endregion

            #region Mẫu web

            var lmw_phothong  = await AC.LoaiMauWeb.Create(new LoaiMauWeb
            {
                Name = "Web phổ thông",
                Code = "lmw_phothong"
            });

            #endregion

            #region Mẫu trang

            var lmt_gioithieu = await AC.LoaiMauTrang.Create(new LoaiMauTrang
            {
                Name = "Trang giới thiệu",
                LoaiMauWeb = lmw_phothong.Name,
                CodeLoaiMauWeb = lmw_phothong.Code,
                Code = "lmt_gioithieu_phothong",
                STT = 1
            });

            var lmt_dichvu = await AC.LoaiMauTrang.Create(new LoaiMauTrang
            {
                Name = "Trang dịch vụ",
                LoaiMauWeb = lmw_phothong.Name,
                CodeLoaiMauWeb = lmw_phothong.Code,
                Code = "lmt_dichvu_phothong",
                STT = 2
            });


            #endregion

            #region Loại Bản tin

            var lbt_header = await AC.LoaiBanTin.Create(new LoaiBanTin
            {
                Name = "Header",
                Code = "lbt_header",
                STT = 1
            });

            var lbt_tintuc = await AC.LoaiBanTin.Create(new LoaiBanTin
            {
                Name = "Tin tức",
                Code = "lbt_tintuc",
                STT = 2
            });

            var lbt_dichvu = await AC.LoaiBanTin.Create(new LoaiBanTin
            {
                Name = "Dịch vụ",
                Code = "lbt_dichvu",
                STT = 3
            });

            var lbt_lienhe = await AC.LoaiBanTin.Create(new LoaiBanTin
            {
                Name = "Liên hệ",
                Code = "lbt_lienhe",
                STT = 4
            });

            #endregion

            //-------------------

            #region Loại Giải pháp chung

            var lgp_quanlytochuc = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý tổ chức ",
                Code = "lgp_quanlytochuc",
            });            
              
            var lgp_quanlyphongban = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý phòng ban",
                Code = "lgp_quanlyphongban",
            });

            var lgp_quanlywebsite = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý website",
                Code = "lgp_quanlywebsite",
            });

            var lgp_quanlydichvu = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý dịch vụ",
                Code = "lgp_quanlydichvu",
            });

            #endregion

            #region Loại Công việc chung

            var lcv_quanlynhanvienphongban = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý nhân viên phòng ban",
                Code = "lcv_quanlynhanvienphongban"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlyphongban, lcv_quanlynhanvienphongban);

            var lcv_quanlynhansutochuc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý nhân sự & phòng ban",
                Code = "lcv_quanlynhansutochuc"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlytochuc, lcv_quanlynhansutochuc);

            var lcv_quanlytochucdoitac = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý tổ chức đối tác",
                Code = "lcv_quanlytochucdoitac"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlytochuc, lcv_quanlytochucdoitac);

            var lcv_xaydungdichvu = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng dịch vụ & hàng hóa",
                Code = "lcv_xaydungdichvuvahanghoa"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlydichvu, lcv_xaydungdichvu);

            var lcv_banhang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Bán hàng",
                Code = "lcv_banhang"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlydichvu, lcv_banhang);

            var lcv_xaydungwebsite = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng website",
                Code = "lcv_xaydungwebsite"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_quanlywebsite, lcv_xaydungwebsite);


            #endregion

            //-----------------

            #region Xcomp

            #region --- Loại tổ chức

            var ltc_xcomp_xcomp = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Xcomp",
                Code = "ltc_xcomp_xcomp"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_xcomp, ltc_xcomp_xcomp);

            #endregion

            #region --- Tổ chức

            var tc_xcomp_xcomp = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Xcomp",
                CodeLoaiToChuc = ltc_xcomp_xcomp.Code,
                LoaiToChuc = ltc_xcomp_xcomp.Name,
                VietTat = "xcomp",
                IdHeThong = ht_xcomp.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_xcomp_xcomp);

            #endregion

            #region --- Loại phòng ban


            //Xcomp ---------------------------
            var lpb_xcomp_giaiphap = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng giải pháp",
                Code = "lpb_xcomp_phonggiaiphap"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_giaiphap);

            var lpb_xcomp_kythuat = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng kỹ thuật",
                Code = "lpb_xcomp_phongkythuat"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_kythuat);

            var lpb_xcomp_yte = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Y tế",
                Code = "lpb_xcomp_yte"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_yte);

            var lpb_xcomp_iot = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "IoT",
                Code = "lpb_xcomp_iot"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_iot);

            var lpb_xcomp_nongnghiep = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Nông nghiệp",
                Code = "lpb_xcomp_nongnghiep"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_nongnghiep);

            var lpb_xcomp_amthuc = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Ẩm thực",
                Code = "lpb_xcomp_amthuc"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_amthuc);

            var lpb_xcomp_anninh = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "An ninh",
                Code = "lpb_xcomp_anninh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_anninh);

            var lpb_xcomp_giaoduc = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Giáo dục",
                Code = "lpb_xcomp_giaoduc"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_giaoduc);

            var lpb_xcomp_baohiem = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Bảo hiểm",
                Code = "lpb_xcomp_baohiem"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_baohiem);

            var lpb_xcomp_dulich = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Du lịch",
                Code = "lpb_xcomp_dulich"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_xcomp_xcomp, lpb_xcomp_dulich);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_xcomp_xcomp);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_xcomp_giaiphap);

            var lgp_xcomp_hethong = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Hệ thống",
                Code = "lgp_xcomp_hethong",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_hethong, lpb_xcomp_giaiphap);

            var lgp_xcomp_kythuat = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Kỹ thuật",
                Code = "lgp_xcomp_kythuat",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_kythuat, lpb_xcomp_giaiphap);

            var lgp_xcomp_san = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Sàn",
                Code = "lgp_xcomp_san",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_san, lpb_xcomp_giaiphap);

            

            var lgp_xcomp_noidung = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Nội dung",
                Code = "lgp_xcomp_noidung",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_noidung, lpb_xcomp_giaiphap);

            var lgp_xcomp_server = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Server",
                Code = "lgp_xcomp_server",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_server, lpb_xcomp_kythuat);

            var lgp_xcomp_thongbaovalog = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Thông báo & Log",
                Code = "lgp_xcomp_thongbaovalog",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_thongbaovalog, lpb_xcomp_kythuat);

            var lgp_xcomp_thanhtoan = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Thanh toán",
                Code = "lgp_xcomp_thanhtoan",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_thanhtoan, lpb_xcomp_kythuat);

            var lgp_xcomp_app = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "App",
                Code = "lgp_xcomp_app",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_app, lpb_xcomp_kythuat);

            var lgp_xcomp_web = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Web",
                Code = "lgp_xcomp_web",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_web, lpb_xcomp_kythuat);

            var lgp_xcomp_cosodulieu = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Cơ sở dữ liệu",
                Code = "lgp_xcomp_cosodulieu",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_cosodulieu, lpb_xcomp_kythuat);

            var lgp_xcomp_nguoidung = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Người dùng",
                Code = "lgp_xcomp_nguoidung",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_nguoidung, lpb_xcomp_kythuat);

            var lgp_xcomp_thuoc = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Thuốc",
                Code = "lgp_xcomp_thuoc",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_thuoc, lpb_xcomp_yte);

            var lgp_xcomp_benhvadieutri = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Bệnh & Điều trị",
                Code = "lgp_xcomp_thuocvadieutri",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_benhvadieutri, lpb_xcomp_yte);

            var lgp_xcomp_tochucyte = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Tổ chức y tế",
                Code = "lgp_xcomp_tochucyte",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_tochucyte, lpb_xcomp_yte);

            var lgp_xcomp_sanyte = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Sàn y tế",
                Code = "lgp_xcomp_sanyte",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_sanyte, lpb_xcomp_yte);

            var lgp_xcomp_thietbiiot = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Thiết bị IoT",
                Code = "lgp_xcomp_thietbiiot",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_thietbiiot, lpb_xcomp_iot);

            var lgp_xcomp_tochuciot = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Tổ chức IoT",
                Code = "lgp_xcomp_tochuciot",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_tochuciot, lpb_xcomp_iot);

            var lgp_xcomp_saniot = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Sàn IoT",
                Code = "lgp_xcomp_saniot",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_saniot, lpb_xcomp_iot);

            var lgp_xcomp_tochucamthuc = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Tổ chức Ẩm thực",
                Code = "lgp_xcomp_tochucamthuc",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_tochucamthuc, lpb_xcomp_amthuc);

            var lgp_xcomp_sanamthuc = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Sàn Ẩm thực",
                Code = "lgp_xcomp_sanamthuc",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_sanamthuc, lpb_xcomp_amthuc);

            var lgp_xcomp_monan = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Món ăn",
                Code = "lgp_xcomp_monan",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_monan, lpb_xcomp_amthuc);

            var lgp_xcomp_amthuc_nguyenlieu = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Nguyên liệu",
                Code = "lgp_xcomp_nguyenlieu",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_amthuc_nguyenlieu, lpb_xcomp_amthuc);

            var lgp_xcomp_tochucnongnghiep = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Tổ chức Nông nghiệp",
                Code = "lgp_xcomp_tochucnongnghiep",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_tochucnongnghiep, lpb_xcomp_nongnghiep);

            var lgp_xcomp_sannongnghiep = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Sàn Nông nghiệp",
                Code = "lgp_xcomp_sannongnghiep",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_sannongnghiep, lpb_xcomp_nongnghiep);

            var lgp_xcomp_vatnuoi = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Vật nuôi",
                Code = "lgp_xcomp_vatnuoi",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_vatnuoi, lpb_xcomp_nongnghiep);

            var lgp_xcomp_caytrong = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Cây trồng",
                Code = "lgp_xcomp_caytrong",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_xcomp_caytrong, lpb_xcomp_nongnghiep);

            #endregion

            #region --- Loại công việc

            var lcv_xcomp_quanlycachethong = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các hệ thống, loại tổ chức, loại giải pháp, loại công việc",
                Code = "lcv_xcomp_quanlycachethong"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_xcomp_hethong, lcv_xcomp_quanlycachethong);
            

            var lcv_xcomp_quanlycacsan = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các sàn giao dịch, loại dịch vụ, loại hàng hóa",
                Code = "lcv_xcomp_quanlycacsan"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_xcomp_san, lcv_xcomp_quanlycacsan);

            var lcv_xcomp_amthuc_quanlynguyenlieu = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý nguyên liệu",
                Code = "lcv_xcomp_amthuc_quanlynguyenlieu"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_xcomp_amthuc_nguyenlieu, lcv_xcomp_amthuc_quanlynguyenlieu);

            var lcv_xcomp_amthuc_quanlymonan = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý món ăn",
                Code = "lcv_xcomp_amthuc_quanlymonan"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_xcomp_monan, lcv_xcomp_amthuc_quanlymonan);




            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            var pb_xcomp_giaiphap = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng giải pháp",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_giaiphap.Name,
                CodeLoaiPhongBan = lpb_xcomp_giaiphap.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_giaiphap);

            var pb_xcomp_kythuat = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng kỹ thuật",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_kythuat.Name,
                CodeLoaiPhongBan = lpb_xcomp_kythuat.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_kythuat);

            var pb_xcomp_yte = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Y tế",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_yte.Name,
                CodeLoaiPhongBan = lpb_xcomp_yte.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_yte);

            var pb_xcomp_iot = await AC.PhongBan.Create(new PhongBan
            {
                Name = "IoT",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_iot.Name,
                CodeLoaiPhongBan = lpb_xcomp_iot.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_iot);

            var pb_xcomp_nongnghiep = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Nông nghiệp",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_nongnghiep.Name,
                CodeLoaiPhongBan = lpb_xcomp_nongnghiep.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_nongnghiep);

            var pb_xcomp_amthuc = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Ẩm thực",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_amthuc.Name,
                CodeLoaiPhongBan = lpb_xcomp_amthuc.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_amthuc);

            var pb_xcomp_anninh = await AC.PhongBan.Create(new PhongBan
            {
                Name = "An ninh",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_xcomp_anninh.Name,
                CodeLoaiPhongBan = lpb_xcomp_anninh.Code
            });
            await AC.ToChuc.Them_PhongBan(tc_xcomp_xcomp, pb_xcomp_anninh);



            #endregion

            #region --- Giải pháp


            var gp_xcomp_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_xcomp_quanlytochuc, tc_xcomp_xcomp);

            var gp_xcomp_quanlynhansuphonggiaiphap = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_xcomp_quanlynhansuphonggiaiphap, pb_xcomp_giaiphap);

            var gp_xcomp_phonggiaiphap_quanlysan = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_xcomp_san.Name,
                CodeLoaiGiaiPhap = lgp_xcomp_san.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_xcomp_phonggiaiphap_quanlysan, pb_xcomp_giaiphap);

            var gp_xcomp_phonggiaiphap_quanlyhethong = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_xcomp_hethong.Name,
                CodeLoaiGiaiPhap = lgp_xcomp_hethong.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_xcomp_phonggiaiphap_quanlyhethong, pb_xcomp_giaiphap);

            var gp_xcomp_phongamthuc_quanlynguyenlieu = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_xcomp_amthuc_nguyenlieu.Name,
                CodeLoaiGiaiPhap = lgp_xcomp_amthuc_nguyenlieu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_xcomp_phongamthuc_quanlynguyenlieu, pb_xcomp_amthuc);

            var gp_xcomp_phongamthuc_quanlymonan = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_xcomp_monan.Name,
                CodeLoaiGiaiPhap = lgp_xcomp_monan.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_xcomp_phongamthuc_quanlymonan, pb_xcomp_amthuc);






            #endregion

            #region --- Nhân viên

            var nv_xcomp_minh = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Founder",
                GioiThieu = "Quản lý xcomp",
                IdHeThong = ht_xcomp.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_xcomp_xcomp, nv_xcomp_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_xcomp_minh);

            var nv_xcomp_minh_phonggiaiphap = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Nhân viên giải pháp",
                GioiThieu = "Quản lý phòng giải pháp",
                IdHeThong = ht_xcomp.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_xcomp_giaiphap, nv_xcomp_minh_phonggiaiphap);
            await AC.ToChuc.Them_NhanVien(tc_xcomp_xcomp, nv_xcomp_minh_phonggiaiphap);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_xcomp_minh_phonggiaiphap);

            var nv_xcomp_minh_phongamthuc = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý món ăn",
                GioiThieu = "Quản lý ẩm thực",
                IdHeThong = ht_xcomp.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_xcomp_amthuc, nv_xcomp_minh_phongamthuc);
            await AC.ToChuc.Them_NhanVien(tc_xcomp_xcomp, nv_xcomp_minh_phongamthuc);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_xcomp_minh_phongamthuc);

            #endregion


            #region --- Công việc

            var cv_xcomp_quanlyxcomp = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdHeThong = ht_xcomp.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_xcomp_quanlytochuc, cv_xcomp_quanlyxcomp);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh, cv_xcomp_quanlyxcomp);


            var cv_xcomp_phonggiaiphap_quanlyphongban = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdPhongBan = pb_xcomp_giaiphap.Id,
                IdHeThong = ht_xcomp.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_xcomp_quanlynhansuphonggiaiphap, cv_xcomp_phonggiaiphap_quanlyphongban);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh_phonggiaiphap, cv_xcomp_phonggiaiphap_quanlyphongban);

            var cv_xcomp_phonggiaiphap_quanlysan = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xcomp_quanlycacsan.Name,
                CodeLoaiCongViec = lcv_xcomp_quanlycacsan.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdPhongBan = pb_xcomp_giaiphap.Id,
                IdHeThong = ht_xcomp.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_xcomp_phonggiaiphap_quanlysan, cv_xcomp_phonggiaiphap_quanlysan);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh_phonggiaiphap, cv_xcomp_phonggiaiphap_quanlysan);

            

            var cv_xcomp_phonggiaiphap_quanlyhethong = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xcomp_quanlycachethong.Name,
                CodeLoaiCongViec = lcv_xcomp_quanlycachethong.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdPhongBan = pb_xcomp_giaiphap.Id,
                IdHeThong = ht_xcomp.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_xcomp_phonggiaiphap_quanlyhethong, cv_xcomp_phonggiaiphap_quanlyhethong);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh_phonggiaiphap, cv_xcomp_phonggiaiphap_quanlyhethong);

            var cv_xcomp_phongamthuc_quanlynguyenlieu = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xcomp_amthuc_quanlynguyenlieu.Name,
                CodeLoaiCongViec = lcv_xcomp_amthuc_quanlynguyenlieu.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdPhongBan = pb_xcomp_amthuc.Id,
                IdHeThong = ht_xcomp.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_xcomp_phongamthuc_quanlynguyenlieu, cv_xcomp_phongamthuc_quanlynguyenlieu);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh_phongamthuc, cv_xcomp_phongamthuc_quanlynguyenlieu);

            var cv_xcomp_phongamthuc_quanlymonan = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xcomp_amthuc_quanlymonan.Name,
                CodeLoaiCongViec = lcv_xcomp_amthuc_quanlymonan.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_xcomp_xcomp.Id,
                IdPhongBan = pb_xcomp_amthuc.Id,
                IdHeThong = ht_xcomp.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_xcomp_phongamthuc_quanlymonan, cv_xcomp_phongamthuc_quanlymonan);
            await AC.NhanVien.ThemCongViec(nv_xcomp_minh_phongamthuc, cv_xcomp_phongamthuc_quanlymonan);

            #endregion


            #endregion

            #region IoT

            #region Nhà phát triển IoT

            #region --- Loại tổ chức

            var ltc_iot_nhaphattrientiot = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà phát triển thiết bị IoT",
                Code = "ltc_iot_nhaphattrieniot"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_nhaphattrientiot);

            #endregion

            #region --- Tổ chức

            var tc_iot_bachduongiot = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Bạch Dương IoT",
                CodeLoaiToChuc = ltc_iot_nhaphattrientiot.Code,
                LoaiToChuc = ltc_iot_nhaphattrientiot.Name,
                VietTat = "bdiot",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_bachduongiot);

            #endregion

            #region --- Loại phòng ban

            //IoT ------------------------
            var lpb_iot_iot_phongcongnghe = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng công nghệ IoT",
                Code = "lpb_iot_iot_phongcongnghe"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphattrientiot, lpb_iot_iot_phongcongnghe);

            var lpb_iot_iot_phongthietbi = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng thiết bị IoT",
                Code = "lpb_iot_iot_phongthietbi"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphattrientiot, lpb_iot_iot_phongthietbi);

            var lpb_iot_iot_phongquanlynhaphanphoi = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng quản lý nhà phân phối",
                Code = "lpb_iot_iot_phongquanlynhaphanphoi"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphattrientiot, lpb_iot_iot_phongquanlynhaphanphoi);

            var lpb_iot_iot_phongquanlynhacungcap = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng quản lý nhà cung cấp",
                Code = "lpb_iot_iot_phongquanlynhacungcap"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphattrientiot, lpb_iot_iot_phongquanlynhacungcap);

            var lpb_iot_iot_phongdichvuvienthong = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng dịch vụ viễn thông",
                Code = "lpb_iot_iot_phongdichvuvienthong"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphattrientiot, lpb_iot_iot_phongdichvuvienthong);


            #endregion

            #region --- Loại giải pháp

            
            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_nhaphattrientiot);

            #endregion

            #region --- Phòng ban

            //IoT-------------------------
            var pb_iot_phongcongnghe = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_iot_phongcongnghe.Name,
                CodeLoaiPhongBan = lpb_iot_iot_phongcongnghe.Code,
                Name = "Phòng công nghệ"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_bachduongiot, pb_iot_phongcongnghe);

            var pb_iot_phongthietbi = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_iot_phongthietbi.Name,
                CodeLoaiPhongBan = lpb_iot_iot_phongthietbi.Code,
                Name = "Phòng thiết bị"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_bachduongiot, pb_iot_phongthietbi);

            var pb_iot_phongnhaphanphoi = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_iot_phongquanlynhaphanphoi.Name,
                CodeLoaiPhongBan = lpb_iot_iot_phongquanlynhaphanphoi.Code,
                Name = "Phòng quản lý nhà phân phối"
            });
            await AC.ToChuc.Them_PhongBan(tc_iot_bachduongiot, pb_iot_phongnhaphanphoi);

            var pb_iot_phongnhacungcap = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_iot_phongquanlynhacungcap.Name,
                CodeLoaiPhongBan = lpb_iot_iot_phongquanlynhacungcap.Code,
                Name = "Phòng quản lý nhà cung cấp"
            });
            await AC.ToChuc.Them_PhongBan(tc_iot_bachduongiot, pb_iot_phongnhacungcap);

            var pb_iot_phongdichvuvienthong = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_iot_phongdichvuvienthong.Name,
                CodeLoaiPhongBan = lpb_iot_iot_phongdichvuvienthong.Code,
                Name = "Phòng dịch vụ viễn thông"
            });
            await AC.ToChuc.Them_PhongBan(tc_iot_bachduongiot, pb_iot_phongdichvuvienthong);

            #endregion

            #endregion

            #region Nhà phân phối thiết bị IoT

            #region --- Loại tổ chức

            var ltc_iot_nhaphanphoiiot = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà phân phối thiết bị IoT",
                Code = "ltc_iot_nhaphanphoiiot"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_nhaphanphoiiot);

            #endregion

            #region --- Tổ chức

            var tc_iot_vihelm = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Vihelm",
                CodeLoaiToChuc = ltc_iot_nhaphanphoiiot.Code,
                LoaiToChuc = ltc_iot_nhaphanphoiiot.Name,
                VietTat = "vihelm",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_vihelm);

            #endregion

            #region --- Sàn
            await AC.ToChuc.Them_San(tc_iot_vihelm, san_iot_thietbiiotyte);
            await AC.ToChuc.Them_San(tc_iot_vihelm, san_iot_thietbiiotanninhhanoi);
            #endregion

            #region --- Loại phòng ban

            //Phân phối IoT ------------
            var lpb_iot_phanphoi_phongphanphoithietbiyte = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng phân phối thiết bị y tế",
                Code = "lpb_iot_phanphoi_phongphanphoivongyte"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphanphoiiot, lpb_iot_phanphoi_phongphanphoithietbiyte);

            var lpb_iot_phanphoi_phongphanphoithietbianninh = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng phân phối thiết bị an ninh",
                Code = "lpb_iot_phanphoi_phongphanphoithietbianninh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphanphoiiot, lpb_iot_phanphoi_phongphanphoithietbianninh);

            var lpb_iot_phanphoi_phongphanphoithietdanhchotreem = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng phân phối thiết bị dành cho trẻ em",
                Code = "lpb_iot_phanphoi_phongphanphoithietbidanhchotreem"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhaphanphoiiot, lpb_iot_phanphoi_phongphanphoithietdanhchotreem);


            #endregion

            #region --- Loại giải pháp

            
            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_nhaphanphoiiot);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_phanphoi_phongphanphoithietbiyte);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_phanphoi_phongphanphoithietbianninh);

            //Phân phối IoT-------------------------
            var lgp_iot_ppiot_phanphoivongyte = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Phân phối vòng y tế",
                Code = "lgp_iot_ppiot_phanphoivongyte",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_ppiot_phanphoivongyte, lpb_iot_phanphoi_phongphanphoithietbiyte);

            var lgp_iot_ppiot_quanlykhachhangcosoyte = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý khách hàng",
                Code = "lgp_iot_ppiot_quanlycosoytekhachhang",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_ppiot_quanlykhachhangcosoyte, lpb_iot_phanphoi_phongphanphoithietbiyte);

            var lgp_iot_ppiot_phanphoithietbicanhbao = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Phân phối thiết bị cảnh báo",
                Code = "lgp_iot_ppiot_phanphoithietbicanhbao",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_ppiot_phanphoithietbicanhbao, lpb_iot_phanphoi_phongphanphoithietbianninh);
            var lgp_iot_ppiot_quanlykhachhanganninh = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý khách hàng nghành an ninh",
                Code = "lgp_iot_ppiot_quanlyanninhkhachhang",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_ppiot_quanlykhachhanganninh, lpb_iot_phanphoi_phongphanphoithietbianninh);

            var lgp_iot_ppiot_quanlytochucphanphoiiot = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý tổ chức phân phối thiết bị IoT ",
                Code = "lgp_iot_ppiot_quanlytochuciot",
            });

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_iot_ppiot_quanlytochucphanphoiiot, ltc_iot_nhaphanphoiiot);

            #endregion

            #region --- Loại dịch vụ

            var ldv_iot_vongyte = await AC.LoaiDichVu.Create(new LoaiDichVu
            {
                Name = "Vòng y tế",
                Code = "ldv_iot_vongyte",
            });
            await AC.LoaiToChuc.ThemLoaiDichVu(ltc_iot_nhaphanphoiiot, ldv_iot_vongyte);
            await AC.LoaiSan.ThemLoaiDichVu(ls_iot_yte_thietbiiot, ldv_iot_vongyte);

            var ldv_iot_vonganninh = await AC.LoaiDichVu.Create(new LoaiDichVu
            {
                Name = "Vòng an ninh",
                Code = "ldv_iot_vonganninh",
            });
            await AC.LoaiToChuc.ThemLoaiDichVu(ltc_iot_nhaphanphoiiot, ldv_iot_vonganninh);
            await AC.LoaiSan.ThemLoaiDichVu(ls_iot_anninh_thietbiiot, ldv_iot_vonganninh);

            

            #endregion

            #region --- Loại hàng hóa

            var lhh_iot_chothuevongyte = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Cho cơ sở y tế thuê vòng y tế",
                Code = "lhh_iot_chothuevongyte"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_iot_vongyte, lhh_iot_chothuevongyte);

            var lhh_iot_vongytechonguoibenh = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Vòng y tế cho người bệnh",
                Code = "lhh_iot_vongytechonguoibenh"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_iot_vongyte, lhh_iot_vongytechonguoibenh);

            var lhh_iot_vonganninh = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Vòng an ninh",
                Code = "lhh_iot_vonganninh"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_iot_vonganninh, lhh_iot_vonganninh);

            

            #endregion

            #region --- Loại công việc

            // Phân phối IoT---------------------
            var lcv_iot_phanphoi_quanlythietbivongyte = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý kho thiết bị",
                Code = "lcv_iot_phanphoi_quanlykhothietbivongyte"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoivongyte, lcv_iot_phanphoi_quanlythietbivongyte);

            var lcv_iot_phanphoi_quanlyvanhanhvongyte = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý vận hành",
                Code = "lcv_iot_phanphoi_quanlyvanhanhvongyte"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoivongyte, lcv_iot_phanphoi_quanlyvanhanhvongyte);

            var lcv_iot_phanphoi_quanlygiavongyte = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý giá",
                Code = "lcv_iot_phanphoi_quanlygiavongyte"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoivongyte, lcv_iot_phanphoi_quanlygiavongyte);

            var lcv_iot_phanphoi_quanlydoanhthuvongyte = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý doanh thu",
                Code = "lcv_iot_phanphoi_quanlydoanhthuvongyte"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoivongyte, lcv_iot_phanphoi_quanlydoanhthuvongyte);

            var lcv_iot_phanphoi_quanlycosoytekhachhang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý khách hàng cơ sở y tế",
                Code = "lcv_iot_phanphoi_quanlycosoytekhachhang"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_quanlykhachhangcosoyte, lcv_iot_phanphoi_quanlycosoytekhachhang);

            var lcv_iot_phanphoi_quanlythietbicanhbao = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý kho thiết bị cảnh báo",
                Code = "lcv_iot_phanphoi_quanlykhothietbicanhbao"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoithietbicanhbao, lcv_iot_phanphoi_quanlythietbicanhbao);

            var lcv_iot_phanphoi_quanlyvanhanhcanhbao = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý vận hành",
                Code = "lcv_iot_phanphoi_quanlyvanhanhcanhbao"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoithietbicanhbao, lcv_iot_phanphoi_quanlyvanhanhcanhbao);

            var lcv_iot_phanphoi_quanlygiacanhbao = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý giá thiết bị",
                Code = "lcv_iot_phanphoi_quanlygiacanhbao"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoithietbicanhbao, lcv_iot_phanphoi_quanlygiacanhbao);

            var lcv_iot_phanphoi_quanlydoanhthucanhbao = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý doanh thu",
                Code = "lcv_iot_phanphoi_quanlydoanhthucanhbao"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_phanphoithietbicanhbao, lcv_iot_phanphoi_quanlydoanhthucanhbao);

            var lcv_iot_phanphoi_quanlycoquananninhkhachhang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý khách hàng cơ quan an ninh",
                Code = "lcv_iot_phanphoi_quanlycosoytekhachhang"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_quanlykhachhanganninh, lcv_iot_phanphoi_quanlycoquananninhkhachhang);

            var lcv_iot_phanphoi_quanlydoanhthutochuc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý doanh thu",
                Code = "lcv_iot_phanphoi_quanlynhansutochuc"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_ppiot_quanlytochucphanphoiiot, lcv_iot_phanphoi_quanlydoanhthutochuc);

            #endregion


            #region --- Dịch vụ

            var dv_iot_vongyte = await AC.DichVu.Create(new DichVu
            {
                LoaiDichVu = ldv_iot_vongyte.Name,
                CodeLoaiDichVu = ldv_iot_vongyte.Code,
                Name = "Vòng y tế"
            });
            await AC.DichVu.SetToChuc(dv_iot_vongyte, tc_iot_vihelm);
            await AC.DichVu.SetSan(dv_iot_vongyte, san_iot_thietbiiotyte);

            var dv_iot_vonganninh = await AC.DichVu.Create(new DichVu
            {
                LoaiDichVu = ldv_iot_vonganninh.Name,
                CodeLoaiDichVu = ldv_iot_vonganninh.Code,
                Name = "Vòng an ninh"
            });
            await AC.DichVu.SetToChuc(dv_iot_vonganninh, tc_iot_vihelm);
            await AC.DichVu.SetSan(dv_iot_vonganninh, san_iot_thietbiiotanninhhanoi);

            #endregion

            #region --- Hàng Hóa

            var hh_iot_chocosoytethuvong = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Cho cơ sở y tế thuê vòng",
                IdToChuc = tc_iot_vihelm.Id,
                Tag = "#vongyte #nguoibenh #cosoyte",
                Anh = "/Files/hh_04.jpg",
                TomTat = "<p> - Theo dõi thông số sức khỏe bệnh nhân 24/24 <br> - Bệnh nhân gọi y tá 24/24 </p>",
                Gia = "<p> - 150.000 vnđ/ca(6 ngày) </p>",
                LienHe = "<p>Hoài Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_iot_vongyte, hh_iot_chocosoytethuvong);
            await AC.HangHoa.SetSan(hh_iot_chocosoytethuvong, san_iot_thietbiiotyte);
            await AC.HangHoa.ThemLoaiHangHoa(hh_iot_chocosoytethuvong, lhh_iot_chothuevongyte);

            var hh_iot_vonganninh = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Vòng an ninh",
                IdToChuc = tc_iot_vihelm.Id,
                Tag = "#vonganninh ",
                Anh = "/Files/hh_05.jpg",
                TomTat = "<p> - Bảo vệ an ninh 24/24 <br> - Theo dõi an ninh 24/24 </p>",
                Gia = "<p> - 3.500.000 vnđ/chiếc <br> - 60.000 vnđ/thuê bao internet/tháng </p>",
                LienHe = "<p>Hoài Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_iot_vonganninh, hh_iot_vonganninh);
            await AC.HangHoa.SetSan(hh_iot_vonganninh, san_iot_thietbiiotanninhhanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_iot_vonganninh, lhh_iot_vonganninh);

            #endregion

            #region --- Phòng ban

            //Phân phối IoT-------------------------------

            var pb_phanphoithietbiiotyte = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_phanphoi_phongphanphoithietbiyte.Name,
                CodeLoaiPhongBan = lpb_iot_phanphoi_phongphanphoithietbiyte.Code,
                Name = "Phòng phân phối thiết bị IoT y tế"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_vihelm, pb_phanphoithietbiiotyte);

            var pb_phanphoithietbiiotanninh = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_phanphoi_phongphanphoithietbianninh.Name,
                CodeLoaiPhongBan = lpb_iot_phanphoi_phongphanphoithietbianninh.Code,
                Name = "Phòng phân phối thiết bị IoT an ninh"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_vihelm, pb_phanphoithietbiiotanninh);

            #endregion

            #region --- Giải pháp

            //IoT----------------------------------------
            var gp_phanphoivongyte = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_ppiot_phanphoivongyte.Name,
                CodeLoaiGiaiPhap = lgp_iot_ppiot_phanphoivongyte.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_phanphoivongyte, pb_phanphoithietbiiotyte);

            var gp_quanlyphongbanphanphoiiot = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_quanlyphongbanphanphoiiot, pb_phanphoithietbiiotyte);



            var gp_quanlydoanhnghiepphanphoiiot = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_quanlydoanhnghiepphanphoiiot, tc_iot_vihelm);

            #endregion

            #region --- Nhân viên

            //Iot-----------------------
            var nv_nam = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0384892305",
                Name = "Nguyễn Đình Nam",
                VaiTro = "Founder",
                GioiThieu = "Founder",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_vihelm, nv_nam, true);
            await AC.NguoiDung.ThemNhanVien(nd_nguyendinhnam, nv_nam);

            var nv_nam_saler = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,
                Phone = "0384892305",
                Name = "Nguyễn Đình Nam",
                VaiTro = "Saler",
                GioiThieu = "Founder",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_phanphoithietbiiotyte, nv_nam_saler);
            await AC.ToChuc.Them_NhanVien(tc_iot_vihelm, nv_nam_saler);
            await AC.NguoiDung.ThemNhanVien(nd_nguyendinhnam, nv_nam_saler);


            var nv_nga = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0989140168",
                Name = "Nguyễn Phương Nga",
                VaiTro = "Founder",
                GioiThieu = "Founder",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_vihelm, nv_nga, true);
            await AC.NguoiDung.ThemNhanVien(nd_nguyenphuongnga, nv_nga);

            var nv_nga_quanly = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0989140168",
                Name = "Nguyễn Phương Nga",
                VaiTro = "Quản lý",
                GioiThieu = "Founder",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_phanphoithietbiiotyte, nv_nga_quanly);
            await AC.ToChuc.Them_NhanVien(tc_iot_vihelm, nv_nga_quanly);
            await AC.NguoiDung.ThemNhanVien(nd_nguyenphuongnga, nv_nga_quanly);

            #endregion

            #region --- Công việc

            //IoT------------------------------

            var cv_quanlynhansutochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_vihelm.Id,
                IdHeThong = ht_iot.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlydoanhnghiepphanphoiiot, cv_quanlynhansutochuc);
            await AC.NhanVien.ThemCongViec(nv_nga, cv_quanlynhansutochuc);

            var cv_quanlynhanvienphongiotyte = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_vihelm.Id,
                IdPhongBan = pb_phanphoithietbiiotyte.Id,
                IdHeThong = ht_iot.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongbanphanphoiiot, cv_quanlynhanvienphongiotyte);
            await AC.NhanVien.ThemCongViec(nv_nga_quanly, cv_quanlynhanvienphongiotyte);

            #endregion

            #endregion

            #region Hãng viễn thông

            #region --- Loại tổ chức

            var ltc_iot_hangvienthong = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Hãng viễn thông",
                Code = "ltc_iot_hangvienthong"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_hangvienthong);

            #endregion

            #region --- Tổ chức

            var tc_iot_htc = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Hà Nội Telecom",
                CodeLoaiToChuc = ltc_iot_hangvienthong.Code,
                LoaiToChuc = ltc_iot_hangvienthong.Name,
                VietTat = "htc",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_htc);

            var tc_iot_viettel = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Viettel",
                CodeLoaiToChuc = ltc_iot_hangvienthong.Code,
                LoaiToChuc = ltc_iot_hangvienthong.Name,
                VietTat = "viettel",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_viettel);

            #endregion

            #region --- Loại phòng ban


            var lpb_iot_maytuphucvu_phongdichvukios = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng dịch vụ kios",
                Code = "lpb_iot_maytuphucvu_phongdichvukios"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_hangvienthong, lpb_iot_maytuphucvu_phongdichvukios);
            
           
            var lpb_iot_maytuphucvu_phongvanhanhkios = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng vận hành kios",
                Code = "lpb_iot_maytuphucvu_phongvanhanhkios"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_hangvienthong, lpb_iot_maytuphucvu_phongvanhanhkios);
            
           

            var lpb_iot_maytuphucvu_quantrikios = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Quản trị kios",
                Code = "lpb_iot_maytuphucvu_phongquantrikios"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_hangvienthong, lpb_iot_maytuphucvu_quantrikios);
            
            




            //Hãng viễn thông -------------------

            var lpb_iot_hangvienthong_phongpesim = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng esim",
                Code = "lpb_iot_hangvienthong_phongesim"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_hangvienthong, lpb_iot_hangvienthong_phongpesim);

            var lpb_iot_hangvienthong_phongpiot = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng Iot",
                Code = "lpb_iot_hangvienthong_phongiot"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_hangvienthong, lpb_iot_hangvienthong_phongpiot);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_hangvienthong);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phongdichvukios);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phongvanhanhkios);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_quantrikios);
            //Máy tự phục vụ ------------------


            var lgp_iot_maytuphucvu_dichvukios = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Dịch vụ kios",
                Code = "lgp_iot_maytucphucvu_dichvukios",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_dichvukios, lpb_iot_maytuphucvu_phongdichvukios);

            var lgp_iot_maytuphucvu_quanlyphongdichvukios = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý phòng dịch vụ Kios",
                Code = "lgp_iot_maytucphucvu_quanlyphongdichvukios",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_quanlyphongdichvukios, lpb_iot_maytuphucvu_phongdichvukios);


            var lgp_iot_maytuphucvu_vanhanhkios = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Vận hành kios",
                Code = "lgp_iot_maytucphucvu_vanhanhkios",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_vanhanhkios, lpb_iot_maytuphucvu_phongvanhanhkios);

            var lgp_iot_maytuphucvu_quantrikios = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản trị kios",
                Code = "lgp_iot_maytucphucvu_quantrikios",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_quantrikios, lpb_iot_maytuphucvu_quantrikios);

            //Hãng viễn thông ----------------------
            var lgp_iot_hangvienthong_esim = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "ESim",
                Code = "lgp_iot_hangvienthong_esim",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_hangvienthong_esim, lpb_iot_hangvienthong_phongpesim);

            var lgp_iot_hangvienthong_iot = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "IoT platform",
                Code = "lgp_iot_hangvienthong_iot",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_hangvienthong_iot, lpb_iot_hangvienthong_phongpiot);

            #endregion

            #region  --- Loại công việc

            //Ma san
            var lcv_iot_phancaphucvu = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Phân ca phục vụ",
                Code = "lcv_iot_phancaphucvu",
                GioiThieu = "Phân ca phục vụ khách hàng qua máy Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quanlyphongdichvukios, lcv_iot_phancaphucvu);
            var lcv_iot_quanlygiaodichvienvakhachhang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý giao dịch viên & khách hàng",
                Code = "lcv_iot_quanlygiaodichvienvakhachhang",
                GioiThieu = "Quản lý giao dịch viên và khách hàng giao dịch qua Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quanlyphongdichvukios, lcv_iot_quanlygiaodichvienvakhachhang);

            var lcv_iot_giaodichquakios = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Giao dịch qua Kios",
                Code = "lcv_iot_giaodichquakios",
                GioiThieu = "Giao dịch thông qua Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_dichvukios, lcv_iot_giaodichquakios);

            var lcv_iot_quanlyhethongkios = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý hệ thống Kios",
                Code = "lcv_iot_quanlyhethongkios",
                GioiThieu = "Quản lý hệ thống Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quantrikios, lcv_iot_quanlyhethongkios);

            var lcv_iot_thietkegiaodienkios = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Thiết kế giao diện Kios",
                Code = "lcv_iot_thietkegiaodienkios",
                GioiThieu = "Thiết kế giao diện Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quantrikios, lcv_iot_thietkegiaodienkios);

            var lcv_iot_baocaovaphantich = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Báo cáo và phân tích",
                Code = "lcv_iot_baocaovaphantich",
                GioiThieu = "Báo cáo và phân tích"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quantrikios, lcv_iot_baocaovaphantich);

            var lcv_iot_phienbannangcap = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý phiên bản và nâng cấp Kios",
                Code = "lcv_iot_quanlyphienbanvanangcap",
                GioiThieu = "Quản lý phiên bản và nâng cấp"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quantrikios, lcv_iot_phienbannangcap);

            var lcv_iot_giamsatvacanhbao = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Giám sát và cảnh báo",
                Code = "lcv_iot_giamsatvacanhbao",
                GioiThieu = "Giám sát và cảnh báo các vấn đề trên hệ thống Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_vanhanhkios, lcv_iot_giamsatvacanhbao);


            var lcv_iot_cauhinh = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Cấu hình Kios",
                Code = "lcv_iot_cauhinhkios",
                GioiThieu = "Cấu hình Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_vanhanhkios, lcv_iot_cauhinh);

            var lcv_iot_logkios = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý log",
                Code = "lcv_iot_logkios",
                GioiThieu = "Log Kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_vanhanhkios, lcv_iot_logkios);

            var lcv_iot_transaction = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý Transaction",
                Code = "lcv_iot_transaction",
                GioiThieu = "Quản lý Transaction"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_vanhanhkios, lcv_iot_transaction);

            var lcv_iot_baoduongbaotri = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Bảo dưỡng bảo trì Kios",
                Code = "lcv_iot_baoduongbaotri",
                GioiThieu = "Quản lý Bảo dưỡng bảo trì"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_vanhanhkios, lcv_iot_baoduongbaotri);

            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban

            //Ma san
            

            





            //hãng viễn thông---------------------------

            var pb_hangvienthong_phongesim = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_hangvienthong_phongpesim.Name,
                CodeLoaiPhongBan = lpb_iot_hangvienthong_phongpesim.Code,
                Name = "Phòng ESim"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_htc, pb_hangvienthong_phongesim);

            var pb_hangvienthong_phongiot = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_hangvienthong_phongpiot.Name,
                CodeLoaiPhongBan = lpb_iot_hangvienthong_phongpiot.Code,
                Name = "Phòng IoT"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_viettel, pb_hangvienthong_phongiot);

            #endregion

            #region --- Giải pháp



            #endregion

            #region --- Nhân viên

            var nv_htc_minh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý",
                GioiThieu = "Quản lý",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_htc, nv_htc_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_htc_minh);

            var nv_viettel_minh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý",
                GioiThieu = "Quản lý",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_viettel, nv_viettel_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_viettel_minh);

            #endregion

            #endregion

            #region Nhà bán lẻ

            #region --- Loại tổ chức

            var ltc_iot_nhabanle = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà bán lẻ",
                Code = "ltc_iot_nhabanle"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_nhabanle);

            #endregion

            #region --- Tổ chức

            var tc_iot_masan = await AC.ToChuc.Create(new ToChuc
            {
                Name = "MaSan",
                CodeLoaiToChuc = ltc_iot_nhabanle.Code,
                LoaiToChuc = ltc_iot_nhabanle.Name,
                VietTat = "masan",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_masan);

            #endregion

            #region --- Loại phòng ban

            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhabanle, lpb_iot_maytuphucvu_phongdichvukios);
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhabanle, lpb_iot_maytuphucvu_phongvanhanhkios);
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhabanle, lpb_iot_maytuphucvu_quantrikios);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_nhabanle);

            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban

            var pb_iot_masan_phongdichvu = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phongdichvukios.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phongdichvukios.Code,
                Name = "Phòng dịch vụ Kios"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_masan, pb_iot_masan_phongdichvu);

            var pb_iot_masan_phongvanhanhkios = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phongvanhanhkios.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phongvanhanhkios.Code,
                Name = "Phòng vận hành Kios"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_masan, pb_iot_masan_phongvanhanhkios);

            var pb_iot_masan_phongquantrikios = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_quantrikios.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_quantrikios.Code,
                Name = "Phòng quản trị Kios"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_masan, pb_iot_masan_phongquantrikios);


            #endregion

            #region --- Giải pháp

            var gp_masan_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_masan_quanlytochuc, tc_iot_masan);

            #endregion

            #region --- Nhân viên

            var nv_masan_minh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý",
                GioiThieu = "Quản lý",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_masan, nv_masan_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_masan_minh);


            #endregion

            #region --- Công việc

            //Masan
            var cv_masan_quanlymasan = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_masan.Id,
                IdHeThong = ht_iot.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_masan_quanlytochuc, cv_masan_quanlymasan);
            await AC.NhanVien.ThemCongViec(nv_masan_minh, cv_masan_quanlymasan);

            #endregion

            #endregion

            #region Ngân hàng

            #region --- Loại tổ chức



            var ltc_iot_nganhang = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Ngân hàng",
                Code = "ltc_iot_nganhang"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_nganhang);





            #endregion

            #region --- Tổ chức









            var tc_iot_vpbank = await AC.ToChuc.Create(new ToChuc
            {
                Name = "VPBank",
                CodeLoaiToChuc = ltc_iot_nganhang.Code,
                LoaiToChuc = ltc_iot_nganhang.Name,
                VietTat = "vpbank",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_vpbank);



            #endregion

            #region --- Loại phòng ban

            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nganhang, lpb_iot_maytuphucvu_phongdichvukios);
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nganhang, lpb_iot_maytuphucvu_phongvanhanhkios);
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nganhang, lpb_iot_maytuphucvu_quantrikios);

            #endregion

            #region --- Loại giải pháp




            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_nganhang);








            #endregion

            #region --- Loại công việc

            #endregion

            #region --- Phòng ban

            #endregion

            #region --- Giải pháp



            //Masan ---



            #endregion

            #region --- Nhân viên

            //---------------------



            var nv_vpbank_minh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý",
                GioiThieu = "Quản lý",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_vpbank, nv_vpbank_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_vpbank_minh);





            #endregion



            #endregion

            #region Máy tự phục vụ

            #region --- Loại tổ chức



            var ltc_iot_nhasanxuatmaytuphucvu = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà sản xuất máy tự phục vụ",
                Code = "ltc_iot_nhasanxuatmaytuphucvu"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_iot, ltc_iot_nhasanxuatmaytuphucvu);

            #endregion

            #region --- Tổ chức

            var tc_iot_miraway = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Miraway",
                CodeLoaiToChuc = ltc_iot_nhasanxuatmaytuphucvu.Code,
                LoaiToChuc = ltc_iot_nhasanxuatmaytuphucvu.Name,
                VietTat = "miraway",
                IdHeThong = ht_iot.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_iot_miraway);


            #endregion

            #region --- Loại phòng ban
            //Máy tự phục vụ---------------
            var lpb_iot_maytuphucvu_phonggiaiphap = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng giải pháp",
                Code = "lpb_iot_maytuphucvu_phonggiaiphap"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhasanxuatmaytuphucvu, lpb_iot_maytuphucvu_phonggiaiphap);

            var lpb_iot_maytuphucvu_phongkythuat = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng kỹ thuật",
                Code = "lpb_iot_maytuphucvu_phongkythuat"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhasanxuatmaytuphucvu, lpb_iot_maytuphucvu_phongkythuat);

            var lpb_iot_maytuphucvu_phongkinhdoanh = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng kinh doanh",
                Code = "lpb_iot_maytuphucvu_phongkinhdoanh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhasanxuatmaytuphucvu, lpb_iot_maytuphucvu_phongkinhdoanh);

            var lpb_iot_maytuphucvu_phongvanhanh = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng vận hành",
                Code = "lpb_iot_maytuphucvu_phongvanhanh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_iot_nhasanxuatmaytuphucvu, lpb_iot_maytuphucvu_phongvanhanh);
            #endregion

            #region  --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_iot_nhasanxuatmaytuphucvu);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phonggiaiphap);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phongkinhdoanh);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phongkythuat);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_iot_maytuphucvu_phongvanhanh);

            var lgp_iot_maytuphucvu_nghiepvu = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý nghiệp vụ",
                Code = "lgp_iot_maytucphucvu_quanlynghiepvu",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_nghiepvu, lpb_iot_maytuphucvu_phonggiaiphap);

            var lgp_iot_maytuphucvu_thietbicuamay = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý thiết bị của máy",
                Code = "lgp_iot_maytucphucvu_quanlythietbi",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_thietbicuamay, lpb_iot_maytuphucvu_phongkythuat);

            var lgp_iot_maytuphucvu_dongmay = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý các dòng máy",
                Code = "lgp_iot_maytucphucvu_dongmay",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_dongmay, lpb_iot_maytuphucvu_phongkythuat);

            var lgp_iot_maytuphucvu_mayvathietbi = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý máy và thiết bị sản xuất",
                Code = "lgp_iot_maytucphucvu_mayvathietbi",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_mayvathietbi, lpb_iot_maytuphucvu_phongkythuat);

            var lgp_iot_maytuphucvu_khachhang = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý khách hàng",
                Code = "lgp_iot_maytucphucvu_khachhang",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_khachhang, lpb_iot_maytuphucvu_phongkinhdoanh);

            var lgp_iot_maytuphucvu_quanlykios = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý kios",
                Code = "lgp_iot_maytucphucvu_kios",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_iot_maytuphucvu_quanlykios, lpb_iot_maytuphucvu_phongvanhanh);

            #endregion

            #region --- Loại công việc

            //Miraway
            var lcv_iot_miraway_xaydungnghiepvu = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng nghiệp vụ",
                Code = "lcv_iot_miraway_xaydungnghiepvu",
                GioiThieu = "Xây dựng quy trình, nghiệp vụ chạy trên máy kios"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_nghiepvu, lcv_iot_miraway_xaydungnghiepvu);

            var lcv_iot_miraway_xaydungtransaction = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng transaction",
                Code = "lcv_iot_miraway_xaydungtransaction",
                GioiThieu = "Xây dựng server transacction"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_nghiepvu, lcv_iot_miraway_xaydungtransaction);

            var lcv_iot_miraway_quanlycackios = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các Kios",
                Code = "lcv_iot_miraway_quanlycackios",
                GioiThieu = "Quản lý các kios của công ty đang kinh doanh"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quanlykios, lcv_iot_miraway_quanlycackios);

            var lcv_iot_miraway_quanlycactransactionserver = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các Transaction Server",
                Code = "lcv_iot_miraway_quanlycactransactionserver",
                GioiThieu = "Quản lý các Transaction Server của công ty"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_quanlykios, lcv_iot_miraway_quanlycactransactionserver);

            var lcv_iot_miraway_quanlycaclooaithietbi = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các loại thiết bị",
                Code = "lcv_iot_miraway_quanlycacloaithietbi",
                GioiThieu = "Quản lý các loại thiêt bị"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_thietbicuamay, lcv_iot_miraway_quanlycaclooaithietbi);

            var lcv_iot_miraway_quanlycacdongmay = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các dòng máy",
                Code = "lcv_iot_miraway_quanlycacdongmay",
                GioiThieu = "Quản lý các dòng máy"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_dongmay, lcv_iot_miraway_quanlycacdongmay);

            var lcv_iot_miraway_quanlycackiosdasanxuat = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý các kios sản xuất",
                Code = "lcv_iot_miraway_quanlycackiossanxuat",
                GioiThieu = "Quản lý các kios đã sản xuất"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_mayvathietbi, lcv_iot_miraway_quanlycackiosdasanxuat);

            var lcv_iot_miraway_quanlykhothietbi = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý kho thiết bị",
                Code = "lcv_iot_miraway_quanlykhothietbi",
                GioiThieu = "Quản lý kho thiết bị"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_mayvathietbi, lcv_iot_miraway_quanlykhothietbi);

            var lcv_iot_miraway_quanlykhachhang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý khách hàng",
                Code = "lcv_iot_miraway_khachhang",
                GioiThieu = "Quản lý khách hàng"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_iot_maytuphucvu_khachhang, lcv_iot_miraway_quanlykhachhang);

            #endregion

            #region --- Phòng ban

            //Miraway -------------------

            var pb_iot_maytuphucvu_phonggiaiphap = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phonggiaiphap.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phonggiaiphap.Code,
                Name = "Phòng giải pháp"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_miraway, pb_iot_maytuphucvu_phonggiaiphap);

            var pb_iot_maytuphucvu_phongkythuat = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phongkythuat.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phongkythuat.Code,
                Name = "Phòng kỹ thuật"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_miraway, pb_iot_maytuphucvu_phongkythuat);

            var pb_iot_maytuphucvu_phongvanhanh = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phongvanhanh.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phongvanhanh.Code,
                Name = "Phòng vận hành"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_miraway, pb_iot_maytuphucvu_phongvanhanh);

            var pb_iot_maytuphucvu_phongkinhdoanh = await AC.PhongBan.Create(new PhongBan
            {
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_iot_maytuphucvu_phongkinhdoanh.Name,
                CodeLoaiPhongBan = lpb_iot_maytuphucvu_phongkinhdoanh.Code,
                Name = "Phòng kinh doanh"

            });
            await AC.ToChuc.Them_PhongBan(tc_iot_miraway, pb_iot_maytuphucvu_phongkinhdoanh);

            #endregion

            #region --- Giải pháp

            var gp_miraway_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_miraway_quanlytochuc, tc_iot_miraway);

            var gp_miraway_quanlyphongban_phonggiaiphap = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlyphongban_phonggiaiphap, pb_iot_maytuphucvu_phonggiaiphap);

            var gp_miraway_quanlyphongban_phongkythuat = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlyphongban_phongkythuat, pb_iot_maytuphucvu_phongkythuat);

            var gp_miraway_quanlyloaithietbi_phongkythuat = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_maytuphucvu_thietbicuamay.Name,
                CodeLoaiGiaiPhap = lgp_iot_maytuphucvu_thietbicuamay.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlyloaithietbi_phongkythuat, pb_iot_maytuphucvu_phongkythuat);

            var gp_miraway_quanlydongmay_phongkythuat = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_maytuphucvu_dongmay.Name,
                CodeLoaiGiaiPhap = lgp_iot_maytuphucvu_dongmay.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlydongmay_phongkythuat, pb_iot_maytuphucvu_phongkythuat);


            var gp_miraway_quanlynghiepvu = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_maytuphucvu_nghiepvu.Name,
                CodeLoaiGiaiPhap = lgp_iot_maytuphucvu_nghiepvu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlynghiepvu, pb_iot_maytuphucvu_phonggiaiphap);

            var gp_miraway_quanlykios = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_maytuphucvu_quanlykios.Name,
                CodeLoaiGiaiPhap = lgp_iot_maytuphucvu_quanlykios.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlykios, pb_iot_maytuphucvu_phongvanhanh);

            var gp_miraway_quanlykhachhang = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_iot_maytuphucvu_khachhang.Name,
                CodeLoaiGiaiPhap = lgp_iot_maytuphucvu_khachhang.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_miraway_quanlykhachhang, pb_iot_maytuphucvu_phongkinhdoanh);

            #endregion

            #region --- Nhân viên

            //Máy tự phục vụ -------------
            //Miraway
            var nv_miraway_minh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Công trình sư",
                GioiThieu = "Thiết kế & xây dựng hệ thống",
                IdHeThong = ht_iot.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_iot_miraway, nv_miraway_minh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_miraway_minh);

            var nv_miraway_minh_phonggiaiphap = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý giải pháp",
                GioiThieu = "Thiết kế & xây dựng hệ thống",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_iot_maytuphucvu_phonggiaiphap, nv_miraway_minh_phonggiaiphap);
            await AC.ToChuc.Them_NhanVien(tc_iot_miraway, nv_miraway_minh_phonggiaiphap);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_miraway_minh_phonggiaiphap);

            var nv_miraway_minh_phongkythuat = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý kỹ thuật",
                GioiThieu = "Thiết kế & xây dựng hệ thống",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_iot_maytuphucvu_phongkythuat, nv_miraway_minh_phongkythuat);
            await AC.ToChuc.Them_NhanVien(tc_iot_miraway, nv_miraway_minh_phongkythuat);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_miraway_minh_phongkythuat);

            var nv_miraway_minh_phongvanhanh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý vận hành",
                GioiThieu = "Thiết kế & xây dựng hệ thống",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_iot_maytuphucvu_phongvanhanh, nv_miraway_minh_phongvanhanh);
            await AC.ToChuc.Them_NhanVien(tc_iot_miraway, nv_miraway_minh_phongvanhanh);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_miraway_minh_phongvanhanh);

            var nv_miraway_minh_phongkinhdoanh = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,

                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý kinh doanh",
                GioiThieu = "Thiết kế & xây dựng hệ thống",
                IdHeThong = ht_iot.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_iot_maytuphucvu_phongkinhdoanh, nv_miraway_minh_phongkinhdoanh);
            await AC.ToChuc.Them_NhanVien(tc_iot_miraway, nv_miraway_minh_phongkinhdoanh);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_miraway_minh_phongkinhdoanh);

            #endregion

            #region --- Công việc

            //Máy tự phục vụ --------------------------
            //Miraway
            var cv_miraway_quanlymiraway = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlytochuc, cv_miraway_quanlymiraway);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh, cv_miraway_quanlymiraway);

            var cv_miraway_quanlyphonggiaiphap = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phonggiaiphap.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlyphongban_phonggiaiphap, cv_miraway_quanlyphonggiaiphap);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phonggiaiphap, cv_miraway_quanlyphonggiaiphap);

            var cv_miraway_xaydungnghiepvu = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_iot_miraway_xaydungnghiepvu.Name,
                CodeLoaiCongViec = lcv_iot_miraway_xaydungnghiepvu.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phonggiaiphap.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlyphongban_phonggiaiphap, cv_miraway_xaydungnghiepvu);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phonggiaiphap, cv_miraway_xaydungnghiepvu);

            var cv_miraway_quanlyphongkythuat = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phongkythuat.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlyphongban_phongkythuat, cv_miraway_quanlyphongkythuat);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phongkythuat, cv_miraway_quanlyphongkythuat);

            var cv_miraway_quanlyloaithietbi = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_iot_miraway_quanlycaclooaithietbi.Name,
                CodeLoaiCongViec = lcv_iot_miraway_quanlycaclooaithietbi.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phongkythuat.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlyloaithietbi_phongkythuat, cv_miraway_quanlyloaithietbi);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phongkythuat, cv_miraway_quanlyloaithietbi);

            var cv_miraway_quanlydongmay = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_iot_miraway_quanlycacdongmay.Name,
                CodeLoaiCongViec = lcv_iot_miraway_quanlycacdongmay.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phongkythuat.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlydongmay_phongkythuat, cv_miraway_quanlydongmay);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phongkythuat, cv_miraway_quanlydongmay);

            var cv_miraway_quanlykios = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_iot_miraway_quanlycackios.Name,
                CodeLoaiCongViec = lcv_iot_miraway_quanlycackios.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phongvanhanh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlykios, cv_miraway_quanlykios);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phongvanhanh, cv_miraway_quanlykios);

            var cv_miraway_quanlykhachhang = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_iot_miraway_quanlykhachhang.Name,
                CodeLoaiCongViec = lcv_iot_miraway_quanlykhachhang.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_iot_miraway.Id,
                IdHeThong = ht_iot.Id,
                IdPhongBan = pb_iot_maytuphucvu_phongkinhdoanh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_miraway_quanlykhachhang, cv_miraway_quanlykhachhang);
            await AC.NhanVien.ThemCongViec(nv_miraway_minh_phongkinhdoanh, cv_miraway_quanlykhachhang);

            #endregion

            #region --- Dòng máy
            var dm_iot_maytuphucvu_vienthong = await AC.DongMayTuPhucVu.Create(new DongMayTuPhucVu
            {
                Name = "Telco Self Service Kios",
                Code = "dm_tssk",
                GioiThieu = "Kios dành cho nhà mạng"
            });

            var dm_iot_maytuphucvu_nganhang = await AC.DongMayTuPhucVu.Create(new DongMayTuPhucVu
            {
                Name = "Banking Self Service Kios",
                Code = "dm_bssk",
                GioiThieu = "Kios dành cho ngân hàng"
            });

            var dm_iot_maytuphucvu_banle = await AC.DongMayTuPhucVu.Create(new DongMayTuPhucVu
            {
                Name = "Retail Self Service Kios",
                Code = "dm_rssk",
                GioiThieu = "Kios dành cho bán lẻ"
            });

            var dm_iot_maytuphucvu_kethop = await AC.DongMayTuPhucVu.Create(new DongMayTuPhucVu
            {
                Name = "Combine Self Service Kios",
                Code = "dm_cssk",
                GioiThieu = "Kios kết hợp"
            });

            #endregion

            #region --- Loại máy

            var lm_iot_maytuphucvu_vienthong_V01 = await AC.LoaiMayTuPhucVu.Create(new LoaiMayTuPhucVu
            {
                Name = "Telco Self Service Kios Version V01",
                Code = "lm_tssk_v01",
                DongMayTuPhucVu = dm_iot_maytuphucvu_vienthong.Name,
                CodeDongMayTuPhucVu = dm_iot_maytuphucvu_vienthong.Code,
                GioiThieu = "Telco Self Service Kios Version V01"
            });

            var lm_iot_maytuphucvu_nganhang_V01 = await AC.LoaiMayTuPhucVu.Create(new LoaiMayTuPhucVu
            {
                Name = "Banking Self Service Kios Version V01",
                Code = "lm_bssk_v01",
                DongMayTuPhucVu = dm_iot_maytuphucvu_nganhang.Name,
                CodeDongMayTuPhucVu = dm_iot_maytuphucvu_nganhang.Code,
                GioiThieu = "Banking Self Service Kios Version V01"
            });

            var lm_iot_maytuphucvu_banle_V01 = await AC.LoaiMayTuPhucVu.Create(new LoaiMayTuPhucVu
            {
                Name = "Retail Self Service Kios Version V01",
                Code = "lm_rssk_v01",
                DongMayTuPhucVu = dm_iot_maytuphucvu_banle.Name,
                CodeDongMayTuPhucVu = dm_iot_maytuphucvu_banle.Code,
                GioiThieu = "Retail Self Service Kios Version V01"
            });

            var lm_iot_maytuphucvu_kethop_V01 = await AC.LoaiMayTuPhucVu.Create(new LoaiMayTuPhucVu
            {
                Name = "Combine Self Service Kios Version V01",
                Code = "lm_rssk_v01",
                DongMayTuPhucVu = dm_iot_maytuphucvu_kethop.Name,
                CodeDongMayTuPhucVu = dm_iot_maytuphucvu_kethop.Code,
                GioiThieu = "Combine Self Service Kios Version V01"
            });

            #endregion

            #region --- Loại tính năng

            var ltn_iot_maytuphucvu_mothenganhang = await AC.LoaiTinhNangMayTuPhucVu.Create(new LoaiTinhNangMayTuPhucVu { 
                Name = "Mở thẻ ngân hàng",
                Code = "ltn_iot_mothenganhang",                
            });
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_nganhang_V01, ltn_iot_maytuphucvu_mothenganhang);
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_kethop_V01, ltn_iot_maytuphucvu_mothenganhang);

            var ltn_iot_maytuphucvu_motaikhoannganhang = await AC.LoaiTinhNangMayTuPhucVu.Create(new LoaiTinhNangMayTuPhucVu
            {
                Name = "Mở tài khoản ngân hàng",
                Code = "ltn_iot_motaikhoannganhang",
            });
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_nganhang_V01, ltn_iot_maytuphucvu_motaikhoannganhang);
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_kethop_V01, ltn_iot_maytuphucvu_motaikhoannganhang);

            var ltn_iot_maytuphucvu_muasim = await AC.LoaiTinhNangMayTuPhucVu.Create(new LoaiTinhNangMayTuPhucVu
            {
                Name = "Mua sim",
                Code = "ltn_iot_muasim",
            });
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_vienthong_V01, ltn_iot_maytuphucvu_muasim);
            await AC.LoaiMayTuPhucVu.ThemLoaiTinhNang(lm_iot_maytuphucvu_kethop_V01, ltn_iot_maytuphucvu_muasim);

            #endregion

            #region --- Loại thiết bị

            var ltb_iot_maytuphucvu_mayin = await AC.LoaiThietBiMayTuPhucVu.Create(new LoaiThietBiMayTuPhucVu
            {
                Name = "Máy in",
                Code = "ltb_iot_mayin",
            });
            await AC.LoaiMayTuPhucVu.ThemLoaiThietBi(lm_iot_maytuphucvu_vienthong_V01, ltb_iot_maytuphucvu_mayin);
            await AC.LoaiMayTuPhucVu.ThemLoaiThietBi(lm_iot_maytuphucvu_kethop_V01, ltb_iot_maytuphucvu_mayin);
            await AC.LoaiMayTuPhucVu.ThemLoaiThietBi(lm_iot_maytuphucvu_nganhang_V01, ltb_iot_maytuphucvu_mayin);
            await AC.LoaiMayTuPhucVu.ThemLoaiThietBi(lm_iot_maytuphucvu_banle_V01, ltb_iot_maytuphucvu_mayin);



            #endregion

            #region --- Khách hàng

            await AC.ToChuc.Them_QuanHeToChuc(tc_iot_miraway, tc_iot_masan, "DsKhachHangMayTuPhucVu");
            await AC.ToChuc.Them_QuanHeToChuc(tc_iot_miraway, tc_iot_viettel, "DsKhachHangMayTuPhucVu");
            await AC.ToChuc.Them_QuanHeToChuc(tc_iot_miraway, tc_iot_vpbank, "DsKhachHangMayTuPhucVu");

            #endregion

            #region --- Máy

            var may_iot_maytuphucvu_vienthong_v01_001 = await AC.MayTuPhucVu.Create(new MayTuPhucVu { 
                Name = "TSSK_V01_001",
                LoaiMayTuPhucVu = lm_iot_maytuphucvu_vienthong_V01.Name,
                CodeLoaiMayTuPhucVu = lm_iot_maytuphucvu_vienthong_V01.Code,
                  
            });
            await AC.MayTuPhucVu.SetCongTySanSuat(may_iot_maytuphucvu_vienthong_v01_001, tc_iot_miraway);
            await AC.MayTuPhucVu.SetCongTyKhachHang(may_iot_maytuphucvu_vienthong_v01_001, tc_iot_viettel);

            var may_iot_maytuphucvu_nganhang_v01_001 = await AC.MayTuPhucVu.Create(new MayTuPhucVu
            {
                Name = "BSSK_V01_001",
                LoaiMayTuPhucVu = lm_iot_maytuphucvu_nganhang_V01.Name,
                CodeLoaiMayTuPhucVu = lm_iot_maytuphucvu_nganhang_V01.Code,

            });
            await AC.MayTuPhucVu.SetCongTySanSuat(may_iot_maytuphucvu_nganhang_v01_001, tc_iot_miraway);
            await AC.MayTuPhucVu.SetCongTyKhachHang(may_iot_maytuphucvu_nganhang_v01_001, tc_iot_vpbank);

            var may_iot_maytuphucvu_kethop_v01_001 = await AC.MayTuPhucVu.Create(new MayTuPhucVu
            {
                Name = "CSSK_V01_001",
                LoaiMayTuPhucVu = lm_iot_maytuphucvu_kethop_V01.Name,
                CodeLoaiMayTuPhucVu = lm_iot_maytuphucvu_kethop_V01.Code,

            });
            await AC.MayTuPhucVu.SetCongTySanSuat(may_iot_maytuphucvu_kethop_v01_001, tc_iot_miraway);
            await AC.MayTuPhucVu.SetCongTyKhachHang(may_iot_maytuphucvu_kethop_v01_001,tc_iot_masan);

            #endregion

            #region --- Tính năng

            var tn_iot_maytuphucvu_muasimviettel = await AC.TinhNangMayTuPhucVu.Create(new TinhNangMayTuPhucVu
            {
                Name = "Mua sim Viettel",
                LoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_muasim.Name,
                CodeLoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_muasim.Code
            });
            await AC.MayTuPhucVu.ThemTinhNang(may_iot_maytuphucvu_vienthong_v01_001, tn_iot_maytuphucvu_muasimviettel);
            await AC.MayTuPhucVu.ThemTinhNang(may_iot_maytuphucvu_kethop_v01_001, tn_iot_maytuphucvu_muasimviettel);

            var tn_iot_maytuphucvu_mothenganhangvpbank = await AC.TinhNangMayTuPhucVu.Create(new TinhNangMayTuPhucVu
            {
                Name = "Mở thẻ VPBank",
                LoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_mothenganhang.Name,
                CodeLoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_mothenganhang.Code
            });
            await AC.MayTuPhucVu.ThemTinhNang(may_iot_maytuphucvu_nganhang_v01_001, tn_iot_maytuphucvu_mothenganhangvpbank);

            var tn_iot_maytuphucvu_mothenganhangtechcombank = await AC.TinhNangMayTuPhucVu.Create(new TinhNangMayTuPhucVu
            {
                Name = "Mở thẻ Techcombank",
                LoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_mothenganhang.Name,
                CodeLoaiTinhNangMayTuPhucVu = ltn_iot_maytuphucvu_mothenganhang.Code
            });
            await AC.MayTuPhucVu.ThemTinhNang(may_iot_maytuphucvu_kethop_v01_001, tn_iot_maytuphucvu_mothenganhangtechcombank);

            #endregion

            #region --- Thiết bị

            var tb_iot_maytuphucvu_mayinsamsung = await AC.ThietBiMayTuPhucVu.Create(new ThietBiMayTuPhucVu
            {
                Name = "Máy in SamSung ML2100",
                LoaiThietBiMayTuPhucVu = ltb_iot_maytuphucvu_mayin.Name, 
                CodeLoaiThietBiMayTuPhucVu = ltb_iot_maytuphucvu_mayin.Code
            });
            await AC.MayTuPhucVu.ThemThietBi(may_iot_maytuphucvu_vienthong_v01_001, tb_iot_maytuphucvu_mayinsamsung);
            await AC.MayTuPhucVu.ThemThietBi(may_iot_maytuphucvu_nganhang_v01_001, tb_iot_maytuphucvu_mayinsamsung);
            await AC.MayTuPhucVu.ThemThietBi(may_iot_maytuphucvu_kethop_v01_001, tb_iot_maytuphucvu_mayinsamsung);

            #endregion

            #region --- Nhóm Module Quy Trình
            var nmq_iot_maytuphucvu_coso = await AC.NhomModuleQuyTrinh.Create(new NhomModuleQuyTrinh
            {
                 Name = "Cơ sở",
                 Stt = 1,
            });
            var nmq_iot_maytuphucvu_giaodien = await AC.NhomModuleQuyTrinh.Create(new NhomModuleQuyTrinh
            {
                Name = "Giao diện",
                Stt = 2,
            });
            var nmq_iot_maytuphucvu_thanhtoan = await AC.NhomModuleQuyTrinh.Create(new NhomModuleQuyTrinh
            {
                Name = "Thanh toán",
                Stt = 3,
            });

            var nmq_iot_maytuphucvu_api = await AC.NhomModuleQuyTrinh.Create(new NhomModuleQuyTrinh
            {
                Name = "API",
                Stt = 4,
            });

            #endregion

            #region --- Module Quy Trình

            var mq_iot_maytuphucvu_start_kios = await AC.ModuleQuyTrinh.Create(new ModuleQuyTrinh
            {
                Name = "Khởi động dịch vụ Kios",
                Code = "start_kios",
                Stt = 1,
            });
            await AC.NhomModuleQuyTrinh.ThemModuleQuyTrinh(nmq_iot_maytuphucvu_coso, mq_iot_maytuphucvu_start_kios);

            var mq_iot_maytuphucvu_lenh_ifthen = await AC.ModuleQuyTrinh.Create(new ModuleQuyTrinh
            {
                Name = "If then",
                Code = "command_ifthen",
                Stt = 2,
            });
            await AC.NhomModuleQuyTrinh.ThemModuleQuyTrinh(nmq_iot_maytuphucvu_coso, mq_iot_maytuphucvu_lenh_ifthen);


            var mq_iot_maytuphucvu_giaodien_html = await AC.ModuleQuyTrinh.Create(new ModuleQuyTrinh
            {
                Name = "Show Html Page",
                Code = "giaodien_showhtmlpage",
                Stt = 1,
            });
            await AC.NhomModuleQuyTrinh.ThemModuleQuyTrinh(nmq_iot_maytuphucvu_giaodien, mq_iot_maytuphucvu_giaodien_html);
            #endregion


            #endregion

            #endregion

            #region Y tế

            #region --- Loại đối tượng

            var ldt_benhnhan = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong { 
               Name = "Bệnh nhân",
               Code = "ldt_yte_benhnhan",
               CodeHeThong = CodeHeThong.YTeMoi
            });

            #endregion

            #region --- Loại phải pháp 

            var lgp_yte_quanlybenhnhan = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý bệnh nhân",
                Code = "lgp_yte_quanlybenhnhan",
            });

            #endregion

            #region --- Loại công việc 

            var lcv_yte_quanlyhosobenhnhan = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý hồ sơ bệnh nhân",
                Code = "lcv_yte_quanlyhosobenhnhan"
            });

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_quanlybenhnhan, lcv_yte_quanlyhosobenhnhan);

            #endregion

            #region --- Loại tiện ích

            var lti_yte_nguoidung_chuabenh = await AC.LoaiTienIch.Create(new LoaiTienIch
            {
                Name = "Bệnh nhân",
                Code = "lti_yte_nguoidung_benhnhanchuabenh",
                CodeHeThong = CodeHeThong.YTeMoi
            });

            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_benhnhan, lti_yte_nguoidung_chuabenh);

            var lti_yte_nguoidung_nguoinhabenhnhan = await AC.LoaiTienIch.Create(new LoaiTienIch
            {
                Name = "Người nhà bệnh nhân",
                Code = "lti_yte_nguoidung_nguoinhabenhnhan",
                CodeHeThong = CodeHeThong.YTeMoi
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_benhnhan, lti_yte_nguoidung_nguoinhabenhnhan);

            #endregion

            #region --- Loại tín hiệu

            var lth_yte_nursecall = await AC.LoaiTinHieu.Create(new LoaiTinHieu
            {
                Name = "Nurse Call",
                Code = "lth_yte_nursecall"
            });

            await AC.LoaiTinHieu.ThemTienIch(lth_yte_nursecall, lti_yte_nguoidung_chuabenh);
            await AC.LoaiTinHieu.ThemTienIch(lth_yte_nursecall, lti_yte_nguoidung_nguoinhabenhnhan);


            #endregion

            #region --- Loại Ca

            //var lc_yte_nursecall = await AC.LoaiCa.Create(new LoaiCa
            //{
            //    Code = "lc_iot_yte_nursecall",
            //    Name = "NurseCall"
            //});
            //await AC.LoaiCa.ThemLoaiHangHoa(lc_yte_nursecall, lhh_iot_chothuevongyte);

            #endregion

            #region Cơ sở y tế

            #region --- Loại Tổ chức

            var ltc_yte_cosoyte = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Cơ sở y tế",
                Code = "ltc_yte_cosoyte"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_yte, ltc_yte_cosoyte);

            #endregion

            #region --- Loại phòng ban

            //Cơ sở y tế ------------------
            var lpb_yte_cosoyte_khoalamsang = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Khoa lâm sàng",
                Code = "lpb_yte_cosoyte_khoalamsang"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_cosoyte, lpb_yte_cosoyte_khoalamsang);

            var lpb_yte_cosoyte_khoacanlamsang = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Khoa cận lâm sàng",
                Code = "lpb_yte_cosoyte_khoacanlamsang"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_cosoyte, lpb_yte_cosoyte_khoacanlamsang);

            var lpb_yte_cosoyte_phongbanchucnang = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng ban chức năng",
                Code = "lpb_yte_cosoyte_phongbanchucnang"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_cosoyte, lpb_yte_cosoyte_phongbanchucnang);



            #endregion

            #region --- Loại phải pháp 

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_quanlybenhnhan, lpb_yte_cosoyte_khoalamsang);

            var lgp_yte_cosoyte_quanlykhoalamsang = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý khoa lâm sàng",
                Code = "lgp_yte_cosoyte_quanlykhoalamsang",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_cosoyte_quanlykhoalamsang, lpb_yte_cosoyte_khoalamsang);

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_yte_cosoyte);

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_yte_cosoyte_khoalamsang);


            //Cơ sở y tế-------------------
            var lgp_yte_cosoyte_dieutri = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Điều trị",
                Code = "lgp_yte_cosoyte_dieutri",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_cosoyte_dieutri, lpb_yte_cosoyte_khoalamsang);

            var lgp_yte_cosoyte_kham = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Khám",
                Code = "lgp_yte_cosoyte_kham",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_cosoyte_kham, lpb_yte_cosoyte_khoalamsang);


            #endregion

            #region --- Loại công việc
                       

            //Cơ sở y tế-----------------------
            var lcv_yte_cosoyte_trucdieuduong = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Trực điều dưỡng",
                Code = "lcv_yte_cosoyte_trucdieuduong"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_dieutri, lcv_yte_cosoyte_trucdieuduong);

            var lcv_yte_cosoyte_trucbacsi = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Trực bác sĩ",
                Code = "lcv_yte_cosoyte_trucbacsi"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_dieutri, lcv_yte_cosoyte_trucbacsi);

            var lcv_yte_cosoyte_lichtrucdieutri = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Lập lịch trực",
                Code = "lcv_yte_cosoyte_lichtrucdieutri"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_dieutri, lcv_yte_cosoyte_lichtrucdieutri);



            var lcv_yte_cosoyte_kham = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Khám bệnh",
                Code = "lcv_yte_cosoyte_kham"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_kham, lcv_yte_cosoyte_kham);

            var lcv_yte_cosoyte_lichkham = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Lập lịch khám",
                Code = "lcv_yte_cosoyte_lichkham"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_kham, lcv_yte_cosoyte_lichkham);



            var lcv_yte_cosoyte_xaydungnhansukhoa = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng nhân sự khoa",
                Code = "lcv_yte_cosoyte_xaydungnhansukhoa"
            });

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_quanlykhoalamsang, lcv_yte_cosoyte_xaydungnhansukhoa);

            var lcv_yte_cosoyte_quanlybuonggiuong = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý buồng giường",
                Code = "lcv_yte_cosoyte_quanlybuonggiuong"
            });

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_quanlykhoalamsang, lcv_yte_cosoyte_quanlybuonggiuong);

            var lcv_yte_cosoyte_thietbiiot = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý thiêt bị IoT y tế",
                Code = "lcv_yte_cosoyte_quanlythietbiiotyte"
            });

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_cosoyte_quanlykhoalamsang, lcv_yte_cosoyte_thietbiiot);


            #endregion

            #region --- Tổ chức

            var tc_yte_benhvienao_ytemoi = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Bệnh viện ảo Y Tế Mới",
                CodeLoaiToChuc = ltc_yte_cosoyte.Code,
                LoaiToChuc = ltc_yte_cosoyte.Name,
                VietTat = "bvaytm",
                IdHeThong = ht_yte.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_yte_benhvienao_ytemoi);

            #endregion

            #region --- Sàn
            await AC.ToChuc.Them_San(tc_yte_benhvienao_ytemoi, san_yte_khamchuabenh);
            #endregion

            #region --- Phòng ban

            //Cơ sở y tê---------------------------

            var pb_khoa_dichvu = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Khoa dịch vụ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_yte_cosoyte_khoalamsang.Name,
                CodeLoaiPhongBan = lpb_yte_cosoyte_khoalamsang.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_yte_benhvienao_ytemoi, pb_khoa_dichvu);


            #endregion

            #region --- Giải pháp


            #endregion

            #region --- Loại Ca


            var lc_yte_dieutrinoitru = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_yte_dieutrinoitru",
                Name = "Điều trị nội trú"
            });

            var lc_yte_dieutringoaitru = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_yte_dieutringoaitru",
                Name = "Điều trị ngoại trú"
            });

            var lc_yte_theodoibenhnhanngoaitru = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_yte_theodoibenhnhanngoaitru",
                Name = "Theo dõi bệnh nhân ngoại trú"
            });



            #endregion

            #region --- Loại Kế Hoạch





            #endregion

            #region --- Loại Việc



            #endregion

            #region --- Phận sự






            #endregion

           

            #endregion

            #region Chăm sóc người bệnh

            #region --- Loại tổ chức

            var ltc_yte_chamsocnguoibenh = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Chăm sóc người bệnh",
                Code = "ltc_yte_chamsocnguoibenh"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_yte, ltc_yte_chamsocnguoibenh);

            #endregion

            #region --- Tổ chức

            var tc_yte_chamsocnguoibenh = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Chăm sóc người bệnh Y Tế Mới",
                CodeLoaiToChuc = ltc_yte_chamsocnguoibenh.Code,
                LoaiToChuc = ltc_yte_chamsocnguoibenh.Name,
                VietTat = "CHĂM BỆNH",
                IdHeThong = ht_yte.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_yte_chamsocnguoibenh);


            #endregion

            #region --- Sàn

            await AC.ToChuc.Them_San(tc_yte_chamsocnguoibenh, san_yte_chamsocnguoibenhhanoi);

            #endregion

            #region --- Loại phòng ban

            //Chăm sóc người bệnh
            var lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng chăm sóc người bệnh",
                Code = "lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_chamsocnguoibenh, lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh);

            var lpb_yte_chamsocnguoibenh_phongdichvu = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng dịch vụ",
                Code = "lpb_yte_chamsocnguoibenh_dichvu"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_chamsocnguoibenh, lpb_yte_chamsocnguoibenh_phongdichvu);

            var lpb_yte_chamsocnguoibenh_phongcongnghethongtin = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng công nghệ thông tin",
                Code = "lpb_yte_chamsocnguoibenh_congnghethongtin"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_yte_chamsocnguoibenh, lpb_yte_chamsocnguoibenh_phongcongnghethongtin);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_yte_chamsocnguoibenh);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlydichvu, lpb_yte_chamsocnguoibenh_phongdichvu);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlywebsite, lpb_yte_chamsocnguoibenh_phongcongnghethongtin);

            //Chăm sóc người bệnh --------------------------

            var lgp_yte_chamsocnguoibenh_chamsocnguoibenh = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Chăm sóc người bệnh",
                Code = "lgp_yte_chamsocnguoibenh_chamsocsnguoibenh",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_chamsocnguoibenh_chamsocnguoibenh, lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh);



            var lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý phòng chăm sóc người bệnh",
                Code = "lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh, lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh);
                       

            #endregion

            #region --- Loại công việc

            //Chăm sóc người bệnh ---------------

            var lcv_yte_chamsocnguoibenh_chamsoc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Chăm sóc người bệnh",
                Code = "lcv_yte_chamsocnguoibenh_chamsoc"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_chamsocnguoibenh, lcv_yte_chamsocnguoibenh_chamsoc);

            var lcv_yte_chamsocnguoibenh_theodoi = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Theo dõi chăm sóc người bệnh",
                Code = "lcv_yte_chamsocnguoibenh_theodoi"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_chamsocnguoibenh, lcv_yte_chamsocnguoibenh_theodoi);


            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh, lcv_yte_quanlyhosobenhnhan);

            var lcv_yte_chamsocnguoibenh_lapkehoachchamsoc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Lập kế hoạch chăm sóc & phân ca",
                Code = "lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh, lcv_yte_chamsocnguoibenh_lapkehoachchamsoc);

            var lcv_yte_chamsocnguoibenh_nhansucphonghamsoc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng nhân sự phòng chăm sóc",
                Code = "lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh, lcv_yte_chamsocnguoibenh_nhansucphonghamsoc);

            var lcv_yte_chamsocnguoibenh_taichinhphongchamsoc = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Tài chính phòng",
                Code = "lcv_yte_chamsocnguoibenh_taichinhphongchamsoc"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh, lcv_yte_chamsocnguoibenh_taichinhphongchamsoc);

            //var lcv_yte_chamsocnguoibenh_quanlydichvuchamsoc = await AC.LoaiCongViec.Create(new LoaiCongViec
            //{
            //    Name = "Quản lý dịch vụ",
            //    Code = "lcv_yte_chamsocnguoibenh_quanlydichvuchamsoc"
            //});
            //await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_yte_chamsocnguoibenh_quanlydichvuchamsoc, lcv_yte_chamsocnguoibenh_quanlydichvuchamsoc);



            #endregion 

            #region --- Phòng ban
            
            //Chăm sóc bệnh nhân---------------------------

            var pb_yte_chamsocbenhnhan_phong1 = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng chăm sóc số 1",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh.Name,
                CodeLoaiPhongBan = lpb_yte_chamsocnguoibenh_phongchamsocnguoibenh.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_yte_chamsocnguoibenh, pb_yte_chamsocbenhnhan_phong1);

            var pb_yte_chamsocbenhnhan_phongdichvu = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng dịch vụ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_yte_chamsocnguoibenh_phongdichvu.Name,
                CodeLoaiPhongBan = lpb_yte_chamsocnguoibenh_phongdichvu.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_yte_chamsocnguoibenh, pb_yte_chamsocbenhnhan_phongdichvu);

            var pb_yte_chamsocbenhnhan_phongcongnghethongtin = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng dịch vụ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_yte_chamsocnguoibenh_phongcongnghethongtin.Name,
                CodeLoaiPhongBan = lpb_yte_chamsocnguoibenh_phongcongnghethongtin.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_yte_chamsocnguoibenh, pb_yte_chamsocbenhnhan_phongcongnghethongtin);

            #endregion

            #region --- Giải pháp

            //var gp_quanlydichvuchamsocnguoibenh = await AC.GiaiPhap.Create(new GiaiPhap
            //{
            //    LoaiGiaiPhap =lgp_yte_chamsocnguoibenh_quanlydichvuchamsoc.Name,
            //    CodeLoaiGiaiPhap = lgp_yte_chamsocnguoibenh_quanlydichvuchamsoc.Code
            //});
            //await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_quanlydichvuchamsocnguoibenh,tc_yte_chamsocnguoibenh);

            var gp_quanlyphongchamsocnguoibenh = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh.Name,
                CodeLoaiGiaiPhap = lgp_yte_chamsocnguoibenh_quanlyphongchamsocnguoibenh.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_quanlyphongchamsocnguoibenh, pb_yte_chamsocbenhnhan_phong1);

            var gp_quanlyphongban = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_quanlyphongban, pb_yte_chamsocbenhnhan_phong1);

            var gp_chammocnguoibenh = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_yte_chamsocnguoibenh_chamsocnguoibenh.Name,
                CodeLoaiGiaiPhap = lgp_yte_chamsocnguoibenh_chamsocnguoibenh.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_chammocnguoibenh, pb_yte_chamsocbenhnhan_phong1);

            var gp_yte_chamsocnguoibenh_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_yte_chamsocnguoibenh_quanlytochuc, tc_yte_chamsocnguoibenh);

            var gp_yte_chammocnguoibenh_phongdichvu_quanlydichvu = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlydichvu.Name,
                CodeLoaiGiaiPhap = lgp_quanlydichvu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_yte_chammocnguoibenh_phongdichvu_quanlydichvu, pb_yte_chamsocbenhnhan_phongdichvu);

            var gp_yte_chammocnguoibenh_phongdichvu_quanlyweb = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlywebsite.Name,
                CodeLoaiGiaiPhap = lgp_quanlywebsite.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_yte_chammocnguoibenh_phongdichvu_quanlyweb, pb_yte_chamsocbenhnhan_phongcongnghethongtin);
            #endregion

            #region --- Loại dịch vụ

            var ldv_yte_chamsocnguoibenh = await AC.LoaiDichVu.Create(new LoaiDichVu
            {
                Name = "Chăm sóc người bệnh",
                Code = "ldv_yte_chamsocnguoibenh",
            });
            await AC.LoaiToChuc.ThemLoaiDichVu(ltc_yte_chamsocnguoibenh, ldv_yte_chamsocnguoibenh);
            await AC.LoaiSan.ThemLoaiDichVu(ls_yte_chamsocnguoibenh, ldv_yte_chamsocnguoibenh);

            #endregion

            #region --- Loại hàng hóa

            var lhh_yte_dichvuchamsocnguoibenh = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Dịch vụ chăm sóc người bệnh",
                Code = "lhh_yte_dichvuchamsocnguoibenh"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_yte_chamsocnguoibenh, lhh_yte_dichvuchamsocnguoibenh);


            #endregion

            #region --- Loại ca

            var lc_yte_phuchoichucnang = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_yte_phuchoichucnang",
                Name = "Phục hồi chức năng",
                CodeHeThong = CodeHeThong.YTeMoi
            });
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_benhnhan, lc_yte_phuchoichucnang);

           
            var lc_yte_chamsocnguoibenh = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_yte_chamsocnguoibenh",
                Name = "Chăm sóc người bệnh",
                CodeHeThong = CodeHeThong.YTeMoi
            });
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_benhnhan, lc_yte_chamsocnguoibenh);
            
            await AC.LoaiCa.ThemLoaiHangHoa(lc_yte_chamsocnguoibenh, lhh_yte_dichvuchamsocnguoibenh);

            #endregion

            #region --- Loại kế hoạch

            var lkh_yte_chamsocnguoibenhtainha = await AC.LoaiKeHoach.Create(new LoaiKeHoach
            {
                Code = "lkh_yte_chamsocnguoibenhtainha",
                Name = "Chăm sóc người bệnh tại nhà"
            });
            await AC.LoaiCa.ThemLoaiKeHoach(lc_yte_chamsocnguoibenh, lkh_yte_chamsocnguoibenhtainha);

            var lkh_yte_chamsocnguoibenhtaivien = await AC.LoaiKeHoach.Create(new LoaiKeHoach
            {
                Code = "lkh_yte_chamsocnguoibenhtaivien",
                Name = "Chăm sóc người bệnh tại cơ sở y tế"
            });
            await AC.LoaiCa.ThemLoaiKeHoach(lc_yte_chamsocnguoibenh, lkh_yte_chamsocnguoibenhtaivien);


            var lkh_yte_tapphuchoichucnang = await AC.LoaiKeHoach.Create(new LoaiKeHoach
            {
                Code = "lkh_yte_tapphuchoichucnang",
                Name = "Tập phục hồi chức năng"
            });
            await AC.LoaiCa.ThemLoaiKeHoach(lc_yte_phuchoichucnang, lkh_yte_tapphuchoichucnang);
            #endregion

            #region --- Loại việc

            var lv_yte_nauchonguoibenh = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Nấu ăn cho người bệnh",
                Code = "lv_yte_nauchonguoibenh",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_nauchonguoibenh);

            var lv_yte_chonguoibenhan = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Cho người bệnh ăn",
                Code = "lv_yte_chobenhnhanan",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_chonguoibenhan);

            var lv_yte_chonguoibenhuongthuoc = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Cho người bệnh uống thuốc",
                Code = "lv_yte_chobenhnhanuongthuoc",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_chonguoibenhuongthuoc);

            var lv_yte_chonguoibenhdivesinh = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Cho người bệnh đi vệ sinh",
                Code = "lv_yte_chobenhnhandivesinh",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_chonguoibenhdivesinh);


            var lv_yte_hutdomchonguoibenh = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Hút đờm cho người bệnh",
                Code = "lv_yte_hutdomchobenhnhan",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_hutdomchonguoibenh);

            var lv_yte_datdaychoanxong = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Đặt dây cho người bệnh",
                Code = "lv_yte_datdaychoanxong",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_datdaychoanxong);

            var lv_yte_xoabopchonguoibenh = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Xoa bóp cho người bệnh",
                Code = "lv_yte_datdaychoanxong",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_xoabopchonguoibenh);

            var lv_yte_chonguoibenhngu = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Cho người bệnh ngủ",
                Code = "lv_yte_chonguoibenhngu",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_chonguoibenhngu);

            var lv_yte_chonguoibenhdidao = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Cho người bệnh đi dạo",
                Code = "lv_yte_chonguoibenhdidao",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_chamsocnguoibenhtainha, lv_yte_chonguoibenhdidao);

            var lv_yte_tapphuchoichucnang = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Tập phục hồi chức năng",
                Code = "lv_yte_tapphuchoichucnang",
                KyNang = false
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_yte_tapphuchoichucnang, lv_yte_tapphuchoichucnang);

            #endregion

            #region --- Phận sự

            var ps_yte_chamsocnguoibenh = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Chăm sóc người bệnh",
                Code = "ps_yte_chamsocnguoibenh",
                CodeHeThong = CodeHeThong.YTeMoi,
                PhanSuCaNhan = true
            }) ;

            await AC.LoaiCa.ThemPhanSu(lc_yte_chamsocnguoibenh, ps_yte_chamsocnguoibenh);
           

            var ps_yte_theodoinguoibenh = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Theo dõi người bệnh",
                Code = "ps_yte_theodoinguoibenh",
                CodeHeThong = CodeHeThong.YTeMoi,
                PhanSuCaNhan = true
            });

            await AC.LoaiCa.ThemPhanSu(lc_yte_chamsocnguoibenh, ps_yte_theodoinguoibenh);
            
            var ps_yte_tapphuchoichucnang = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Kỹ thuật viên phục hồi chức năng",
                Code = "ps_yte_kythuatvienphuchoichucnang",
                CodeHeThong = CodeHeThong.YTeMoi,
                PhanSuCaNhan = true
            });

            await AC.LoaiCa.ThemPhanSu(lc_yte_phuchoichucnang, ps_yte_tapphuchoichucnang);

            var ps_yte_trucphong = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Trực phòng",
                Code = "ps_yte_trucphong",
                CodeHeThong = CodeHeThong.YTeMoi,
                PhanSuNhom = true
            });

            #endregion

            #region --- Dịch vụ

            var dv_yte_chamsocnguoibenh = await AC.DichVu.Create(new DichVu
            {
                LoaiDichVu = ldv_yte_chamsocnguoibenh.Name,
                CodeLoaiDichVu = ldv_yte_chamsocnguoibenh.Code,
                Name = "Chăm sóc người bệnh tại Hà Nội"
            });
            await AC.DichVu.SetToChuc(dv_yte_chamsocnguoibenh, tc_yte_chamsocnguoibenh);
            await AC.DichVu.SetSan(dv_yte_chamsocnguoibenh, san_yte_chamsocnguoibenhhanoi);

            #endregion

            #region --- Hàng Hóa

            var hh_chamsocbenhnhantainha_canang = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Dịch vụ chăm sóc bệnh nhân nặng tại nhà",
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                Tag = "#benhnang #chamsoc",
                Anh = "/Files/hh_02.jpg",
                TomTat = "<p> - Chăm sóc những bệnh nhân nặng bởi những kỹ thuật viên tốt nhất <br> - Theo dõi bệnh nhân và công việc 24/24</p>",
                Gia = "<p> - 350.000 vnđ/ngày  <br> - 10 triệu vnđ/tháng</p>",
                LienHe = "<p>Phan Hoài Minh : 087654789<p> ",
                GioiThieu = ""

            });
            await AC.DichVu.ThemHangHoa(dv_yte_chamsocnguoibenh, hh_chamsocbenhnhantainha_canang);
            await AC.HangHoa.SetSan(hh_chamsocbenhnhantainha_canang, san_yte_chamsocnguoibenhhanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_chamsocbenhnhantainha_canang, lhh_yte_dichvuchamsocnguoibenh);

            var hh_chamsocbenhnhantainha_canhe = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Dịch vụ chăm sóc người bệnh nhẹ, người già tại nhà",
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                Tag = "#nguoigia #nguoibenh #chamsoc",
                Anh = "/Files/hh_01.jpg",
                TomTat = "<p> - Chăm sóc những bệnh nhân nặng bởi những kỹ thuật viên tốt nhất <br> - Theo dõi bệnh nhân và công việc 24/24</p>",
                Gia = "<p> - 350.000 vnđ/ngày  <br> - 10 triệu vnđ/tháng</p>",
                LienHe = "<p>Đoàn Lan Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_yte_chamsocnguoibenh, hh_chamsocbenhnhantainha_canhe);
            await AC.HangHoa.SetSan(hh_chamsocbenhnhantainha_canhe, san_yte_chamsocnguoibenhhanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_chamsocbenhnhantainha_canang, lhh_yte_dichvuchamsocnguoibenh);

            #endregion

            #region --- Nhân viên

            var nv_minh_yte_tochuc_chamsocnguoibenh = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Founder",
                GioiThieu = "Quản lý dịch vụ chăm sóc người bệnh",
                IdHeThong = ht_yte.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_yte_chamsocnguoibenh, nv_minh_yte_tochuc_chamsocnguoibenh, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_yte_tochuc_chamsocnguoibenh);


            var nv_chihang = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0345781235",
                Name = "Nguyễn Thị Hằng",
                VaiTro = "Y tá",
                GioiThieu = "Quản lý phòng chăm sóc số 1",
                IdHeThong = ht_yte.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_yte_chamsocbenhnhan_phong1, nv_chihang);
            await AC.ToChuc.Them_NhanVien(tc_yte_chamsocnguoibenh, nv_chihang);
            await AC.NguoiDung.ThemNhanVien(nd_nguyenthihang, nv_chihang);
            await AC.PhongBan.ThemPhanSuNhanVien(pb_yte_chamsocbenhnhan_phong1, nv_chihang, ps_yte_theodoinguoibenh);

            var nv_chithuy = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0392384598",
                Name = "Nguyễn Thúy",
                VaiTro = "Chăm sóc người bệnh",
                GioiThieu = "Người chăm sóc người bệnh",
                IdHeThong = ht_yte.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_yte_chamsocbenhnhan_phong1, nv_chithuy);
            await AC.ToChuc.Them_NhanVien(tc_yte_chamsocnguoibenh, nv_chithuy);
            await AC.NguoiDung.ThemNhanVien(nd_nguyenthuy, nv_chithuy);
            await AC.PhongBan.ThemPhanSuNhanVien(pb_yte_chamsocbenhnhan_phong1, nv_chithuy, ps_yte_chamsocnguoibenh);

            var nv_minh_yte_chamsocnguoibenh_dichvu = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Minh",
                VaiTro = "Quản lý dịch vụ",
                GioiThieu = "Người chăm sóc người bệnh",
                IdHeThong = ht_yte.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_yte_chamsocbenhnhan_phongdichvu, nv_minh_yte_chamsocnguoibenh_dichvu);
            await AC.ToChuc.Them_NhanVien(tc_yte_chamsocnguoibenh, nv_minh_yte_chamsocnguoibenh_dichvu);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_yte_chamsocnguoibenh_dichvu);

            var nv_minh_yte_chamsocnguoibenh_web = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Minh",
                VaiTro = "Quản lý web",
                GioiThieu = "Người chăm sóc người bệnh",
                IdHeThong = ht_yte.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_yte_chamsocbenhnhan_phongcongnghethongtin, nv_minh_yte_chamsocnguoibenh_web);
            await AC.ToChuc.Them_NhanVien(tc_yte_chamsocnguoibenh, nv_minh_yte_chamsocnguoibenh_web);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_yte_chamsocnguoibenh_web);

            #endregion

            #region --- Công việc

            var cv_yte_chamsocbenhnhan_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_yte_chamsocnguoibenh_quanlytochuc, cv_yte_chamsocbenhnhan_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_yte_tochuc_chamsocnguoibenh, cv_yte_chamsocbenhnhan_quanlytochuc);

            var cv_quanlybenhnhan = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_quanlyhosobenhnhan.Name,
                CodeLoaiCongViec = lcv_yte_quanlyhosobenhnhan.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongchamsocnguoibenh, cv_quanlybenhnhan);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_quanlybenhnhan);


            var cv_quanlynhanvien = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });

            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongban, cv_quanlynhanvien);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_quanlynhanvien);

            var cv_chamsocnguoibenh = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_chamsoc.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_chamsoc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_chammocnguoibenh, cv_chamsocnguoibenh);
            await AC.NhanVien.ThemCongViec(nv_chithuy, cv_chamsocnguoibenh);

            var cv_chihang_chamsocnguoibenh = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_chamsoc.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_chamsoc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_chammocnguoibenh, cv_chihang_chamsocnguoibenh);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_chihang_chamsocnguoibenh);

            var cv_theodoinguoibenh = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_theodoi.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_theodoi.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_chammocnguoibenh, cv_theodoinguoibenh);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_theodoinguoibenh);

            var cv_xaydungnhansu = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_nhansucphonghamsoc.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_nhansucphonghamsoc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongchamsocnguoibenh, cv_xaydungnhansu);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_xaydungnhansu);

            var cv_taichinh = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_taichinhphongchamsoc.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_taichinhphongchamsoc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongchamsocnguoibenh, cv_taichinh);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_taichinh);


            var cv_phanca = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_yte_chamsocnguoibenh_lapkehoachchamsoc.Name,
                CodeLoaiCongViec = lcv_yte_chamsocnguoibenh_lapkehoachchamsoc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phong1.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_quanlyphongchamsocnguoibenh, cv_phanca);
            await AC.NhanVien.ThemCongViec(nv_chihang, cv_phanca);

            var cv_yte_chamsocnguoibenh_dichvu = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xaydungdichvu.Name,
                CodeLoaiCongViec = lcv_xaydungdichvu.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phongdichvu.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_yte_chammocnguoibenh_phongdichvu_quanlydichvu, cv_yte_chamsocnguoibenh_dichvu);
            await AC.NhanVien.ThemCongViec(nv_minh_yte_chamsocnguoibenh_dichvu, cv_yte_chamsocnguoibenh_dichvu);

            var cv_yte_chamsocnguoibenh_web = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec =lcv_xaydungwebsite.Name,
                CodeLoaiCongViec = lcv_xaydungwebsite.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id,
                IdPhongBan = pb_yte_chamsocbenhnhan_phongcongnghethongtin.Id,
                IdHeThong = ht_yte.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_yte_chammocnguoibenh_phongdichvu_quanlyweb, cv_yte_chamsocnguoibenh_web);
            await AC.NhanVien.ThemCongViec(nv_minh_yte_chamsocnguoibenh_web, cv_yte_chamsocnguoibenh_web);

            #endregion

            #region --- Nhóm

            //Chăm sóc bệnh nhân------------------------
            var nhom_yte_chamsocnguoibenh_phong1_nhom1 = await AC.Nhom.Create(new Nhom
            {
                Name = "Nhóm trực giờ hành chính"
            });

            await AC.PhongBan.Them_Nhom(pb_yte_chamsocbenhnhan_phong1, nhom_yte_chamsocnguoibenh_phong1_nhom1);
            await AC.Nhom.Them_NhanVien(nhom_yte_chamsocnguoibenh_phong1_nhom1, nv_chihang);

            #endregion

            #region --- Lịch

            var lt_yte_chamsocnguoibenh_phong1_nhom1_trucphong = await AC.Lich.Create(new Lich
            {
                Loai = LoaiLich.TrucPhongChamSoc,
                NgayStart = new DateTime(2022, 1, 1),
                NgayEnd = new DateTime(2032, 1, 1),
                DsDay = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
                GioStart = new DateTime(2022, 1, 1, 7, 0, 0),
                GioEnd = new DateTime(2022, 1, 1, 17, 0, 0)
            });
            await AC.Nhom.Them_Lich(nhom_yte_chamsocnguoibenh_phong1_nhom1, lt_yte_chamsocnguoibenh_phong1_nhom1_trucphong);
            await AC.PhongBan.Them_Lich(pb_yte_chamsocbenhnhan_phong1, lt_yte_chamsocnguoibenh_phong1_nhom1_trucphong, "DsLichTrucPhongChamSoc");


            #endregion

            #region --- Trang

            var trang_yte_chamsocnguoibenh_gioithieu = await AC.Trang.Create(new Trang
            {
                Name = "Giới thiệu",
                LoaiMauTrang = lmt_gioithieu.Name,
                CodeMauTrang = lmt_gioithieu.Code,
                STT = 1,
            });

            await AC.ToChuc.Them_Trang(tc_yte_chamsocnguoibenh, trang_yte_chamsocnguoibenh_gioithieu);
            await AC.ToChuc.Set_TrangChu(tc_yte_chamsocnguoibenh, trang_yte_chamsocnguoibenh_gioithieu);

            #endregion

            #region --- Bản tin

            var bt_yte_chamsocnguoibenh_gioithieu = await AC.BanTin.Create(new BanTin
            {
                Name = "Giới thiệu",
                LoaiBanTin = lbt_header.Name,
                CodeBanTin = lbt_header.Code,
                STT = 1, 
                IdToChuc = tc_yte_chamsocnguoibenh.Id
            });

            await AC.Trang.Them_BanTin(trang_yte_chamsocnguoibenh_gioithieu, bt_yte_chamsocnguoibenh_gioithieu);

            #endregion

            #region --- Đối tượng

            var dt_yte_bn_lebaanhduc = await AC.DoiTuong.Create(new DoiTuong
            {
                Name = "Lê Bá Anh Đức",
                CreatedBy = nd_lebahongminh.Id,
                LoaiDoiTuong = ldt_benhnhan.Name,
                CodeLoaiDoiTuong = ldt_benhnhan.Code

            });
            await AC.PhongBan.Them_DoiTuong(pb_yte_chamsocbenhnhan_phong1, dt_yte_bn_lebaanhduc);

            //var bn_lebaanhduc = await AC.BenhNhan.Create(new BenhNhan
            //{
            //    Name = "Lê Bá Anh Đức",
            //    CreatedBy = nd_lebahongminh.Id
            //});
            //await AC.PhongBan.Them_BenhNhan(pb_yte_chamsocbenhnhan_phong1, bn_lebaanhduc);

            #endregion

            #region --- Tiện ích

            var ti_nguoinhabenhnhan = await AC.TienIch.Create(new TienIch
            {
                LoaiTienIch = lti_yte_nguoidung_nguoinhabenhnhan.Name,
                CodeLoaiTienIch = lti_yte_nguoidung_nguoinhabenhnhan.Code,
                CodeHeThong = lti_yte_nguoidung_chuabenh.CodeHeThong,
                VaiTroNguoiDung = "Bố bệnh nhân",
                Name = "Lê Bá Hồng Minh"
            });

            await AC.TienIch.Set_NguoiDung(ti_nguoinhabenhnhan, nd_lebahongminh);
            await AC.TienIch.Set_DoiTuong(ti_nguoinhabenhnhan, dt_yte_bn_lebaanhduc);

            var ti_nguoibenh = await AC.TienIch.Create(new TienIch
            {
                LoaiTienIch = lti_yte_nguoidung_chuabenh.Name,
                CodeLoaiTienIch = lti_yte_nguoidung_chuabenh.Code,
                CodeHeThong = lti_yte_nguoidung_chuabenh.CodeHeThong,
                VaiTroNguoiDung = "Người bệnh",
                Name = "Lê Bá Anh Đức"

            });

            await AC.TienIch.Set_NguoiDung(ti_nguoibenh, nd_lebaanhduc);
            await AC.TienIch.Set_DoiTuong(ti_nguoibenh, dt_yte_bn_lebaanhduc);

            #endregion

            #region --- Ca

            var ca_chamduc = await AC.Ca.Create(new Ca
            {
                CodeLoaiCa = lc_yte_chamsocnguoibenh.Code,
                LoaiCa = lc_yte_chamsocnguoibenh.Name
            });

            await AC.Ca.SetDoiTuong(ca_chamduc, dt_yte_bn_lebaanhduc);
            await AC.Ca.ThemPhanSuNhanVien(ca_chamduc, nv_chithuy, ps_yte_chamsocnguoibenh);
            await AC.Ca.ThemPhanSuNhanVien(ca_chamduc, nv_chihang, ps_yte_chamsocnguoibenh);
            await AC.Ca.ThemPhanSuNhanVien(ca_chamduc, nv_chihang, ps_yte_theodoinguoibenh);


            #endregion

            #region --- Kế hoạch

            var kh_chamsocduc = await AC.KeHoach.Create(new KeHoach
            {
                LoaiKeHoach = lkh_yte_chamsocnguoibenhtainha.Name,
                CodeLoaiKeHoach = lkh_yte_chamsocnguoibenhtainha.Code,
                DanDo = "Thường xuyên xoa bóp cho cháu lúc có thời gian"
            });
            await AC.Ca.Them_KeHoach(ca_chamduc, kh_chamsocduc);

            var viec_nauansang = await AC.Viec.Create(new Viec
            {
                LoaiViec = lv_yte_nauchonguoibenh.Name,
                CodeLoaiViec = lv_yte_nauchonguoibenh.Code,
                NhanDe = "Nấu cho cháu bữa sáng",
                ThoiGianText = "6h00",
                Stt = 1.0,
                DanDo = "<p> - Nấu cháo Cá Hồi và sáng thứ 2 4 6 </br> - Nấu cháo thịt bò vào sáng thứ 3 5 7 chủ nhật</p>"
            });
            await AC.KeHoach.Them_Viec(kh_chamsocduc, viec_nauansang);

            var viec_choanbuoisang = await AC.Viec.Create(new Viec
            {
                LoaiViec = lv_yte_chonguoibenhan.Name,
                CodeLoaiViec = lv_yte_chonguoibenhan.Code,
                NhanDe = "Cho cháu ăn sáng",
                ThoiGianText = "6h30",
                Stt = 1.1
            });
            await AC.KeHoach.Them_Viec(kh_chamsocduc, viec_choanbuoisang);

            #endregion

            #region --- Giao dịch

            var gd_thuenguoichamsoc = await AC.GiaoDich.Create(new GiaoDich
            {
                IdHeThong = ht_yte.Id,
                IdToChuc = tc_yte_chamsocnguoibenh.Id
            });

            await AC.GiaoDich.SetHangHoa(gd_thuenguoichamsoc, hh_chamsocbenhnhantainha_canang);
            await AC.PhongBan.ThemGiaoDich(pb_yte_chamsocbenhnhan_phong1, gd_thuenguoichamsoc);
            await AC.Ca.ThemGiaoDich(ca_chamduc, gd_thuenguoichamsoc);

            await AC.NguoiDung.ThemGiaoDich(nd_lebahongminh, gd_thuenguoichamsoc);
            await AC.DichVu.ThemGiaoDich(dv_yte_chamsocnguoibenh, gd_thuenguoichamsoc);

            #endregion

            #region --- Thanh toán

            var tt_chamducthang2 = await AC.ThanhToan.Create(new ThanhToan
            {
                LyDo = "Thanh toán tiền chăm Đức 13/2/2022 đến 12/3/2022",
                SoTienPhaiThanhToan = 12000000,
            });

            await AC.GiaoDich.ThemThanhToan(gd_thuenguoichamsoc, tt_chamducthang2);

            #endregion


            #endregion

            #endregion

            #region Nông nghiệp

            #region Viện nghiên cứu

            #region --- Loại tổ chức

            var ltc_nongnghiep_viennghiencuunongnghiep = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Viện nghiên cứu nông nghiệp",
                Code = "ltc_nongnghiep_viennghiencuunongnghiep"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_nongnghiep, ltc_nongnghiep_viennghiencuunongnghiep);


            #endregion

            #region --- Tổ chức

            var tc_nongnghiep_viennghiencuunongnghiep = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Trung tâm nghiên cứu sinh học Đông Nam Á",
                CodeLoaiToChuc = ltc_nongnghiep_viennghiencuunongnghiep.Code,
                LoaiToChuc = ltc_nongnghiep_viennghiencuunongnghiep.Name,
                VietTat = "sabc",
                IdHeThong = ht_nongnghiep.Id,
                Url = "sabc-vn.org"
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_nongnghiep_viennghiencuunongnghiep);

            #endregion

            #region --- Loại phòng ban

            var lpb_nongnghiep_viennghiencuu_phongcongnghethongtin = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng công nghệ thông tin",
                Code = "lpb_nongnghiep_viennghiencuu_congnghethongtin"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_nongnghiep_viennghiencuunongnghiep, lpb_nongnghiep_viennghiencuu_phongcongnghethongtin);


            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_nongnghiep_viennghiencuunongnghiep);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlywebsite, lpb_nongnghiep_viennghiencuu_phongcongnghethongtin);

            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban

            var pb_nongnghiep_viennghiencuu_phongcongnghethongtin = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng công nghệ thông tin",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_nongnghiep_viennghiencuu_phongcongnghethongtin.Name,
                CodeLoaiPhongBan = lpb_nongnghiep_viennghiencuu_phongcongnghethongtin.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_nongnghiep_viennghiencuunongnghiep, pb_nongnghiep_viennghiencuu_phongcongnghethongtin);

            #endregion

            #region --- Giải pháp

            var gp_nongnghiep_viennghiencuu_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_nongnghiep_viennghiencuu_quanlytochuc, tc_nongnghiep_viennghiencuunongnghiep);

            var gp_nongnghiep_viennghiencuu_phongcongnghe_quanlywebsite = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlywebsite.Name,
                CodeLoaiGiaiPhap = lgp_quanlywebsite.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_nongnghiep_viennghiencuu_phongcongnghe_quanlywebsite, pb_nongnghiep_viennghiencuu_phongcongnghethongtin);

            #endregion

            #region --- Nhân viên

            var nv_minh_nongnghiep_quanlytochuc = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý hệ thống",
                GioiThieu = "Thiết kế và lập trình hệ thống",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_nongnghiep_viennghiencuunongnghiep, nv_minh_nongnghiep_quanlytochuc, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_nongnghiep_quanlytochuc);

            var nv_minh_nongnghiep_phongcongnghethongtin = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý công nghệ thông tin",
                GioiThieu = "Quản lý phòng dịch vụ",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.PhongBan.Them_NhanVien( pb_nongnghiep_viennghiencuu_phongcongnghethongtin, nv_minh_nongnghiep_phongcongnghethongtin);
            await AC.ToChuc.Them_NhanVien(tc_nongnghiep_viennghiencuunongnghiep, nv_minh_nongnghiep_phongcongnghethongtin);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_nongnghiep_phongcongnghethongtin);

            #endregion

            #region --- Công việc

            var cv_nongnghiep_viennghiencuu_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_nongnghiep_viennghiencuunongnghiep.Id,
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_nongnghiep_viennghiencuu_quanlytochuc, cv_nongnghiep_viennghiencuu_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_nongnghiep_quanlytochuc, cv_nongnghiep_viennghiencuu_quanlytochuc);

            var cv_nongnghiep_viennghiencuu_phongcntt_xaydungweb = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xaydungwebsite.Name,
                CodeLoaiCongViec = lcv_xaydungwebsite.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_nongnghiep_viennghiencuunongnghiep.Id,
                IdPhongBan = pb_nongnghiep_viennghiencuu_phongcongnghethongtin.Id,
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_nongnghiep_viennghiencuu_phongcongnghe_quanlywebsite, cv_nongnghiep_viennghiencuu_phongcntt_xaydungweb);
            await AC.NhanVien.ThemCongViec(nv_minh_nongnghiep_phongcongnghethongtin, cv_nongnghiep_viennghiencuu_phongcntt_xaydungweb);

            #endregion

            #endregion

            #region Trang trại 

            #region --- Loại tổ chức

            var ltc_nongnghiep_trangtrai = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Trang trại",
                Code = "ltc_nongnghiep_trangtrai"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_nongnghiep, ltc_nongnghiep_trangtrai);

            #endregion

            #region --- Tổ chức

            var tc_nongnghiep_trangtrai_trangtraithogiong = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Trang trại thỏ giống Hà nội",
                CodeLoaiToChuc = ltc_nongnghiep_trangtrai.Code,
                LoaiToChuc = ltc_nongnghiep_trangtrai.Name,
                VietTat = "tttg",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_nongnghiep_trangtrai_trangtraithogiong);

            #endregion

            #region --- Loại phòng ban


            var lpb_nongnghiep_trangtrai_phongthogiong = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng thỏ giống",
                Code = "lpb_nongnghiep_trangtrai_phongthogiong"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_nongnghiep_trangtrai, lpb_nongnghiep_trangtrai_phongthogiong);

            var lpb_nongnghiep_trangtrai_kinhdoanhthogiong = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng kinh doanh thỏ giống",
                Code = "lpb_nongnghiep_trangtrai_phongkinhdoanhthogiong"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_nongnghiep_trangtrai, lpb_nongnghiep_trangtrai_kinhdoanhthogiong);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_nongnghiep_trangtrai);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlywebsite, lpb_nongnghiep_viennghiencuu_phongcongnghethongtin);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_nongnghiep_trangtrai_phongthogiong);

            var lgp_nongnghiep_trangtrai_quanlythogiong = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý thỏ giống",
                Code = "lgp_nongnghiep_trangtrai_quanlythogiong",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_nongnghiep_trangtrai_quanlythogiong, lpb_nongnghiep_trangtrai_phongthogiong);

            var lgp_nongnghiep_trangtrai_nhangiongtho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Nhân giống thỏ",
                Code = "lgp_nongnghiep_trangtrai_nhangiongtho",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_nongnghiep_trangtrai_nhangiongtho, lpb_nongnghiep_trangtrai_phongthogiong);

            var lgp_nongnghiep_trangtrai_quanlychuongtraitho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý chuồng trại thỏ",
                Code = "lgp_nongnghiep_trangtrai_quanlychuongtraitho",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_nongnghiep_trangtrai_quanlychuongtraitho, lpb_nongnghiep_trangtrai_phongthogiong);

            var lgp_nongnghiep_trangtrai_channuoitho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Chăn nuôi thỏ",
                Code = "lgp_nongnghiep_trangtrai_channuoitho",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_nongnghiep_trangtrai_channuoitho, lpb_nongnghiep_trangtrai_phongthogiong);

            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban

            var pb_nongnghiep_trangtrai_phongthogiong = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng thỏ giống",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_nongnghiep_trangtrai_phongthogiong.Name,
                CodeLoaiPhongBan = lpb_nongnghiep_trangtrai_phongthogiong.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_nongnghiep_trangtrai_trangtraithogiong, pb_nongnghiep_trangtrai_phongthogiong);

            var pb_nongnghiep_trangtrai_phongkinhdoanh = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng kinh doanh thỏ giống",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan =lpb_nongnghiep_trangtrai_kinhdoanhthogiong.Name,
                CodeLoaiPhongBan = lpb_nongnghiep_trangtrai_kinhdoanhthogiong.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_nongnghiep_trangtrai_trangtraithogiong, pb_nongnghiep_trangtrai_phongkinhdoanh);

            #endregion


            #region --- Giải pháp

            var gp_nongnghiep_trangtrai_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_nongnghiep_trangtrai_quanlytochuc, tc_nongnghiep_trangtrai_trangtraithogiong);

            var gp_nongnghiep_trangtrai_kinhdoanh = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlydichvu.Name,
                CodeLoaiGiaiPhap = lgp_quanlydichvu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_nongnghiep_trangtrai_kinhdoanh, pb_nongnghiep_trangtrai_phongkinhdoanh);



            #endregion

            #region --- Nhân viên

            var nv_minh_nongnghiep_quanlytrangtrrai = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý hệ thống",
                GioiThieu = "Thiết kế và lập trình hệ thống",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.ToChuc.Them_NhanVien( tc_nongnghiep_trangtrai_trangtraithogiong, nv_minh_nongnghiep_quanlytrangtrrai, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_nongnghiep_quanlytrangtrrai);

            #endregion

            #region --- Công việc

            var cv_nongnghiep_trangtrai_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_nongnghiep_trangtrai_trangtraithogiong.Id,
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_nongnghiep_trangtrai_quanlytochuc, cv_nongnghiep_trangtrai_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_nongnghiep_quanlytrangtrrai, cv_nongnghiep_trangtrai_quanlytochuc);

            #endregion


            #endregion

            #region Hộ nông dân

            #region --- Loại tổ chức

            var ltc_nongnghiep_honongdan = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Hộ nông dân",
                Code = "ltc_nongnghiep_honongdan"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_nongnghiep, ltc_nongnghiep_honongdan);

            #endregion

            #region --- Tổ chức

            var tc_nongnghiep_honongdan_honuoitho = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Hộ nuôi thỏ",
                CodeLoaiToChuc = ltc_nongnghiep_honongdan.Code,
                LoaiToChuc = ltc_nongnghiep_honongdan.Name,
                VietTat = "hnt",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_nongnghiep_honongdan_honuoitho);

            #endregion

            #region --- Loại phòng ban




            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_nongnghiep_honongdan);
            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlydichvu, ltc_nongnghiep_honongdan);

            var lgp_nongnghiep_honongdan_quanlytho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý thỏ ",
                Code = "lgp_nongnghiep_honongdan_quanlythog",
            });

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_nongnghiep_honongdan_quanlytho, ltc_nongnghiep_honongdan);

            
            var lgp_nongnghiep_honongdan_quanlychuongtraitho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý chuồng trại thỏ",
                Code = "lgp_nongnghiep_honongdan_quanlychuongtraitho",
            });

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_nongnghiep_honongdan_quanlychuongtraitho, ltc_nongnghiep_honongdan);

            var lgp_nongnghiep_honongdan_channuoitho = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Chăn nuôi thỏ",
                Code = "lgp_nongnghiep_honongdan_channuoitho",
            });

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_nongnghiep_honongdan_channuoitho, ltc_nongnghiep_honongdan);

            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            #endregion

            #region --- Giải pháp

            var gp_nongnghiep_honongdan_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_nongnghiep_honongdan_quanlytochuc, tc_nongnghiep_honongdan_honuoitho);

            #endregion

            #region --- Nhân viên

            var nv_minh_nongnghiep_quanlyhonongdan = await AC.NhanVien.Create(new NhanVien
            {

                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý hộ nông dân",
                GioiThieu = "Thiết kế và lập trình hệ thống",
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_nongnghiep_honongdan_honuoitho, nv_minh_nongnghiep_quanlyhonongdan, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_nongnghiep_quanlyhonongdan);

            #endregion

            #region --- Công việc

            var cv_nongnghiep_honongdan_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_nongnghiep_honongdan_honuoitho.Id,
                IdHeThong = ht_nongnghiep.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_nongnghiep_honongdan_quanlytochuc, cv_nongnghiep_honongdan_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_nongnghiep_quanlyhonongdan, cv_nongnghiep_honongdan_quanlytochuc);

            #endregion

            #endregion

            #endregion

            #region Ẩm thực

            #region Bếp

            #region --- Loại tổ chức

            var ltc_amthuc_bep = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà bếp",
                Code = "ltc_amthuc_nhabep"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_amthuc, ltc_amthuc_bep);

            #endregion

            #region --- Tổ chức

            var tc_amthuc_bepminhchau = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Bếp Minh Châu",
                CodeLoaiToChuc = ltc_amthuc_bep.Code,
                LoaiToChuc = ltc_amthuc_bep.Name,
                VietTat = "bmc",
                IdHeThong = ht_amthuc.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_amthuc_bepminhchau);

            #endregion

            #region --- Sàn
            await AC.ToChuc.Them_San(tc_amthuc_bepminhchau, san_amthuc_monanbaithuoc);
            #endregion

            #region --- Loại phòng ban

            var lpb_amthuc_bep_phongdichvu = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng kinh doanh",
                Code = "lpb_amthuc_bep_phongkinhdoanh"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_amthuc_bep, lpb_amthuc_bep_phongdichvu);

            var lpb_amthuc_phongbeptruong = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng bếp trưởng",
                Code = "lpb_amthuc_phongbeptruong"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_amthuc_bep, lpb_amthuc_phongbeptruong);

            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlydichvu, lpb_amthuc_bep_phongdichvu);

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_amthuc_bep);

            var lgp_amthuc_xaydungmon = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Xây dựng món",
                Code = "lgp_amthuc_xaydungmon",
            });
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_amthuc_xaydungmon, lpb_amthuc_phongbeptruong);

            #endregion

            #region --- Loại công việc

            var lcv_amthuc_xaydungcamnang = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng cẩm nang món ăn",
                Code = "lcv_amthuc_xaydungcamnangmonan"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_amthuc_xaydungmon, lcv_amthuc_xaydungcamnang);

            #endregion

            #region --- Loại dịch vụ

            var ldv_amthuc_monanbaithuoc = await AC.LoaiDichVu.Create(new LoaiDichVu
            {
                Name = "Món ăn bài thuốc",
                Code = "ldv_amthuc_monanbaithuoc",
            });
            await AC.LoaiToChuc.ThemLoaiDichVu(ltc_amthuc_bep, ldv_amthuc_monanbaithuoc);
            await AC.LoaiSan.ThemLoaiDichVu(ls_amthuc_yte_moanbaithuoc, ldv_amthuc_monanbaithuoc);



            #endregion

            #region --- Loại Hàng Hóa


            var lhh_amthuc_monanbaithuocxuongcot = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Món ăn dành cho người đau xương cốt",
                Code = "lhh_amthuc_monandanhchonguoidauxuongcot"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_amthuc_monanbaithuoc, lhh_amthuc_monanbaithuocxuongcot);

            #endregion

            #region --- Dịch vụ

            var dv_amthuc_monanbaithuochanoi = await AC.DichVu.Create(new DichVu
            {
                LoaiDichVu = ldv_amthuc_monanbaithuoc.Name,
                CodeLoaiDichVu = ldv_amthuc_monanbaithuoc.Code,
                Name = "Món ăn bài thuốc tại Hà Nội"
            });
            await AC.DichVu.SetToChuc(dv_amthuc_monanbaithuochanoi, tc_amthuc_bepminhchau);
            await AC.DichVu.SetSan(dv_amthuc_monanbaithuochanoi, san_amthuc_monanbaithuoc);

            #endregion

            #region --- Hàng Hóa

            var hh_amthuc_chandehamthuocbac = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Chân dê hầm thuốc bắc",
                IdToChuc = tc_amthuc_bepminhchau.Id,
                Tag = "#thitde #de #thuocbac #xuongkhop",
                Anh = "/Files/hh_03.jpg",
                TomTat = "<p> - Món ăn bổ dưỡng <br> - Dành cho bệnh nhân bị bệnh xương cốt</p>",
                Gia = "<p>- 100.000 vnđ/1 bát dành cho một người ăn <br> - 350.000 vnđ/1 nồi 4 người ăn</p>",
                LienHe = "<p>Minh Châu: 087654789<p> ",
                GioiThieu = ""

            });
            await AC.DichVu.ThemHangHoa(dv_amthuc_monanbaithuochanoi, hh_amthuc_chandehamthuocbac);
            await AC.HangHoa.SetSan(hh_amthuc_chandehamthuocbac, san_amthuc_monanbaithuoc);
            await AC.HangHoa.ThemLoaiHangHoa(hh_amthuc_chandehamthuocbac, lhh_amthuc_monanbaithuocxuongcot);

            #endregion

            #region --- Phòng ban

            var pb_amthuc_bep_phongdichvu = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng dịch vụ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_amthuc_bep_phongdichvu.Name,
                CodeLoaiPhongBan = lpb_amthuc_bep_phongdichvu.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_amthuc_bepminhchau, pb_amthuc_bep_phongdichvu);

            var pb_amthuc_bep_phongbeptruong = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng bếp trưởng",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_amthuc_phongbeptruong.Name,
                CodeLoaiPhongBan = lpb_amthuc_phongbeptruong.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_amthuc_bepminhchau, pb_amthuc_bep_phongbeptruong);

            #endregion

            #region --- Giải pháp

            var gp_amthuc_bepminhchau_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_amthuc_bepminhchau_quanlytochuc, tc_amthuc_bepminhchau);

            var gp_amthuc_bep_phongdichvu_quanlydichvu = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlydichvu.Name,
                CodeLoaiGiaiPhap = lgp_quanlydichvu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_amthuc_bep_phongdichvu_quanlydichvu, pb_amthuc_bep_phongdichvu);

            var gp_amthuc_bep_phongbeptruong_xaydungmon = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_amthuc_xaydungmon.Name,
                CodeLoaiGiaiPhap = lgp_amthuc_xaydungmon.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_amthuc_bep_phongbeptruong_xaydungmon, pb_amthuc_bep_phongbeptruong);

            #endregion

            #region  --- Nhân viên

            var nv_minh_amthuc_bep_tochuc_bepminhchau = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Founder",
                GioiThieu = "Quản lý tổ chức",
                IdHeThong = ht_amthuc.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_amthuc_bepminhchau, nv_minh_amthuc_bep_tochuc_bepminhchau, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_amthuc_bep_tochuc_bepminhchau);

            var nv_minh_amthuc_bepminhchau_phongdichvu = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý dịch vụ",
                GioiThieu = "Quản lý phòng dịch vụ",
                IdHeThong = ht_amthuc.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_amthuc_bep_phongdichvu, nv_minh_amthuc_bepminhchau_phongdichvu);
            await AC.ToChuc.Them_NhanVien(tc_amthuc_bepminhchau, nv_minh_amthuc_bepminhchau_phongdichvu);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_amthuc_bepminhchau_phongdichvu);

            var nv_minh_amthuc_bepminhchau_phongbeptruong = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý món",
                GioiThieu = "Quản lý phòng dịch vụ",
                IdHeThong = ht_amthuc.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_amthuc_bep_phongbeptruong, nv_minh_amthuc_bepminhchau_phongbeptruong);
            await AC.ToChuc.Them_NhanVien(tc_amthuc_bepminhchau, nv_minh_amthuc_bepminhchau_phongbeptruong);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_amthuc_bepminhchau_phongbeptruong);

            #endregion

            #region --- Công việc

            var cv_amthuc_bepminhchau_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_amthuc_bepminhchau.Id,
                IdHeThong = ht_amthuc.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_amthuc_bepminhchau_quanlytochuc, cv_amthuc_bepminhchau_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_amthuc_bep_tochuc_bepminhchau, cv_amthuc_bepminhchau_quanlytochuc);

            var cv_amthuc_bep_phongdichvu_xaydunghanghoa = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xaydungdichvu.Name,
                CodeLoaiCongViec = lcv_xaydungdichvu.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_amthuc_bepminhchau.Id,
                IdPhongBan = pb_amthuc_bep_phongdichvu.Id,
                IdHeThong = ht_amthuc.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_amthuc_bep_phongdichvu_quanlydichvu, cv_amthuc_bep_phongdichvu_xaydunghanghoa);
            await AC.NhanVien.ThemCongViec(nv_minh_amthuc_bepminhchau_phongdichvu, cv_amthuc_bep_phongdichvu_xaydunghanghoa);

            var cv_amthuc_bep_phongdichvu_banhang = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_banhang.Name,
                CodeLoaiCongViec = lcv_banhang.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_amthuc_bepminhchau.Id,
                IdPhongBan = pb_amthuc_bep_phongdichvu.Id,                
                IdHeThong = ht_amthuc.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_amthuc_bep_phongdichvu_quanlydichvu, cv_amthuc_bep_phongdichvu_banhang);
            await AC.NhanVien.ThemCongViec(nv_minh_amthuc_bepminhchau_phongdichvu, cv_amthuc_bep_phongdichvu_banhang);


            var cv_amthuc_bep_phongbeptruong_xaydungmon = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_amthuc_xaydungcamnang.Name,
                CodeLoaiCongViec = lcv_amthuc_xaydungcamnang.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_amthuc_bepminhchau.Id,
                IdPhongBan = pb_amthuc_bep_phongbeptruong.Id,
                IdHeThong = ht_amthuc.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_amthuc_bep_phongbeptruong_xaydungmon, cv_amthuc_bep_phongbeptruong_xaydungmon);
            await AC.NhanVien.ThemCongViec(nv_minh_amthuc_bepminhchau_phongbeptruong, cv_amthuc_bep_phongbeptruong_xaydungmon);

            #endregion

            #region --- Loại cẩm nang

            var lcn_sotay = await AC.LoaiCamNang.Create(new LoaiCamNang
            {
                Name = "Sổ tay",
                Code = "lcn_sotay",
            });

            var lcn_sach = await AC.LoaiCamNang.Create(new LoaiCamNang
            {
                Name = "Sách",
                Code = "lcn_sach",
            });

            var lcn_suutam = await AC.LoaiCamNang.Create(new LoaiCamNang
            {
                Name = "Sưu tầm",
                Code = "lcn_suutam",
            });

            #endregion

            #region --- Cẩm nang

            var cn_amthuc_70monanbaithuoc = await AC.CamNang.Create(new CamNang
            {
                Name = "70 Món ăn bài thuốc",
                CodeLoaiCamNang = lcn_sach.Code,
                LoaiCamNang = lcn_sach.Name
            }) ;
            await AC.CamNang.Them_ToChuc(cn_amthuc_70monanbaithuoc, tc_amthuc_bepminhchau);

            #endregion

            #region --- Chương cẩm nang

            var ccn_amthuc_tangcuongsinhluc = await AC.ChuongCamNang.Create(new ChuongCamNang
            {
                Name = "Món ăn giúp tăng cường sinh lực cho các cặp vợ chồng",
                Stt = 1,
            });
            await AC.CamNang.Them_Chuong(cn_amthuc_70monanbaithuoc, ccn_amthuc_tangcuongsinhluc);

            #endregion

            #region --- Món ăn

            var mon_amthuc_cudattiemhatsen = await AC.MonAn.Create(new MonAn{
                Name = "Cu đất tiềm hạt sen",                
            });
            

            #endregion

            #region --- Công thức

            var ct_amthuc_cudattiemhatsen = await AC.CongThuc.Create(new CongThuc
            {
                Name = "Cu đất tiềm hạt sen"
            });
            await AC.MonAn.Them_CongThuc(mon_amthuc_cudattiemhatsen, ct_amthuc_cudattiemhatsen);
            await AC.ChuongCamNang.Them_CongThuc(ccn_amthuc_tangcuongsinhluc,ct_amthuc_cudattiemhatsen);

            #endregion

            #region --- Loại nguyên liệu

            var lnl_amthuc_giasuc = await AC.LoaiNguyenLieu.Create(new LoaiNguyenLieu
            {
                Name = "Gia súc"
            });

            #endregion

            #region --- Nguyên liệu

            var nl_amthuc_lon = await AC.NguyenLieu.Create(new NguyenLieu
            {
                Name = "Lợn"
            });

            await AC.LoaiNguyenLieu.Them_NguyenLieu(lnl_amthuc_giasuc, nl_amthuc_lon);

            #endregion

            #region --- Giống nguyên liệu

            var gnl_amthuc_lonlandrace = await AC.GiongNguyenLieu.Create(new GiongNguyenLieu
            {
                Name = "Lợn Landrace"
            });

            await AC.NguyenLieu.Them_GiongNguyenLieu(nl_amthuc_lon, gnl_amthuc_lonlandrace);

            #endregion

            #region --- Bộ phận nguyên liệu

            var bpnl_amthuc_changiolon = await AC.BoPhanNguyenLieu.Create(new BoPhanNguyenLieu
            {
                Name = "Chân giò lợn"
            });

            await AC.NguyenLieu.Them_BoPhanNguyenLieu(nl_amthuc_lon, bpnl_amthuc_changiolon);

            #endregion

            #endregion

            #region Quán ăn

            #region --- Loại tổ chức

            var ltc_amthuc_quanan = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Quán ăn",
                Code = "ltc_amthuc_quanan"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_amthuc, ltc_amthuc_quanan);

            #endregion

            #region --- Tổ chức



            #endregion

            #region --- Loại phòng ban




            #endregion

            #region --- Loại giải pháp



            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            #endregion

            #region --- Giải pháp



            #endregion

            #endregion

            #region Nhà hàng

            #region --- Loại tổ chức

            var ltc_amthuc_nhahang = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Nhà hàng",
                Code = "ltc_amthuc_nhahang"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_amthuc, ltc_amthuc_nhahang);

            #endregion

            #region --- Tổ chức



            #endregion

            #region --- Loại phòng ban




            #endregion

            #region --- Loại giải pháp



            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            #endregion

            #region --- Giải pháp



            #endregion

            #endregion

            #endregion

            #region An ninh

            #region --- Loại phải pháp 

            var lgp_anninh_quanlydoituongbaove = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý đối tượng bảo vệ",
                Code = "lgp_anninh_quanlydoituongbaove",
            });

            #endregion

            #region --- Loại công việc 

            var lcv_anninh_quanlyhosodoituongbaove = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý hồ sơ đối tượng bảo vệ",
                Code = "lcv_anninh_quanlyhosodoituongbaove"
            });

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_quanlydoituongbaove, lcv_anninh_quanlyhosodoituongbaove);

            #endregion

            #region --- Loại tiện ích

            var lti_anninh_nguoidung_nguoiduocbaove = await AC.LoaiTienIch.Create(new LoaiTienIch
            {
                Name = "Người được bảo vệ",
                Code = "lti_anninh_nguoidung_nguoiduocbaove",
                CodeHeThong = CodeHeThong.AnNinh
            });

            #endregion

            #region --- Loại tín hiệu

            var lth_anninh_sos = await AC.LoaiTinHieu.Create(new LoaiTinHieu
            {
                Name = "SOS",
                Code = "lth_anninh_sos"
            });

            await AC.LoaiTinHieu.ThemTienIch(lth_anninh_sos, lti_anninh_nguoidung_nguoiduocbaove);


            #endregion

            #region Cơ quan công an

            #region --- Loại tổ chức

            var ltc_anninh_coquancongan = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Cơ quan công an",
                Code = "ltc_anninh_coquancongan"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_anninh, ltc_anninh_coquancongan);

            #endregion

            #region --- Tổ chức

            var tc_anninh_baoveanninhHoangMai = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Cơ quan công an quận Hoàng Mai",
                CodeLoaiToChuc = ltc_anninh_coquancongan.Code,
                LoaiToChuc = ltc_anninh_coquancongan.Name,
                VietTat = "conganquanhoangmai",
                IdHeThong = ht_anninh.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_anninh_baoveanninhHoangMai);

            #endregion

            #region --- Loại phòng ban




            #endregion

            #region --- Loại giải pháp



            #endregion

            #region --- Loại dịch vụ



            #endregion

            #region --- Phòng ban



            #endregion

            #region --- Giải pháp



            #endregion

            #endregion

            #region Công ty bảo vệ

            #region --- Loại tổ chức

            var ltc_anninh_congtybaove = await AC.LoaiToChuc.Create(new LoaiToChuc
            {
                Name = "Công ty bảo vệ",
                Code = "ltc_anninh_congtybaove"
            });
            await AC.HeThong.ThemLoaiToChuc(ht_anninh, ltc_anninh_congtybaove);

            #endregion

            #region --- Tổ chức

            var tc_anninh_congtybaove_vihelm = await AC.ToChuc.Create(new ToChuc
            {
                Name = "Công ty bảo vệ Vihelm",
                CodeLoaiToChuc = ltc_anninh_congtybaove.Code,
                LoaiToChuc = ltc_anninh_congtybaove.Name,
                VietTat = "vihelms",
                IdHeThong = ht_anninh.Id
            });
            await AC.NguoiDung.ThemToChuc(nd_lebahongminh, tc_anninh_congtybaove_vihelm);

            #endregion

            #region --- Sàn
            await AC.ToChuc.Them_San(tc_anninh_congtybaove_vihelm, san_anninh_dichvubaovehanoi);
            #endregion

            #region --- Loại phòng ban

            //Chăm sóc người bệnh
            var lpb_anninh_baove_baove = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng bảo vệ",
                Code = "lpb_anninh_baove_phongbaove"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_anninh_congtybaove, lpb_anninh_baove_baove);

            var lpb_anninh_baove_phongdichvu = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng dịch vụ",
                Code = "lpb_anninh_baove_dichvu"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_anninh_congtybaove, lpb_anninh_baove_phongdichvu);

            var lpb_anninh_baove_phongcongnghethongtin = await AC.LoaiPhongBan.Create(new LoaiPhongBan
            {
                Name = "Phòng công nghệ thông tin",
                Code = "lpb_anninh_baove_congnghethongtin"
            });
            await AC.LoaiToChuc.ThemLoaiPhongBan(ltc_anninh_congtybaove, lpb_anninh_baove_phongcongnghethongtin);


            #endregion

            #region --- Loại giải pháp

            await AC.LoaiGiaiPhap.ThemLoaiToChuc(lgp_quanlytochuc, ltc_anninh_congtybaove);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_anninh_baove_baove);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_anninh_baove_phongdichvu);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlyphongban, lpb_anninh_baove_phongcongnghethongtin);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlywebsite, lpb_anninh_baove_phongcongnghethongtin);
            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_quanlydichvu, lpb_anninh_baove_phongdichvu);

            //Chăm sóc người bệnh --------------------------

            var lgp_anninh_baove_baove = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Bảo vệ",
                Code = "lgp_anninh_baove_baove",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_anninh_baove_baove, lpb_anninh_baove_baove);

            var lgp_anninh_baove_quanlyphongbaove = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý phòng bảo vệ",
                Code = "lgp_anninh_baove_quanlyphongbaove",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_anninh_baove_quanlyphongbaove, lpb_anninh_baove_baove);

            var lgp_anninh_baove_quanlythietbibaove = await AC.LoaiGiaiPhap.Create(new LoaiGiaiPhap
            {
                Name = "Quản lý thiết bị bảo vệ",
                Code = "lgp_anninh_baove_quanlythietbibaove",
            });

            await AC.LoaiGiaiPhap.ThemLoaiPhongBan(lgp_anninh_baove_quanlythietbibaove, lpb_anninh_baove_phongcongnghethongtin);

            


            #endregion

            #region --- Loại công việc

            //Chăm sóc người bệnh ---------------

            var lcv_anninh_baove_xulytinhhuongtructiep = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xử lý tình huống trực tiếp",
                Code = "lcv_anninh_baove_xulytinhhuongtructiep"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_baove, lcv_anninh_baove_xulytinhhuongtructiep);

            var lcv_anninh_baove_theodoicammera = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Trực và Theo dõi camera",
                Code = "lcv_anninh_baove_theodoicammera"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_baove, lcv_anninh_baove_theodoicammera);

            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_quanlyphongbaove, lcv_anninh_quanlyhosodoituongbaove);

            var lcv_anninh_baove_lapkehoachbaove = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Lập kế hoạch bảo vệ & phân ca",
                Code = "lcv_anninh_baove_lapkehoachbaovevaphanca"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_quanlyphongbaove, lcv_anninh_baove_lapkehoachbaove);

            var lcv_anninh_baove_nhansucphongbaove = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Xây dựng nhân sự phòng bảo vệ",
                Code = "lcv_anninh_baove_xaydungnhansuphongbaove"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_quanlyphongbaove, lcv_anninh_baove_nhansucphongbaove);

            var lcv_anninh_baove_taichinhphongbaove = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Tài chính phòng",
                Code = "lcv_anninh_baove_taichinhphongbaove"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_quanlyphongbaove, lcv_anninh_baove_taichinhphongbaove);

            var lcv_anninh_baove_quanlythietbiiot = await AC.LoaiCongViec.Create(new LoaiCongViec
            {
                Name = "Quản lý thiết bị iot",
                Code = "lcv_anninh_baove_quanlythietbiiot"
            });
            await AC.LoaiGiaiPhap.ThemLoaiCongViec(lgp_anninh_baove_quanlythietbibaove, lcv_anninh_baove_quanlythietbiiot);

            #endregion

            #region --- Loại dịch vụ

            var ldv_anninh_baove_baoveanninh = await AC.LoaiDichVu.Create(new LoaiDichVu
            {
                Name = "Bảo vệ an ninh",
                Code = "ldv_anninh_baove_baoveanninh",
            });
            await AC.LoaiToChuc.ThemLoaiDichVu(ltc_anninh_congtybaove, ldv_anninh_baove_baoveanninh);
            await AC.LoaiSan.ThemLoaiDichVu(ls_anninh_dichvubaove, ldv_anninh_baove_baoveanninh);

            #endregion

            #region --- Loại Hàng Hóa

            var lhh_anninh_baoveanninhcuahangcuahieu = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Bảo vệ an ninh cửa hàng cửa hiệu",
                Code = "lhh_iot_baoveanninhcuchangcuahieu"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_anninh_baove_baoveanninh, lhh_anninh_baoveanninhcuahangcuahieu);

            var lhh_anninh_baoveanninhnharieng = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Bảo vệ an ninh nhà riêng",
                Code = "lhh_iot_baoveanninhnharieng"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_anninh_baove_baoveanninh, lhh_anninh_baoveanninhnharieng);

            var lhh_anninh_baoveanninhhocsinh = await AC.LoaiHangHoa.Create(new LoaiHangHoa
            {
                Name = "Bảo vệ an ninh học sinh",
                Code = "lhh_iot_baoveanninhhocsinh"
            });
            await AC.LoaiDichVu.ThemLoaiHangHoa(ldv_anninh_baove_baoveanninh, lhh_anninh_baoveanninhhocsinh);

            #endregion

            #region --- Loại ca

            var lc_anninh_baove_baovetuxa = await AC.LoaiCa.Create(new LoaiCa
            {
                Code = "lc_anninh_baove_baove",
                Name = "Bảo vệ từ xa",
                CodeHeThong = CodeHeThong.AnNinh
            });

            #endregion

            #region --- Loại kế hoạch

            var lkh_anninh_kehoachbaovetuxa = await AC.LoaiKeHoach.Create(new LoaiKeHoach
            {
                Code = "lkh_anninh_kehoachbaovetuxa",
                Name = "Kế hoạch bảo vệ từ xa"
            });
            await AC.LoaiCa.ThemLoaiKeHoach(lc_anninh_baove_baovetuxa, lkh_anninh_kehoachbaovetuxa);


            #endregion

            #region --- Loại việc

            var lv_anninh_theodoicamera = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Theo dõi Cammera",
                Code = "lv_anninh_theodoicamera",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_anninh_kehoachbaovetuxa, lv_anninh_theodoicamera);

            var lv_anninh_tructinhieucaucuu = await AC.LoaiViec.Create(new LoaiViec
            {
                Name = "Trực tín hiệu cầu cứu",
                Code = "lv_anninh_tructinhieucaucuu",
                KyNang = true
            });
            await AC.LoaiKeHoach.ThemLoaiViec(lkh_anninh_kehoachbaovetuxa, lv_anninh_tructinhieucaucuu);

            #endregion


            #region --- Dịch vụ

            var dv_anninh_baove_baoveanninh = await AC.DichVu.Create(new DichVu
            {
                LoaiDichVu = ldv_anninh_baove_baoveanninh.Name,
                CodeLoaiDichVu = ldv_anninh_baove_baoveanninh.Code,
                Name = "Bảo vệ an ninh tại Hà Nội"
            });
            await AC.DichVu.SetToChuc(dv_anninh_baove_baoveanninh, tc_anninh_congtybaove_vihelm);
            await AC.DichVu.SetSan(dv_anninh_baove_baoveanninh,san_anninh_dichvubaovehanoi);

            #endregion

            #region --- Hàng Hóa

            var hh_anninh_baove_baoveanninh = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Bảo vệ cửa hàng cửa hiệu",
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,               
                Tag = "#baoveanninh ",
                Anh = "/Files/hh_06.jpg",
                TomTat = "<p> - Bảo vệ an ninh các của hàng cửa hiệu <br> - Trông xe<br> - Theo dõi camera 24/24 <br> - Thông báo và gọi cơ quan công an địa phương  nhanh chóng</p>",
                Gia = "<p> - Liên hệ để biết chi tiết </p>",
                LienHe = "<p>Hoài Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_anninh_baove_baoveanninh, hh_anninh_baove_baoveanninh);
            await AC.HangHoa.SetSan(hh_anninh_baove_baoveanninh,san_anninh_dichvubaovehanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_anninh_baove_baoveanninh, lhh_anninh_baoveanninhcuahangcuahieu);

            var hh_anninh_baove_baovenhadan = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Bảo vệ nhà riêng",
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                Tag = "#baoveanninh ",
                Anh = "/Files/hh_07.jpg",
                TomTat = "<p> - Bảo vệ an ninh nhà dân <br> - Trông xe<br> - Theo dõi camera 24/24 <br> - Thông báo và gọi cơ quan công an địa phương  nhanh chóng</p>",
                Gia = "<p> - Liên hệ để biết chi tiết </p>",
                LienHe = "<p>Hoài Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_anninh_baove_baoveanninh, hh_anninh_baove_baovenhadan);
            await AC.HangHoa.SetSan(hh_anninh_baove_baovenhadan, san_anninh_dichvubaovehanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_anninh_baove_baovenhadan, lhh_anninh_baoveanninhnharieng);

            var hh_anninh_baove_baovehocsinh = await AC.HangHoa.Create(new HangHoa
            {
                Name = "Bảo vệ học sinh",
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                Tag = "#baoveanninh ",
                Anh = "/Files/hh_08.jpeg",
                TomTat = "<p> - Bảo vệ học sinh <br> - Trông xe<br> - Theo dõi camera 24/24 <br> - Thông báo và gọi cơ quan công an địa phương  nhanh chóng</p>",
                Gia = "<p> - Liên hệ để biết chi tiết </p>",
                LienHe = "<p>Hoài Phương: 087654789<p> ",
                GioiThieu = "Chăm sóc các ca nhẹ, người già: \n Người chăm cần có những kỹ năng sau: Y tá:  Bác sĩ.."

            });
            await AC.DichVu.ThemHangHoa(dv_anninh_baove_baoveanninh, hh_anninh_baove_baovehocsinh);
            await AC.HangHoa.SetSan(hh_anninh_baove_baovehocsinh, san_anninh_dichvubaovehanoi);
            await AC.HangHoa.ThemLoaiHangHoa(hh_anninh_baove_baovehocsinh, lhh_anninh_baoveanninhhocsinh);

            #endregion

            #region --- Phòng ban

            var pb_anninh_viheml_phongbaove_so1 = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng bảo vệ số 1 - Khu vực quận Hoàng Mai",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_anninh_baove_baove.Name,
                CodeLoaiPhongBan = lpb_anninh_baove_baove.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_anninh_congtybaove_vihelm, pb_anninh_viheml_phongbaove_so1);

            var pb_anninh_viheml_phongdichvu = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng dịch vụ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_anninh_baove_phongdichvu.Name,
                CodeLoaiPhongBan = lpb_anninh_baove_phongdichvu.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_anninh_congtybaove_vihelm, pb_anninh_viheml_phongdichvu);

            var pb_anninh_viheml_phongcongnghethongtin = await AC.PhongBan.Create(new PhongBan
            {
                Name = "Phòng công nghệ",
                CreatedBy = nd_lebahongminh.Id,
                LoaiPhongBan = lpb_anninh_baove_phongcongnghethongtin.Name,
                CodeLoaiPhongBan = lpb_anninh_baove_phongcongnghethongtin.Code

            });
            await AC.ToChuc.Them_PhongBan(tc_anninh_congtybaove_vihelm, pb_anninh_viheml_phongcongnghethongtin);

            #endregion

            #region --- Giải pháp

            var gp_anninh_vihelm_quanlytochuc = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlytochuc.Name,
                CodeLoaiGiaiPhap = lgp_quanlytochuc.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_ToChuc(gp_anninh_vihelm_quanlytochuc, tc_anninh_congtybaove_vihelm);

            var gp_anninh_vihelm_phongbaove_quanlyphongban = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongbaove_quanlyphongban, pb_anninh_viheml_phongbaove_so1);

            var gp_anninh_vihelm_phongbaove_baove = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_anninh_baove_baove.Name,
                CodeLoaiGiaiPhap = lgp_anninh_baove_baove.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongbaove_baove, pb_anninh_viheml_phongbaove_so1);

            var gp_anninh_vihelm_phongbaove_quanlyphongbaove = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_anninh_baove_quanlyphongbaove.Name,
                CodeLoaiGiaiPhap = lgp_anninh_baove_quanlyphongbaove.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongbaove_quanlyphongbaove, pb_anninh_viheml_phongbaove_so1);

            var gp_anninh_vihelm_phongdichvu_quanlyphongban = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongdichvu_quanlyphongban, pb_anninh_viheml_phongdichvu);

            var gp_anninh_vihelm_phongdichvu_quanlydichvu = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlydichvu.Name,
                CodeLoaiGiaiPhap = lgp_quanlydichvu.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongdichvu_quanlydichvu, pb_anninh_viheml_phongdichvu);

            var gp_anninh_vihelm_phongcongnghe_quanlyphongban = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlyphongban.Name,
                CodeLoaiGiaiPhap = lgp_quanlyphongban.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongcongnghe_quanlyphongban, pb_anninh_viheml_phongcongnghethongtin);

            var gp_anninh_vihelm_phongcongnghe_quanlywebsite = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_quanlywebsite.Name,
                CodeLoaiGiaiPhap = lgp_quanlywebsite.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongcongnghe_quanlywebsite, pb_anninh_viheml_phongcongnghethongtin);

            var gp_anninh_vihelm_phongcongnghe_quanlythietbi = await AC.GiaiPhap.Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp_anninh_baove_quanlythietbibaove.Name,
                CodeLoaiGiaiPhap = lgp_anninh_baove_quanlythietbibaove.Code
            });
            await AC.GiaiPhap.SetGiaiPhap_PhongBan(gp_anninh_vihelm_phongcongnghe_quanlythietbi, pb_anninh_viheml_phongcongnghethongtin);

            #endregion

            #region --- Phận sự

            var ps_anninh_theodoi = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Theo dõi",
                Code = "ps_anninh_theodoi",
                CodeHeThong = CodeHeThong.AnNinh,
                PhanSuNhom = true,
                PhanSuCaNhan = true,
            });

            await AC.LoaiCa.ThemPhanSu(lc_anninh_baove_baovetuxa, ps_anninh_theodoi);

            var ps_anninh_baove = await AC.PhanSu.Create(new PhanSu
            {
                Name = "Bảo vệ",
                Code = "ps_anninh_baove",
                CodeHeThong = CodeHeThong.AnNinh,
                PhanSuNhom = true,
                PhanSuCaNhan = true
            });

            await AC.LoaiCa.ThemPhanSu(lc_anninh_baove_baovetuxa, ps_anninh_baove);

            #endregion

            #region --- Nhân viên

            var nv_minh_anninh_tochuc_baovevihelm = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Founder",
                GioiThieu = "Quản lý tổ chức",
                IdHeThong = ht_anninh.Id
            });
            await AC.ToChuc.Them_NhanVien(tc_anninh_congtybaove_vihelm, nv_minh_anninh_tochuc_baovevihelm, true);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_anninh_tochuc_baovevihelm);

            var nv_minh_anninh_tochuc_baovevihelm_phongbaove = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý bảo vệ",
                GioiThieu = "Quản lý phòng bảo vệ",
                IdHeThong = ht_anninh.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_anninh_viheml_phongbaove_so1, nv_minh_anninh_tochuc_baovevihelm_phongbaove);
            await AC.ToChuc.Them_NhanVien(tc_anninh_congtybaove_vihelm, nv_minh_anninh_tochuc_baovevihelm_phongbaove);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_anninh_tochuc_baovevihelm_phongbaove);
            await AC.PhongBan.ThemPhanSuNhanVien(pb_anninh_viheml_phongbaove_so1, nv_minh_anninh_tochuc_baovevihelm_phongbaove, ps_anninh_theodoi);

            var nv_minh_anninh_tochuc_baovevihelm_phongdichvu = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý dịch vụ",
                GioiThieu = "Quản lý phòng dịch vụ",
                IdHeThong = ht_anninh.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_anninh_viheml_phongdichvu, nv_minh_anninh_tochuc_baovevihelm_phongdichvu);
            await AC.ToChuc.Them_NhanVien(tc_anninh_congtybaove_vihelm, nv_minh_anninh_tochuc_baovevihelm_phongdichvu);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_anninh_tochuc_baovevihelm_phongdichvu);

            var nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin = await AC.NhanVien.Create(new NhanVien
            {
                CreatedBy = nd_lebahongminh.Id,
                Phone = "0981481527",
                Name = "Lê Bá Hồng Minh",
                VaiTro = "Quản lý công nghệ thông tin",
                GioiThieu = "Quản lý phòng dịch vụ",
                IdHeThong = ht_anninh.Id
            });
            await AC.PhongBan.Them_NhanVien(pb_anninh_viheml_phongcongnghethongtin, nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin);
            await AC.ToChuc.Them_NhanVien(tc_anninh_congtybaove_vihelm, nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin);
            await AC.NguoiDung.ThemNhanVien(nd_lebahongminh, nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin);

            #endregion

            #region --- Công việc

            var cv_anninh_vihelm_quanlytochuc = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhansutochuc.Name,
                CodeLoaiCongViec = lcv_quanlynhansutochuc.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_quanlytochuc, cv_anninh_vihelm_quanlytochuc);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm, cv_anninh_vihelm_quanlytochuc);


            var cv_anninh_vihelm_phongbaove_quanlyphongban = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_quanlynhanvienphongban.Name,
                CodeLoaiCongViec = lcv_quanlynhanvienphongban.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_quanlyphongban, cv_anninh_vihelm_phongbaove_quanlyphongban);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_quanlyphongban);

            var cv_anninh_vihelm_phongbaove_xulytinhhuong = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_xulytinhhuongtructiep.Name,
                CodeLoaiCongViec = lcv_anninh_baove_xulytinhhuongtructiep.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_baove, cv_anninh_vihelm_phongbaove_xulytinhhuong);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_xulytinhhuong);

            var cv_anninh_vihelm_phongbaove_theodoicammera = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_theodoicammera.Name,
                CodeLoaiCongViec = lcv_anninh_baove_theodoicammera.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_baove, cv_anninh_vihelm_phongbaove_theodoicammera);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_theodoicammera);

            var cv_anninh_vihelm_phongbaove_quanlyhosodoituong = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_quanlyhosodoituongbaove.Name,
                CodeLoaiCongViec = lcv_anninh_quanlyhosodoituongbaove.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_quanlyphongbaove, cv_anninh_vihelm_phongbaove_quanlyhosodoituong);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_quanlyhosodoituong);

            var cv_anninh_vihelm_phongbaove_lapkehoach = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_lapkehoachbaove.Name,
                CodeLoaiCongViec = lcv_anninh_baove_lapkehoachbaove.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_quanlyphongbaove, cv_anninh_vihelm_phongbaove_lapkehoach);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_lapkehoach);

            var cv_anninh_vihelm_phongbaove_xaydungnhansu = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_nhansucphongbaove.Name,
                CodeLoaiCongViec = lcv_anninh_baove_nhansucphongbaove.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_quanlyphongbaove, cv_anninh_vihelm_phongbaove_xaydungnhansu);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_xaydungnhansu);

            var cv_anninh_vihelm_phongbaove_taichinhphong = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_taichinhphongbaove.Name,
                CodeLoaiCongViec = lcv_anninh_baove_taichinhphongbaove.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongbaove_so1.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongbaove_quanlyphongbaove, cv_anninh_vihelm_phongbaove_taichinhphong);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongbaove, cv_anninh_vihelm_phongbaove_taichinhphong);

            var cv_anninh_vihelm_phongdichvu_xaydunghanghoa = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xaydungdichvu.Name,
                CodeLoaiCongViec = lcv_xaydungdichvu.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan =pb_anninh_viheml_phongdichvu.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongdichvu_quanlydichvu, cv_anninh_vihelm_phongdichvu_xaydunghanghoa);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongdichvu, cv_anninh_vihelm_phongdichvu_xaydunghanghoa);

            var cv_anninh_vihelm_phongdichvu_banhang = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_banhang.Name,
                CodeLoaiCongViec = lcv_banhang.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongdichvu.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongdichvu_quanlydichvu, cv_anninh_vihelm_phongdichvu_banhang);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongdichvu, cv_anninh_vihelm_phongdichvu_banhang);

            var cv_anninh_vihelm_phongcntt_xaydungweb = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_xaydungwebsite.Name,
                CodeLoaiCongViec = lcv_xaydungwebsite.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongcongnghethongtin.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongcongnghe_quanlywebsite, cv_anninh_vihelm_phongcntt_xaydungweb);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin, cv_anninh_vihelm_phongcntt_xaydungweb);

            var cv_anninh_vihelm_phongcntt_quanlythietbi = await AC.CongViec.Create(new CongViec
            {
                LoaiCongViec = lcv_anninh_baove_quanlythietbiiot.Name,
                CodeLoaiCongViec = lcv_anninh_baove_quanlythietbiiot.Code,
                CreatedBy = nd_lebahongminh.Id,
                IdToChuc = tc_anninh_congtybaove_vihelm.Id,
                IdPhongBan = pb_anninh_viheml_phongcongnghethongtin.Id,
                IdHeThong = ht_anninh.Id
            });
            await AC.GiaiPhap.ThemCongViec(gp_anninh_vihelm_phongcongnghe_quanlythietbi, cv_anninh_vihelm_phongcntt_quanlythietbi);
            await AC.NhanVien.ThemCongViec(nv_minh_anninh_tochuc_baovevihelm_phongcongnghethongtin, cv_anninh_vihelm_phongcntt_quanlythietbi);

            #endregion

            #region --- Loại đối tượng

            var ldt_anninh_cuahangcuahieu = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong
            {
                Name = "Cửa hàng cửa hiệu",
                Code = "lyn_anninh_cuahangcuahieu",
                CodeHeThong = CodeHeThong.AnNinh
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_anninh_cuahangcuahieu, lti_anninh_nguoidung_nguoiduocbaove);
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_anninh_cuahangcuahieu, lc_anninh_baove_baovetuxa);

            var ldt_anninh_quanbarvutruong = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong
            {
                Name = "Quán bar vũ trường",
                Code = "lyn_anninh_quanbarvutruong",
                CodeHeThong = CodeHeThong.AnNinh
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_anninh_quanbarvutruong, lti_anninh_nguoidung_nguoiduocbaove);
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_anninh_quanbarvutruong, lc_anninh_baove_baovetuxa);

            var ldt_anninh_karaoke = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong
            {
                Name = "Karaoke",
                Code = "lyn_anninh_karaoke",
                CodeHeThong = CodeHeThong.AnNinh
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_anninh_karaoke, lti_anninh_nguoidung_nguoiduocbaove);
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_anninh_karaoke, lc_anninh_baove_baovetuxa);


            var ldt_anninh_nharieng = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong
            {
                Name = "Nhà riêng",
                Code = "lyn_anninh_nharieng",
                CodeHeThong = CodeHeThong.AnNinh
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_anninh_nharieng, lti_anninh_nguoidung_nguoiduocbaove);
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_anninh_nharieng, lc_anninh_baove_baovetuxa);

            var ldt_anninh_hocsinh = await AC.LoaiDoiTuong.Create(new LoaiDoiTuong
            {
                Name = "Học sinh",
                Code = "lyn_anninh_hocsinh",
                CodeHeThong = CodeHeThong.AnNinh
            });
            await AC.LoaiDoiTuong.Them_LoaiTienIch(ldt_anninh_hocsinh, lti_anninh_nguoidung_nguoiduocbaove);
            await AC.LoaiDoiTuong.Them_LoaiCa(ldt_anninh_hocsinh, lc_anninh_baove_baovetuxa);

            #endregion

            #region --- Yếu nhân

            var dt_anninh_nharieng_300laclongquan = await AC.DoiTuong.Create(new DoiTuong
            {
                Name = "Nhà 300 Lạc Long Quân",
                CodeLoaiDoiTuong = ldt_anninh_nharieng.Code,
                LoaiDoiTuong = ldt_anninh_nharieng.Name
            });

            await AC.PhongBan.Them_DoiTuong(pb_anninh_viheml_phongbaove_so1, dt_anninh_nharieng_300laclongquan);

            #endregion


            #region --- Tiện ích

            var ti_anninh_nguoiduocbaove = await AC.TienIch.Create(new TienIch
            {
                LoaiTienIch = lti_anninh_nguoidung_nguoiduocbaove.Name,
                CodeLoaiTienIch = lti_anninh_nguoidung_nguoiduocbaove.Code,
                CodeHeThong = lti_anninh_nguoidung_nguoiduocbaove.CodeHeThong,
                VaiTroNguoiDung = "Chủ hộ",
                Name = "Nguyễn Văn Tuấn"
            });

            await AC.TienIch.Set_NguoiDung(ti_anninh_nguoiduocbaove, nd_lebahongminh);
            await AC.TienIch.Set_DoiTuong(ti_anninh_nguoiduocbaove, dt_anninh_nharieng_300laclongquan);

            

            #endregion


            #region --- Ca

            var ca_baove = await AC.Ca.Create(new Ca
            {
                CodeLoaiCa = lc_anninh_baove_baovetuxa.Code,
                LoaiCa = lc_anninh_baove_baovetuxa.Name
            });

            await AC.Ca.SetDoiTuong(ca_baove, dt_anninh_nharieng_300laclongquan);
            await AC.Ca.ThemPhanSuNhanVien(ca_baove, nv_minh_anninh_tochuc_baovevihelm_phongbaove, ps_anninh_theodoi);


            #endregion

            #endregion

            #endregion

            #region 
            #endregion

        }



    }
}
