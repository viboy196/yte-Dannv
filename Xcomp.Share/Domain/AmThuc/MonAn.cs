using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class MonAn:BaseModel
    {
        public string Name { get; set; } 

        public string GioiThieu { get; set; }

        // Giải pháp-----------------------------
        public List<string> DsIdCongThuc { get; set; }

        public MonAn ThemCongThuc(string Idgp)
        {
            if (DsIdCongThuc == null) DsIdCongThuc = new List<string>();
            if (DsIdCongThuc.IndexOf(Idgp) < 0) DsIdCongThuc.Add(Idgp);
            return this;
        }

        public MonAn XoaCongThuc(string Idgp)
        {
            if (DsIdCongThuc != null) DsIdCongThuc.Remove(Idgp);
            return this;
        }

    }
}
