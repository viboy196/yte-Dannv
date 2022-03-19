using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class GiaiPhap:BaseModel
    {
        public string LoaiGiaiPhap { get; set; } 

        public string CodeLoaiGiaiPhap { get; set; } 

        public string GioiThieu { get; set; } 

        //-----------------------------------------
        public string IdToChuc { get; set; } 

        public GiaiPhap SetToChuc(string idbd)
        {
            IdToChuc = idbd;
            return this;
        }

        public GiaiPhap XoaToChuc(string idbd)
        {
            IdToChuc = null;
            return this;
        }

        //-----------------------------------------
        public string IdPhongBan { get; set; }

        public GiaiPhap SetPhongBan(string idbd)
        {
            IdPhongBan = idbd;
            return this;
        }

        public GiaiPhap XoaPhongBan(string idbd)
        {
            IdPhongBan = null;
            return this;
        }

        //Đối tượng --------------------
        public List<string> DsIdDoiTuong { get; set; }

        public GiaiPhap ThemDoiTuong(string iddt)
        {
            if (DsIdDoiTuong == null) DsIdDoiTuong = new List<string>();
            if (DsIdDoiTuong.IndexOf(iddt) < 0) DsIdDoiTuong.Add(iddt);
            return this;
        }

        public GiaiPhap XoaDoiTuong(string iddt)
        {
            if (DsIdDoiTuong != null) DsIdDoiTuong.Remove(iddt);
            return this;
        }

        //Công việc --------------------
        public List<string> DsIdCongViec { get; set; } 

        public GiaiPhap ThemCongViec(string idcv)
        {
            if (DsIdCongViec == null) DsIdCongViec = new List<string>();
            if (DsIdCongViec.IndexOf(idcv) < 0) DsIdCongViec.Add(idcv);
            return this;
        }

        public GiaiPhap XoaCongViec(string idcv)
        {
            if (DsIdCongViec != null) DsIdCongViec.Remove(idcv);
            return this;
        }

        //Công việc --------------------
        public List<string> DsIdPhanSu { get; set; } 

        public GiaiPhap ThemPhanSu(string idcv)
        {
            if (DsIdPhanSu == null) DsIdPhanSu = new List<string>();
            if (DsIdPhanSu.IndexOf(idcv) < 0) DsIdPhanSu.Add(idcv);
            return this;
        }

        public GiaiPhap XoaPhanSu(string idcv)
        {
            if (DsIdPhanSu != null) DsIdPhanSu.Remove(idcv);
            return this;
        }
    }
}
