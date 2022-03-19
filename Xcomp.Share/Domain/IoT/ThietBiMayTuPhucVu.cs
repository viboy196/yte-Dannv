using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class ThietBiMayTuPhucVu:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiThietBiMayTuPhucVu { get; set; } 

        public string CodeLoaiThietBiMayTuPhucVu { get; set; } 

        public string GioiThieu { get; set; }

        //Máy --------------------
        public List<string> DsIdMayTuPhucVu { get; set; }

        public ThietBiMayTuPhucVu ThemMayTuPhucVu(string Idltc)
        {
            if (DsIdMayTuPhucVu == null) DsIdMayTuPhucVu = new List<string>();
            if (DsIdMayTuPhucVu.IndexOf(Idltc) < 0) DsIdMayTuPhucVu.Add(Idltc);
            return this;
        }

        public ThietBiMayTuPhucVu XoaMayTuPhucVu(string Idltc)
        {
            if (DsIdMayTuPhucVu != null) DsIdMayTuPhucVu.Remove(Idltc);
            return this;
        }
    }
}
