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
    public class AC_LoaiMauWeb
    {
        
        private readonly ILoaiMauWebRepository _LoaiMauWebRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiMauWeb(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiMauWebRepository = services.GetRequiredService<ILoaiMauWebRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiMauWebRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiMauWeb> Create(LoaiMauWeb ltc)
        {
            _LoaiMauWebRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiMauWeb> Update(LoaiMauWeb ltc)
        {
            _LoaiMauWebRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiMauWeb> GetById(string id)
        {   
            return await _LoaiMauWebRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiMauWeb>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiMauWeb>() : (List<LoaiMauWeb>)(await _LoaiMauWebRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiMauWeb> GetByCode(string Code)
        {
            return await _LoaiMauWebRepository.GetAsync(c=> c.Code == Code);
        }

        //---------------------------

    }
}
