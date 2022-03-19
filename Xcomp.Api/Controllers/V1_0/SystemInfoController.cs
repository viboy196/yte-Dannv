
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
    public class SystemInfoController : BaseController
    {
       
        [HttpGet]
        [AllowAnonymous]
        public async Task<ExcuteResult> GetAsync()
        {
            var sys = SystemInfo.CodeHeThong;
            return new ExcuteResult(true, null, sys);
        }

     
    }
}
