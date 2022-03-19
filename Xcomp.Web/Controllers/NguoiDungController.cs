using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;

namespace Xcomp.Web.Controllers
{
    [Authorize]
    public class NguoiDungController : Controller
    {
        #region Người dùng

        public IActionResult nguoidung_home()
        {
            return View();
        }

        #endregion

        #region Nhân viên

        [AllowAnonymous]
        public IActionResult nhanvien()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult nhanvien_lamviec_mobile(string id)
        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult nhanvien_home()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult nhanvien_coquan()
        {
            return View();
        }

        public async Task<IActionResult> nhanvien_lamviec(string id = "")
        {
            var cv = await AC.CongViec.GetById(id);
            var lcv = await AC.LoaiCongViec.GetByCode(cv.CodeLoaiCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
            return View();
        }

        private async Task<bool> KiemTraNhanVienCongViec(string id)
        {
            if (id == "") return false;
            var cv = await AC.CongViec.GetById(id);
            if (cv == null) return false;
            if ((await AC.NhanVien.GetById(cv.IdNhanVien)).IdNguoiDung != User.Identity.Name) return false;

            TempData["idcv"] = id;
            TempData["codecv"] = cv.CodeLoaiCongViec;
            TempData["tencv"] = cv.LoaiCongViec;

            return true;
        }

        private string redirectKiemTra = "nhanvien_home";

        #endregion

        #region Công việc

        #region Tổ chức

        #region Quản lý nhân sự và phòng ban
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;

            ViewBag.id = id;

            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_phongban_create(string id, string idlpb)
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            ViewBag.id = id;
            PhongBanRequest model = new PhongBanRequest();

            model.IdCongViec = id;
            model.IdLoaiPhongBan = idlpb;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_phongban_create(PhongBanRequest model)
        {
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên phòng ban không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }
            model.IdNguoiTao = User.Identity.Name;
            await AC.PhongBan.Create_PhongBan(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_phongban_update(string id, string idpb)
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            ViewBag.id = id;
            //Kiểm tra người dùng có quyền update công việc hay không
            var pb = await AC.PhongBan.GetById(idpb);

            PhongBanRequest model = new PhongBanRequest()
            {
                Id = pb.Id,
                IdToChuc = pb.IdToChuc,
                LoaiPhongBan = (await AC.LoaiPhongBan.GetByCode(pb.CodeLoaiPhongBan)).Name,
                Ten = pb.Name,
                GioiThieu = pb.GioiThieu,
                TrangThai = pb.TrangThai,
                IdPhongBanMe = pb.IdPhongBanMe,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_phongban_update(PhongBanRequest model)
        {
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.PhongBan.Update_PhongBan(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_congviec_create(string id, string idlcv, string idgp)
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            ViewBag.id = id;
            CongViecRequest model = new CongViecRequest();
            model.IdCongViec = id;
            model.IdLoaiCongViec = idlcv;
            model.IdGiaiPhap = idgp;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_congviec_create(CongViecRequest model)
        {
            if (model.IdNhanVien == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhân viên";
                return View(model); // mật khẩu nhật không khớp return
            }
            model.IdNguoiTao = User.Identity.Name;
            await AC.CongViec.TaoCongViecMoi(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_congviec_update(string id, string idcv)
        {
            //Kiểm tra người dùng có quyền update công việc hay không
            var cv = await AC.CongViec.GetById(idcv);


            CongViecRequest model = new CongViecRequest()
            {
                Id = cv.Id,
                IdToChuc = cv.IdToChuc,
                IdLoaiCongViec = (await AC.LoaiCongViec.GetByCode(cv.CodeLoaiCongViec)).Id,
                IdNhanVien = cv.IdNhanVien,
                IdPhongBan = cv.IdPhongBan,
                TrangThai = cv.TrangThai,
                TrangThaiNhanVienLamViec = cv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = cv.TrangThai_NhanVienTraLoi,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_congviec_update(CongViecRequest model)
        {
            ViewBag.id = model.IdCongViec;
            var cv = await AC.CongViec.GetById(model.Id);
            cv.TrangThai = model.TrangThai;

            await AC.CongViec.Update(cv);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_nhanvien_create(string id, string idpb = null)
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            ViewBag.id = id;
            NhanVienRequest model = new NhanVienRequest();
            model.IdCongViec = id;
            model.IdPhongBan = idpb;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_nhanvien_create(NhanVienRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên nhân viên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }


            model.IdNguoiTao = User.Identity.Name;

            if (model.IdPhongBan == null)
            {
                await AC.NhanVien.Create_NhanVien(model, true);
            }
            else
            {
                await AC.NhanVien.Create_NhanVien(model);
            }



            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_nhanvien_update(string id, string idnv)
        {
            ViewBag.id = id;
            var nv = await AC.NhanVien.GetById(idnv);

            NhanVienRequest model = new NhanVienRequest()
            {
                Id = nv.Id,
                IdToChuc = nv.IdToChuc,
                IdPhongBan = nv.IdPhongBan,
                IdNguoiDung = nv.IdNguoiDung,
                TrangThai = nv.TrangThai,
                TrangThaiNhanVienLamViec = nv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = nv.TrangThai_NhanVienTraLoi,
                SoDienThoai = nv.Phone,
                Ten = nv.Name,
                GioiThieu = nv.GioiThieu,
                VaiTro = nv.VaiTro,
                IdCongViec = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_nhanvien_update(NhanVienRequest model)
        {
            ViewBag.id = model.Id;

            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.NhanVien.Update_NhanVien(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_tochuc_update(string id)
        {
            var cv = await AC.CongViec.GetById(id);
            var tc = await AC.ToChuc.GetById(cv.IdToChuc);



            ToChucRequest model = new ToChucRequest();
            model.Id = tc.Id;
            model.Ten = tc.Name;
            model.GioiThieu = tc.GioiThieu;
            model.TrangThai = tc.TrangThai;
            model.IdToChucMe = tc.IdToChucMe;
            model.IdCongViec = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_tochuc_update(ToChucRequest model)
        {

            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenCaThe = " Tên tổ chức không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.ToChuc.Update_ToChuc(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + model.IdCongViec);
        }


        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhansutochuc_giaiphap_create(string id, string idlgp, string idtc = null, string idpb = null)
        {
            if (idtc != null)
            {
                await AC.GiaiPhap.TaoMoiGiaiPhap_ToChuc(idtc, idlgp);
            }
            else
            if (idpb != null)
            {
                await AC.GiaiPhap.TaoMoiGiaiPhap_PhongBan(idpb, idlgp);
            }


            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhansutochuc/" + id);
        }
        #endregion

        #endregion

        #region Phòng ban

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_create(string id)
        {
            ViewBag.id = id;
            var cv = await AC.CongViec.GetById(id);
            NhomRequest model = new NhomRequest();
            
            model.IdPhongBan = cv.IdPhongBan;
            model.IdCongViec = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_create(NhomRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên nhóm không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.Nhom.Create_Nhom(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_update(string id, string idnhom)
        {
            ViewBag.id = id;
            var nhom = await AC.Nhom.GetById(idnhom);
            NhomRequest model = new NhomRequest();
            model.Id = idnhom;
            model.IdPhongBan = nhom.IdPhongBan;
            model.Ten = nhom.Name;
            model.GioiThieu = nhom.GioiThieu;
            model.TrangThai = nhom.TrangThai;            
            model.IdCongViec = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_update(NhomRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên nhóm không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.Nhom.Update_Nhom(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_nhanvien_add(string id, string idnhom)
        {
            ViewBag.id = id;
            ViewBag.idnhom = idnhom;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_nhanvien_add(string id, string idnhom, string idnv)
        {
            if (idnv != null)
            {
                await AC.Nhom.Add_NhanVien(idnhom, idnv);
            }    
            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_nhom_nhanvien_xoa(string id, string idnhom, string idnv)
        {
            await AC.Nhom.Xoa_NhanVien(idnhom, idnv);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_create(string id)
        {
            ViewBag.id = id;
            var cv = await AC.CongViec.GetById(id);
            NhanVienRequest model = new NhanVienRequest();
            model.IdToChuc = cv.IdToChuc;
            model.IdPhongBan = cv.IdPhongBan;
            model.IdCongViec = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_create(NhanVienRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên nhân viên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }


            model.IdNguoiTao = User.Identity.Name;

            await AC.NhanVien.Create_NhanVien(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_update(string id, string idnv)
        {
            ViewBag.id = id;
            var nv = await AC.NhanVien.GetById(idnv);

            NhanVienRequest model = new NhanVienRequest()
            {
                Id = nv.Id,
                IdToChuc = nv.IdToChuc,
                IdPhongBan = nv.IdPhongBan,
                IdNguoiDung = nv.IdNguoiDung,
                TrangThai = nv.TrangThai,
                TrangThaiNhanVienLamViec = nv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = nv.TrangThai_NhanVienTraLoi,
                SoDienThoai = nv.Phone,
                Ten = nv.Name,
                GioiThieu = nv.GioiThieu,
                VaiTro = nv.VaiTro,
                IdCongViec = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_update(NhanVienRequest model)
        {
            ViewBag.id = model.Id;

            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.NhanVien.Update_NhanVien(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }


        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_congviec_create(string id, string idlv, string idgp)
        {
            var cv = await AC.CongViec.GetById(id);
            CongViecRequest model = new CongViecRequest();
            model.IdToChuc = cv.IdToChuc;
            model.IdPhongBan = cv.IdPhongBan;
            model.IdLoaiCongViec = idlv;
            model.IdCongViec = id;
            model.IdGiaiPhap = idgp;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_congviec_create(CongViecRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.IdNhanVien == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhân viên";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.CongViec.TaoCongViecMoi(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_congviec_update(string id, string idcv)
        {
            //Kiểm tra người dùng có quyền update công việc hay không
            var cv = await AC.CongViec.GetById(idcv);


            CongViecRequest model = new CongViecRequest()
            {
                Id = cv.Id,
                IdToChuc = cv.IdToChuc,
                IdLoaiCongViec = (await AC.LoaiCongViec.GetByCode(cv.CodeLoaiCongViec)).Id,
                IdNhanVien = cv.IdNhanVien,
                IdPhongBan = cv.IdPhongBan,
                TrangThai = cv.TrangThai,
                TrangThaiNhanVienLamViec = cv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = cv.TrangThai_NhanVienTraLoi,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_congviec_update(CongViecRequest model)
        {
            ViewBag.id = model.IdCongViec;
            var cv = await AC.CongViec.GetById(model.Id);
            cv.TrangThai = model.TrangThai;

            await AC.CongViec.Update(cv);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_quanlynhanvienphongban_giaiphap_create(string id, string idlgp)
        {
            await AC.GiaiPhap.TaoMoiGiaiPhap_PhongBan(id, idlgp);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_quanlynhanvienphongban/" + id);
        }


        #endregion

        #region Dịch vụ

        #region Xây dựng dịch vụ & hàng hóa

        public async Task<IActionResult> nhanvien_congviec_lcv_xaydungdichvuvahanghoa(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }


        #endregion

        #region Bán hàng

        public async Task<IActionResult> nhanvien_congviec_lcv_banhang(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }


        #endregion

        #region



        #endregion

        #endregion

        #region Website

        #region Xây dựng website

        public async Task<IActionResult> nhanvien_congviec_lcv_xaydungwebsite(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }


        #endregion



        #region



        #endregion

        #endregion

        #region Xcomp

        #region Phòng giải pháp - Quản lý các sàn giao dịch

        public async Task<IActionResult> nhanvien_congviec_lcv_xcomp_quanlycacsan(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }
        #endregion

        #region Phòng giải pháp - Quản lý các hệ thống

        public async Task<IActionResult> nhanvien_congviec_lcv_xcomp_quanlycachethong(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion


        #region Phòng ẩm thực - Quản lý nguyên liệu

        public async Task<IActionResult> nhanvien_congviec_lcv_xcomp_amthuc_quanlynguyenlieu(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion


        #region Phòng ẩm thực - Quản lý món ăn

        public async Task<IActionResult> nhanvien_congviec_lcv_xcomp_amthuc_quanlymonan(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #endregion

        #region Y tế

        #region Phòng chăm sóc người bệnh - Quản lý hồ sơ bệnh nhân

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// Tạo Bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_create(string id)
        {
            ViewBag.id = id;

            DoiTuongRequest model = new DoiTuongRequest
            {
                IdCongViec = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_create(DoiTuongRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên bệnh nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Create_DoiTuong(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Cập nhật thông tin bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_update(string id, string idbn)
        {
            ViewBag.id = id;
            var bn = await AC.DoiTuong.GetById(idbn);
            DoiTuongRequest model = new DoiTuongRequest
            {
                IdCongViec = id,
                Id = idbn,
                GioiThieu = bn.GioiThieu,
                SoDienThoai = bn.Phone,
                Ten = bn.Name,
                TrangThai = bn.TrangThaiHoSo,
                CodeLoaiDoiTuong = bn.CodeLoaiDoiTuong
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_update(DoiTuongRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên bệnh nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_DoiTuong(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Thêm mới tiện ích dành cho bệnh nhân: Liên hệ với người nhà bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_tienich_create(string id, string idbn)
        {
            ViewBag.id = id;
            TienIchRequest model = new TienIchRequest
            {
                IdCongViec = id,
                IdDoiTuong = idbn
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_tienich_create(TienIchRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            if (model.VaiTro == null || model.VaiTro.Trim().Count() < 2)
            {
                ViewBag.ErrVaiTro = " Vai trò không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }


            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Them_TienIch(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Update thông tin tiên ích của bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <param name="idti"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_tienich_update(string id, string idbn, string idti)
        {
            ViewBag.id = id;
            var ti = await AC.TienIch.GetById(idti);

            TienIchRequest model = new TienIchRequest
            {
                IdCongViec = id,
                IdDoiTuong = idbn,
                Id = idti,
                Ten = ti.Name,
                SoDienThoai = ti.Phone,
                GioiThieu = ti.GioiThieu,
                VaiTro = ti.VaiTroNguoiDung,
                TrangThai = ti.TrangThaiHoSo, 
                IdLoaiTienIch = (await AC.LoaiTienIch.GetByCode(ti.CodeLoaiTienIch)).Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_quanlyhosobenhnhan_tienich_update(TienIchRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên bệnh nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            if (model.VaiTro == null || model.VaiTro.Trim().Count() < 2)
            {
                ViewBag.ErrVaiTro = " vai trò không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_TienIch(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        #endregion

        #region Chăm sóc người bệnh

        #region Phòng chăm sóc người bệnh - Lập kế hoạch chăm sóc & phân ca

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_create(string id, string idbn)
        {
            ViewBag.id = id;
            CaRequest model = new CaRequest
            {
                IdCongViec = id,
                IdDoiTuong = idbn
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_create(CaRequest model)
        {
            ViewBag.id = model.IdCongViec;
            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Them_Ca(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_update(string id, string idbn, string idca)
        {
            ViewBag.id = id;
            var ca = await AC.Ca.GetById(idca);

            CaRequest model = new CaRequest
            {
                IdCongViec = id,
                IdDoiTuong = idbn,
                Id = idca,
                IdLoaiCa = (await AC.LoaiCa.GetByCode(ca.CodeLoaiCa)).Id,
                GioiThieu = ca.GioiThieu,
                TrangThai = ca.TrangThaiHoSo
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_update(CaRequest model)
        {
            ViewBag.id = model.IdCongViec;
            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_Ca(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_nhansu(string id, string idbn, string idca)
        {
            ViewBag.id = id;
            ViewBag.idbn = idbn;
            ViewBag.idca = idca;

            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_nhansu_xoa(string id, string idbn, string idca, string ds, string idxoa)
        {

            await AC.Ca.Xoa_NhanVien(idca, idxoa, ds);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_nhansu?id=" + id + "&idbn=" + idbn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_nhansu_them(string id, string idbn, string idca, string ds, string idthem)
        {

            await AC.Ca.Them_NhanVien(await AC.Ca.GetById(idca), await AC.NhanVien.GetById(idthem), ds);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_nhansu?id=" + id + "&idbn=" + idbn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach(string id, string idbn, string idca)
        {
            ViewBag.id = id;
            ViewBag.idbn = idbn;
            ViewBag.idca = idca;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach_viec_create(ViecRequest model)
        {
            if (model.IdLoaiViec != null)
                await AC.Viec.Create_Viec(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach?id=" + model.IdCongViec + "&idbn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach_viec_update(ViecRequest model)
        {
            await AC.Viec.Update_Viec(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach?id=" + model.IdCongViec + "&idbn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach_viec_xoa(string id, string idbn, string idca, string idviec)
        {
            await AC.KeHoach.Xoa_Viec(idviec);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach?id=" + id + "&idbn=" + idbn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach_them(string id, string idbn, string idca, string idlkh)
        {
            await AC.KeHoach.ThemKeHoachTheoCa(idca, idlkh);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach?id=" + id + "&idbn=" + idbn + "&idca=" + idca);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach_dando_update(ViecRequest model)
        {
            await AC.KeHoach.Update_DanDo(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_lapkehoachchamsocvaphanca_ca_kehoach?id=" + model.IdCongViec + "&idbn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }

        #endregion

        #region Phòng chăm sóc người bệnh - Xây dựng nhân sự phòng chăm sóc

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc(string id)
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_create(string id, string idps)
        {
            ViewBag.id = id;
            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_create(PhanSuRequest model)
        {
            ViewBag.id = model.IdCongViec;

            if (model.IdNhanVien == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhân viên";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.NhanVien.ThemPhanSu(model);


            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_xoa(string id, string idps, string idnv)
        {

            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id,
                IdNhanVien = idnv
            };

            await AC.NhanVien.XoaPhanSu(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_nhom_create(string id, string idps)
        {
            ViewBag.id = id;
            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_nhom_create(PhanSuRequest model)
        {
            ViewBag.id = model.IdCongViec;

            if (model.IdNhom == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhóm";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.Nhom.ThemPhanSu(model);


            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc_phansu_nhom_xoa(string id, string idps, string idnhom)
        {

            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id,
                IdNhom = idnhom
            };

            await AC.Nhom.XoaPhanSu(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_yte_chamsocnguoibenh_xaydungnhansuphongchamsoc/" + model.IdCongViec);
        }


        #endregion

        #region Phòng chăm sóc người bệnh - Tài chính phòng

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_taichinhphongchamsoc(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #region Phòng chăm sóc người bệnh - Theo dõi chăm sóc người bệnh

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_theodoi(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #region Phòng chăm sóc người bệnh - Chăm sóc người bệnh

        public async Task<IActionResult> nhanvien_congviec_lcv_yte_chamsocnguoibenh_chamsoc(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion


        #endregion

        #region Cơ sở y tế

        #endregion

        #endregion

        #region IoT

        #region Miraway

        #region Phòng giải pháp - Xây dựng nghiệp vụ

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_xaydungnghiepvu(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_xaydungnghiepvu_quanlycaidat(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion


        #region Phòng kỹ thuật - Quản lý các loại thiết bị

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_quanlycacloaithietbi(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #region Phòng giải pháp - Quản lý các dòng máy

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_quanlycacdongmay(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #region Phòng vận hành - Quản lý kios

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_quanlycackios(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #region Phòng kinh doanh - Quản lý khách hàng

        public async Task<IActionResult> nhanvien_congviec_lcv_iot_miraway_khachhang(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion



        #endregion

        #endregion

        #region Ẩm thực

        #region Bếp

        #region Phòng bếp trưởng - Xây dựng cẩm nang món ăn

        public async Task<IActionResult> nhanvien_congviec_lcv_amthuc_xaydungcamnangmonan(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        #endregion

        #endregion

        #endregion

        #region An ninh

        #region Vihelm Bảo vệ

        #region Phòng công nghệ - Quản lý thiêt bị iot

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_quanlythietbiiot(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }



        #endregion

        #region Phòng bảo vệ - Xử lý tình huống trực tiếp

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xulytinhhuongtructiep(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }



        #endregion

        #region Phòng bảo vệ - Quản lý hồ sơ đối tượng bảo vệ

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        // <summary>
        /// Tạo Bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_create(string id)
        {
            ViewBag.id = id;

            DoiTuongRequest model = new DoiTuongRequest
            {
                IdCongViec = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_create(DoiTuongRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên yếu nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo yếu nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Create_DoiTuong(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Cập nhật thông tin bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_update(string id, string idyn)
        {
            ViewBag.id = id;
            var yn = await AC.DoiTuong.GetById(idyn);
            DoiTuongRequest model = new DoiTuongRequest
            {
                IdCongViec = id,
                Id = idyn,
                GioiThieu = yn.GioiThieu,
                SoDienThoai = yn.Phone,
                Ten = yn.Name,
                TrangThai = yn.TrangThaiHoSo,
                CodeLoaiDoiTuong = yn.CodeLoaiDoiTuong
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_update(DoiTuongRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên yếu nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_DoiTuong(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Thêm mới tiện ích dành cho bệnh nhân: Liên hệ với người nhà bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_tienich_create(string id, string idyn)
        {
            ViewBag.id = id;
            TienIchRequest model = new TienIchRequest
            {
                IdCongViec = id,
                IdDoiTuong = idyn
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_tienich_create(TienIchRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            if (model.VaiTro == null || model.VaiTro.Trim().Count() < 2)
            {
                ViewBag.ErrVaiTro = " Vai trò không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }


            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Them_TienIch(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        /// <summary>
        /// Update thông tin tiên ích của bệnh nhân
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idbn"></param>
        /// <param name="idti"></param>
        /// <returns></returns>
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_tienich_update(string id, string idyn, string idti)
        {
            ViewBag.id = id;
            var ti = await AC.TienIch.GetById(idti);

            TienIchRequest model = new TienIchRequest
            {
                IdCongViec = id,
                IdDoiTuong = idyn,
                Id = idti,
                Ten = ti.Name,
                SoDienThoai = ti.Phone,
                GioiThieu = ti.GioiThieu,
                VaiTro = ti.VaiTroNguoiDung,
                TrangThai = ti.TrangThaiHoSo,
                IdLoaiTienIch = (await AC.LoaiTienIch.GetByCode(ti.CodeLoaiTienIch)).Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_quanlyhosodoituongbaove_tienich_update(TienIchRequest model)
        {
            ViewBag.id = model.IdCongViec;
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenBenhNhan = " Tên yếu nhân không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            if (model.VaiTro == null || model.VaiTro.Trim().Count() < 2)
            {
                ViewBag.ErrVaiTro = " vai trò không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_TienIch(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }


        #endregion

        #region Phòng bảo vệ - Trực và Theo dõi camera

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_theodoicammera(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        

        #endregion

        #region Phòng bảo vệ - Lập kế hoạch bảo vệ & phân ca

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_create(string id, string idyn)
        {
            ViewBag.id = id;
            CaRequest model = new CaRequest
            {
                IdCongViec = id,
                IdDoiTuong = idyn
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_create(CaRequest model)
        {
            ViewBag.id = model.IdCongViec;
            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Them_Ca(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_update(string id, string idyn, string idca)
        {
            ViewBag.id = id;
            var ca = await AC.Ca.GetById(idca);

            CaRequest model = new CaRequest
            {
                IdCongViec = id,
                IdDoiTuong = idyn,
                Id = idca,
                IdLoaiCa = (await AC.LoaiCa.GetByCode(ca.CodeLoaiCa)).Id,
                GioiThieu = ca.GioiThieu,
                TrangThai = ca.TrangThaiHoSo
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_update(CaRequest model)
        {
            ViewBag.id = model.IdCongViec;
            //Tạo bệnh nhân
            model.IdNguoiTao = User.Identity.Name;
            await AC.DoiTuong.Update_Ca(model);

            //Thoát về màn hình chính 
            var cv = await AC.CongViec.GetById(model.IdCongViec);
            return Redirect("/nguoidung/nhanvien_congviec_" + cv.CodeLoaiCongViec + "/" + cv.Id);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_nhansu(string id, string idyn, string idca)
        {
            ViewBag.id = id;
            ViewBag.idyn = idyn;
            ViewBag.idca = idca;

            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_nhansu_xoa(string id, string idyn, string idca, string ds, string idxoa)
        {

            await AC.Ca.Xoa_NhanVien(idca, idxoa, ds);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_nhansu?id=" + id + "&idyn=" + idyn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_nhansu_them(string id, string idyn, string idca, string ds, string idthem)
        {

            await AC.Ca.Them_NhanVien(await AC.Ca.GetById(idca), await AC.NhanVien.GetById(idthem), ds);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_nhansu?id=" + id + "&idyn=" + idyn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach(string id, string idyn, string idca)
        {
            ViewBag.id = id;
            ViewBag.idyn = idyn;
            ViewBag.idca = idca;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach_viec_create(ViecRequest model)
        {
            if (model.IdLoaiViec != null)
                await AC.Viec.Create_Viec(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach?id=" + model.IdCongViec + "&idyn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach_viec_update(ViecRequest model)
        {
            await AC.Viec.Update_Viec(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach?id=" + model.IdCongViec + "&idyn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach_viec_xoa(string id, string idyn, string idca, string idviec)
        {
            await AC.KeHoach.Xoa_Viec(idviec);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach?id=" + id + "&idyn=" + idyn + "&idca=" + idca);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach_them(string id, string idyn, string idca, string idlkh)
        {
            await AC.KeHoach.ThemKeHoachTheoCa(idca, idlkh);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach?id=" + id + "&idyn=" + idyn + "&idca=" + idca);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach_dando_update(ViecRequest model)
        {
            await AC.KeHoach.Update_DanDo(model);
            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_lapkehoachbaovevaphanca_ca_kehoach?id=" + model.IdCongViec + "&idyn=" + model.IdBenhNhan + "&idca=" + model.IdCa);
        }
        #endregion

        #region Phòng bảo vệ - Xây dựng nhân sự phòng bảo vệ

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_create(string id, string idps)
        {
            ViewBag.id = id;
            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_create(PhanSuRequest model)
        {
            ViewBag.id = model.IdCongViec;

            if (model.IdNhanVien == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhân viên";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.NhanVien.ThemPhanSu(model);


            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_xoa(string id, string idps, string idnv)
        {

            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id,
                IdNhanVien = idnv
            };

            await AC.NhanVien.XoaPhanSu(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_nhom_create(string id, string idps)
        {
            ViewBag.id = id;
            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_nhom_create(PhanSuRequest model)
        {
            ViewBag.id = model.IdCongViec;

            if (model.IdNhom == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhóm";
                return View(model); // mật khẩu nhật không khớp return
            }

            await AC.Nhom.ThemPhanSu(model);


            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove/" + model.IdCongViec);
        }

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove_phansu_nhom_xoa(string id, string idps, string idnhom)
        {

            PhanSuRequest model = new PhanSuRequest()
            {
                IdPhanSu = idps,
                IdCongViec = id,
                IdNhom = idnhom
            };

            await AC.Nhom.XoaPhanSu(model);

            return Redirect("/nguoidung/nhanvien_congviec_lcv_anninh_baove_xaydungnhansuphongbaove/" + model.IdCongViec);
        }

        #endregion

        #region Phòng bảo vệ - Tài chính phòng

        public async Task<IActionResult> nhanvien_congviec_lcv_anninh_baove_taichinhphongbaove(string id = "")
        {
            if (!await KiemTraNhanVienCongViec(id)) return RedirectToAction(redirectKiemTra);
            var cv = await AC.CongViec.GetById(id);
            TempData["codelcv"] = cv.CodeLoaiCongViec;
            TempData["namelcv"] = cv.LoaiCongViec;
            TempData["idcv"] = cv.Id;
            ViewBag.id = id;
            return View();
        }



        #endregion

        #endregion


        #endregion

        #endregion

        #region Tổ chức

        [AllowAnonymous]
        public IActionResult tochuc()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult tochuc_home()
        {
            return View();
        }

        //[AllowAnonymous]
        //public IActionResult tochuc_huongdan()
        //{
        //    return View();
        //}

        public async Task<IActionResult> tochuc_giaiphap_create(string idtc, string idlgp)
        {
            await AC.GiaiPhap.TaoMoiGiaiPhap_ToChuc(idtc, idlgp);

            return Redirect("/nguoidung/tochuc_home");
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <returns></returns>
        public IActionResult tochuc_create()
        {
            ToChucRequest model = new ToChucRequest();
            return View(model);
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> tochuc_create(ToChucRequest model)
        {
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenCaThe = " Tên tổ chức không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            if (model.IdLoaiToChuc == null)
            {
                ViewBag.ErrLoaiToChuc = " Loại tổ chức không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;
            await AC.ToChuc.Create_ToChuc(model);
            return Redirect("/nguoidung/tochuc_home");
        }

        /// <summary>
        /// OK        
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> tochuc_update(string id)
        {
            //Chỉ người tạo mới cho Update tại đây
            var tc = await AC.ToChuc.GetById(id);

            if (tc == null || tc.CreatedBy != User.Identity.Name) return RedirectToAction("tochuc_home");

            ToChucRequest model = new ToChucRequest();
            model.Id = tc.Id;
            model.Ten = tc.Name;
            model.GioiThieu = tc.GioiThieu;
            model.TrangThai = tc.TrangThai;
            model.IdToChucMe = tc.IdToChucMe;
            return View(model);
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> tochuc_update(ToChucRequest model)
        {

            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTenCaThe = " Tên tổ chức không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.ToChuc.Update_ToChuc(model);

            return Redirect("/nguoidung/tochuc_home");
        }

        public async Task<IActionResult> tochuc_nhanvien_create(string id)
        {
            var tc = await AC.ToChuc.GetById(id);

            if (tc == null || tc.CreatedBy != User.Identity.Name) return RedirectToAction("tochuc_home");

            NhanVienRequest model = new NhanVienRequest();
            model.IdToChuc = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> tochuc_nhanvien_create(NhanVienRequest nhanvien)
        {
            if (nhanvien.Ten == null || nhanvien.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên không hợp lệ";
                return View(nhanvien); // mật khẩu nhật không khớp return
            }
                        
            nhanvien.IdNguoiTao = User.Identity.Name;

            await AC.NhanVien.Create_NhanVien(nhanvien, true);

            return Redirect("/nguoidung/tochuc_home");
        }

        public async Task<IActionResult> tochuc_nhanvien_update(string id)
        {
            //Kiểm tra người dùng có quyền update công việc hay không
            var nv = await AC.NhanVien.GetById(id);
            if (nv == null) return RedirectToAction("cathe_home");

            var tc = await AC.ToChuc.GetById(nv.IdToChuc);
            if (tc.CreatedBy != User.Identity.Name) return RedirectToAction("cathe_home");

            NhanVienRequest model = new NhanVienRequest()
            {
                Id = nv.Id,
                IdToChuc = nv.IdToChuc,
                IdNguoiDung = nv.IdNguoiDung,
                TrangThai = nv.TrangThai,
                TrangThaiNhanVienLamViec = nv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = nv.TrangThai_NhanVienTraLoi,
                SoDienThoai = nv.Phone,
                Ten = nv.Name,
                GioiThieu = nv.GioiThieu,
                VaiTro = nv.VaiTro
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> tochuc_nhanvien_update(NhanVienRequest model)
        {
            var nv = await AC.NhanVien.GetById(model.Id);
            if (model.Ten == null || model.Ten.Trim().Count() < 2)
            {
                ViewBag.ErrTen = " Tên không hợp lệ";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.NhanVien.Update_NhanVien(model);

            return Redirect("/nguoidung/tochuc_home");
        }

        public async Task<IActionResult> tochuc_congviec_create(string idtc, string idlcv, string idgp)
        {

            var tc = await AC.ToChuc.GetById(idtc);

            var lv = await AC.LoaiCongViec.GetById(idlcv);


            CongViecRequest model = new CongViecRequest();
            model.IdToChuc = tc.Id;
            model.IdLoaiCongViec = idlcv;
            model.IdGiaiPhap = idgp;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> tochuc_congviec_create(CongViecRequest model)
        {
            if (model.IdNhanVien == null)
            {
                ViewBag.ErrNhanVien = " Chưa chọn nhân viên";
                return View(model); // mật khẩu nhật không khớp return
            }

            model.IdNguoiTao = User.Identity.Name;

            await AC.CongViec.TaoCongViecMoi(model);

            return Redirect("/nguoidung/tochuc_home");
        }

        public async Task<IActionResult> tochuc_congviec_update(string id)
        {
            //Kiểm tra người dùng có quyền update công việc hay không
            var cv = await AC.CongViec.GetById(id);
            if (cv == null) return RedirectToAction("tochuc_home");
            //var tc = await AC.ToChuc.GetById(cv.IdToChuc);
            //if (tc.IdNguoiDung != User.Identity.Name) return RedirectToAction("tochuc_home");

            CongViecRequest model = new CongViecRequest()
            {
                Id = cv.Id,
                IdToChuc = cv.IdToChuc,
                IdLoaiCongViec = (await AC.LoaiCongViec.GetByCode(cv.CodeLoaiCongViec)).Id,
                IdNhanVien = cv.IdNhanVien,
                IdPhongBan = cv.IdPhongBan,
                TrangThai = cv.TrangThai,
                TrangThaiNhanVienLamViec = cv.TrangThai_NhanVienLamViec,
                TrangThaiNhanVienTraLoi = cv.TrangThai_NhanVienTraLoi,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> tochuc_congviec_update(CongViecRequest congviec)
        {
            var cv = await AC.CongViec.GetById(congviec.Id);
            cv.TrangThai = congviec.TrangThai;

            await AC.CongViec.Update(cv);

            return Redirect("/nguoidung/tochuc_home");
        }

        #endregion

        #region Thông báo

        public async Task<PartialViewResult> _thongbao(string id)
        {
            ViewBag.tb = await AC.ThongBao.GetById(id);
            return PartialView();
        }

        public PartialViewResult _listThongBao(int st = 1)
        {
            ViewBag.st = st;
            return PartialView();
        }


        #endregion

        #region Tín hiệu

        public async Task<PartialViewResult> _tinhieu(string id = "")
        {
            ViewBag.tinhieu = await AC.TinHieu.GetById(id);
            return PartialView();
        }


        #endregion
    }
}
