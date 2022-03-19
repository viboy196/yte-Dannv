using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Ca:BaseModel
    {
        public string LoaiCa { get; set; } 

        public string CodeLoaiCa { get; set; }

        public string GioiThieu { get; set; } 

        

        //Bệnh nhân -----------------
        public string IdDoiTuong { get; set; }

        public Ca SetDoiTuong(string Idbn)
        {
            IdDoiTuong = Idbn;
            return this;
        }

        public Ca XoaDoiTuong()
        {
            IdDoiTuong = null;
            return this;
        }

        

        //Thiết bị -----------------
        public string IdThietBi { get; set; } 

        public Ca SetThietBi(string Idtb)
        {
            IdThietBi = Idtb;
            return this;
        }

        public Ca XoaThietBi()
        {
            IdThietBi = null;
            return this;
        }

        //Giao dịch ---------------------

        public List<string> DsIdGiaoDich { get; set; }

        public Ca ThemGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich == null) DsIdGiaoDich = new List<string>();

            if (DsIdGiaoDich.IndexOf(Idgd) < 0) DsIdGiaoDich.Add(Idgd);
            return this;

        }

        public Ca XoaGiaoDich(string Idgd)
        {
            if (DsIdGiaoDich != null) DsIdGiaoDich.Remove(Idgd);
            return this;
        }

        //Kế hoạch ---------------------
        public List<string> DsIdKeHoach { get; set; } 

        public Ca ThemKeHoach(string Idgd)
        {
            if (DsIdKeHoach == null) DsIdKeHoach = new List<string>();

            if (DsIdKeHoach.IndexOf(Idgd) < 0) DsIdKeHoach.Add(Idgd);
            return this;

        }

        public Ca XoaKeHoach(string Idgd)
        {
            if (DsIdKeHoach != null) DsIdKeHoach.Remove(Idgd);
            return this;
        }

        //Kế hoạch ---------------------
        public List<string> DsIdCaCon { get; set; }
        public string IdCaMe { get; set; } = null!;
        public Ca ThemCaCon(string Idcacon)
        {
            if (DsIdCaCon == null) DsIdCaCon = new List<string>();

            if (DsIdCaCon.IndexOf(Idcacon) < 0) DsIdCaCon.Add(Idcacon);
            return this;

        }

        public Ca XoaCaCon(string Idcaccon)
        {
            if (DsIdCaCon != null) DsIdCaCon.Remove(Idcaccon);
            return this;
        }

        public Ca SetCaMe(string Idcm)
        {
            IdCaMe = Idcm;
            return this;

        }

        public Ca XoaCaMe()
        {
            IdCaMe = null;
            return this;
        }
        //---------------------------
    }
}
