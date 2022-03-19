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
    public class AC_LoaiPhongBan
    {
        
        private readonly ILoaiPhongBanRepository _LoaiPhongBanRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiPhongBan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiPhongBanRepository = services.GetRequiredService<ILoaiPhongBanRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiPhongBanRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiPhongBan> Create(LoaiPhongBan ltc)
        {
            _LoaiPhongBanRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiPhongBan> Update(LoaiPhongBan ltc)
        {
            _LoaiPhongBanRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiPhongBan> GetById(string id)
        {   
            return await _LoaiPhongBanRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiPhongBan>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiPhongBan>() : (List<LoaiPhongBan>)(await _LoaiPhongBanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiPhongBan> GetByCode(string Code)
        {
            return await _LoaiPhongBanRepository.GetAsync(c => c.Code == Code);
        }
        //---------------------------

    }
}
