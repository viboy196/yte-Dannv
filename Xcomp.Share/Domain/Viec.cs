using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Viec:BaseModel
    {
        public string LoaiViec { get; set; } 

        public string CodeLoaiViec { get; set; } 

        public double Stt { get; set; } = 0.0;

        public string ThoiGianText { get; set; } 

        public string NhanDe { get; set; } 

        public string DanDo { get; set; }

        //Kế hoạch ----------------------
        public string IdKeHoach { get; set; } 

        public Viec SetKeHoach(string Id)
        {
            IdKeHoach = Id;
            return this;
        }

        public Viec XoaKeHoach()
        {
            IdKeHoach = null;
            return this;
        }

        //--------------------------
    }
}
