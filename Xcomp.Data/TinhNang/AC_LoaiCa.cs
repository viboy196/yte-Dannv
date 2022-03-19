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
    public class AC_LoaiCa
    {
        
        private readonly ILoaiCaRepository _LoaiCaRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiCa(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiCaRepository = services.GetRequiredService<ILoaiCaRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiCaRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiCa> Create(LoaiCa ltc)
        {
            _LoaiCaRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiCa> Update(LoaiCa ltc)
        {
            _LoaiCaRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiCa> GetById(string id)
        {   
            return await _LoaiCaRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiCa>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiCa>() : (List<LoaiCa>)(await _LoaiCaRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<LoaiCa>> GetByCodeHeThong(CodeHeThong Code)
        {
            return (List<LoaiCa>)(await _LoaiCaRepository.GetAllAsync(c =>c.CodeHeThong == Code));
        }

        public async Task<LoaiCa> GetByCode(string Code)
        {
            return await _LoaiCaRepository.GetAsync(c => c.Code == Code);
        }
        //---------------------------

        public async Task ThemLoaiHangHoa(LoaiCa lc, LoaiHangHoa lhh)
        {
            await Update(lc.ThemLoaiHangHoa(lhh.Id));
            await AC.LoaiHangHoa.Update(lhh.ThemLoaiCa(lc.Id));
        }

        public async Task ThemLoaiKeHoach(LoaiCa lc, LoaiKeHoach lkh)
        {
            await Update(lc.ThemLoaiKeHoach(lkh.Id));
        }

        public async Task ThemPhanSu(LoaiCa lc, PhanSu ps)
        {
            await Update(lc.ThemPhanSu(ps.Id));
        }
    }
}
