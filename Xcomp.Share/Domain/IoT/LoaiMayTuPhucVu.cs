using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiMayTuPhucVu:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public string DongMayTuPhucVu { get; set; }

        public string CodeDongMayTuPhucVu { get; set; }

        //Loại tính năng --------------------
        public List<string> DsIdLoaiTinhNangMayTuPhucVu { get; set; }

        public LoaiMayTuPhucVu ThemLoaiTinhNangMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiTinhNangMayTuPhucVu == null) DsIdLoaiTinhNangMayTuPhucVu = new List<string>();
            if (DsIdLoaiTinhNangMayTuPhucVu.IndexOf(Idltc) < 0) DsIdLoaiTinhNangMayTuPhucVu.Add(Idltc);
            return this;
        }

        public LoaiMayTuPhucVu XoaLoaiTinhNangMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiTinhNangMayTuPhucVu != null) DsIdLoaiTinhNangMayTuPhucVu.Remove(Idltc);
            return this;
        }

        //Loại thiết bị --------------------
        public List<string> DsIdLoaiThietBiMayTuPhucVu { get; set; }

        public LoaiMayTuPhucVu ThemLoaiThietBiMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiThietBiMayTuPhucVu == null) DsIdLoaiThietBiMayTuPhucVu = new List<string>();
            if (DsIdLoaiThietBiMayTuPhucVu.IndexOf(Idltc) < 0) DsIdLoaiThietBiMayTuPhucVu.Add(Idltc);
            return this;
        }

        public LoaiMayTuPhucVu XoaLoaiThietBiMayTuPhucVu(string Idltc)
        {
            if (DsIdLoaiThietBiMayTuPhucVu != null) DsIdLoaiThietBiMayTuPhucVu.Remove(Idltc);
            return this;
        }
    }
}
