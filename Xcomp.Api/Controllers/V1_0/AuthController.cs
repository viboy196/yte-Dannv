
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Xcomp.Api.Security.Auth;
using Xcomp.Data;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Models;
using Xcomp.Share.Ultils;

namespace Xcomp.Api.Controllers.V1_0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : BaseController
    {
        const string invalidAccount = "Account or password is invalid.";
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly IUnitOfWork _uow;

        public AuthController(
            IUnitOfWork uow,
            INguoiDungRepository nguoidungRepository)
        {
            _nguoiDungRepository = nguoidungRepository;
            _uow = uow;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ExcuteResult> PostAsync([FromBody] LoginUserModel input)
        {
            try
            {
                var existNguoiDung = await _nguoiDungRepository.GetAsync(c => c.Phone == input.Phone);
                if (existNguoiDung == null)
                {
                    return new ExcuteResult(false, invalidAccount);
                }
                var passwordSalt = Convert.FromBase64String(existNguoiDung.PasswordSalt);
                var passwordHash = Convert.FromBase64String(existNguoiDung.Password);
                if (PasswordHasher.VerifyPassword(input.Password, passwordSalt, passwordHash))
                {

                    List<string> roleNames = new List<string>();
                    if (existNguoiDung.Role != null)
                    {
                        roleNames.Add(existNguoiDung.Role.Name);
                    }
                    List<Claim> extendClaims = new List<Claim>();
                    extendClaims.Add(new Claim(ClaimTypes.Sid, existNguoiDung.Id));
                    TokenBuilder tokenBuilder = new TokenBuilder();
                    string token = tokenBuilder.Build(existNguoiDung.Phone, roleNames.ToArray(),
                        existNguoiDung.Permissions?.Select(c => c.Name).ToArray(), extendClaims, TimeSpan.FromDays(1));
                    return new ExcuteResult(true, "", token);
                }
            }
            catch (Exception ex)
            {

            }
            return new ExcuteResult(false, invalidAccount);
        }

     
    }
}
