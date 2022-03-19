using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class LoaiCa:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public CodeHeThong CodeHeThong { get; set; }

       

        //Phận sự trong loại ca-----------------
        public List<string> DsIdPhanSu { get; set; } 

        public LoaiCa ThemPhanSu(string idps)
        {
            if (DsIdPhanSu == null) DsIdPhanSu = new List<string>();
            if (DsIdPhanSu.IndexOf(idps) < 0) DsIdPhanSu.Add(idps);
            return this;
        }

        public LoaiCa XoaPhanSu(string idps)
        {
            if (DsIdPhanSu != null) DsIdPhanSu.Remove(idps);
            return this;
        }

        //Loại Kế Hoạch ----------------------
        public List<string> DsIdLoaiKeHoach { get; set; } 

        public LoaiCa ThemLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach == null) DsIdLoaiKeHoach = new List<string>();
            if (DsIdLoaiKeHoach.IndexOf(idlgp) < 0) DsIdLoaiKeHoach.Add(idlgp);
            return this;
        }

        public LoaiCa XoaLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach != null) DsIdLoaiKeHoach.Remove(idlgp);
            return this;
        }

        //Loại hàng hóa-------------------------------------
        public List<string> DsIdLoaiHangHoa { get; set; }

        public LoaiCa ThemLoaiHangHoa(string Idlhh)
        {
            if (DsIdLoaiHangHoa == null) DsIdLoaiHangHoa = new List<string>();
            if (DsIdLoaiHangHoa.IndexOf(Idlhh) < 0) DsIdLoaiHangHoa.Add(Idlhh);
            return this;
        }

        public LoaiCa XoaLoaiHangHoa(string Idlhh)
        {
            if (DsIdLoaiHangHoa != null) DsIdLoaiHangHoa.Remove(Idlhh);
            return this;
        }
        //-----------------------------------------

        //Loại đối tượng ----------------------
        public List<string> DsIdLoaiDoiTuong { get; set; }

        public LoaiCa ThemLoaiDoiTuong(string idlgp)
        {
            if (DsIdLoaiDoiTuong == null) DsIdLoaiDoiTuong = new List<string>();
            if (DsIdLoaiDoiTuong.IndexOf(idlgp) < 0) DsIdLoaiDoiTuong.Add(idlgp);
            return this;
        }

        public LoaiCa XoaLoaiDoiTuong(string idlgp)
        {
            if (DsIdLoaiDoiTuong != null) DsIdLoaiDoiTuong.Remove(idlgp);
            return this;
        }
    }
}
