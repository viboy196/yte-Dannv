
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Claims;
using Xcomp.Api.Security.Auth;
using Xcomp.Data;
using Xcomp.Data.IRepositories;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;
using Xcomp.Share.Models;
using Xcomp.Share.Ultils;

namespace Xcomp.Api.Controllers.V1_0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class NotiController : BaseController
    {
        private readonly IAppRepository _appRepository;
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly ITienIchRepository _tienichRepository;



        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public NotiController(
            IUnitOfWork uow,
            IAppRepository appRepository,
            INguoiDungRepository nguoiDungRepository,
            IMapper mapper)
        {
            _appRepository = appRepository;
            _nguoiDungRepository = nguoiDungRepository;
            _uow = uow;
            _mapper = mapper;
        }  
        [HttpGet("SendNoti-SoS")]
        public async Task<ExcuteResult> GetAsync(string idti)
        {
            try
            {
                var nd = await _nguoiDungRepository.GetByIdAsync(RequestUserId);
                var ti = await AC.TienIch.GetById(idti);
                var lth = await AC.LoaiTinHieu.GetByCode("lth_anninh_sos");
                var dt = await AC.DoiTuong.GetById(ti.IdDoiTuong);

                var th = await AC.TinHieu.Create(new TinHieu
                {
                    LoaiTinHieu = lth.Name,
                    CodeLoaiTinHieu = lth.Code,
                    CreatedAt = DateTime.Now
                });

                await AC.DoiTuong.Update(dt.ThemTinHieu(th.Id));
                th.IdDoiTuong = dt.Id;
                await AC.TienIch.Update(ti.ThemTinHieu(th.Id));
                th.IdTienIch = ti.Id;
                await AC.TinHieu.Update(th);

                var dsca = await AC.Ca.Get(dt.DsIdCa);
                List<NhanVien> dsnv = new List<NhanVien>();
                foreach (var ca in dsca)
                {
                    dsnv.AddRange(await AC.NhanVien.Get(ca.DS_DsId("Ca_ps_anninh_theodoi")));
                }
                var dsIDng = new List<string>(); ;
                dsnv.ForEach(nv =>
                {
                    dsIDng.Add(nv.IdNguoiDung);
                });
                var dsApp = (List<App>)await _appRepository.GetAllAsync(app => dsIDng.Contains(app.IdNguoiDung));


                return new ExcuteResult(Result: sendNoti(dsApp, nd.Name));
            }
            catch (Exception ex)
            {
                return new ExcuteResult(false, ex.Message);
            }

        }

        private static string sendNoti(List<App> dsApp, string name)
        {
            var dsToken = new List<string>();
            dsApp.ForEach(app =>
            {
                if (app.AppTokens != null)
                {
                    app.AppTokens.ForEach(token =>
                    {
                        dsToken.Add(token.AppToken);
                    });
                }
            });
            var data = new
            {
                to = dsToken,
                title = "có Yêu cầu SOS",
                body = name + " cần trợ giúp SOS"
            };
            var json = JsonConvert.SerializeObject(data);
            var client = new RestClient("https://exp.host/--/api/v2/push/send");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;

        }
    }
}
