using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class ThanhToan:BaseModel
    {
        public string LyDo { get; set; } 

        public double SoTienPhaiThanhToan { get; set; } = 0;

        public double SoTienDaThanhToan { get; set; } = 0;

        //Người dùng ----------------------
        public string IdNguoiDung_ThanhToan { get; set; } 

        public ThanhToan SetNguoiDung_ThanhToan(string Idnd_tt)
        {
            IdNguoiDung_ThanhToan = Idnd_tt;
            return this;
        }

        //GiaoDich-----------------------------------
        public string IdGiaoDich { get; set; } 

        public ThanhToan SetGiaoDich(string Idgd)
        {
            IdGiaoDich = Idgd;
            return this;
        }
    }
}
