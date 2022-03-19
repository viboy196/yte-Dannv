using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class PhanSu:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; }

        public string GioiThieu { get; set; }

        public CodeHeThong CodeHeThong { get; set; }

        public bool PhanSuCaNhan { get; set; } = false;

        public bool PhanSuNhom { get; set; } = false;



    }
}
