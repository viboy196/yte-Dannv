using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_LoaiTinHieu
    {
        
        private readonly ILoaiTinHieuRepository _LoaiTinHieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiTinHieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiTinHieuRepository = services.GetRequiredService<ILoaiTinHieuRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiTinHieuRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiTinHieu> Create(LoaiTinHieu ltc)
        {
            _LoaiTinHieuRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiTinHieu> Update(LoaiTinHieu ltc)
        {
            _LoaiTinHieuRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiTinHieu> GetById(string id)
        {   
            return await _LoaiTinHieuRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiTinHieu>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiTinHieu>() : (List<LoaiTinHieu>)(await _LoaiTinHieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiTinHieu> GetByCode(string Code)
        {
            return await _LoaiTinHieuRepository.GetAsync(c=> c.Code == Code);
        }

        public async Task ThemTienIch(LoaiTinHieu lth, LoaiTienIch lti)
        {
            await Update(lth.ThemLoaiTienIch(lti.Id));
            await AC.LoaiTienIch.Update(lti.ThemLoaiTinHieu(lth.Id));
        }
    }
}
