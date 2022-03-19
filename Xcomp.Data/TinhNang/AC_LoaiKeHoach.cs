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
    public class AC_LoaiKeHoach
    {
        
        private readonly ILoaiKeHoachRepository _LoaiKeHoachRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiKeHoach(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiKeHoachRepository = services.GetRequiredService<ILoaiKeHoachRepository>();

        }

        public async Task RemoveAll()
        {
            _LoaiKeHoachRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<LoaiKeHoach> Create(LoaiKeHoach ltc)
        {
            _LoaiKeHoachRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiKeHoach> Update(LoaiKeHoach ltc)
        {
            _LoaiKeHoachRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<LoaiKeHoach> GetById(string id)
        {   
            return await _LoaiKeHoachRepository.GetByIdAsync(id);
        }

        public async Task<List<LoaiKeHoach>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<LoaiKeHoach>() : (List<LoaiKeHoach>)(await _LoaiKeHoachRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //---------------------------

        public async Task ThemLoaiViec(LoaiKeHoach lkh, LoaiViec lv)
        {
            await Update(lkh.ThemLoaiViec(lv.Id));
            await AC.LoaiViec.Update(lv.ThemLoaiKeHoach(lkh.Id));
        }

    }
}
