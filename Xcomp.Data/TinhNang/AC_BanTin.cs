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
    public class AC_BanTin
    {
        
        private readonly IBanTinRepository _BanTinRepository;

        private readonly IUnitOfWork _uow;

        public AC_BanTin(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _BanTinRepository = services.GetRequiredService<IBanTinRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _BanTinRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<BanTin> Create(BanTin tc)
        {
            try
            {
                _BanTinRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][Create]:" + ex.Message, ex);
            }

        }

        public async Task<BanTin> Update(BanTin ltc)
        {
            try
            {
                _BanTinRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][Update]:" + ex.Message, ex);
            }

        }

        public async Task<BanTin> GetById(string id)
        {
            try
            {
                return await _BanTinRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<BanTin>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<BanTin>() : (List<BanTin>)(await _BanTinRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][Get]:" + ex.Message, ex);
            }
            
        }

       
        //---------------------------
        public async Task ThemLog(BanTin tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][ThemLog]:" + ex.Message, ex);
            }
        }

       


    }
}
