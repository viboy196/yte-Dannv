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
    public class AC_LoaiDichVu
    {
        
        private readonly ILoaiDichVuRepository _LoaiDichVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiDichVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiDichVuRepository = services.GetRequiredService<ILoaiDichVuRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiDichVuRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiDichVu> Create(LoaiDichVu ltc)
        {
            _LoaiDichVuRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiDichVu> Update(LoaiDichVu ltc)
        {
            _LoaiDichVuRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiDichVu> GetById(string id)
        {   
            return await _LoaiDichVuRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiDichVu>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiDichVu>() : (List<LoaiDichVu>)(await _LoaiDichVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<LoaiDichVu> GetByCode(string Code)
        {
            return await _LoaiDichVuRepository.GetAsync(c => c.Code == Code);
        }

        //---------------------------

        public async Task ThemLoaiHangHoa(LoaiDichVu ldv, LoaiHangHoa lhh)
        {
            await AC.LoaiHangHoa.Update(lhh.ThemLoaiDichVu(ldv.Id));
            await AC.LoaiDichVu.Update(ldv.ThemLoaiHangHoa(lhh.Id));
        }
    }
}
