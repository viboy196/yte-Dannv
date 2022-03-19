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
    public class AC_ThanhToan
    {
        
        private readonly IThanhToanRepository _ThanhToanRepository;

        private readonly IUnitOfWork _uow;

        public AC_ThanhToan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ThanhToanRepository = services.GetRequiredService<IThanhToanRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ThanhToanRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<ThanhToan> Create(ThanhToan tc)
        {
            try
            {
                _ThanhToanRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][Create]:" + ex.Message, ex);
            }

        }

        public async Task<ThanhToan> Update(ThanhToan ltc)
        {
            try
            {
                _ThanhToanRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][Update]:" + ex.Message, ex);
            }

        }

        public async Task<ThanhToan> GetById(string id)
        {
            try
            {
                return await _ThanhToanRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ThanhToan>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<ThanhToan>() : (List<ThanhToan>)(await _ThanhToanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][Get]:" + ex.Message, ex);
            }
            
        }

       
        //---------------------------
        public async Task ThemLog(ThanhToan tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ThanhToan][ThemLog]:" + ex.Message, ex);
            }
        }
        //-------------------------------
       

    }
}
