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
    public class AC_TinhNangMayTuPhucVu
    {
        
        private readonly ITinhNangMayTuPhucVuRepository _TinhNangMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_TinhNangMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _TinhNangMayTuPhucVuRepository = services.GetRequiredService<ITinhNangMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _TinhNangMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<TinhNangMayTuPhucVu> Create(TinhNangMayTuPhucVu tc)
        {
            try
            {
                _TinhNangMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<TinhNangMayTuPhucVu> Update(TinhNangMayTuPhucVu ltc)
        {
            try
            {
                _TinhNangMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<TinhNangMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _TinhNangMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TinhNangMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<TinhNangMayTuPhucVu>() : (List<TinhNangMayTuPhucVu>)(await _TinhNangMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TinhNangMayTuPhucVu>> GetByCode(string Code)
        {
            try
            {
                return (List<TinhNangMayTuPhucVu>)(await _TinhNangMayTuPhucVuRepository.GetAllAsync(c => c.CodeLoaiTinhNangMayTuPhucVu == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][GetByCode]:" + ex.Message, ex);
            }

        }

        //---------------------------
        public async Task ThemLog(TinhNangMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TinhNangMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }
       

    }
}
