using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Forum:BaseModel
    {
        public string Name { get; set; } 

        public KieuForum Kieu { get; set; }

        //Đối tượng chủ forum---------------------------
        //Data Ca

        //Đối tượng tham gia forum---------------------------
        //Data Doi Tuong Tham Gia

        // Giải pháp-----------------------------
        public List<string> DsIdMes { get; set; } 

        public Forum ThemMes(string Idgp)
        {
            if (DsIdMes == null) DsIdMes = new List<string>();
            if (DsIdMes.IndexOf(Idgp) < 0) DsIdMes.Add(Idgp);
            return this;
        }

        public Forum XoaMes(string Idgp)
        {
            if (DsIdMes != null) DsIdMes.Remove(Idgp);
            return this;
        }        
    }
}
