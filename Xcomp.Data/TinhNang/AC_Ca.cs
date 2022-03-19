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
    public class AC_Ca
    {
        
        private readonly ICaRepository _CaRepository;

        private readonly IUnitOfWork _uow;

        public AC_Ca(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _CaRepository = services.GetRequiredService<ICaRepository>();

        }

        public async Task RemoveAll()
        {
            _CaRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<Ca> Create(Ca ltc)
        {
            _CaRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<Ca> Update(Ca ltc)
        {
            _CaRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<Ca> GetById(string id)
        {   
            return await _CaRepository.GetByIdAsync(id);
        }

        public async Task<List<Ca>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<Ca>() : (List<Ca>)(await _CaRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        //---------------------------

        public async Task SetDoiTuong(Ca ca, DoiTuong dt)
        {
            await Update(ca.SetDoiTuong(dt.Id));
            await AC.DoiTuong.Update(dt.ThemCa(ca.Id));
        }


        public async Task ThemLog(Ca ca, Log lg)
        {
            ca.QL_ThemLog(lg);
            await Update(ca);
        }

        public async Task Xoa_NhanVien(string idca, string idnv, string Ds)
        {
            var nv = await AC.NhanVien.GetById(idnv);
            var ca = await AC.Ca.GetById(idca);

            await Update((Ca)ca.DS_Xoa(idnv, Ds));
            await AC.NhanVien.Update((NhanVien)nv.DS_Xoa(ca.Id, Ds));
        }

        public async Task Them_NhanVien(Ca ca, NhanVien nv, string Ds)
        {
            await Update((Ca)ca.DS_Add(nv.Id, Ds));
            await AC.NhanVien.Update((NhanVien)nv.DS_Add(ca.Id, Ds));
        }

        public async Task Them_KeHoach(Ca ca, KeHoach kh)
        {
            await Update(ca.ThemKeHoach(kh.Id));
            await AC.KeHoach.Update(kh.SetHoSo(ca.Id));
        }

        public async Task ThemPhanSuNhanVien(Ca ca, NhanVien nv, PhanSu ps)
        {
            await ThemNhanVien(ca, nv, "Ca_" + ps.Code);
        }

        public async Task ThemNhanVien(Ca ca, NhanVien nv, string Ds)
        {
            await Update((Ca)ca.DS_Add(nv.Id, Ds));
            await AC.NhanVien.Update((NhanVien)nv.DS_Add(ca.Id, Ds));
        }

        public async Task ThemGiaoDich(Ca ca, GiaoDich gd)
        {
            await Update(ca.ThemGiaoDich(gd.Id));
            await AC.GiaoDich.Update(gd.SetHoSo(ca.Id));
        }
    }
}
