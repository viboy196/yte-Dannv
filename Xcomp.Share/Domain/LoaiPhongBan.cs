using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiPhongBan:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; } 

        //Loại tổ chức----------------------------
        public List<string> DsIdLoaiToChuc { get; set; } 
        public LoaiPhongBan ThemLoaiToChuc(string Idltc)
        {
            if (DsIdLoaiToChuc == null) DsIdLoaiToChuc = new List<string>();
            DsIdLoaiToChuc.Add(Idltc);

            return this;
        }

        public LoaiPhongBan XoaLoaiToChuc(string Idltc)
        {
            if (DsIdLoaiToChuc != null) DsIdLoaiToChuc.Remove(Idltc);

            return this;
        }

        //Loại Giải Pháp ----------------------
        public List<string> DsIdLoaiGiaiPhap { get; set; } 

        public LoaiPhongBan ThemLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap == null) DsIdLoaiGiaiPhap = new List<string>();
            if (DsIdLoaiGiaiPhap.IndexOf(idlgp) < 0) DsIdLoaiGiaiPhap.Add(idlgp);
            return this;
        }

        public LoaiPhongBan XoaLoaiGiaiPhap(string idlgp)
        {
            if (DsIdLoaiGiaiPhap != null) DsIdLoaiGiaiPhap.Remove(idlgp);
            return this;
        }
    }
}
