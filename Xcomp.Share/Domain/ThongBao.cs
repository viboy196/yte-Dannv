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
    public class ThongBao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public LoaiThongBao Loai { get; set; } = LoaiThongBao.ThongBaoThuong; //Code Loại ThongBao

        public string NoiDung { get; set; } = null!; //Nội dung thông báo

        public bool DaDoc { get; set; } = false; //Nội dung thông báo
        public bool DaXuLy { get; set; } = false; //Nội dung thông báo
        public string KetQua { get; set; } = null!; //Kết quả xử lý

        public DateTime Create { get; set; } = DateTime.Now; //Thời gian tạo

        public string IdNguoinhan { get; set; } = null!;

        public string IdNguoiGui { get; set; } = null!;

        public string IdDoiTuongNhan { get; set; } = null!; // Đối tượng nhận thông báo

        public string IdDoiTuongGui { get; set; } = null!; // Đối tượng gửi

        public BsonDocument Data { get; set; } = null!; //Tính năng của tin, Mã tất cả các thông tin tính năng tại đây
    }
}
