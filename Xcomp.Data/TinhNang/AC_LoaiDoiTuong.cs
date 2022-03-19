using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_LoaiDoiTuong
    {
        
        private readonly ILoaiDoiTuongRepository _LoaiDoiTuongRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiDoiTuong(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiDoiTuongRepository = services.GetRequiredService<ILoaiDoiTuongRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiDoiTuongRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiDoiTuong> Create(LoaiDoiTuong ltc)
        {
            _LoaiDoiTuongRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiDoiTuong> Update(LoaiDoiTuong ltc)
        {
            _LoaiDoiTuongRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiDoiTuong> GetById(string id)
        {   
            return await _LoaiDoiTuongRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiDoiTuong>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiDoiTuong>() : (List<LoaiDoiTuong>)(await _LoaiDoiTuongRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiDoiTuong> GetByCode(string Code)
        {
            return await _LoaiDoiTuongRepository.GetAsync(c=> c.Code == Code);
        }

        public async Task<List<LoaiDoiTuong>> GetByCodeHeThong(CodeHeThong Code)
        {
            return  (List<LoaiDoiTuong>)(await _LoaiDoiTuongRepository.GetAllAsync(c => c.CodeHeThong == Code));
        }

        public async Task Them_LoaiTienIch(LoaiDoiTuong ldt, LoaiTienIch lti)
        {
            await Update(ldt.ThemLoaiTienIch(lti.Id));
            await AC.LoaiTienIch.Update(lti.ThemLoaiDoiTuong(ldt.Id));
        }

        public async Task Them_LoaiCa(LoaiDoiTuong ldt, LoaiCa lc)
        {
            await Update(ldt.ThemLoaiCa(lc.Id));
            await AC.LoaiCa.Update(lc.ThemLoaiDoiTuong(ldt.Id));
        }

    }
}
