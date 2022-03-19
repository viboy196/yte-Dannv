using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class CongThuc:BaseModel
    {
        public string Name { get; set; } 

        public string GioiThieu { get; set; }

        //Món ăn ---------------------------
        public string IdMonAn { get; set; }

        public CongThuc SetMonAn(string Iddt)
        {
            IdMonAn = Iddt;
            return this;
        }

        public CongThuc XoaMonAn()
        {
            IdMonAn = null;
            return this;
        }

        //----------------------------------

        // Chương Cẩm Nang-----------------------------
        public List<string> DsIdChuongCamNang { get; set; }

        public CongThuc ThemChuongCamNang(string Idgp)
        {
            if (DsIdChuongCamNang == null) DsIdChuongCamNang = new List<string>();
            if (DsIdChuongCamNang.IndexOf(Idgp) < 0) DsIdChuongCamNang.Add(Idgp);
            return this;
        }

        public CongThuc XoaChuongCamNang(string Idgp)
        {
            if (DsIdChuongCamNang != null) DsIdChuongCamNang.Remove(Idgp);
            return this;
        }

    }
}
