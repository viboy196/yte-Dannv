using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Domain;

namespace Xcomp.Share.Models
{
    public class NhanVienModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string IdToChuc { get; set; }
        public string NameToChuc { get; set; }


        public string VaiTro { get; set; }
        public IEnumerable<CongViec>? DsCongViec { get; set; }
        public NhanVienModel()
        {
            DsCongViec = new List<CongViec>();
        }
    }
}
