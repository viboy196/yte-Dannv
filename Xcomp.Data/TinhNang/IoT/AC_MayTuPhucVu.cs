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
    public class AC_MayTuPhucVu
    {
        
        private readonly IMayTuPhucVuRepository _MayTuPhucVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_MayTuPhucVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _MayTuPhucVuRepository = services.GetRequiredService<IMayTuPhucVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _MayTuPhucVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<MayTuPhucVu> Create(MayTuPhucVu tc)
        {
            try
            {
                _MayTuPhucVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<MayTuPhucVu> Update(MayTuPhucVu ltc)
        {
            try
            {
                _MayTuPhucVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<MayTuPhucVu> GetById(string id)
        {
            try
            {
                return await _MayTuPhucVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<MayTuPhucVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<MayTuPhucVu>() : (List<MayTuPhucVu>)(await _MayTuPhucVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<MayTuPhucVu>> GetAll()
        {
            try
            {
                return (List<MayTuPhucVu>)(await _MayTuPhucVuRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][Get]:" + ex.Message, ex);
            }

        }

        public async Task<List<MayTuPhucVu>> GetByCode(string Code)
        {
            try
            {
                return (List<MayTuPhucVu>)(await _MayTuPhucVuRepository.GetAllAsync(c => c.CodeLoaiMayTuPhucVu == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(MayTuPhucVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task SetCongTyKhachHang(MayTuPhucVu may, ToChuc tochuc)
        {
            try
            {
                await Update((MayTuPhucVu)may.Truong_Set(tochuc.Id, "IdToChucKhachHang"));
                await AC.ToChuc.Update((ToChuc)tochuc.DS_Add(may.Id, "DsIdMayTuPhucVuCuaToChuc"));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][SetCongTyKhachHang]:" + ex.Message, ex);
            }
           
        }

        public async Task SetCongTySanSuat(MayTuPhucVu may, ToChuc tochuc)
        {
            try
            {
                await Update((MayTuPhucVu)may.Truong_Set(tochuc.Id, "IdToChucSanXuat"));
                await AC.ToChuc.Update((ToChuc)tochuc.DS_Add(may.Id, "DsIdMayTuPhucVuSanXuat"));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][SetCongTySanSuat]:" + ex.Message, ex);
            }
           
        }

        public async Task ThemTinhNang(MayTuPhucVu may, TinhNangMayTuPhucVu ltn)
        {
            try
            {
                await Update(may.ThemTinhNangMayTuPhucVu(ltn.Id));
                await AC.TinhNangMayTuPhucVu.Update(ltn.ThemMayTuPhucVu(may.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][ThemTinhNang]:" + ex.Message, ex);
            }
            
        }

        public async Task ThemThietBi(MayTuPhucVu lm, ThietBiMayTuPhucVu ltb)
        {
            try
            {
                await Update(lm.ThemThietBiMayTuPhucVu(ltb.Id));
                await AC.ThietBiMayTuPhucVu.Update(ltb.ThemMayTuPhucVu(lm.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_MayTuPhucVu][ThemThietBi]:" + ex.Message, ex);
            }
           
        }

    }
}
