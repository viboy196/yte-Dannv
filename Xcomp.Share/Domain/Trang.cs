using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Trang:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiMauTrang { get; set; } 
        public string CodeMauTrang { get; set; }

        public double STT { get; set; } = 1;
                
        public bool View { get; set; } = true;

        //Tổ chức ---------------------------
        public string IdToChuc { get; set; } 

        public Trang SetToChuc(string Iddt)
        {
            IdToChuc = Iddt;
            return this;
        }

        public Trang XoaToChuc()
        {
            IdToChuc = null;
            return this;
        }
        // Giải pháp-----------------------------
        public List<string> DsIdBanTin { get; set; }

        public Trang ThemBanTin(string Idgp)
        {
            if (DsIdBanTin == null) DsIdBanTin = new List<string>();
            if (DsIdBanTin.IndexOf(Idgp) < 0) DsIdBanTin.Add(Idgp);
            return this;
        }

        public Trang XoaBanTin(string Idgp)
        {
            if (DsIdBanTin != null) DsIdBanTin.Remove(Idgp);
            return this;
        }

    }
}
