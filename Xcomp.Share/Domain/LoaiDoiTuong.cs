using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class LoaiDoiTuong:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public CodeHeThong CodeHeThong { get; set; }

        //Loại Giải Pháp ----------------------
        public List<string> DsIdLoaiTienIch { get; set; }

        public LoaiDoiTuong ThemLoaiTienIch(string idlgp)
        {
            if (DsIdLoaiTienIch == null) DsIdLoaiTienIch = new List<string>();
            if (DsIdLoaiTienIch.IndexOf(idlgp) < 0) DsIdLoaiTienIch.Add(idlgp);
            return this;
        }

        public LoaiDoiTuong XoaLoaiTienIch(string idlgp)
        {
            if (DsIdLoaiTienIch != null) DsIdLoaiTienIch.Remove(idlgp);
            return this;
        }

        //Loại Giải Pháp ----------------------
        public List<string> DsIdLoaiCa { get; set; }

        public LoaiDoiTuong ThemLoaiCa(string idlgp)
        {
            if (DsIdLoaiCa == null) DsIdLoaiCa = new List<string>();
            if (DsIdLoaiCa.IndexOf(idlgp) < 0) DsIdLoaiCa.Add(idlgp);
            return this;
        }

        public LoaiDoiTuong XoaLoaiCa(string idlgp)
        {
            if (DsIdLoaiCa != null) DsIdLoaiCa.Remove(idlgp);
            return this;
        }
    }
}
