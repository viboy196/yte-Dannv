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
    public class AC_LoaiCongViec
    {
        
        private readonly ILoaiCongViecRepository _LoaiCongViecRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiCongViec(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiCongViecRepository = services.GetRequiredService<ILoaiCongViecRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiCongViecRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiCongViec> Create(LoaiCongViec ltc)
        {
            _LoaiCongViecRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiCongViec> Update(LoaiCongViec ltc)
        {
            _LoaiCongViecRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiCongViec> GetById(string id)
        {   
            return await _LoaiCongViecRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiCongViec>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiCongViec>() : (List<LoaiCongViec>)(await _LoaiCongViecRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiCongViec> GetByCode(string Code)
        {
            return await _LoaiCongViecRepository.GetAsync(c => c.Code == Code);
        }
        //---------------------------

    }
}
