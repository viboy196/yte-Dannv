using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiGiaiPhap:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; } 


        // Loại công việc ------------------------------

        public List<string> DsIdLoaiCongViec { get; set; } 

        public LoaiGiaiPhap ThemLoaiCongViec(string Idlcv)
        {
            if (DsIdLoaiCongViec == null) DsIdLoaiCongViec = new List<string>();
            if (DsIdLoaiCongViec.IndexOf(Idlcv) < 0) DsIdLoaiCongViec.Add(Idlcv);
            return this;
        }

        public LoaiGiaiPhap XoaLoaiCongViec(string Idlcv)
        {
            if (DsIdLoaiCongViec != null) DsIdLoaiCongViec.Remove(Idlcv);
            return this;
        }


        //Đối tượng------------------------------        

        public List<string> DsIdLoaiDoiTuong { get; set; } 

        public LoaiGiaiPhap ThemLoaiDoiTuong(string idldt)
        {
            if (DsIdLoaiDoiTuong == null) DsIdLoaiDoiTuong = new List<string>();
            if (DsIdLoaiDoiTuong.IndexOf(idldt) < 0) DsIdLoaiDoiTuong.Add(idldt);
            return this;
        }

        public LoaiGiaiPhap XoaLoaiDoiTuong(string idldt)
        {
            if (DsIdLoaiDoiTuong != null) DsIdLoaiDoiTuong.Remove(idldt);
            return this;
        }

        //Tổ chức ------------------------------        
        public List<string> DsIdLoaiToChuc { get; set; } 

        public LoaiGiaiPhap ThemLoaiToChuc(string idltc)
        {
            if (DsIdLoaiToChuc == null) DsIdLoaiToChuc = new List<string>();
            if (DsIdLoaiToChuc.IndexOf(idltc) < 0) DsIdLoaiToChuc.Add(idltc);
            return this;
        }

        public LoaiGiaiPhap XoaLoaiToChuc(string idltc)
        {
            if (DsIdLoaiToChuc != null) DsIdLoaiToChuc.Remove(idltc);
            return this;
        }

        //Phòng ban ------------------------------        
        public List<string> DsIdLoaiPhongBan { get; set; } 

        public LoaiGiaiPhap ThemLoaiPhongBan(string idlpb)
        {
            if (DsIdLoaiPhongBan == null) DsIdLoaiPhongBan = new List<string>();
            if (DsIdLoaiPhongBan.IndexOf(idlpb) < 0) DsIdLoaiPhongBan.Add(idlpb);
            return this;
        }

        public LoaiGiaiPhap XoaLoaiPhongBan(string idlpb)
        {
            if (DsIdLoaiPhongBan != null) DsIdLoaiPhongBan.Remove(idlpb);
            return this;
        }

        //Loại Kế Hoạch ----------------------
        public List<string> DsIdLoaiKeHoach { get; set; } 

        public LoaiGiaiPhap ThemLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach == null) DsIdLoaiKeHoach = new List<string>();
            if (DsIdLoaiKeHoach.IndexOf(idlgp) < 0) DsIdLoaiKeHoach.Add(idlgp);
            return this;
        }

        public LoaiGiaiPhap XoaLoaiKeHoach(string idlgp)
        {
            if (DsIdLoaiKeHoach != null) DsIdLoaiKeHoach.Remove(idlgp);
            return this;
        }

        

        
    }
}
