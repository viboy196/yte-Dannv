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
    public class AC_LoaiHangHoa
    {
        
        private readonly ILoaiHangHoaRepository _LoaiHangHoaRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiHangHoa(IServiceProvider services)
        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiHangHoaRepository = services.GetRequiredService<ILoaiHangHoaRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiHangHoaRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiHangHoa> Create(LoaiHangHoa ltc)
        {
            _LoaiHangHoaRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiHangHoa> Update(LoaiHangHoa ltc)
        {
            _LoaiHangHoaRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiHangHoa> GetById(string id)
        {   
            return await _LoaiHangHoaRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiHangHoa>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiHangHoa>() : (List<LoaiHangHoa>)(await _LoaiHangHoaRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //---------------------------

        
    }
}
