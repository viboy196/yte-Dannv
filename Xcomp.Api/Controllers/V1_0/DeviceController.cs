using AutoMapper;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
    public class DeviceController : BaseController
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IAppRepository _appRepository;

       


        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public static HeThong ht { get; set; }

        public DeviceController(
            IUnitOfWork uow,
            IMapper mapper,
            IDeviceRepository deviceRepository,
            IAppRepository appRepository
            )
        {
            _deviceRepository = deviceRepository;
            _appRepository = appRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ExcuteResult> PostAsync([FromBody] DeviceModel input)
        {
            if (input.Domain == null) input.Domain = "171.244.133.171";
            var device = _mapper.Map<Device>(input);
            _deviceRepository.Add(device);
            var res = await _uow.CommitAsync();
            if (res == true) return new ExcuteResult(true, "create sucsses", input);
            else return new ExcuteResult(false,null, null);
        }

        [HttpPost("sendnoti")]
        [AllowAnonymous]
        public async Task<ExcuteResult> SendNotiAsync([FromBody] DeviceSendModel input)
        {

            var device =await _deviceRepository.GetByCodeAsync(input.Code);
            if( device == null) return new ExcuteResult(false,"not found" , null);
            var apps = (List<App>)await _appRepository.GetAll();
            List<string> tokens = new List<string>();

            // tim nguoi dung phu trach de gui noti ve cho nguoi dung
            // tìm app online theo id người dùng ==> tim các token 
            // gửi noti theo list tokens

            tokens.Add("fXlSXqgYTh-os4oq6j8tom:APA91bFBrliy3mdqTgidxZ1Q7teo1K1tnD_geJLp7QVuLe9vPRU6ItApHmCosQK36xOUUCmWLAgJypsholv1ara9wglMsNXOl3A3NREsaaYmfbTHJKb0Ijhm_3SGUu16vFhilAV6ToNV");
            apps.ForEach(app =>
            {
                app.AppTokens.ForEach(token =>
                {
                    tokens.Add(token.AppToken);
                });
            });
            var res =await sendFireBaseNotiAsync(tokens,device);
            if(res == true) return new ExcuteResult(true,"send noti suscess" , null);
            else return new ExcuteResult(false,"send noti firebase faile" , null);
        }

        private async Task<bool> sendFireBaseNotiAsync(List<string> registrationToken ,Device device)
        {
            if(registrationToken.Count ==0) return false;
            // See documentation on defining a message payload.
            var message = new MulticastMessage()
            {
                Notification = new Notification
                {
                    Body = $"Thông báo từ thiết bị {device.Code}",
                    Title = "Thông báo"
                },
                Tokens = registrationToken,

            };
            var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
            return response.SuccessCount > 0;

        }
    }
}
