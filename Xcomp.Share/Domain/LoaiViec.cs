using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiViec:BaseModel
    {
        public string Name { get; set; } 
        public string Code { get; set; } 

        public string GioiThieu { get; set; } 

        public bool KyNang { get; set; } 

        //Loại Kế Hoạch ----------------------
        public List<string> DsIdLoaiKeHoach { get; set; } 

        public LoaiViec ThemLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach == null) DsIdLoaiKeHoach = new List<string>();
            if (DsIdLoaiKeHoach.IndexOf(idlgp) < 0) DsIdLoaiKeHoach.Add(idlgp);
            return this;
        }

        public LoaiViec XoaLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach != null) DsIdLoaiKeHoach.Remove(idlgp);
            return this;
        }
    }
}
