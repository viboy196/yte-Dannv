using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class LoaiMauTrang:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public string LoaiMauWeb { get; set; }
        public string CodeLoaiMauWeb { get; set; }

        public double STT { get; set; } = 1;

    }
}
