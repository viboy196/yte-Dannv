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
    public class AC_GiaoDich
    {
        
        private readonly IGiaoDichRepository _GiaoDichRepository;

        private readonly IUnitOfWork _uow;

        public AC_GiaoDich(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _GiaoDichRepository = services.GetRequiredService<IGiaoDichRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _GiaoDichRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<GiaoDich> Create(GiaoDich tc)
        {
            try
            {
                _GiaoDichRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][Create]:" + ex.Message, ex);
            }

        }

        public async Task<GiaoDich> Update(GiaoDich ltc)
        {
            try
            {
                _GiaoDichRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][Update]:" + ex.Message, ex);
            }

        }

        public async Task<GiaoDich> GetById(string id)
        {
            try
            {
                return await _GiaoDichRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<GiaoDich>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<GiaoDich>() : (List<GiaoDich>)(await _GiaoDichRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(GiaoDich tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][ThemLog]:" + ex.Message, ex);
            }
        }
        //-------------------------------
        public async Task SetHangHoa(GiaoDich gd, HangHoa hh)
        {
            try
            {
                await Update(gd.SetHangHoa(hh.Id));
                await AC.HangHoa.Update(hh.ThemGiaoDich(gd.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][SetHangHoa]:" + ex.Message, ex);
            }
            
        }

        public async Task ThemThanhToan(GiaoDich gd, ThanhToan tt)
        {
            try
            {
                await Update(gd.ThemThanhToan(tt.Id));
                await AC.ThanhToan.Update(tt.SetGiaoDich(gd.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiaoDich][ThemThanhToan]:" + ex.Message, ex);
            }
        }


    }
}
