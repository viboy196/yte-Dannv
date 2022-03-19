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
    public class TienIchController : BaseController
    {
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly ITienIchRepository _tienichRepository;


        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public static HeThong ht { get; set; }

        public TienIchController(
            IUnitOfWork uow,
            IMapper mapper,
            INguoiDungRepository nguoidungRepository,
            ITienIchRepository tienichRepository
            )
        {
            _nguoiDungRepository = nguoidungRepository;
            _tienichRepository = tienichRepository;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("get-tienich-anninh-by-nguoidung")]
        public async Task<ExcuteResult> GetAsync()
        {
            var nguoidung = await _nguoiDungRepository.GetByIdAsync(RequestUserId);
            if (nguoidung == null) return new ExcuteResult(false, "not found");
            if (nguoidung.DsIdTienIch == null) return new ExcuteResult(false, "Nguoi dung khong co tien ich");
            var Dstienich = await _tienichRepository.GetAllAsync(ti => ti.IdNguoidung == nguoidung.Id && ti.CodeHeThong ==CodeHeThong.AnNinh);
            if (Dstienich == null) return new ExcuteResult(false, "Nguoi dung khong co tien ich");
            return new ExcuteResult(true,null,Dstienich);
        }
    }
}
