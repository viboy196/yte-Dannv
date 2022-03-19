using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class CamNang:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiCamNang { get; set; } 

        public string CodeLoaiCamNang { get; set; } 

        public string GioiThieu { get; set; }

        // Giải pháp-----------------------------
        public List<string> DsIdChuongCamNang { get; set; }

        public CamNang ThemChuongCamNang(string Idgp)
        {
            if (DsIdChuongCamNang == null) DsIdChuongCamNang = new List<string>();
            if (DsIdChuongCamNang.IndexOf(Idgp) < 0) DsIdChuongCamNang.Add(Idgp);
            return this;
        }

        public CamNang XoaChuongCamNang(string Idgp)
        {
            if (DsIdChuongCamNang != null) DsIdChuongCamNang.Remove(Idgp);
            return this;
        }

    }
}
