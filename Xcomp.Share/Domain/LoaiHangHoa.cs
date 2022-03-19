using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiHangHoa:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; }

        public string GioiThieu { get; set; } 

        public string IdLoaiMe { get; set; } 

        public string DsIdLoaiCon { get; set; } 

        //Loại dịch vụ ---------------------
        public List<string> DsIdLoaiDichVu { get; set; } 

        public LoaiHangHoa ThemLoaiDichVu(string Idldv)
        {
            if (DsIdLoaiDichVu == null) DsIdLoaiDichVu = new List<string>();
            if (DsIdLoaiDichVu.IndexOf(Idldv) < 0) DsIdLoaiDichVu.Add(Idldv);
            return this;
        }

        public LoaiHangHoa XoaLoaiDichVu(string Idldv)
        {
            if (DsIdLoaiDichVu != null) DsIdLoaiDichVu.Remove(Idldv);
            return this;
        }

        //Loại ca -------------------------
        public List<string> DsIdLoaiCa { get; set; } 

        public LoaiHangHoa ThemLoaiCa(string Idldv)
        {
            if (DsIdLoaiCa == null) DsIdLoaiCa = new List<string>();
            if (DsIdLoaiCa.IndexOf(Idldv) < 0) DsIdLoaiCa.Add(Idldv);
            return this;
        }

        public LoaiHangHoa XoaLoaiCa(string Idldv)
        {
            if (DsIdLoaiCa != null) DsIdLoaiCa.Remove(Idldv);
            return this;
        }
        //-------------------------------

    }
}
