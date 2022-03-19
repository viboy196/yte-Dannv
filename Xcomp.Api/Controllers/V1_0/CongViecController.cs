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
    public class CongViecController : BaseController
    {
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICongViecRepository _congViecRepository;



        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CongViecController(
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
            _congViecRepository = congViecRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("get-list-CongViec-by-IdNhanVien")]
        public async Task<ExcuteResult> GetCongViecByNhanVien(string idNhanVien)
        {
            var lsCongViec = (List<CongViec>)await _congViecRepository.GetAllAsync(cv => cv.IdNhanVien == idNhanVien && cv.IdHeThong == SystemInfo.HeThong.Id);
            if (lsCongViec == null) return new ExcuteResult(false, "not exited");
            return new ExcuteResult(true, "", lsCongViec);
        }

        [HttpGet("get-list-congviec-by-system-anninh")]
        public async Task<ExcuteResult> GetCongViecBySysTemSOS()
        {
            var nguoidung = await _nguoiDungRepository.GetByIdAsync(RequestUserId);
            if (nguoidung.DsIdNhanVien != null)
            {
                var lsCongViec = (List<CongViec>)await _congViecRepository.GetAllAsync(cv => nguoidung.DsIdNhanVien.Contains(cv.IdNhanVien) && cv.IdHeThong == SystemInfo.HeThongAnNinh.Id);
                if (lsCongViec == null) return new ExcuteResult(false, "not exited");
                return new ExcuteResult(true, "", lsCongViec);
            }
            return new ExcuteResult(false);
        }




    }
}
