using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class ToChuc:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiToChuc { get; set; } 

        public string CodeLoaiToChuc { get; set; } 

        public string VietTat { get; set; } 

        public string GioiThieu { get; set; }

        public string Url { get; set; }

        public TrangThaiToChuc TrangThai { get; set; } = TrangThaiToChuc.DangHoatDong; //TRạng thái của tổ chức

        public string IdHeThong { get; set; }
                
        public bool View { get; set; } = true;

        //Đối tượng ---------------------------
        public string IdDoiTuong { get; set; } 

        public ToChuc SetDoiTuong(string Iddt)
        {
            IdDoiTuong = Iddt;
            return this;
        }

        public ToChuc XoaDoiTuong()
        {
            IdDoiTuong = null;
            return this;
        }
        // Giải pháp-----------------------------
        public List<string> DsIdGiaiPhap { get; set; } 

        public ToChuc ThemGiaiPhap(string Idgp)
        {
            if (DsIdGiaiPhap == null) DsIdGiaiPhap = new List<string>();
            if (DsIdGiaiPhap.IndexOf(Idgp) < 0) DsIdGiaiPhap.Add(Idgp);
            return this;
        }

        public ToChuc XoaGiaiPhap(string Idgp)
        {
            if (DsIdGiaiPhap != null) DsIdGiaiPhap.Remove(Idgp);
            return this;
        }


        //----------------------------------
        public List<string> DsIdPhongBan { get; set; } 

        public ToChuc ThemPhongBan(string Idpb)
        {
            if (DsIdPhongBan == null) DsIdPhongBan = new List<string>();
            if (DsIdPhongBan.IndexOf(Idpb) < 0) DsIdPhongBan.Add(Idpb);
            return this;
        }

        public ToChuc XoaPhongBan(string Idpb)
        {
            if (DsIdPhongBan != null) DsIdPhongBan.Remove(Idpb);
            return this;
        }

        //----------------------------------
        public string IdTrangChu { get; set; }

        public List<string> DsIdTrang { get; set; }

        public ToChuc ThemTrang(string Idpb)
        {
            if (DsIdTrang == null) DsIdTrang = new List<string>();
            if (DsIdTrang.IndexOf(Idpb) < 0) DsIdTrang.Add(Idpb);
            return this;
        }

        public ToChuc XoaTrang(string Idpb)
        {
            if (DsIdTrang != null) DsIdTrang.Remove(Idpb);
            return this;
        }
        //Loại thiết bị sản suất-----------------------
        public ToChuc ThemLoaiThietBiSanXuat(string IdLoaiThietBi)
        {
            DS_Add(IdLoaiThietBi, "DsIdLoaiThietBiSanXuat");
            return this;
        }

        // Danh sách nhân viên --------------------------------
        public List<string> DsIdNhanVienToChuc { get; set; }
        public List<string> DsIdNhanVien { get; set; }

        /// <summary>
        /// Thêm nhân viên cho tổ chức
        /// </summary>
        /// <param name="IdNhanVien"></param>
        /// <returns></returns>
        public ToChuc ThemNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien == null) DsIdNhanVien = new List<string>();
            if (DsIdNhanVien.IndexOf(IdNhanVien) < 0) DsIdNhanVien.Add(IdNhanVien);
            return this;

        }

        public ToChuc ThemNhanVienToChuc(string IdNhanVien)
        {
            if (DsIdNhanVienToChuc == null) DsIdNhanVienToChuc = new List<string>();
            if (DsIdNhanVienToChuc.IndexOf(IdNhanVien) < 0) DsIdNhanVienToChuc.Add(IdNhanVien);
            return this;

        }

        //Tổ chức mẹ con ---------------------------------------
        public List<string> DsIdToChucCon { get; set; }
        public string IdToChucMe { get; set; } = null!;

        // Dành cho cơ sở y tế ----------------------------------
        public List<string> DsIdDichVu { get; set; } 
        public List<string> DsIdSan { get; set; } 


        public ToChuc SetNguoiTao(string Idnd)
        {
            CreatedBy = Idnd;
            return this;
        }

        public ToChuc XoaNguoiTao()
        {
            CreatedBy = null;
            return this;
        }


        public ToChuc ThemSan(string Ids)
        {
            if (DsIdSan == null) DsIdSan = new List<string>();
            if (DsIdSan.IndexOf(Ids) < 0) DsIdSan.Add(Ids);
            return this;
        }

        public ToChuc ThemDichVu(string Iddv)
        {
            if (DsIdDichVu == null) DsIdDichVu = new List<string>();
            if (DsIdDichVu.IndexOf(Iddv) < 0) DsIdDichVu.Add(Iddv);
            return this;
        }

        public ToChuc NhanThongBao(ThongBao tb)
        {
            QL_NhanThongBao(tb);
            return this;
        }
        public ToChuc GuiThongBao(ThongBao tb)
        {
            QL_GuiThongBao(tb);
            return this;
        }



        public ToChuc ThemToChucCon(string IdToChuc)
        {
            if (DsIdToChucCon == null) DsIdToChucCon = new List<string>();
            DsIdToChucCon.Add(IdToChuc);
            return this;

        }

        public ToChuc XoaToChucCon(string IdToChuc)
        {
            if (DsIdToChucCon == null) DsIdToChucCon = new List<string>();
            DsIdToChucCon.Remove(IdToChuc);
            return this;

        }
    }
}
