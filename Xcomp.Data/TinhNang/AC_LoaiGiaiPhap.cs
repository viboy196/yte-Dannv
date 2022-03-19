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
    public class AC_LoaiGiaiPhap
    {
        
        private readonly ILoaiGiaiPhapRepository _LoaiGiaiPhapRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiGiaiPhap(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiGiaiPhapRepository = services.GetRequiredService<ILoaiGiaiPhapRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiGiaiPhapRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiGiaiPhap> Create(LoaiGiaiPhap ltc)
        {
            _LoaiGiaiPhapRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiGiaiPhap> Update(LoaiGiaiPhap ltc)
        {
            _LoaiGiaiPhapRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiGiaiPhap> GetById(string id)
        {   
            return await _LoaiGiaiPhapRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiGiaiPhap>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiGiaiPhap>() : (List<LoaiGiaiPhap>)(await _LoaiGiaiPhapRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiGiaiPhap> GetByCode(string Code)
        {
            return await _LoaiGiaiPhapRepository.GetAsync(c => c.Code == Code);
        }

        public async Task<List<LoaiGiaiPhap>> GetAll()
        {
            return (List<LoaiGiaiPhap>)(await _LoaiGiaiPhapRepository.GetAllAsync());
        }

        //---------------------------

        public async Task ThemLoaiToChuc(LoaiGiaiPhap lgp, LoaiToChuc ltc)
        {
            await Update(lgp.ThemLoaiToChuc(ltc.Id));
            await AC.LoaiToChuc.Update(ltc.ThemLoaiGiaiPhap(lgp.Id));
        }
        public async Task ThemLoaiPhongBan(LoaiGiaiPhap lgp, LoaiPhongBan lpb)
        {
            await Update(lgp.ThemLoaiPhongBan(lpb.Id));
            await AC.LoaiPhongBan.Update(lpb.ThemLoaiGiaiPhap(lgp.Id));
        }

        public async Task ThemLoaiCongViec(LoaiGiaiPhap lhscv, LoaiCongViec lcv)
        {
            await Update(lhscv.ThemLoaiCongViec(lcv.Id));
            await AC.LoaiCongViec.Update(lcv.ThemLoaiGiaiPhap(lhscv.Id));
        }

       

       
    }
}
