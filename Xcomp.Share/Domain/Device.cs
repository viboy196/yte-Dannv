using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Device:BaseModel
    {
        [BsonElement("Code")]
        public string? Code { get; set; }
        public string? Voip_Sip { get; set; }
        public string? Voip_Password { get; set; }
        public string? Domain { get; set; }


    }
}
