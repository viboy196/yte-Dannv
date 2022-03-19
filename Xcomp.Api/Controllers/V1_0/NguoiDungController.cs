using AutoMapper;
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
    public class NguoiDungController : BaseController
    {
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHeThongRepository _hethongRepository;
        private readonly ICongViecRepository _congViecRepository;
        private readonly IToChucRepository _toChucRepository;


        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public static HeThong ht { get; set; }

        public NguoiDungController(
            IUnitOfWork uow,
            IMapper mapper,
            INguoiDungRepository nguoidungRepository
            )
        {
            _nguoiDungRepository = nguoidungRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ExcuteResult> PostAsync([FromBody] CreateUserModel input)
        {
            var existUser = await _nguoiDungRepository.GetAsync(c => c.Phone == input.Phone);
            if (existUser != null)
            {
                return new ExistRecordResult();
            }
            var user = _mapper.Map<NguoiDung>(input);
            var byteSalt = PasswordHasher.GenerateSalt();
            user.PasswordSalt = Convert.ToBase64String(byteSalt);
            user.Password = Convert.ToBase64String(PasswordHasher.ComputeHash(user.Password, byteSalt));
            user.Id = null;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.CreatedBy = RequestUserId;
            user.UpdatedBy = RequestUserId;
            _nguoiDungRepository.Add(user);
            var result = await _uow.CommitAsync();
            if (result)
            {
                var addUser = await _nguoiDungRepository.GetAsync(c => c.Phone == input.Phone);
                return new ExcuteResult(true, "", _mapper.Map<UserModel>(addUser));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


 

        [HttpGet("getAll")]
        [AllowAnonymous]
        public async Task<ExcuteResult> GetAll()
        {
             var ls = await _nguoiDungRepository.GetAll();
            return new ExcuteResult(true, "", ls);
        }

        [HttpGet("Detail")]
        public async Task<ExcuteResult> GetAsync()
        {

            var nd = await _nguoiDungRepository.GetByIdAsync(RequestUserId);
            if (nd == null)
            {
                return new ExcuteResult(false, ErrorMessage: "not found");
            }
        
            return new ExcuteResult(true,null, nd);


        }




    }
}
