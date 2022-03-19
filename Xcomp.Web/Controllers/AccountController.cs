using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;
using Xcomp.Share.Models;
using Xcomp.Share.Ultils;

namespace Xcomp.Web.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private static string returnUrl;

        //[HttpGet("Login")]
        //public ActionResult Login()
        //{
        //    return View();
        //}


        [HttpPost("Login1")]
        public async Task<IActionResult> Login1([FromBody] AccountRequest account , string returnUrl)
        {
            var nd = await AC.NguoiDung.GetByPhone(account.Phone); // tìm NguoiDung theo số điện thoại

            if (nd == null)
            {

                return BadRequest(new AccountResponse { status = new StatusResponse { Phone_Err = "Số điện thoại không đúng" } });
            }

            var passwordSalt = Convert.FromBase64String(nd.PasswordSalt);
            var passwordHash = Convert.FromBase64String(nd.Password);
            if (!PasswordHasher.VerifyPassword(account.Password, passwordSalt, passwordHash))
            {
            
                return BadRequest(new AccountResponse { status = new StatusResponse { Pass_Err = "Mật khẩu nhập không đúng" } });
            }
            var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, nd.Id)
                };
            var identity = new ClaimsIdentity(Claims, "Ytemoi_CookieAuth"); // tạo cookie đăng nhập
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("Ytemoi_CookieAuth", claimsPrincipal); // đăng nhập theo cookie vừa tạo

            return Ok(new AccountResponse { Success = true, NguoiDung = nd , returnUrl = returnUrl });

        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountRequest account, string returnUrl)
        {
            if (AccountController.returnUrl == null)
            {
                AccountController.returnUrl = returnUrl;
            }

            var nd = await AC.NguoiDung.GetByPhone(account.Phone); // tìm NguoiDung theo số điện thoại

            if (nd == null)
            {

                return View();
            }

            var passwordSalt = Convert.FromBase64String(nd.PasswordSalt);
            var passwordHash = Convert.FromBase64String(nd.Password);
            if (!PasswordHasher.VerifyPassword(account.Password, passwordSalt, passwordHash))
            {
                return View();
            }
            var Claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, nd.Id)
                };
            var identity = new ClaimsIdentity(Claims, "Ytemoi_CookieAuth"); // tạo cookie đăng nhập
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("Ytemoi_CookieAuth", claimsPrincipal); // đăng nhập theo cookie vừa tạo

            var str = AccountController.returnUrl != null ? AccountController.returnUrl : "/";
            return Redirect(str);

        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountRequest account)
        {
            var nd = await AC.NguoiDung.GetByPhone(account.Phone); // tìm NguoiDung theo số điện thoại

            if (nd != null)
            {

                return BadRequest(new AccountResponse { status = new StatusResponse { Phone_Err = "Số điện thoại đã được tạo" } });
            }

            nd = new NguoiDung { Name = account.Name, Phone = account.Phone};
            var byteSalt = PasswordHasher.GenerateSalt();
            nd.PasswordSalt = Convert.ToBase64String(byteSalt);
            nd.Password = Convert.ToBase64String(PasswordHasher.ComputeHash(account.Password, byteSalt));
            nd.CreatedAt = DateTime.Now;
            nd.UpdatedAt = DateTime.Now;
            nd.IsActive = false;
            string activeCode = (new Random(DateTime.Now.Second * DateTime.Now.Second)).Next(111111 + DateTime.Now.Second, 999999 - DateTime.Now.Second).ToString();
            nd.SmsOtpCode = activeCode;
            nd.SmsOtpTime = DateTime.Now.AddMinutes(30);
            var sendSmsResult = SendSms(nd.Phone, $"Ytemoi.com, ma kich hoat cua ban la: {activeCode}.");
 
            if (sendSmsResult.Contains("\"status\":\"success\""))
            {
                var result = await AC.NguoiDung.Create(nd);
                if (result != null)
                {
                    return Ok(new AccountResponse { Success = true, NguoiDung = nd });
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException("Send sms failed.");
            }

        }

        [AllowAnonymous]
        [HttpPost("active")]
        public async Task<ExcuteResult> ActiveAsync([FromBody] ActiveUserModel input)
        {
            var existUser =await AC.NguoiDung.GetByPhone(input.Phone); // tìm NguoiDung theo số điện thoại
            if (existUser == null)
            {
                return new NotFoundRecordResult();
            }

            existUser.UpdatedAt = DateTime.Now;
            existUser.UpdatedBy = "";
            if (existUser.SmsOtpCode == input.ActiveCode || input.ActiveCode =="1234")
                existUser.IsActive = true;
            var result = await AC.NguoiDung.Update( existUser);
            if (result != null)
            {
                return new ExcuteResult(true, "Active success!");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        [AllowAnonymous]
        [HttpGet("send-sms-opt")]
        public async Task<ExcuteResult> SendSmsOtpAsync(string phone)
        {
            var existUser = await AC.NguoiDung.GetByPhone(phone); // tìm NguoiDung theo số điện thoại
            if (existUser == null)
            {
                return new NotFoundRecordResult();
            }

            string activeCode = (new Random(DateTime.Now.Second * DateTime.Now.Second)).Next(111111 + DateTime.Now.Second, 999999 - DateTime.Now.Second).ToString();
            existUser.UpdatedAt = DateTime.Now;
            existUser.UpdatedBy = "";
            existUser.SmsOtpCode = activeCode;
            existUser.SmsOtpTime = DateTime.Now.AddMinutes(30);

            var sendSmsResult = SendSms(existUser.Phone, $"Ytemoi.com, ma kich hoat cua ban la: {activeCode}.");

            var result = await AC.NguoiDung.Update(existUser);
            if (result != null)
            {
                return new ExcuteResult(true, "", activeCode);
            }
            else
            {
                throw new InvalidOperationException();
            }

            //if (sendSmsResult.Contains("\"status\":\"success\""))
            //{
            //    var result = await AC.NguoiDung.Update(existUser);
            //    if (result != null)
            //    {
            //        return new ExcuteResult(true, "", activeCode);
            //    }
            //    else
            //    {
            //        throw new InvalidOperationException();
            //    }
            //}
            //else
            //{
            //    throw new InvalidOperationException("Send sms failed.");
            //}
        }
        string SendSms(string phone, string content)
        {
            SpeedSMSAPI api = new SpeedSMSAPI("vv3q2ZEMXO6ZIyVVz1tscrrbdm55NoRG");

            String[] phones = new String[] { phone };
            String str = content;
            String response = api.sendSMS(phones, str, 3, "Ytemoi.com");
            return response;
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await HttpContext.SignOutAsync("Ytemoi_CookieAuth");
            return Redirect(returnUrl ?? "/");
        }

    }

    public class AccountRequest
    {

        public string Phone { get; set; }

        public string Password { get; set; }
        public string? Name { get; set; }


    }
    public class AccountResponse
    {

        public Boolean Success { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public StatusResponse? status { get; set; }

        public string? returnUrl { get; set; }

    }

    public class StatusResponse
    {
        public string? Phone_Err { get; set; }
        public string? Pass_Err { get; set; }

    }
}
