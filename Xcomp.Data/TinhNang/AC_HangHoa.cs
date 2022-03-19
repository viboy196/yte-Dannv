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
    public class AC_HangHoa
    {
        
        private readonly IHangHoaRepository _HangHoaRepository;

        private readonly IUnitOfWork _uow;

        public AC_HangHoa(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _HangHoaRepository = services.GetRequiredService<IHangHoaRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _HangHoaRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<HangHoa> Create(HangHoa tc)
        {
            try
            {
                _HangHoaRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][Create]:" + ex.Message, ex);
            }

        }

        public async Task<HangHoa> Update(HangHoa ltc)
        {
            try
            {
                _HangHoaRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][Update]:" + ex.Message, ex);
            }

        }

        public async Task<HangHoa> GetById(string id)
        {
            try
            {
                return await _HangHoaRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<HangHoa>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<HangHoa>() : (List<HangHoa>)(await _HangHoaRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][Get]:" + ex.Message, ex);
            }
            
        }

      
        //---------------------------
        public async Task ThemLog(HangHoa tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][ThemLog]:" + ex.Message, ex);
            }
        }
        public async Task SetSan(HangHoa hh, San s)
        {
            try
            {
                await Update(hh.SetSan(s.Id));
                await AC.San.Update(s.ThemHangHoa(hh.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][SetSan]:" + ex.Message, ex);
            }
            
        }

        public async Task ThemLoaiHangHoa(HangHoa hh, LoaiHangHoa lhh)
        {
            try
            {
                await Update(hh.ThemLoaiHangHoa(lhh.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_HangHoa][ThemLoaiHangHoa]:" + ex.Message, ex);
            }
            
        }

        //-------------------------------------


    }
}
