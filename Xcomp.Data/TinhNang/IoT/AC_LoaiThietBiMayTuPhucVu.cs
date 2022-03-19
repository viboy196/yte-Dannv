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
    public class AC_LoaiThietBiMayTuPhucVu
    {
        
        private readonly ILoaiThietBiMayTuPhucVuRepository _LoaiThietBiMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiThietBiMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiThietBiMayTuPhucVuRepository = services.GetRequiredService<ILoaiThietBiMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LoaiThietBiMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiThietBiMayTuPhucVu> Create(LoaiThietBiMayTuPhucVu tc)
        {
            try
            {
                _LoaiThietBiMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiThietBiMayTuPhucVu> Update(LoaiThietBiMayTuPhucVu ltc)
        {
            try
            {
                _LoaiThietBiMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiThietBiMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _LoaiThietBiMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiThietBiMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<LoaiThietBiMayTuPhucVu>() : (List<LoaiThietBiMayTuPhucVu>)(await _LoaiThietBiMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiThietBiMayTuPhucVu>> GetAll()
        {
            try
            {
                return (List<LoaiThietBiMayTuPhucVu>)(await _LoaiThietBiMayTuPhucVuRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][GetAll]:" + ex.Message, ex);
            }

        }

        //---------------------------
        public async Task ThemLog(LoaiThietBiMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiThietBiMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }
       

    }
}
