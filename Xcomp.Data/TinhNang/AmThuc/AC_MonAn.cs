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
    public class AC_MonAn
    {
        
        private readonly IMonAnRepository _MonAnRepository;

        private readonly IUnitOfWork _uow;

        public AC_MonAn(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _MonAnRepository = services.GetRequiredService<IMonAnRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _MonAnRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<MonAn> Create(MonAn tc)
        {
            try
            {
                _MonAnRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][Create]:" + ex.Message, ex);
            }

        }

        public async Task<MonAn> Update(MonAn ltc)
        {
            try
            {
                _MonAnRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][Update]:" + ex.Message, ex);
            }

        }

        public async Task<MonAn> GetById(string id)
        {
            try
            {
                return await _MonAnRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<MonAn>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<MonAn>() : (List<MonAn>)(await _MonAnRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<MonAn>> GetAll()
        {
            try
            {
                return (List<MonAn>)await _MonAnRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][GetAll]:" + ex.Message, ex);
            }


        }

        //---------------------------
        public async Task ThemLog(MonAn tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][ThemLog]:" + ex.Message, ex);
            }
        }


        //---------------------------

        public async Task Them_CongThuc(MonAn mon, CongThuc ct)
        {
            try
            {
                await Update(mon.ThemCongThuc(ct.Id));
                await AC.CongThuc.Update(ct.SetMonAn(mon.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MonAn][Them_CongThuc]:" + ex.Message, ex);
            }

        }


    }
}
