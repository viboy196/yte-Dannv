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
    public class AC_LoaiMauTrang
    {
        
        private readonly ILoaiMauTrangRepository _LoaiMauTrangRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiMauTrang(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiMauTrangRepository = services.GetRequiredService<ILoaiMauTrangRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiMauTrangRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiMauTrang> Create(LoaiMauTrang ltc)
        {
            _LoaiMauTrangRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiMauTrang> Update(LoaiMauTrang ltc)
        {
            _LoaiMauTrangRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiMauTrang> GetById(string id)
        {   
            return await _LoaiMauTrangRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiMauTrang>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiMauTrang>() : (List<LoaiMauTrang>)(await _LoaiMauTrangRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiMauTrang> GetByCode(string Code)
        {
            return await _LoaiMauTrangRepository.GetAsync(c=> c.Code == Code);
        }

        //---------------------------

    }
}
