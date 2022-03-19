using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class HangHoa:BaseModel
    {
        public string Name { get; set; } = null!; //Tên dịch vụ y tế Chữa bệnh, khám bệnh, cấp cứu...

        public string Anh { get; set; } = null!; //Giới thiệu sự kiện
        public string TomTat { get; set; } = null!; //Giới thiệu sự kiện
        public string GioiThieu { get; set; } = null!; //Giới thiệu sự kiện
        public string Gia { get; set; } = null!; //Giới thiệu sự kiện
        public string LienHe { get; set; } = null!; //Giới thiệu sự kiện

        public string IdToChuc { get; set; } = null!;

        //Dịch vụ ---------------------
        public string IdDichVu { get; set; } = null!;

        public HangHoa SetDichVu(string iddv)
        {
            IdDichVu = iddv;
            return this;
        }

        //Sàn ---------------------
        public string IdSan { get; set; } = null!;

        public HangHoa SetSan(string ids)
        {
            IdSan = ids;
            return this;
        }

        //Giao dịch ---------------------

        public List<string> DsIdGiaoDich { get; set; } = null!; //Giao dịch của người dùng

        public HangHoa ThemGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich == null) DsIdGiaoDich = new List<string>();

            if (DsIdGiaoDich.IndexOf(Idgd) < 0) DsIdGiaoDich.Add(Idgd);
            return this;

        }

        public HangHoa XoaGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich != null) DsIdGiaoDich.Remove(Idgd);
            return this;

        }

        //Loại hàng hóa ---------------------

        public List<string> DsIdLoaiHangHoa { get; set; } = null!; //Giao dịch của người dùng

        public HangHoa ThemLoaiHangHoa(string Idgd)
        {
            if (DsIdLoaiHangHoa == null) DsIdLoaiHangHoa = new List<string>();

            if (DsIdLoaiHangHoa.IndexOf(Idgd) < 0) DsIdLoaiHangHoa.Add(Idgd);
            return this;

        }

        public HangHoa XoaLoaiHangHoa(string Idgd)
        {
            if (DsIdLoaiHangHoa != null) DsIdLoaiHangHoa.Remove(Idgd);
            return this;

        }
        //-------------------------------
    }
}
