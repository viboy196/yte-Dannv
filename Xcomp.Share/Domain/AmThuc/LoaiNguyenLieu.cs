using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiNguyenLieu:BaseModel
    {
        public string Name { get; set; } 

        public string GioiThieu { get; set; }

        public double Stt { get; set; }

        // Giải pháp-----------------------------
        public List<string> DsIdNguyenLieu { get; set; }

        public LoaiNguyenLieu ThemNguyenLieu(string Idgp)
        {
            if (DsIdNguyenLieu == null) DsIdNguyenLieu = new List<string>();
            if (DsIdNguyenLieu.IndexOf(Idgp) < 0) DsIdNguyenLieu.Add(Idgp);
            return this;
        }

        public LoaiNguyenLieu XoaNguyenLieu(string Idgp)
        {
            if (DsIdNguyenLieu != null) DsIdNguyenLieu.Remove(Idgp);
            return this;
        }

        // Giải pháp-----------------------------
        public List<string> DsIdLoaiNguyenLieuCon { get; set; }
        public string IdLoaiNguyenLieuMe { get; set; }

        public LoaiNguyenLieu ThemLoaiNguyenLieuCon(string Idgp)
        {
            if (DsIdLoaiNguyenLieuCon == null) DsIdLoaiNguyenLieuCon = new List<string>();
            if (DsIdLoaiNguyenLieuCon.IndexOf(Idgp) < 0) DsIdLoaiNguyenLieuCon.Add(Idgp);
            return this;
        }

        public LoaiNguyenLieu XoaLoaiNguyenLieuCon(string Idgp)
        {
            if (DsIdLoaiNguyenLieuCon != null) DsIdLoaiNguyenLieuCon.Remove(Idgp);
            return this;
        }

    }
}
