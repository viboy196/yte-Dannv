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
    public class AC_CongViec
    {
        
        private readonly ICongViecRepository _CongViecRepository;

        private readonly IUnitOfWork _uow;

        public AC_CongViec(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _CongViecRepository = services.GetRequiredService<ICongViecRepository>();

        }

        public async Task RemoveAll()
        {
            _CongViecRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<CongViec> Create(CongViec ltc)
        {
            ltc.CreatedAt = DateTime.Now;
            ltc.UpdatedAt = DateTime.Now;
            _CongViecRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<CongViec> Update(CongViec ltc)
        {
            _CongViecRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<CongViec> GetById(string id)
        {   
            return await _CongViecRepository.GetByIdAsync(id);
        }

        public async Task<List<CongViec>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<CongViec>() : (List<CongViec>)(await _CongViecRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        public async Task<List<CongViec>> GetByCode(string Code)
        {
            return (List<CongViec>)(await _CongViecRepository.GetAllAsync(c=> c.CodeLoaiCongViec == Code));
        }
        //---------------------------

        public async Task<CongViec> TaoCongViecMoi(CongViecRequest model)
        {

            var lv = await AC.LoaiCongViec.GetById(model.IdLoaiCongViec);
            var gp = await AC.GiaiPhap.GetById(model.IdGiaiPhap);

            var cv = new CongViec()
            {
                IdNhanVien = model.IdNhanVien,
                LoaiCongViec = lv.Name,
                CodeLoaiCongViec = lv.Code,
                IdToChuc = model.IdToChuc,
                ThucHien = lv.ThucHien,
                IdHeThong = SystemInfo.HeThong != null ? SystemInfo.HeThong.Id : model.IdHeThong,
                IdPhongBan = gp.IdPhongBan,
                CreatedBy = model.IdNguoiTao

            };

            await AC.CongViec.Create(cv);
            
            await AC.GiaiPhap.ThemCongViec(gp, cv);

            var nv = await AC.NhanVien.GetById(cv.IdNhanVien);
            await AC.NhanVien.Update(nv.ThemCongViec(cv.Id));

            if (nv.IdNguoiDung != null)
            {
                var nd = await AC.NguoiDung.GetById(nv.IdNguoiDung);
                var tc = await AC.ToChuc.GetById(cv.IdToChuc);
                var tb_taomoicongviec = await AC.ThongBao.Create(new ThongBao
                {
                    Loai = LoaiThongBao.Tao_CongViec,
                    IdDoiTuongGui = nv.IdToChuc,
                    IdDoiTuongNhan = cv.Id,
                    IdNguoinhan = nv.IdNguoiDung,
                    NoiDung = "Lời mời tham gia công việc " + cv.LoaiCongViec + " từ " + tc.Name
                });
                await NhanThongBao(cv, tb_taomoicongviec);
                await AC.NguoiDung.NhanThongBao(nd, tb_taomoicongviec);
            }


            return cv;

        }

        public async Task NhanThongBao(CongViec cv, ThongBao tb)
        {
            cv.QL_NhanThongBao(tb);
            await Update(cv);
        }

        public async Task ThemLog(CongViec cv, Log lg)
        {
            cv.QL_ThemLog(lg);
            await Update(cv);
        }
    }
}
