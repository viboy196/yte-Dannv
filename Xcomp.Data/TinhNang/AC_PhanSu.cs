using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_PhanSu
    {
        
        private readonly IPhanSuRepository _PhanSuRepository;

        private readonly IUnitOfWork _uow;

        public AC_PhanSu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _PhanSuRepository = services.GetRequiredService<IPhanSuRepository>();

        }

        public async Task RemoveAll()
        {
            _PhanSuRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<PhanSu> Create(PhanSu ltc)
        {
            _PhanSuRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<PhanSu> Update(PhanSu ltc)
        {
            _PhanSuRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<PhanSu> GetById(string id)
        {   
            return await _PhanSuRepository.GetByIdAsync(id);
        }

        public async Task<List<PhanSu>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<PhanSu>() : (List<PhanSu>)(await _PhanSuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<PhanSu>> GetByCodeHeThong(CodeHeThong Code)
        {
            return (List<PhanSu>)(await _PhanSuRepository.GetAllAsync(c => c.CodeHeThong == Code));
        }


        //---------------------------

    }
}
