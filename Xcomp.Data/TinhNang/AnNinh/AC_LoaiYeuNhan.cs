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
    public class AC_LoaiYeuNhan
    {
        
        private readonly ILoaiYeuNhanRepository _LoaiYeuNhanRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiYeuNhan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiYeuNhanRepository = services.GetRequiredService<ILoaiYeuNhanRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiYeuNhanRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiYeuNhan> Create(LoaiYeuNhan ltc)
        {
            _LoaiYeuNhanRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiYeuNhan> Update(LoaiYeuNhan ltc)
        {
            _LoaiYeuNhanRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiYeuNhan> GetById(string id)
        {   
            return await _LoaiYeuNhanRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiYeuNhan>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiYeuNhan>() : (List<LoaiYeuNhan>)(await _LoaiYeuNhanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiYeuNhan> GetByCode(string Code)
        {
            return await _LoaiYeuNhanRepository.GetAsync(c=> c.Code == Code);
        }

        public async Task<List<LoaiYeuNhan>> GetAll()
        {
            return (List<LoaiYeuNhan>)await _LoaiYeuNhanRepository.GetAllAsync();

        }

        //---------------------------

    }
}
