using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class GiaoDich:BaseModel
    {
        public string Name { get; set; }


        //Người dùng ----------------------
        public string IdNguoiDung { get; set; } 

        public GiaoDich SetNguoiDung(string Idnd)
        {
            IdNguoiDung = Idnd;
            return this;
        }

        //Dịch vụ-----------------------------------
        public string IdDichVu { get; set; }

        public GiaoDich SetDichVu(string Iddv)
        {
            IdDichVu = Iddv;
            return this;
        }

        //------------------------------

        public string IdHeThong { get; set; } 

        public TrangThaiGiaoDich TrangThai { get; set; } = TrangThaiGiaoDich.DatHang;

        //Hồ sơ thực hiện giao dịch : có thể là Ca ---------------
        public string IdHoso { get; set; } 

        public GiaoDich SetHoSo(string Idca)
        {
            IdHoso = Idca;
            return this;
        }
        // Tổ chức-------------------------------
        public string IdToChuc { get; set; } 

        public GiaoDich SetToChuc(string Idtc)
        {
            IdToChuc = Idtc;
            return this;
        }

        // Phòng ban-------------------------------
        public string IdPhongBan { get; set; } 

        public GiaoDich SetPhongBan(string Idpb)
        {
            IdPhongBan = Idpb;
            return this;
        }

        //Hàng Hóa ------------------------------
        public string IdHangHoa { get; set; }

        public double SoLuong { get; set; } = 0;

        public GiaoDich SetHangHoa(string idhh)
        {
            IdHangHoa = idhh;
            return this;
        }

        public GiaoDich XoaHangHoa()
        {
            IdHangHoa = null;
            return this;
        }

        //Thanh toán ---------------------
        public List<string> DsIdThanhToan { get; set; } 

        public GiaoDich ThemThanhToan(string Idtt)
        {
            if (DsIdThanhToan == null) DsIdThanhToan = new List<string>();
            if (DsIdThanhToan.IndexOf(Idtt) < 0) DsIdThanhToan.Add(Idtt);
            return this;
        }

        public GiaoDich XoaThanhToan(string Idtt)
        {
            if (DsIdThanhToan != null) DsIdThanhToan.Remove(Idtt);
            return this;
        }
    }
}
