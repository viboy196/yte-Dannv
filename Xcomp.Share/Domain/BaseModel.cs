using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xcomp.Share.Common;

namespace Xcomp.Share.Domain
{


    [Serializable] //?
    [BsonDiscriminator(RootClass = true)]  //?
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } 
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
        public TrangThaiHoSo TrangThaiHoSo { get; set; } = TrangThaiHoSo.DangHoatDong;

        //Thông tin bổ xung ------------------------        
        
        public string Tag { get; set; } = null!;

        //Thông báo -----------------------
        public List<string> DsIdThongBaoNhan { get; set; } 
        public int SoLuongThongBaoNhanMoi { get; set; } = 0; //Số lượng thông báo mới
        public List<string> DsIdThongBaoGui { get; set; } 
        public int SoLuongThongBaoGuiMoi { get; set; } = 0; //Số lượng thông báo mới

        public void QL_NhanThongBao(ThongBao tb)
        {
            if (DsIdThongBaoNhan == null) DsIdThongBaoNhan = new List<string>();
            if (DsIdThongBaoNhan.IndexOf(tb.Id) < 0)
            {
                DsIdThongBaoNhan.Add(tb.Id);
                SoLuongThongBaoNhanMoi++;
            }


        }

        public void QL_GuiThongBao(ThongBao tb)
        {
            if (DsIdThongBaoGui == null) DsIdThongBaoGui = new List<string>();
            if (DsIdThongBaoGui.IndexOf(tb.Id) < 0)
            {
                DsIdThongBaoGui.Add(tb.Id);
                SoLuongThongBaoGuiMoi++;
            }
        }

        public void QL_NguoiNhanThongBao(ThongBao tb)
        {
            if (DsIdThongBaoNhan == null) DsIdThongBaoNhan = new List<string>();
            if (DsIdThongBaoNhan.IndexOf(tb.Id) < 0)
            {
                DsIdThongBaoNhan.Add(tb.Id);
                SoLuongThongBaoNhanMoi++;
            }
        }

        public void QL_NguoiGuiThongBao(ThongBao tb)
        {
            if (DsIdThongBaoGui == null) DsIdThongBaoGui = new List<string>();
            if (DsIdThongBaoGui.IndexOf(tb.Id) < 0)
            {
                DsIdThongBaoGui.Add(tb.Id);
                SoLuongThongBaoGuiMoi++;
            }
        }

        //Log ----------------------
        public List<string> DsIdLog { get; set; }

        public async Task QL_ThemLog(Log lg)
        {
            if (DsIdLog == null) DsIdLog = new List<string>();
            if (DsIdLog.IndexOf(lg.Id) < 0) DsIdLog.Add(lg.Id);
        }

        //Data ---------------------       
        public BsonDocument Data { get; set; } 
        public List<string> DS_DsId(string tenDs)
        {
            var ds = new List<string>();
            if (Data == null) return ds;
            var dsidbn = (BsonArray)Data.GetValue(tenDs, null);
            if (dsidbn == null) return ds;
            foreach (var id in dsidbn) ds.Add(id.ToString());
            return ds;
        }

        public object DS_Add(string Id, string tenDs)
        {
            if (Data == null) Data = new BsonDocument();
            var dsidbn = (BsonArray)Data.GetValue(tenDs, null);
            if (dsidbn == null)
            {
                dsidbn = new BsonArray();
                Data.Set(tenDs, dsidbn);
            }
            if (dsidbn.IndexOf(Id) < 0) dsidbn.Add(Id);

            return this;
        }

        public object DS_Xoa(string Id, string tenDs)
        {
            if (Data == null) Data = new BsonDocument();
            var dsidbn = (BsonArray)Data.GetValue(tenDs, null);
            if (dsidbn == null)
            {
                dsidbn = new BsonArray();
                Data.Set(tenDs, dsidbn);
            }
            if (dsidbn.IndexOf(Id) >= 0) dsidbn.Remove(Id);

            return this;
        }

        public string Truong_View(string tenTruong)
        {

            if (Data == null) return null;
            string s = (string)Data.GetValue(tenTruong, null);
            return s;

        }

        public object Truong_Set(string GiaTri, string tenTruong)
        {
            if (Data == null) Data = new BsonDocument();
            Data.Set(tenTruong, GiaTri);
            return this;
        }

        public object Truong_Xoa(string tenTruong)
        {
            if (Data == null) Data = new BsonDocument();
            Data.Remove(tenTruong);
            return this;
        }
    }

   

    

}
