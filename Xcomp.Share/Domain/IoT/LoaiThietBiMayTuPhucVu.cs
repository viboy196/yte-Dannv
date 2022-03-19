using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiThietBiMayTuPhucVu:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        //Loại máy --------------------
        public List<string> DsIdLoaiMayTuPhucVu { get; set; }

        public LoaiThietBiMayTuPhucVu ThemLoaiMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiMayTuPhucVu == null) DsIdLoaiMayTuPhucVu = new List<string>();
            if (DsIdLoaiMayTuPhucVu.IndexOf(Idltc) < 0) DsIdLoaiMayTuPhucVu.Add(Idltc);
            return this;
        }

        public LoaiThietBiMayTuPhucVu XoaLoaiMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiMayTuPhucVu != null) DsIdLoaiMayTuPhucVu.Remove(Idltc);
            return this;
        }

    }
}
