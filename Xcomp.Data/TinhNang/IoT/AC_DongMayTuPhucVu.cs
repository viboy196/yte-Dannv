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
    public class AC_DongMayTuPhucVu
    {
        
        private readonly IDongMayTuPhucVuRepository _DongMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_DongMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _DongMayTuPhucVuRepository = services.GetRequiredService<IDongMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _DongMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<DongMayTuPhucVu> Create(DongMayTuPhucVu tc)
        {
            try
            {
                _DongMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<DongMayTuPhucVu> Update(DongMayTuPhucVu ltc)
        {
            try
            {
                _DongMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<DongMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _DongMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<DongMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<DongMayTuPhucVu>() : (List<DongMayTuPhucVu>)(await _DongMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<DongMayTuPhucVu>> GetAll ()
        {
            try
            {
                return (List<DongMayTuPhucVu>)(await _DongMayTuPhucVuRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][GetAll]:" + ex.Message, ex);
            }

        }


        //---------------------------
        public async Task ThemLog(DongMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DongMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }
       

    }
}
