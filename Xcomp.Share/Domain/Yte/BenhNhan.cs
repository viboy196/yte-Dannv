﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class BenhNhan:BaseModel
    {
        public string Name { get; set; } 

        public string Phone { get; set; } 

        public string GioiThieu { get; set; } 




        // Ca -----------------------------
        public List<string> DsIdCa { get; set; }

        public BenhNhan ThemCa(string Idca)
        {
            if (DsIdCa == null) DsIdCa = new List<string>();
            if (DsIdCa.IndexOf(Idca) < 0) DsIdCa.Add(Idca);
            return this;
        }

        public BenhNhan XoaCa(string Idca)
        {
            if (DsIdCa != null) DsIdCa.Remove(Idca);
            return this;
        }

        // Tiện ích -----------------------------
        public List<string> DsIdTienIch { get; set; } 

        public BenhNhan ThemTienIch(string Idti)
        {
            if (DsIdTienIch == null) DsIdTienIch = new List<string>();
            if (DsIdTienIch.IndexOf(Idti) < 0) DsIdTienIch.Add(Idti);
            return this;
        }

        public BenhNhan XoaTienIch(string Idti)
        {
            if (DsIdTienIch != null) DsIdTienIch.Remove(Idti);
            return this;
        }

        //---------------------------------
    }
}
