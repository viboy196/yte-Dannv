using Microsoft.AspNetCore.SignalR;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Domain;

namespace Xcomp.Web
{
    public class UserOnline
    {
        public string NguoiDungId { get; set; }
        public string ConnectionId { get; set; }
     
    }

    public class RoomTrucTinHieuOnline
    {
        public string ConnectionId { get; set; }

        public string IdToChuc { get; set; }

        public string IdPhongBan { get; set; }

        public string IdNhanVien { get; set; }

        public string NguoiDungId { get; set; }

        public List<string> DsIdCa { get; set; } = new List<string>();

    }
    public class ComHub : Hub
    {

        public static List<UserOnline> DsUser = new List<UserOnline>();
        public static List<RoomTrucTinHieuOnline> DsRoomTrucTinHieu = new List<RoomTrucTinHieuOnline>();
        public static IHubContext<ComHub> _hubContext;

        public override async Task OnConnectedAsync()
        {
            //Thêm User vào danh sách
            var u = new UserOnline
            {
                ConnectionId = Context.ConnectionId,
            };

            if (Context.User.Identity.IsAuthenticated)
            {
                u.NguoiDungId = Context.User.Identity.Name;
            }    

            DsUser.Add(u);

            await Clients.Caller.SendAsync("OnConnected", Context.ConnectionId);

            await base.OnConnectedAsync();
        }
        
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //Xóa User khỏi danh sách online
            var u = UserOn();
            DsUser.Remove(u);

            //Xóa room trực tín hiệu
            DsRoomTrucTinHieu.RemoveAll(c => c.ConnectionId == u.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }

        private UserOnline UserOn()
        {
            return DsUser.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId);
        }

        

        #region Thông báo 

        public async void xulyThongBao(string idtb, string luachon)
        {
            var connectionId = Context.ConnectionId;
            await AC.ThongBao.XuLyThongBao(idtb, luachon);            
            await _hubContext.Clients.Clients(connectionId).SendAsync("updateThongBao", idtb);
        }

        public async void updateThongBao()
        {
            await  Clients.Caller.SendAsync("updateSoLuongThongBao",(new Random()).Next(30));
        }

        public async void tatThongBao()
        {
            var u = UserOn();
            if (u.NguoiDungId != null)
            {
                var nd = await AC.NguoiDung.GetById(u.NguoiDungId);
                nd.SoLuongThongBaoNhanMoi = 0;
                await AC.NguoiDung.Update(nd);

                await _hubContext.Clients.Clients(u.ConnectionId).SendAsync("updateSoLuongThongBao", nd.SoLuongThongBaoNhanMoi);
            }

        }

        public static async Task ThongBaoNguoiDungNhan(NguoiDung nd)
        {
            var dsol = DsUser.Where(u => u.NguoiDungId == nd.Id).ToList();

            var dscn = new List<string>();
            foreach (var u in dsol)
            {
                dscn.Add(u.ConnectionId);
            }

            if (_hubContext!= null)
            await _hubContext.Clients.Clients(dscn).SendAsync("updateSoLuongThongBao", nd.SoLuongThongBaoNhanMoi);

        }

        public static async Task ThongBaoNguoiDungGui(NguoiDung nd)
        {

        }

        #endregion

        #region Tín hiệu

        public async void guiTinHieu(string codelth, string idti, string idca, string nguon, string thongso)
        {
            var u = UserOn();
            if (u.NguoiDungId != null)
            {
                var th = await AC.TinHieu.NhanTinHieu(codelth, idti, idca, nguon, thongso);

                var dsr = DsRoomTrucTinHieu.Where(c => c.DsIdCa.Contains(idca));
               
                
                foreach (var r in dsr)
                {

                    await _hubContext.Clients.Clients(r.ConnectionId).SendAsync("themTinHieuCa", idca, th.Id);
                }    
            }

        }

        public async void dangkyRoomTrucTinHieu(string idnhanvien, string phansu)
        {
            var u = UserOn();
            if (u.NguoiDungId != null)
            {
                if (DsRoomTrucTinHieu.FirstOrDefault(c=> c.ConnectionId == u.ConnectionId) == null)
                {
                    var nv = await AC.NhanVien.GetById(idnhanvien);

                    var r = new RoomTrucTinHieuOnline();
                    r.ConnectionId = u.ConnectionId;                    
                    r.NguoiDungId = u.NguoiDungId;

                    r.IdNhanVien = nv.Id;
                    r.IdToChuc = nv.IdToChuc;
                    if (nv.IdPhongBan != null) 
                        r.IdPhongBan = nv.IdPhongBan;

                    r.DsIdCa = nv.DS_DsId(phansu); 
                    
                    DsRoomTrucTinHieu.Add(r);
                }
            }

        }

        #endregion

        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
