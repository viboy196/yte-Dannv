using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcomp.Share.Models
{
    public class DeviceModel
    {
        public string? Code { get; set; }
        public string? Voip_Sip { get; set; }
        public string? Voip_Password { get; set; }
        public string? Domain { get; set; }
    }
    public class DeviceSendModel
    {
        public string Code { get; set; }
    }

}
