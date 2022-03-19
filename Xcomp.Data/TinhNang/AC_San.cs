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
    public class AC_San
    {
        
        private readonly ISanRepository _SanRepository;

        private readonly IUnitOfWork _uow;

        public AC_San(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _SanRepository = services.GetRequiredService<ISanRepository>();

        }

        public async Task RemoveAll()
        {
            _SanRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<San> Create(San ltc)
        {
            _SanRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<San> Update(San ltc)
        {
            _SanRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<San> GetById(string id)
        {   
            return await _SanRepository.GetByIdAsync(id);
        }

        public async Task<List<San>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<San>() : (List<San>)(await _SanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<San>> GetByCode(string Code)
        {
            return (List<San>)(await _SanRepository.GetAllAsync(c => c.CodeLoaiSan == Code));
        }
        //---------------------------

    }
}
