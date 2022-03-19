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
    public class AC_Lich
    {
        
        private readonly ILichRepository _LichRepository;

        private readonly IUnitOfWork _uow;

        public AC_Lich(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LichRepository = services.GetRequiredService<ILichRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LichRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Lich> Create(Lich tc)
        {
            try
            {
                _LichRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Lich> Update(Lich ltc)
        {
            try
            {
                _LichRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Lich> GetById(string id)
        {
            try
            {
                return await _LichRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<Lich>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Lich>() : (List<Lich>)(await _LichRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(Lich tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Lich][ThemLog]:" + ex.Message, ex);
            }
        }

       
        //-------------------------------


    }
}
