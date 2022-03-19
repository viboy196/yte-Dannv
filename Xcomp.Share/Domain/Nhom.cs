using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Nhom:BaseModel
    {
        public string Name { get; set; }
        public string GioiThieu { get; set; }

        public TrangThaiNhom TrangThai { get; set; }

        //----------------------------------
        public string IdPhongBan { get; set; } 

        public Nhom SetPhongBan(string Idpb)
        {
            IdPhongBan =Idpb;
            return this;
        }

        public Nhom XoaPhongBan()
        {
            IdPhongBan = null;
            return this;
        }
        

        // Danh sách nhân viên --------------------------------
        
        public List<string> DsIdNhanVien { get; set; }

        /// <summary>
        /// Thêm nhân viên cho tổ chức
        /// </summary>
        /// <param name="IdNhanVien"></param>
        /// <returns></returns>
        public Nhom ThemNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien == null) DsIdNhanVien = new List<string>();
            if (DsIdNhanVien.IndexOf(IdNhanVien) < 0) DsIdNhanVien.Add(IdNhanVien);
            return this;

        }

        public Nhom XoaNhanVien(string IdNhanVien)
        {
            if (DsIdNhanVien != null) DsIdNhanVien.Remove(IdNhanVien);
            return this;
        }
        //Danh sách lịch trực -----------------       
        public List<string> DsIdLich { get; set; }
        
        public Nhom ThemLich(string IdLich)
        {
            if (DsIdLich == null) DsIdLich = new List<string>();
            if (DsIdLich.IndexOf(IdLich) < 0) DsIdLich.Add(IdLich);
            return this;
        }

        public Nhom XoaLich(string IdLich)
        {
            if (DsIdLich != null) DsIdLich.Remove(IdLich);
            return this;

        }
    }
}
