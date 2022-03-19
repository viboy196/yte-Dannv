using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class NguyenLieu:BaseModel
    {
        public string Name { get; set; } 

        public string GioiThieu { get; set; }

        public double Stt { get; set; }

        // Giải pháp-----------------------------
        public List<string> DsIdBoPhanNguyenLieu { get; set; }

        public NguyenLieu ThemBoPhanNguyenLieu(string Idgp)
        {
            if (DsIdBoPhanNguyenLieu == null) DsIdBoPhanNguyenLieu = new List<string>();
            if (DsIdBoPhanNguyenLieu.IndexOf(Idgp) < 0) DsIdBoPhanNguyenLieu.Add(Idgp);
            return this;
        }

        public NguyenLieu XoaBoPhanNguyenLieu(string Idgp)
        {
            if (DsIdBoPhanNguyenLieu != null) DsIdBoPhanNguyenLieu.Remove(Idgp);
            return this;
        }

        // Giải pháp-----------------------------
        public List<string> DsIdGiongNguyenLieu { get; set; }

        public NguyenLieu ThemGiongNguyenLieu(string Idgp)
        {
            if (DsIdGiongNguyenLieu == null) DsIdGiongNguyenLieu = new List<string>();
            if (DsIdGiongNguyenLieu.IndexOf(Idgp) < 0) DsIdGiongNguyenLieu.Add(Idgp);
            return this;
        }

        public NguyenLieu XoaGiongNguyenLieu(string Idgp)
        {
            if (DsIdGiongNguyenLieu != null) DsIdGiongNguyenLieu.Remove(Idgp);
            return this;
        }

        // Giải pháp-----------------------------
        public string IdLoaiNguyenLieu { get; set; }

        public NguyenLieu SetLoaiNguyenLieu(string Iddt)
        {
            IdLoaiNguyenLieu = Iddt;
            return this;
        }

        public NguyenLieu XoaLoaiNguyenLieu()
        {
            IdLoaiNguyenLieu = null;
            return this;
        }

    }
}
