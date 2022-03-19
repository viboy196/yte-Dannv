using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiSan:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }

        public string Url { get; set; }

        //Loại dịch vụ
        public List<string> DsIdLoaiDichVu { get; set; }

        

        public LoaiSan ThemLoaiDichVu(string IdLoaiDichVu)
        {
            if (DsIdLoaiDichVu == null) DsIdLoaiDichVu = new List<string>();
            if (DsIdLoaiDichVu.IndexOf(IdLoaiDichVu) < 0) DsIdLoaiDichVu.Add(IdLoaiDichVu);
            return this;
        }

        public LoaiSan XoaLoaiDichVu(string IdLoaiDichVu)
        {
            DsIdLoaiDichVu.Remove(IdLoaiDichVu);
            return this;
        }
    }
}
