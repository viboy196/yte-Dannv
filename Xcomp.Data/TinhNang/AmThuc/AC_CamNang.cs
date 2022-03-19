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
    public class AC_CamNang
    {
        
        private readonly ICamNangRepository _CamNangRepository;

        private readonly IUnitOfWork _uow;

        public AC_CamNang(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _CamNangRepository = services.GetRequiredService<ICamNangRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _CamNangRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<CamNang> Create(CamNang tc)
        {
            try
            {
                _CamNangRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][Create]:" + ex.Message, ex);
            }

        }

        public async Task<CamNang> Update(CamNang ltc)
        {
            try
            {
                _CamNangRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][Update]:" + ex.Message, ex);
            }

        }

        public async Task<CamNang> GetById(string id)
        {
            try
            {
                return await _CamNangRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<CamNang>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<CamNang>() : (List<CamNang>)(await _CamNangRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<CamNang>> GetByCode(string Code)
        {
            try
            {
                return (List<CamNang>)(await _CamNangRepository.GetAllAsync(c => c.CodeLoaiCamNang == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(CamNang tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task Them_ToChuc(CamNang cn, ToChuc tc)
        {
            try
            {
                await Update((CamNang)cn.DS_Add(tc.Id,"DsCamNangToChuc"));
                await AC.ToChuc.Update((ToChuc)tc.DS_Add(cn.Id, "DsCamNangToChuc"));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][Them_ToChuc]:" + ex.Message, ex);
            }

        }

        public async Task Them_Chuong(CamNang cn, ChuongCamNang ccn)
        {
            try
            {
                await Update(cn.ThemChuongCamNang(ccn.Id));
                await AC.ChuongCamNang.Update(ccn.SetCamNang(cn.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_CamNang][Them_Chuong]:" + ex.Message, ex);
            }

        }

    }
}
