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
    public class AC_LoaiToChuc
    {
        
        private readonly ILoaiToChucRepository _LoaiToChucRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiToChuc(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiToChucRepository = services.GetRequiredService<ILoaiToChucRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiToChucRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiToChuc> Create(LoaiToChuc ltc)
        {
            _LoaiToChucRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiToChuc> Update(LoaiToChuc ltc)
        {
            _LoaiToChucRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiToChuc> GetById(string id)
        {   
            return await _LoaiToChucRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiToChuc>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiToChuc>() : (List<LoaiToChuc>)(await _LoaiToChucRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiToChuc> GetByCode(string Code)
        {
            return await _LoaiToChucRepository.GetAsync(c=> c.Code == Code);
        }

        //---------------------------

        public async Task ThemLoaiPhongBan(LoaiToChuc ltc, LoaiPhongBan lpb)
        {
            await Update(ltc.ThemLoaiPhongBan(lpb.Id));
            await AC.LoaiPhongBan.Update(lpb.ThemLoaiToChuc(ltc.Id));
        }

        public async Task ThemLoaiDichVu(LoaiToChuc ltc, LoaiDichVu ldv)
        {
            await Update(ltc.ThemLoaiDichVu(ldv.Id));
            await AC.LoaiDichVu.Update(ldv.ThemLoaiToChuc(ltc.Id));
        }
    }
}
