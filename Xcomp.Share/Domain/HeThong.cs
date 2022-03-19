using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class HeThong:BaseModel
    {
        public string Name { get; set; }

        public string LinhVuc { get; set; }

        public CodeHeThong CodeHeThong { get; set; } 

        public string Code { get; set; } 

        public string Url { get; set; } 

        public string ThuongHieu { get; set; } 

        public string GioiThieu { get; set; }

        public string Logo { get; set; }

        //Loại tổ chức của hệ thống --------------------
        public List<string> DsIdLoaiToChuc { get; set; }

        public HeThong ThemLoaiToChuc(string Idltc)
        {
            if (DsIdLoaiToChuc == null) DsIdLoaiToChuc = new List<string>();
            if (DsIdLoaiToChuc.IndexOf(Idltc) < 0) DsIdLoaiToChuc.Add(Idltc);
            return this;
        }

        public HeThong XoaLoaiToChuc(string Idltc)
        {
            if (DsIdLoaiToChuc != null)  DsIdLoaiToChuc.Remove(Idltc);
            return this;
        }
        
        //-----------------------

    }
}
