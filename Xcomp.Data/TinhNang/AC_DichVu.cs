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
    public class AC_DichVu
    {
        
        private readonly IDichVuRepository _DichVuRepository;

        private readonly IUnitOfWork _uow;

        public AC_DichVu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _DichVuRepository = services.GetRequiredService<IDichVuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _DichVuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<DichVu> Create(DichVu tc)
        {
            try
            {
                _DichVuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<DichVu> Update(DichVu ltc)
        {
            try
            {
                _DichVuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<DichVu> GetById(string id)
        {
            try
            {
                return await _DichVuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<DichVu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<DichVu>() : (List<DichVu>)(await _DichVuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][Get]:" + ex.Message, ex);
            }
            
        }

       


        //---------------------------
        public async Task ThemLog(DichVu tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][ThemLog]:" + ex.Message, ex);
            }
        }
        
        public async Task SetSan(DichVu dv, San s)
        {
            try
            {
                dv.IdSan = s.Id;
                await Update(dv);
                await AC.San.Update(s.ThemDichVu(dv.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][SetSan]:" + ex.Message, ex);
            }
            
        }

        public async Task SetToChuc(DichVu dv, ToChuc tc)
        {
            try
            {
                dv.IdToChuc = tc.Id;
                await Update(dv);
                await AC.ToChuc.Update(tc.ThemDichVu(dv.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][SetToChuc]:" + ex.Message, ex);
            }
        }

        public async Task ThemHangHoa(DichVu dv, HangHoa hh)
        {
            try
            {
                await Update(dv.ThemHangHoa(hh.Id));
                await AC.HangHoa.Update(hh.SetDichVu(dv.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][ThemHangHoa]:" + ex.Message, ex);
            }
            
        }
        //-------------------------------------
        public async Task ThemGiaoDich(DichVu dv, GiaoDich gd)
        {
            try
            {
                await Update(dv.ThemGiaoDich(gd.Id));
                await AC.GiaoDich.Update(gd.SetDichVu(dv.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DichVu][ThemGiaoDich]:" + ex.Message, ex);
            }
        }

    }
}
