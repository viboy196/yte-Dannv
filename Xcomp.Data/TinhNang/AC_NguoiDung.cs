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
    public class AC_NguoiDung
    {
        
        private readonly INguoiDungRepository _NguoiDungRepository;

        private readonly IUnitOfWork _uow;

        public AC_NguoiDung(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _NguoiDungRepository = services.GetRequiredService<INguoiDungRepository>();

        }

        public async Task RemoveAll()
        {
            _NguoiDungRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<NguoiDung> Create(NguoiDung ltc)
        {
            _NguoiDungRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<NguoiDung> Update(NguoiDung ltc)
        {
            _NguoiDungRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<NguoiDung> GetById(string id)
        {   
            return await _NguoiDungRepository.GetByIdAsync(id);
        }

        public async Task<List<NguoiDung>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<NguoiDung>() : (List<NguoiDung>)(await _NguoiDungRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //---------------------------

        public async Task<NguoiDung> GetByPhone(string Phone)
        {
            return await _NguoiDungRepository.GetAsync(c => c.Phone== Phone);
        }

        public async Task ThemToChuc(NguoiDung nd, ToChuc tc)
        {
            if (tc.CreatedBy != null)
            {
                var ndc = await GetById(tc.CreatedBy);
                await Update(ndc.XoaToChuc(tc.Id));
            }
            await Update(nd.ThemToChuc(tc.Id));
            await AC.ToChuc.Update(tc.SetNguoiTao(nd.Id));
        }

        public async Task ThemNhanVien(NguoiDung nd, NhanVien nv)
        {
            await AC.NhanVien.Update(nv.SetNguoiDung(nd.Id));
            await Update(nd.ThemNhanVien(nv.Id));
        }

        public async Task NhanThongBao(NguoiDung nd, ThongBao tb)
        {
            nd.QL_NguoiNhanThongBao(tb);
            await Update(nd);
            //await ComHub.ThongBaoNguoiDungNhan(nd);
        }

        public async Task ThemGiaoDich(NguoiDung nd, GiaoDich gd)
        {
            await Update(nd.ThemGiaoDich(gd.Id));
            await AC.GiaoDich.Update(gd.SetNguoiDung(nd.Id));
        }
    }
}
