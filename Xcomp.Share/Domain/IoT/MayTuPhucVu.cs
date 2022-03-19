using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class MayTuPhucVu:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiMayTuPhucVu { get; set; } 

        public string CodeLoaiMayTuPhucVu { get; set; }

        public string GioiThieu { get; set; }

        //Thiết bị --------------------
        public List<string> DsIdThietBiMayTuPhucVu { get; set; }

        public MayTuPhucVu ThemThietBiMayTuPhucVu(string Idltc)
        {
            if (DsIdThietBiMayTuPhucVu == null) DsIdThietBiMayTuPhucVu = new List<string>();
            if (DsIdThietBiMayTuPhucVu.IndexOf(Idltc) < 0) DsIdThietBiMayTuPhucVu.Add(Idltc);
            return this;
        }

        public MayTuPhucVu XoaThietBiMayTuPhucVu(string Idltc)
        {
            if (DsIdThietBiMayTuPhucVu != null) DsIdThietBiMayTuPhucVu.Remove(Idltc);
            return this;
        }

        //Tính năng --------------------
        public List<string> DsIdTinhNangMayTuPhucVu { get; set; }

        public MayTuPhucVu ThemTinhNangMayTuPhucVu(string Idltc)
        {
            if (DsIdTinhNangMayTuPhucVu == null) DsIdTinhNangMayTuPhucVu = new List<string>();
            if (DsIdTinhNangMayTuPhucVu.IndexOf(Idltc) < 0) DsIdTinhNangMayTuPhucVu.Add(Idltc);
            return this;
        }

        public MayTuPhucVu XoaTinhNangMayTuPhucVu(string Idltc)
        {
            if (DsIdTinhNangMayTuPhucVu != null) DsIdTinhNangMayTuPhucVu.Remove(Idltc);
            return this;
        }

    }
}
