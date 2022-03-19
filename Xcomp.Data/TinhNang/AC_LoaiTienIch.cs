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
    public class AC_LoaiTienIch
    {
        
        private readonly ILoaiTienIchRepository _LoaiTienIchRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiTienIch(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiTienIchRepository = services.GetRequiredService<ILoaiTienIchRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiTienIchRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiTienIch> Create(LoaiTienIch ltc)
        {
            _LoaiTienIchRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiTienIch> Update(LoaiTienIch ltc)
        {
            _LoaiTienIchRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiTienIch> GetById(string id)
        {   
            return await _LoaiTienIchRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiTienIch>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiTienIch>() : (List<LoaiTienIch>)(await _LoaiTienIchRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<LoaiTienIch>> GetAll()
        {
            return (List<LoaiTienIch>)await _LoaiTienIchRepository.GetAllAsync();

        }

        public async Task<LoaiTienIch> GetByCode(string Code)
        {
            return await _LoaiTienIchRepository.GetAsync(c => c.Code == Code);
        }

        //---------------------------


    }
}
