﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class LoaiYeuNhan:BaseModel
    {
        public string Name { get; set; } 

        public string Code { get; set; } 

        public string GioiThieu { get; set; }
        
    }
}
