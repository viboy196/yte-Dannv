using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Domain
{
    public class Permission : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
