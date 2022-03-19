using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class LoaiTienIch:BaseModel
    {
        public string Name { get; set; } 
        public string Code { get; set; } 
        
        public string GioiThieu { get; set; }

        public string ThucHien { get; set; } = "WEBAPP";

        public CodeHeThong CodeHeThong { get; set; }

        //Loại đối tượng ----------------------
        public List<string> DsIdLoaiDoiTuong { get; set; }

        public LoaiTienIch ThemLoaiDoiTuong(string idlgp)
        {
            if (DsIdLoaiDoiTuong == null) DsIdLoaiDoiTuong = new List<string>();
            if (DsIdLoaiDoiTuong.IndexOf(idlgp) < 0) DsIdLoaiDoiTuong.Add(idlgp);
            return this;
        }

        public LoaiTienIch XoaLoaiDoiTuong(string idlgp)
        {
            if (DsIdLoaiDoiTuong != null) DsIdLoaiDoiTuong.Remove(idlgp);
            return this;
        }

        //Loại đối tượng ----------------------
        public List<string> DsIdLoaiTinHieu { get; set; }

        public LoaiTienIch ThemLoaiTinHieu(string idlgp)
        {
            if (DsIdLoaiTinHieu == null) DsIdLoaiTinHieu = new List<string>();
            if (DsIdLoaiTinHieu.IndexOf(idlgp) < 0) DsIdLoaiTinHieu.Add(idlgp);
            return this;
        }

        public LoaiTienIch XoaLoaiTinHieu(string idlgp)
        {
            if (DsIdLoaiTinHieu != null) DsIdLoaiTinHieu.Remove(idlgp);
            return this;
        }
    }
}
