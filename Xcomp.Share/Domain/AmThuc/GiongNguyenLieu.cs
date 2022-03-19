using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class GiongNguyenLieu:BaseModel
    {
        public string Name { get; set; } 

        public string GioiThieu { get; set; }

        public double Stt { get; set; }

        
        // Giải pháp-----------------------------
        public string IdNguyenLieu { get; set; }

        public GiongNguyenLieu SetNguyenLieu(string Iddt)
        {
            IdNguyenLieu = Iddt;
            return this;
        }

        public GiongNguyenLieu XoaNguyenLieu()
        {
            IdNguyenLieu = null;
            return this;
        }

    }
}
