using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{
    public class Lich:BaseModel
    {
        public LoaiLich Loai { get; set; } //Loại lịch trực
        
        //Nhóm trực--------------------
        public string IdNhom { get; set; } 

        public Lich SetNhom(string idnhom)
        {
            IdNhom = idnhom;
            return this;
        }

        public Lich XoaNhom()
        {
            IdNhom = null;
            return this;
        }

        //Thời gian -----------------------
        public DateTime NgayStart { get; set; } = DateTime.Now; //THời gian bắt đầu áp dụng
        public DateTime NgayEnd { get; set; } = DateTime.Now; //THời gian kết thúc áp dụng

        public List<DayOfWeek> DsDay { get; set; }  //Danh sách ngày trong tuần làm việc

        public DateTime GioStart { get; set; } = DateTime.Now; //Giờ bắt đầu làm việc
        public DateTime GioEnd { get; set; } = DateTime.Now; //Giờ kết thúc làm việc

        //Đối tượng trực  -----------------------
        //Data       
    }
}
