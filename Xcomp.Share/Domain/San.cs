using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class San:BaseModel
    {
        public string LoaiSan { get; set; }

        public string CodeLoaiSan { get; set; }

        public string Name { get; set; } 

        public string GioiThieu { get; set; } 

        public int Stt { get; set; } = int.MaxValue; 

        public TrangThaiSan TrangThai { get; set; } = TrangThaiSan.DangXayDung;

        public MauWebSan MauSan { get; set; } = MauWebSan.TieuChuan;

        //Tổ chức tham gia sàn ---------------
        public List<string> DsIdToChuc { get; set; } 

        public San ThemToChuc(string Idtc)
        {
            if (DsIdToChuc == null) DsIdToChuc = new List<string>();
            if (DsIdToChuc.IndexOf(Idtc) < 0) DsIdToChuc.Add(Idtc);
            return this;
        }

        public San XoaToChuc(string Idtc)
        {
            if (DsIdToChuc != null) DsIdToChuc.Remove(Idtc);
            return this;
        }

        //Dịch vụ tham gia sàn -------------
        public List<string> DsIdDichVu { get; set; }

        public San ThemDichVu(string Iddv)
        {
            if (DsIdDichVu == null) DsIdDichVu = new List<string>();
            if (DsIdDichVu.IndexOf(Iddv) < 0) DsIdDichVu.Add(Iddv);
            return this;
        }

        public San XoaDichVu(string Iddv)
        {
            if (DsIdDichVu != null) DsIdDichVu.Remove(Iddv);
            return this;
        }

        //Hàng hóa trên sàn -------------
        public List<string> DsIdHangHoa { get; set; } 

        public San ThemHangHoa(string Iddv)
        {
            if (DsIdHangHoa == null) DsIdHangHoa = new List<string>();
            if (DsIdHangHoa.IndexOf(Iddv) < 0) DsIdHangHoa.Add(Iddv);
            return this;
        }

        public San XoaHangHoa(string Iddv)
        {
            if (DsIdHangHoa != null) DsIdHangHoa.Remove(Iddv);
            return this;
        }
    }
}
