using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class NhanVien:BaseModel
    {
        public string Name { get; set; } 

        public string VaiTro { get; set; } 

        //Mã số nhân viên dùng để add cho dễ 
        public string Code { get; set; } 

        //Công việc --------------------------
        public List<string> DsIdCongViec { get; set; } 
        public NhanVien ThemCongViec(string IdCongViec)
        {
            if (DsIdCongViec == null) DsIdCongViec = new List<string>();
            if (DsIdCongViec.IndexOf(IdCongViec) < 0) DsIdCongViec.Add(IdCongViec);
            return this;
        }

        public NhanVien XoaCongViec(string IdCongViec)
        {
            if (DsIdCongViec != null) DsIdCongViec.Remove(IdCongViec);
            return this;
        }

        //Nhóm --------------------------
        public List<string> DsIdNhom { get; set; } 

        public NhanVien ThemNhom(string IdNhom)
        {
            if (DsIdNhom == null) DsIdNhom = new List<string>();
            if (DsIdNhom.IndexOf(IdNhom) < 0) DsIdNhom.Add(IdNhom);
            return this;
        }

        public NhanVien XoaNhom(string IdNhom)
        {
            if (DsIdNhom != null) DsIdNhom.Remove(IdNhom);
            return this;
        }

        //Người dùng --------------------
        public string IdNguoiDung { get; set; } 

        public NhanVien SetNguoiDung(string idnd)
        {
            IdNguoiDung = idnd;
            return this;
        }

        public NhanVien XoaNguoiDung()
        {
            IdNguoiDung = null;
            return this;
        }
        //Tổ chức -------------------
        public string IdToChuc { get; set; } 

        public NhanVien SetToChuc(string idtc)
        {
            IdToChuc = idtc;
            return this;
        }

        public NhanVien XoaToChuc()
        {
            IdToChuc = null;
            return this;
        }

        //Phòng ban-----------------------------
        public string IdPhongBan { get; set; } 

        public NhanVien SetPhongBan(string idpb)
        {
            IdPhongBan = idpb;
            return this;
        }

        public NhanVien XoaPhongBan()
        {
            IdPhongBan = null;
            return this;
        }

        //Danh sách lịch trực -----------------       
        public List<string> DsIdLich { get; set; } 

        /// <summary>
        /// Thêm nhân viên cho tổ chức
        /// </summary>
        /// <param name="IdLich"></param>
        /// <returns></returns>
        public NhanVien ThemLich(string IdLich)
        {
            if (DsIdLich == null) DsIdLich = new List<string>();
            if (DsIdLich.IndexOf(IdLich) < 0) DsIdLich.Add(IdLich);
            return this;
        }

        public NhanVien XoaLich(string IdLich)
        {
            if (DsIdLich != null) DsIdLich.Remove(IdLich);
            return this;

        }

        //---------------------------
        public string IdHeThong { get; set; }

        public string Phone { get; set; } 

        public string GioiThieu { get; set; } 

        public TrangThaiNhanVien TrangThai { get; set; } = TrangThaiNhanVien.DangHoatDong; //Trạng thái nhân viên
        public TrangThaiNhanVien_NhanVienTraLoi TrangThai_NhanVienTraLoi { get; set; } = TrangThaiNhanVien_NhanVienTraLoi.ChuaTraLoi; //Nhân viên trả lời
        public TrangThaiNhanVien_NhanVienLamViec TrangThai_NhanVienLamViec { get; set; } = TrangThaiNhanVien_NhanVienLamViec.DangLamViec; //Nhân viên đang làm việc hay không


        //---------------------------------


        public NhanVien NhanThongBao(ThongBao tb)
        {
            QL_NhanThongBao(tb);
            return this;
        }

        public NhanVien GuiThongBao(ThongBao tb)
        {
            QL_GuiThongBao(tb);
            return this;
        }
    }
}
