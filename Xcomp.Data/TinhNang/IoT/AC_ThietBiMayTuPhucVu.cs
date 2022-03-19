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
    public class AC_ThietBiMayTuPhucVu
    {
        
        private readonly IThietBiMayTuPhucVuRepository _ThietBiMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_ThietBiMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ThietBiMayTuPhucVuRepository = services.GetRequiredService<IThietBiMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ThietBiMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<ThietBiMayTuPhucVu> Create(ThietBiMayTuPhucVu tc)
        {
            try
            {
                _ThietBiMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<ThietBiMayTuPhucVu> Update(ThietBiMayTuPhucVu ltc)
        {
            try
            {
                _ThietBiMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<ThietBiMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _ThietBiMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ThietBiMayTuPhucVu>> GetByCode(string Code)
        {
            try
            {
                return (List<ThietBiMayTuPhucVu>)(await _ThietBiMayTuPhucVuRepository.GetAllAsync(c => c.CodeLoaiThietBiMayTuPhucVu ==Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][GetByCode]:" + ex.Message, ex);
            }

        }

        public async Task<List<ThietBiMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<ThietBiMayTuPhucVu>() : (List<ThietBiMayTuPhucVu>)(await _ThietBiMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }
                
        //---------------------------
        public async Task ThemLog(ThietBiMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThietBiMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }
       

    }
}
