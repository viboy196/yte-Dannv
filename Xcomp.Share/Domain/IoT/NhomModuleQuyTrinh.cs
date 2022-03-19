using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class NhomModuleQuyTrinh:BaseModel
    {
        public string Name { get; set; } 

        public int Stt { get; set; } 

        public string GioiThieu { get; set; }

        //Máy --------------------
        public List<string> DsIdModuleQuyTrinh { get; set; }

        public NhomModuleQuyTrinh ThemModuleQuyTrinh(string Idltc)
        {
            if (DsIdModuleQuyTrinh == null) DsIdModuleQuyTrinh = new List<string>();
            if (DsIdModuleQuyTrinh.IndexOf(Idltc) < 0) DsIdModuleQuyTrinh.Add(Idltc);
            return this;
        }

        public NhomModuleQuyTrinh XoaModuleQuyTrinh(string Idltc)
        {
            if (DsIdModuleQuyTrinh != null) DsIdModuleQuyTrinh.Remove(Idltc);
            return this;
        }

    }
}
