using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiCongViec:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string ThucHien { get; set; } = "WEB"; 

        public string GioiThieu { get; set; } 

        //Loại Giải pháp  ----------------------------

        public List<string> DsIdLoaiGiaiPhap { get; set; } 

        public LoaiCongViec ThemLoaiGiaiPhap(string Idlhscv)
        {
            if (DsIdLoaiGiaiPhap == null) DsIdLoaiGiaiPhap = new List<string>();
            if (DsIdLoaiGiaiPhap.IndexOf(Idlhscv) < 0) DsIdLoaiGiaiPhap.Add(Idlhscv);
            return this;
        }

        public LoaiCongViec XoaLoaiGiaiPhap(string Idlhscv)
        {
            if (DsIdLoaiGiaiPhap != null) DsIdLoaiGiaiPhap.Remove(Idlhscv);
            return this;
        }
        //-----------------------------
    }
}
