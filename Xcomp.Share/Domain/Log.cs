using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string IdNguoiDung { get; set; } 

        public LoaiLog LoaiLog { get; set; } 

        public string IdDoiTuong { get; set; } 

        public DateTime Create { get; set; } = DateTime.Now; //Tên cơ sở y tên

        public string NoiDung { get; set; }

        public BsonDocument Data { get; set; }
    }
}
