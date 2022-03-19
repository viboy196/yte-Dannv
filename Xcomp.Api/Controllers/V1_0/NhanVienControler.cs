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
    public class NhanVienController : BaseController
    {
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly INhanVienRepository _nhanVienRepository;



        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public NhanVienController(
            IUnitOfWork uow,
            IMapper mapper,
            INguoiDungRepository nguoidungRepository,
            INhanVienRepository nhanVienRepository,
            IHeThongRepository hethongRepository,
            ICongViecRepository congViecRepository,
             IToChucRepository toChucRepository
            )
        {
            _nguoiDungRepository = nguoidungRepository;
            _nhanVienRepository = nhanVienRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("get-Nhanviens-by-nguoidung")]
        public async Task<ExcuteResult> GetNhanViensByNguoiDung()
        {
            var nguoidung = await _nguoiDungRepository.GetByIdAsync(RequestUserId);

             var lsNhanVien =(List<NhanVien>) await _nhanVienRepository.GetAllAsync(nv => nguoidung.Id == nv.IdNguoiDung && nv.IdHeThong == SystemInfo.HeThong.Id);

            if (lsNhanVien == null) return new ExcuteResult(false, "not exited");

            return new ExcuteResult(true, "", lsNhanVien);
        }




    }
}
