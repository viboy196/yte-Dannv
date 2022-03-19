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
    public class AC_LoaiMayTuPhucVu
    {
        
        private readonly ILoaiMayTuPhucVuRepository _LoaiMayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiMayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiMayTuPhucVuRepository = services.GetRequiredService<ILoaiMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LoaiMayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiMayTuPhucVu> Create(LoaiMayTuPhucVu tc)
        {
            try
            {
                _LoaiMayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiMayTuPhucVu> Update(LoaiMayTuPhucVu ltc)
        {
            try
            {
                _LoaiMayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiMayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _LoaiMayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiMayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<LoaiMayTuPhucVu>() : (List<LoaiMayTuPhucVu>)(await _LoaiMayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<LoaiMayTuPhucVu>> GetByCode(string Code)
        {
            try
            {
                return (List<LoaiMayTuPhucVu>)(await _LoaiMayTuPhucVuRepository.GetAllAsync(c => c.CodeDongMayTuPhucVu==Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][GetByCode]:" + ex.Message, ex);
            }

        }


        //---------------------------
        public async Task ThemLog(LoaiMayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiMayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task ThemLoaiTinhNang(LoaiMayTuPhucVu lm, LoaiTinhNangMayTuPhucVu ltn)
        {
            await Update(lm.ThemLoaiTinhNangMayTuPhucVu(ltn.Id));
            await AC.LoaiTinhNangMayTuPhucVu.Update(ltn.ThemLoaiMayTuPhucVu(lm.Id));
        }

        public async Task ThemLoaiThietBi(LoaiMayTuPhucVu lm, LoaiThietBiMayTuPhucVu ltb)
        {
            await Update(lm.ThemLoaiThietBiMayTuPhucVu(ltb.Id));
            await AC.LoaiThietBiMayTuPhucVu.Update(ltb.ThemLoaiMayTuPhucVu(lm.Id));
        }


    }
}
