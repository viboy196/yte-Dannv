using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiKeHoach:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; } 

        
        //Loại Giải Pháp ----------------------
        public List<string> DsIdLoaiGiaiPhap { get; set; } 

        public LoaiKeHoach ThemLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap == null) DsIdLoaiGiaiPhap = new List<string>();
            if (DsIdLoaiGiaiPhap.IndexOf(idlgp) < 0) DsIdLoaiGiaiPhap.Add(idlgp);
            return this;
        }

        public LoaiKeHoach XoaLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap != null) DsIdLoaiGiaiPhap.Remove(idlgp);
            return this;
        }

        //Loại Kế Hoạch ----------------------
        public List<string> DsIdLoaiViec { get; set; }

        public LoaiKeHoach ThemLoaiViec(string idlgp)
        {
            if (DsIdLoaiViec == null) DsIdLoaiViec = new List<string>();
            if (DsIdLoaiViec.IndexOf(idlgp) < 0) DsIdLoaiViec.Add(idlgp);
            return this;
        }

        public LoaiKeHoach XoaLoaiViec(string idlgp)
        {
            if (DsIdLoaiViec != null) DsIdLoaiViec.Remove(idlgp);
            return this;
        }


    }
}
