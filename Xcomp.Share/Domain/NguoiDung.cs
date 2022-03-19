using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class NguoiDung:BaseModel
    {
        public string Name { get; set; } 

        public string Phone { get; set; } 

        public string Email { get; set; } 

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public bool IsActive { get; set; }

        public string SmsOtpCode { get; set; }

        public DateTime? SmsOtpTime { get; set; }

        public Role Role { get; set; }

        public List<Permission> Permissions { get; set; }




        //Sự kiện người dùng ------------------------
        public List<string> DsIdTienIch { get; set; } 
        public NguoiDung ThemTienIch(string Idti)
        {
            if (DsIdTienIch == null) DsIdTienIch = new List<string>();
            if (DsIdTienIch.IndexOf(Idti) < 0) DsIdTienIch.Add(Idti);
            return this;

        }

        public NguoiDung XoaTienIch(string Idti)
        {
            if (DsIdTienIch != null) DsIdTienIch.Remove(Idti);
            return this;

        }
        // Danh sách nhân viên --------------------------------

        public List<string> DsIdNhanVien { get; set; }

        /// <summary>
        /// Thêm nhân viên cho tổ chức
        /// </summary>
        /// <param name="IdNhanVien"></param>
        /// <returns></returns>
        public NguoiDung ThemNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien == null) DsIdNhanVien = new List<string>();
            if (DsIdNhanVien.IndexOf(IdNhanVien) < 0) DsIdNhanVien.Add(IdNhanVien);
            return this;
        }

        public NguoiDung XoaNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien != null) DsIdNhanVien.Remove(IdNhanVien);
            return this;

        }


        //Account tổ chức mà người dùng sở hữu-------------------------------------
        public List<string> DsIdToChuc { get; set; } 

        public NguoiDung ThemToChuc(string IdToChuc)
        {
            if (DsIdToChuc == null) DsIdToChuc = new List<string>();
            if (DsIdToChuc.IndexOf(IdToChuc) < 0) DsIdToChuc.Add(IdToChuc);
            return this;

        }
        public NguoiDung XoaToChuc(string IdToChuc)
        {
            if (DsIdToChuc != null) DsIdToChuc.Add(IdToChuc);
            return this;

        }


        //Giao dịch ---------------------

        public List<string> DsIdGiaoDich { get; set; }

        public NguoiDung ThemGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich == null) DsIdGiaoDich = new List<string>();

            if (DsIdGiaoDich.IndexOf(Idgd) < 0) DsIdGiaoDich.Add(Idgd);
            return this;

        }

        public NguoiDung XoaGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich != null) DsIdGiaoDich.Remove(Idgd);
            return this;

        }
        //---------------------------------------
    }
}
