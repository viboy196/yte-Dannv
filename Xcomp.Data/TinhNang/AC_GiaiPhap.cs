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
    public class AC_GiaiPhap
    {
        
        private readonly IGiaiPhapRepository _GiaiPhapRepository;

        private readonly IUnitOfWork _uow;

        public AC_GiaiPhap(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _GiaiPhapRepository = services.GetRequiredService<IGiaiPhapRepository>();

        }

        public async Task RemoveAll()
        {
            _GiaiPhapRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<GiaiPhap> Create(GiaiPhap ltc)
        {
            _GiaiPhapRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<GiaiPhap> Update(GiaiPhap ltc)
        {
            _GiaiPhapRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<GiaiPhap> GetById(string id)
        {   
            return await _GiaiPhapRepository.GetByIdAsync(id);
        }

        public async Task<List<GiaiPhap>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<GiaiPhap>() : (List<GiaiPhap>)(await _GiaiPhapRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<GiaiPhap>> GetByCode(string Code)
        {
            return (List<GiaiPhap>)(await _GiaiPhapRepository.GetAllAsync(c=> c.CodeLoaiGiaiPhap == Code));
        }
        //---------------------------
        public async Task SetGiaiPhap_ToChuc(GiaiPhap gp, ToChuc tc)
        {
            await AC.ToChuc.Update(tc.ThemGiaiPhap(gp.Id));
            await Update(gp.SetToChuc(tc.Id));
        }
        public async Task SetGiaiPhap_PhongBan(GiaiPhap gp, PhongBan pb)
        {
            await AC.PhongBan.Update(pb.ThemGiaiPhap(gp.Id));
            await Update(gp.SetPhongBan(pb.Id));
        }

        public async Task ThemCongViec(GiaiPhap gp, CongViec cv)
        {
            await AC.CongViec.Update(cv.SetGiaiPhap(gp.Id));
            await Update(gp.ThemCongViec(cv.Id));
        }

        public async Task TaoMoiGiaiPhap_ToChuc(string idtc, string idlgp)
        {
            var tc = await AC.ToChuc.GetById(idtc);
            var lgp = await AC.LoaiGiaiPhap.GetById(idlgp);

            var gp = await Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp.Name,
                CodeLoaiGiaiPhap = lgp.Code
            });
            await SetGiaiPhap_ToChuc(gp, tc);
        }

        public async Task TaoMoiGiaiPhap_PhongBan(string idpb, string idlgp)
        {
            var pb = await AC.PhongBan.GetById(idpb);
            var lgp = await AC.LoaiGiaiPhap.GetById(idlgp);

            var gp = await Create(new GiaiPhap
            {
                LoaiGiaiPhap = lgp.Name,
                CodeLoaiGiaiPhap = lgp.Code
            });
            await SetGiaiPhap_PhongBan(gp, pb);
        }

    }
}
