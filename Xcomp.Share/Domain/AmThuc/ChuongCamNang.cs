using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class ChuongCamNang:BaseModel
    {
        public string Name { get; set; } 
                
        public string GioiThieu { get; set; }

        public int Stt { get; set; } = 0;

        //Cẩm nang ---------------------------
        public string IdCamNang { get; set; }

        public ChuongCamNang SetCamNang(string Iddt)
        {
            IdCamNang = Iddt;
            return this;
        }

        public ChuongCamNang XoaCamNang()
        {
            IdCamNang = null;
            return this;
        }

        // Giải pháp-----------------------------
        public List<string> DsIdCongThuc { get; set; }

        public ChuongCamNang ThemCongThuc(string Idgp)
        {
            if (DsIdCongThuc == null) DsIdCongThuc = new List<string>();
            if (DsIdCongThuc.IndexOf(Idgp) < 0) DsIdCongThuc.Add(Idgp);
            return this;
        }

        public ChuongCamNang XoaCongThuc(string Idgp)
        {
            if (DsIdCongThuc != null) DsIdCongThuc.Remove(Idgp);
            return this;
        }


    }
}
