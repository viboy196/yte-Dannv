using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiTinHieu:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        //Phòng ban---------------------------------
        public List<string> DsIdLoaiTienIch { get; set; } 

        public LoaiTinHieu ThemLoaiTienIch(string IdLoaiTienIch)
        {
            if (DsIdLoaiTienIch == null) DsIdLoaiTienIch = new List<string>();
            if (DsIdLoaiTienIch.IndexOf(IdLoaiTienIch) < 0) DsIdLoaiTienIch.Add(IdLoaiTienIch);
            return this;
        }
        public LoaiTinHieu XoaLoaiTienIch(string IdLoaiTienIch)
        {
            if (DsIdLoaiTienIch != null) DsIdLoaiTienIch.Remove(IdLoaiTienIch);
            return this;
        }


       
    }
}
