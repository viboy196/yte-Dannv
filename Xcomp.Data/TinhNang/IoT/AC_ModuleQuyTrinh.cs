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
    public class AC_ModuleQuyTrinh
    {
        
        private readonly IModuleQuyTrinhRepository _ModuleQuyTrinhRepository;

        private readonly IUnitOfWork _uow;

        public AC_ModuleQuyTrinh(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ModuleQuyTrinhRepository = services.GetRequiredService<IModuleQuyTrinhRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ModuleQuyTrinhRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<ModuleQuyTrinh> Create(ModuleQuyTrinh tc)
        {
            try
            {
                _ModuleQuyTrinhRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][Create]:" + ex.Message, ex);
            }

        }

        public async Task<ModuleQuyTrinh> Update(ModuleQuyTrinh ltc)
        {
            try
            {
                _ModuleQuyTrinhRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][Update]:" + ex.Message, ex);
            }

        }

        public async Task<ModuleQuyTrinh> GetById(string id)
        {
            try
            {
                return await _ModuleQuyTrinhRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ModuleQuyTrinh>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<ModuleQuyTrinh>() : (List<ModuleQuyTrinh>)(await _ModuleQuyTrinhRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(ModuleQuyTrinh tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ModuleQuyTrinh][ThemLog]:" + ex.Message, ex);
            }
        }

        

    }
}
