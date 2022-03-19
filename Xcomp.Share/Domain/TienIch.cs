using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class TienIch:BaseModel
    {
        public string CodeLoaiTienIch { get; set; } 

        public string LoaiTienIch { get; set; } 

        public string VaiTroNguoiDung { get; set; } 

        public string GioiThieu { get; set; } = null!;

        //Thông tin để kết nối tiện ích với người dùng qua số Phone-------------------------
        public string Name { get; set; } 

        public string Phone { get; set; } 

        //Người Dùng ---------------------
        public string IdNguoidung { get; set; } 

        public TienIch SetNguoiDung(string idnd)
        {
            IdNguoidung = idnd;
            return this;
        }

        public TienIch XoaNguoiDung()
        {
            IdNguoidung = null;
            return this;
        }

        //---------------------------------------
        public string IdDoiTuong { get; set; } 

        public CodeHeThong CodeHeThong { get; set; }

        // Tín hiệu-----------------------------
        public List<string> DsIdTinHieu { get; set; }

        public TienIch ThemTinHieu(string Idgp)
        {
            if (DsIdTinHieu == null) DsIdTinHieu = new List<string>();
            if (DsIdTinHieu.IndexOf(Idgp) < 0) DsIdTinHieu.Add(Idgp);
            UpdatedAt = DateTime.Now;
            return this;
        }

        public TienIch XoaTinHieu(string Idgp)
        {
            if (DsIdTinHieu != null) DsIdTinHieu.Remove(Idgp);
            UpdatedAt = DateTime.Now;
            return this;
        }

    }
}
