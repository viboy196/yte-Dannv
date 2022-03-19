using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class DoiTuong:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiDoiTuong { get; set; } 

        public string CodeLoaiDoiTuong { get; set; }

        public string Phone { get; set; }

        public string GioiThieu { get; set; }


        // Ca -----------------------------
        public List<string> DsIdCa { get; set; }

        public DoiTuong ThemCa(string Idca)
        {
            if (DsIdCa == null) DsIdCa = new List<string>();
            if (DsIdCa.IndexOf(Idca) < 0) DsIdCa.Add(Idca);
            return this;
        }

        public DoiTuong XoaCa(string Idca)
        {
            if (DsIdCa != null) DsIdCa.Remove(Idca);
            return this;
        }

        // Tiện ích -----------------------------
        public List<string> DsIdTienIch { get; set; }

        public DoiTuong ThemTienIch(string Idti)
        {
            if (DsIdTienIch == null) DsIdTienIch = new List<string>();
            if (DsIdTienIch.IndexOf(Idti) < 0) DsIdTienIch.Add(Idti);
            return this;
        }

        public DoiTuong XoaTienIch(string Idti)
        {
            if (DsIdTienIch != null) DsIdTienIch.Remove(Idti);
            return this;
        }

        // Tín hiệu-----------------------------
        public List<string> DsIdTinHieu { get; set; }

        public DoiTuong ThemTinHieu(string Idgp)
        {
            if (DsIdTinHieu == null) DsIdTinHieu = new List<string>();
            if (DsIdTinHieu.IndexOf(Idgp) < 0) DsIdTinHieu.Add(Idgp);
            UpdatedAt = DateTime.Now;
            return this;
        }

        public DoiTuong XoaTinHieu(string Idgp)
        {
            if (DsIdTinHieu != null) DsIdTinHieu.Remove(Idgp);
            UpdatedAt = DateTime.Now;
            return this;
        }
        //---------------------------------


    }
}
