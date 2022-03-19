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
    public class AC_LoaiTinhNangMayTuPhucVu
    {
        
        private readonly ILoaiTinhNangMayTuPhucVuRepository _LoaiTinhNangMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiTinhNangMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiTinhNangMayTuPhucVuRepository = services.GetRequiredService<ILoaiTinhNangMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LoaiTinhNangMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiTinhNangMayTuPhucVu> Create(LoaiTinhNangMayTuPhucVu tc)
        {
            try
            {
                _LoaiTinhNangMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiTinhNangMayTuPhucVu> Update(LoaiTinhNangMayTuPhucVu ltc)
        {
            try
            {
                _LoaiTinhNangMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiTinhNangMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _LoaiTinhNangMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiTinhNangMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<LoaiTinhNangMayTuPhucVu>() : (List<LoaiTinhNangMayTuPhucVu>)(await _LoaiTinhNangMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiTinhNangMayTuPhucVu>> GetAll()
        {
            try
            {
                return  (List<LoaiTinhNangMayTuPhucVu>)(await _LoaiTinhNangMayTuPhucVuRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][Get]:" + ex.Message, ex);
            }

        }
        //---------------------------
        public async Task ThemLog(LoaiTinhNangMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiTinhNangMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }
       

    }
}
