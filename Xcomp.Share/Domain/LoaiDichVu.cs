using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiDichVu:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; } 

        
        //Loại sàn ---------------------------
        public string IdLoaiSan { get; set; } 

        public LoaiDichVu SetLoaiSan(string IdLS)
        {
            IdLoaiSan = IdLS;
            return this;
        }

        public LoaiDichVu XoaLoaiSan()
        {
            IdLoaiSan = null;
            return this;
        }

        //Loại tổ chức-----------------------
        public List<string> DsIdLoaiToChuc { get; set; } 

        public LoaiDichVu ThemLoaiToChuc(string idltc)
        {
            if (DsIdLoaiToChuc == null) DsIdLoaiToChuc = new List<string>();
            if (DsIdLoaiToChuc.IndexOf(idltc) < 0) DsIdLoaiToChuc.Add(idltc);
            return this;
        }

        public LoaiDichVu XoaLoaiToChuc(string idltc)
        {
            if (DsIdLoaiToChuc != null) DsIdLoaiToChuc.Remove(idltc);
            return this;
        }

        //Loại hàng hóa-------------------------------------
        public List<string> DsIdLoaiHangHoa { get; set; } 

        public LoaiDichVu ThemLoaiHangHoa(string Idlhh)
        {
            if (DsIdLoaiHangHoa == null) DsIdLoaiHangHoa = new List<string>();
            if (DsIdLoaiHangHoa.IndexOf(Idlhh) < 0) DsIdLoaiHangHoa.Add(Idlhh);
            return this;
        }

        public LoaiDichVu XoaLoaiHangHoa(string Idlhh)
        {
            if (DsIdLoaiHangHoa != null) DsIdLoaiHangHoa.Remove(Idlhh);
            return this;
        }
        //------------------------------
        public List<string> DsIdLoaiDichVuCon { get; set; } 
        public List<string> DsIdLoaiDichVuMe { get; set; } 
                
        public LoaiDichVu ThemDichVuCon(string IdDichVuCon)
        {
            if (DsIdLoaiDichVuCon == null) DsIdLoaiDichVuCon = new List<string>();
            if (DsIdLoaiDichVuCon.IndexOf(IdDichVuCon) < 0) DsIdLoaiDichVuCon.Add(IdDichVuCon);
            return this;
        }

        public LoaiDichVu XoaDichVuCon(string IdDichVuCon)
        {
            if (DsIdLoaiDichVuCon != null) DsIdLoaiDichVuCon.Remove(IdDichVuCon);
            return this;
        }

        public LoaiDichVu ThemDichVuMe(string IdDichVuMe)
        {
            if (DsIdLoaiDichVuMe == null) DsIdLoaiDichVuMe = new List<string>();
            if (DsIdLoaiDichVuMe.IndexOf(IdDichVuMe) < 0) DsIdLoaiDichVuMe.Add(IdDichVuMe);
            return this;
        }

        public LoaiDichVu XoaDichVuMe(string IdDichVuMe)
        {
            if (DsIdLoaiDichVuMe != null) DsIdLoaiDichVuMe.Remove(IdDichVuMe);
            return this;
        }
    }
}
