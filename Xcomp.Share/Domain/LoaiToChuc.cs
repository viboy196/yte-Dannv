using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiToChuc:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public bool View { get; set; } = true;

        //Hệ thống ----------------------------
        public string IdHeThong { get; set; }

        public LoaiToChuc SetHeThong(string IdHeThong)
        {
            this.IdHeThong = IdHeThong;
            return this;
        }

        public LoaiToChuc XoaHeThong()
        {
            this.IdHeThong = null;
            return this;
        }

        //Phòng ban---------------------------------
        public List<string> DsIdLoaiPhongBan { get; set; } 

        public LoaiToChuc ThemLoaiPhongBan(string IdLoaiPhongBan)
        {
            if (DsIdLoaiPhongBan == null) DsIdLoaiPhongBan = new List<string>();
            if (DsIdLoaiPhongBan.IndexOf(IdLoaiPhongBan) < 0) DsIdLoaiPhongBan.Add(IdLoaiPhongBan);
            return this;
        }
        public LoaiToChuc XoaLoaiPhongBan(string IdLoaiPhongban)
        {
            if (DsIdLoaiPhongBan != null) DsIdLoaiPhongBan.Remove(IdLoaiPhongban);
            return this;
        }


        //Loại Giải Pháp ----------------------
        public List<string> DsIdLoaiGiaiPhap { get; set; }

        public LoaiToChuc ThemLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap == null) DsIdLoaiGiaiPhap = new List<string>();
            if (DsIdLoaiGiaiPhap.IndexOf(idlgp) < 0) DsIdLoaiGiaiPhap.Add(idlgp);
            return this;
        }

        public LoaiToChuc XoaLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap != null) DsIdLoaiGiaiPhap.Remove(idlgp);
            return this;
        }

        //Loại Dịch vụ ----------------------
        public List<string> DsIdLoaiDichVu { get; set; } 

        public LoaiToChuc ThemLoaiDichVu(string idldv)
        {
            if (DsIdLoaiDichVu == null) DsIdLoaiDichVu = new List<string>();
            if (DsIdLoaiDichVu.IndexOf(idldv) < 0) DsIdLoaiDichVu.Add(idldv);
            return this;
        }

        public LoaiToChuc XoaLoaiDichVu(string idldv)
        {
            if (DsIdLoaiDichVu != null) DsIdLoaiDichVu.Remove(idldv);
            return this;
        }
       
        //------------------------------------
    }
}
