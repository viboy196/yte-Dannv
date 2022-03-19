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
    public class AC_LoaiViec
    {
        
        private readonly ILoaiViecRepository _LoaiViecRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiViec(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiViecRepository = services.GetRequiredService<ILoaiViecRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiViecRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiViec> Create(LoaiViec ltc)
        {
            _LoaiViecRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiViec> Update(LoaiViec ltc)
        {
            _LoaiViecRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiViec> GetById(string id)
        {   
            return await _LoaiViecRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiViec>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiViec>() : (List<LoaiViec>)(await _LoaiViecRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //---------------------------

    }
}
