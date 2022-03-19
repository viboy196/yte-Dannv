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
    public class AC_CongThuc
    {
        
        private readonly ICongThucRepository _CongThucRepository;

        private readonly IUnitOfWork _uow;

        public AC_CongThuc(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _CongThucRepository = services.GetRequiredService<ICongThucRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _CongThucRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<CongThuc> Create(CongThuc tc)
        {
            try
            {
                _CongThucRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][Create]:" + ex.Message, ex);
            }

        }

        public async Task<CongThuc> Update(CongThuc ltc)
        {
            try
            {
                _CongThucRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][Update]:" + ex.Message, ex);
            }

        }

        public async Task<CongThuc> GetById(string id)
        {
            try
            {
                return await _CongThucRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<CongThuc>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<CongThuc>() : (List<CongThuc>)(await _CongThucRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(CongThuc tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CongThuc][ThemLog]:" + ex.Message, ex);
            }
        }

       

    }
}
