using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class TinhNangMayTuPhucVu:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiTinhNangMayTuPhucVu { get; set; } 

        public string CodeLoaiTinhNangMayTuPhucVu { get; set; } 

        public string GioiThieu { get; set; }

        //Máy --------------------
        public List<string> DsIdMayTuPhucVu { get; set; }

        public TinhNangMayTuPhucVu ThemMayTuPhucVu(string Idltc)
        {
            if (DsIdMayTuPhucVu == null) DsIdMayTuPhucVu = new List<string>();
            if (DsIdMayTuPhucVu.IndexOf(Idltc) < 0) DsIdMayTuPhucVu.Add(Idltc);
            return this;
        }

        public TinhNangMayTuPhucVu XoaMayTuPhucVu(string Idltc)
        {
            if (DsIdMayTuPhucVu != null) DsIdMayTuPhucVu.Remove(Idltc);
            return this;
        }
    }
}
