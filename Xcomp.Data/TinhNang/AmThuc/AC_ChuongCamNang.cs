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
    public class AC_ChuongCamNang
    {
        
        private readonly IChuongCamNangRepository _ChuongCamNangRepository;

        private readonly IUnitOfWork _uow;

        public AC_ChuongCamNang(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ChuongCamNangRepository = services.GetRequiredService<IChuongCamNangRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ChuongCamNangRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<ChuongCamNang> Create(ChuongCamNang tc)
        {
            try
            {
                _ChuongCamNangRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][Create]:" + ex.Message, ex);
            }

        }

        public async Task<ChuongCamNang> Update(ChuongCamNang ltc)
        {
            try
            {
                _ChuongCamNangRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][Update]:" + ex.Message, ex);
            }

        }

        public async Task<ChuongCamNang> GetById(string id)
        {
            try
            {
                return await _ChuongCamNangRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ChuongCamNang>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<ChuongCamNang>() : (List<ChuongCamNang>)(await _ChuongCamNangRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(ChuongCamNang tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task Them_CongThuc(ChuongCamNang ccn, CongThuc ct)
        {
            try
            {
                await Update(ccn.ThemCongThuc(ct.Id));
                await AC.CongThuc.Update(ct.ThemChuongCamNang(ccn.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ChuongCamNang][Them_CongThuc]:" + ex.Message, ex);
            }

        }

    }
}
