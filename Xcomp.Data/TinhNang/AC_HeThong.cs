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
    public class AC_HeThong
    {
        private readonly IHeThongRepository _HeThongRepository;

        private readonly IUnitOfWork _uow;

        public AC_HeThong(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();

            _HeThongRepository = services.GetRequiredService<IHeThongRepository>();

        }

        public async Task<HeThong> Create(HeThong ht)
        {
            _HeThongRepository.Add(ht);
            await _uow.CommitAsync();
            return ht;

        }

        public async Task<HeThong> Update(HeThong ht)
        {
            _HeThongRepository.Update(ht.Id, ht);
            await _uow.CommitAsync();
            return ht;
        }

        public async Task<HeThong> GetById(string id)
        {
            return await _HeThongRepository.GetByIdAsync(id);
        }

        public async Task<HeThong> GetByCodeHeThong(CodeHeThong Code)
        {
            return await _HeThongRepository.GetByCodeHeThongAsync(Code);
        }

        public async Task<List<HeThong>>GetAll()
        {
            return (List<HeThong>) await _HeThongRepository.GetAllAsync();

        }

        public async Task RemoveAll()
        {
            _HeThongRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<List<HeThong>> Get(List<string> Dsid)
        {
            return Dsid==null? new List<HeThong>(): (List<HeThong>)(await _HeThongRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //----------------------------------
        public async Task ThemLoaiToChuc(HeThong ht, LoaiToChuc ltc)
        {            
            await Update(ht.ThemLoaiToChuc(ltc.Id));
            await AC.LoaiToChuc.Update(ltc.SetHeThong(ht.Id));
        }
                
        public async Task ThemLoaiSan(HeThong ht, LoaiSan ls, string QuanHe)
        {
            await Update((HeThong)ht.DS_Add(ls.Id,QuanHe));
            await AC.LoaiSan.Update((LoaiSan)ls.DS_Add(ht.Id,QuanHe));
        }
    }
}
