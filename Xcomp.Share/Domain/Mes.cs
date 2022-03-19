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
    public class Mes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string IdForum { get; set; }

        public string IdNguoiDung { get; set; }

        public KieuMes Kieu { get; set; } = KieuMes.Text;

        public DateTime Create { get; set; } = DateTime.Now; //Tên cơ sở y tên

        public string NoiDung { get; set; } 

        public BsonDocument Data { get; set; } //Giới thiệu cơ sở y tế
    }
}
