using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_TinHieu
    {
        
        private readonly ITinHieuRepository _TinHieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_TinHieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _TinHieuRepository = services.GetRequiredService<ITinHieuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _TinHieuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<TinHieu> Create(TinHieu tc)
        {
            try
            {
                _TinHieuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<TinHieu> Update(TinHieu ltc)
        {
            try
            {
                _TinHieuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<TinHieu> GetById(string id)
        {
            try
            {
                return await _TinHieuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TinHieu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<TinHieu>() : (List<TinHieu>)(await _TinHieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TinHieu>> GetByCode(string Code)
        {
            try
            {
                return (List<TinHieu>)(await _TinHieuRepository.GetAllAsync(c => c.CodeLoaiTinHieu == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(TinHieu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][ThemLog]:" + ex.Message, ex);
            }
        }
        

        public async Task<TinHieu> NhanTinHieu(string codelth, string idti, string idca, string nguon, string thongso)
        {
            try
            {
                var ca = await AC.Ca.GetById(idca);
                var ti = await AC.TienIch.GetById(idti);
                var lth = await AC.LoaiTinHieu.GetByCode(codelth);
                var dt = await AC.DoiTuong.GetById(ca.IdDoiTuong);

                var th = await Create(new TinHieu
                {
                     LoaiTinHieu = lth.Name,
                     CodeLoaiTinHieu = lth.Code,
                     CreatedAt = DateTime.Now
                });

                await AC.DoiTuong.Update(dt.ThemTinHieu(th.Id));
                th.IdDoiTuong = dt.Id;
                await AC.TienIch.Update(ti.ThemTinHieu(th.Id));
                th.IdTienIch = ti.Id;
                await Update(th);

                return th;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinHieu][NhanTinHieu]:" + ex.Message, ex);
            }
            
        }    

    }
}
