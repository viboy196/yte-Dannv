using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class TinHieu:BaseModel
    {        
        public string LoaiTinHieu { get; set; } 

        public string CodeLoaiTinHieu { get; set; } 

        public string IdTienIch { get; set; }

        public string IdDoiTuong { get; set; }

    }
}
