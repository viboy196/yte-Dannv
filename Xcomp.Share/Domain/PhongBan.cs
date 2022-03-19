using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class PhongBan:BaseModel
    {
        public string Name { get; set; }

        public string LoaiPhongBan { get; set; } 

        public string CodeLoaiPhongBan { get; set; }

        public string GioiThieu { get; set; }

        public TrangThaiPhongBan TrangThai { get; set; } = TrangThaiPhongBan.DangHoatDong;

        //Tổ chức --------------------
        public string IdToChuc { get; set; }

        public PhongBan SetToChuc(string Idtc)
        {
            IdToChuc = Idtc;
            return this;
        }

        public PhongBan XoaToChuc()
        {
            IdToChuc = null;
            return this;
        }

        // Giải pháp-----------------------------
        public List<string> DsIdGiaiPhap { get; set; }

        public PhongBan ThemGiaiPhap(string Idgp)
        {
            if (DsIdGiaiPhap == null) DsIdGiaiPhap = new List<string>();
            if (DsIdGiaiPhap.IndexOf(Idgp) < 0) DsIdGiaiPhap.Add(Idgp);
            return this;
        }

        public PhongBan XoaGiaiPhap(string Idgp)
        {
            if (DsIdGiaiPhap != null) DsIdGiaiPhap.Remove(Idgp);
            return this;
        }

        //Tổ chức mẹ con ---------------------------------------
        public List<string> DsIdPhongBanCon { get; set; } 
        public string IdPhongBanMe { get; set; } = null!;

        public PhongBan ThemPhongBanCon(string IdPhongBan)
        {
            if (DsIdPhongBanCon == null) DsIdPhongBanCon = new List<string>();
            if (DsIdPhongBanCon.IndexOf(IdPhongBan) < 0) DsIdPhongBanCon.Add(IdPhongBan);
            return this;

        }

        public PhongBan XoaPhongBanCon(string IdPhongBan)
        {
            if (DsIdPhongBanCon != null) DsIdPhongBanCon.Remove(IdPhongBan);
            return this;

        }
        // Danh sách nhân viên --------------------------------

        public List<string> DsIdNhanVien { get; set; } 

        /// <summary>
        /// Thêm nhân viên cho tổ chức
        /// </summary>
        /// <param name="IdNhanVien"></param>
        /// <returns></returns>
        public PhongBan ThemNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien == null) DsIdNhanVien = new List<string>();
            if (DsIdNhanVien.IndexOf(IdNhanVien) < 0) DsIdNhanVien.Add(IdNhanVien);
            return this;
        }

        public PhongBan XoaNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien != null) DsIdNhanVien.Remove(IdNhanVien);
            return this;

        }

        //Giao dịch ---------------------

        public List<string> DsIdGiaoDich { get; set; }

        public PhongBan ThemGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich == null) DsIdGiaoDich = new List<string>();

            if (DsIdGiaoDich.IndexOf(Idgd) < 0) DsIdGiaoDich.Add(Idgd);
            return this;

        }

        public PhongBan XoaGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich != null) DsIdGiaoDich.Remove(Idgd);
            return this;

        }
        //Nhóm ---------------------

        public List<string> DsIdNhom { get; set; } 

        public PhongBan ThemNhom(string Idgd)
        {
            if (DsIdNhom == null) DsIdNhom = new List<string>();

            if (DsIdNhom.IndexOf(Idgd) < 0) DsIdNhom.Add(Idgd);
            return this;

        }

        public PhongBan XoaNhom(string Idgd)
        {
            if (DsIdNhom != null) DsIdNhom.Remove(Idgd);
            return this;

        }
        //-------------------------------
    }
}
