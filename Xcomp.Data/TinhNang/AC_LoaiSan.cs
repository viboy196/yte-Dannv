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
    public class AC_LoaiSan
    {
        
        private readonly ILoaiSanRepository _LoaiSanRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiSan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiSanRepository = services.GetRequiredService<ILoaiSanRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiSanRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiSan> Create(LoaiSan ltc)
        {
            _LoaiSanRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiSan> Update(LoaiSan ltc)
        {
            _LoaiSanRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiSan> GetById(string id)
        {   
            return await _LoaiSanRepository.GetByIdAsync(id);
        }

        public async Task<LoaiSan> GetByCode(string Code)
        {
            return await _LoaiSanRepository.GetAsync(c => c.Code == Code);
        }

        public async Task<List<LoaiSan>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiSan>() : (List<LoaiSan>)(await _LoaiSanRepository.GetAllAsync(c=> Dsid.Contains(c.Id)));
        }

        public async Task<List<LoaiSan>> GetAll()
        {
            return (List<LoaiSan>)(await _LoaiSanRepository.GetAllAsync());
        }


        //---------------------------
        public async Task ThemLoaiDichVu(LoaiSan ls, LoaiDichVu ldv)
        {
            await Update(ls.ThemLoaiDichVu(ldv.Id));
            await AC.LoaiDichVu.Update(ldv.SetLoaiSan(ls.Id));
        }
    }
}
