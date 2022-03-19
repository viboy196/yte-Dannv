using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class CongViec:BaseModel
    {
        public string LoaiCongViec { get; set; } 

        public string CodeLoaiCongViec { get; set; } 

        public string ThucHien { get; set; } 

        public string IdHeThong { get; set; } 

        //Nhân viên-----------------------------
        public string IdNhanVien { get; set; } 

        public CongViec SetNhanVien(string Idnv)
        {
            IdNhanVien = Idnv;
            return this;
        }

        public CongViec XoaNhanVien()
        {
            IdNhanVien = null;
            return this;
        }
        //Giải pháp---------------------
        public string IdGiaiPhap { get; set; } 

        public CongViec SetGiaiPhap(string Idgp)
        {
            IdGiaiPhap = Idgp;
            return this;
        }

        public CongViec XoaGiaiPhap()
        {
            IdGiaiPhap = null;
            return this;
        }

        //Tổ chức -----------------------------------
        public string IdToChuc { get; set; } 

        public CongViec SetToChuc(string Idtc)
        {
            IdToChuc = Idtc;
            return this;
        }

        public CongViec XoaToChuc()
        {
            IdToChuc = null;
            return this;
        }


        //-----------------------------------------
        public string IdPhongBan { get; set; } 

        public TrangThaiCongViec TrangThai { get; set; } = TrangThaiCongViec.DangHoatDong; //Trạng thái
        public TrangThaiNhanVien_NhanVienTraLoi TrangThai_NhanVienTraLoi { get; set; } = TrangThaiNhanVien_NhanVienTraLoi.ChuaTraLoi; //Nhân viên trả lời
        public TrangThaiNhanVien_NhanVienLamViec TrangThai_NhanVienLamViec { get; set; } = TrangThaiNhanVien_NhanVienLamViec.DangLamViec; //Nhân viên đang làm việc hay không

       

        public CongViec NhanThongBao(ThongBao tb)
        {
            QL_NhanThongBao(tb);
            return this;
        }

        public CongViec GuiThongBao(ThongBao tb)
        {
            QL_GuiThongBao(tb);
            return this;
        }
    }
}
