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
    public class AC_LoaiBanTin
    {
        
        private readonly ILoaiBanTinRepository _LoaiBanTinRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiBanTin(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiBanTinRepository = services.GetRequiredService<ILoaiBanTinRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiBanTinRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiBanTin> Create(LoaiBanTin ltc)
        {
            _LoaiBanTinRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiBanTin> Update(LoaiBanTin ltc)
        {
            _LoaiBanTinRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiBanTin> GetById(string id)
        {   
            return await _LoaiBanTinRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiBanTin>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiBanTin>() : (List<LoaiBanTin>)(await _LoaiBanTinRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiBanTin> GetByCode(string Code)
        {
            return await _LoaiBanTinRepository.GetAsync(c=> c.Code == Code);
        }

        //---------------------------

    }
}
