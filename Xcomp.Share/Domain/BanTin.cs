using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class BanTin:BaseModel
    {
        public string Name { get; set; } 

        public string LoaiBanTin { get; set; } 
        public string CodeBanTin { get; set; }

        public double STT { get; set; } = 1;
                
        public bool View { get; set; } = true;

        public string IdToChuc { get; set; }

        //Tổ chức ---------------------------
        public string IdTrang { get; set; } 

        public BanTin SetTrang(string Iddt)
        {
            IdTrang = Iddt;
            return this;
        }

        public BanTin XoaTrang()
        {
            IdTrang = null;
            return this;
        }
        

    }
}
