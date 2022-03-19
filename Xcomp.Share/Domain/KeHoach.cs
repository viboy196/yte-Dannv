using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class KeHoach:BaseModel
    {
        public string LoaiKeHoach { get; set; }

        public string CodeLoaiKeHoach { get; set; } 

        public string DanDo { get; set; }

        //Ca ----------------------
        public string IdHoSo { get; set; } 

        public KeHoach SetHoSo(string idhs)
        {
            IdHoSo = idhs;
            return this;
        }

        public KeHoach XoaHoSo()
        {
            IdHoSo = null;
            return this;
        }

        //Viec ----------------------
        public List<string> DsIdViec { get; set; }

        public KeHoach ThemViec(string idlgp)
        {
            if (DsIdViec == null) DsIdViec = new List<string>();
            if (DsIdViec.IndexOf(idlgp) < 0) DsIdViec.Add(idlgp);
            return this;
        }

        public KeHoach XoaViec(string idlgp)
        {
            if (DsIdViec != null) DsIdViec.Remove(idlgp);
            return this;
        }
        //-------------------------
    }
}
