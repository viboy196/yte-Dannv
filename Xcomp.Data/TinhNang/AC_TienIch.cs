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
    public class AC_TienIch
    {
        
        private readonly ITienIchRepository _TienIchRepository;

        private readonly IUnitOfWork _uow;

        public AC_TienIch(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _TienIchRepository = services.GetRequiredService<ITienIchRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _TienIchRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<TienIch> Create(TienIch tc)
        {
            try
            {
                _TienIchRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Create]:" + ex.Message, ex);
            }

        }

        public async Task<TienIch> Update(TienIch ltc)
        {
            try
            {
                _TienIchRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Update]:" + ex.Message, ex);
            }

        }

        public async Task<TienIch> GetById(string id)
        {
            try
            {
                return await _TienIchRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TienIch>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<TienIch>() : (List<TienIch>)(await _TienIchRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<TienIch>> Get(List<string> Dsid, CodeHeThong Codeht)
        {
            try
            {
                
                return Dsid == null ? new List<TienIch>() : (List<TienIch>)(await _TienIchRepository.GetAllAsync(c => Dsid.Contains(c.Id) && c.CodeHeThong == Codeht ));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Get]:" + ex.Message, ex);
            }

        }

        public async Task<List<TienIch>> GetByCode(string Code)
        {
            try
            {
                return (List<TienIch>)(await _TienIchRepository.GetAllAsync(c => c.CodeLoaiTienIch == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(TienIch tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][ThemLog]:" + ex.Message, ex);
            }
        }

       

        public async Task Set_NguoiDung(TienIch ti, NguoiDung nd)
        {            
            try
            {
                await Update(ti.SetNguoiDung(nd.Id));
                await AC.NguoiDung.Update(nd.ThemTienIch(ti.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Set_NguoiDung]:" + ex.Message, ex);
            }
        }

        public async Task Xoa_NguoiDung(TienIch ti, NguoiDung nd)
        {
            try
            {
                await Update(ti.XoaNguoiDung());
                await AC.NguoiDung.Update(nd.XoaTienIch(ti.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Xoa_NguoiDung]:" + ex.Message, ex);
            }
            
        }

        public async Task Set_DoiTuong(TienIch ti, DoiTuong dt)
        {
            try
            {
                ti.IdDoiTuong = dt.Id;
                await Update(ti);
                await AC.DoiTuong.Update(dt.ThemTienIch(ti.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_TienIch][Set_DoiTuong]:" + ex.Message, ex);
            }
        }

        


    }
}
