using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class DichVu:BaseModel
    {
        public string Name { get; set; } = null!;

        public string LoaiDichVu { get; set; } = null!;

        public string CodeLoaiDichVu { get; set; } = null!;

        public string GioiThieu { get; set; } = null!;

        public string IdToChuc { get; set; } = null!;

        public string IdSan { get; set; } = null!;

        //Hàng Hóa ------------------------------
        public List<string> DsIdHangHoa { get; set; } = null!;

        public DichVu ThemHangHoa(string idhh)
        {
            if (DsIdHangHoa == null) DsIdHangHoa = new List<string>();
            if (DsIdHangHoa.IndexOf(idhh) < 0) DsIdHangHoa.Add(idhh);
            return this;
        }

        public DichVu XoaHangHoa(string idhh)
        {
            if (DsIdHangHoa != null) DsIdHangHoa.Remove(idhh);
            return this;
        }

        //--------------------------------------

        public List<string> DsIdGiaoDich { get; set; } = null!; //Giao dịch của dịch vụ

        public DichVu NhanThongBao(ThongBao tb)
        {
            QL_NhanThongBao(tb);
            return this;
        }

        public DichVu ThemGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich == null) DsIdGiaoDich = new List<string>();

            if (DsIdGiaoDich.IndexOf(Idgd) < 0) DsIdGiaoDich.Add(Idgd);
            return this;

        }
    }
}
