using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class ModuleQuyTrinh:BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int Stt { get; set; } = 0;

        public string GioiThieu { get; set; }
        
        public string Icon { get; set; }

        //Nhóm -------------------
        public string IdNhom { get; set; }

        public ModuleQuyTrinh SetNhom(string idtc)
        {
            IdNhom = idtc;
            return this;
        }

        public ModuleQuyTrinh XoaNhom()
        {
            IdNhom = null;
            return this;
        }


    }
}
