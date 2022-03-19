
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Xcomp.Api.Security.Auth;
using Xcomp.Data;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;
using Xcomp.Share.Models;
using Xcomp.Share.Ultils;

namespace Xcomp.Api.Controllers.V1_0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppController : BaseController
    {
        private readonly IAppRepository _appRepository;
        private readonly INguoiDungRepository _nguoiDungRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AppController(
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
        [HttpPost("active-app")]
        public async Task<ExcuteResult> PostAsync([FromBody] AppModel input)
        {
            var app = await _appRepository.GetAsync(it => it.IdNguoiDung == RequestUserId);
            if (app == null)
            {
                var appn = new App { IdNguoiDung = RequestUserId };
                appn.AppTokens.Add(new Token { AppToken = input.AppToken, CodeHeThong = SystemInfo.CodeHeThong });
                _appRepository.Add(appn);
                var res = await _uow.CommitAsync();
                return new ExcuteResult(true, null, null);
            }
            else
            {
                if (app.AppTokens.Find(x => x.AppToken == input.AppToken) != null)
                    return new ExcuteResult(true, null, null);

                app.AppTokens.Add(new Token { AppToken = input.AppToken, CodeHeThong = SystemInfo.CodeHeThong });
                _appRepository.Update(app.Id, app);
                await _uow.CommitAsync();
                return new ExcuteResult(true, null, null);
            }
        }


    }
}
