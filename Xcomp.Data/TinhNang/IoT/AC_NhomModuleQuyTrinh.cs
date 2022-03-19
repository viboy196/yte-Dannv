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
    public class AC_NhomModuleQuyTrinh
    {
        
        private readonly INhomModuleQuyTrinhRepository _NhomModuleQuyTrinhRepository;

        private readonly IUnitOfWork _uow;

        public AC_NhomModuleQuyTrinh(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _NhomModuleQuyTrinhRepository = services.GetRequiredService<INhomModuleQuyTrinhRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _NhomModuleQuyTrinhRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<NhomModuleQuyTrinh> Create(NhomModuleQuyTrinh tc)
        {
            try
            {
                _NhomModuleQuyTrinhRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][Create]:" + ex.Message, ex);
            }

        }

        public async Task<NhomModuleQuyTrinh> Update(NhomModuleQuyTrinh ltc)
        {
            try
            {
                _NhomModuleQuyTrinhRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][Update]:" + ex.Message, ex);
            }

        }

        public async Task<NhomModuleQuyTrinh> GetById(string id)
        {
            try
            {
                return await _NhomModuleQuyTrinhRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<NhomModuleQuyTrinh>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<NhomModuleQuyTrinh>() : (List<NhomModuleQuyTrinh>)(await _NhomModuleQuyTrinhRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<NhomModuleQuyTrinh>> GetAll()
        {
            try
            {
                return (List<NhomModuleQuyTrinh>)(await _NhomModuleQuyTrinhRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][GetAll]:" + ex.Message, ex);
            }

        }


        //---------------------------
        public async Task ThemLog(NhomModuleQuyTrinh tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task ThemModuleQuyTrinh(NhomModuleQuyTrinh nmq, ModuleQuyTrinh mq)
        {
            try
            {
                await Update(nmq.ThemModuleQuyTrinh(mq.Id));
                await AC.ModuleQuyTrinh.Update(mq.SetNhom(nmq.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NhomModuleQuyTrinh][ThemModuleQuyTrinh]:" + ex.Message, ex);
            }
        }
        

    }
}
