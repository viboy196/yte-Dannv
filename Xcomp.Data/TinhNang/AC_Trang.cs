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
    public class AC_Trang
    {
        
        private readonly ITrangRepository _TrangRepository;

        private readonly IUnitOfWork _uow;

        public AC_Trang(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _TrangRepository = services.GetRequiredService<ITrangRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _TrangRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Trang> Create(Trang tc)
        {
            try
            {
                _TrangRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Trang> Update(Trang ltc)
        {
            try
            {
                _TrangRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Trang> GetById(string id)
        {
            try
            {
                return await _TrangRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<Trang>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Trang>() : (List<Trang>)(await _TrangRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][Get]:" + ex.Message, ex);
            }
            
        }

       
        //---------------------------
        public async Task ThemLog(Trang tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Trang][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task Them_BanTin(Trang trang, BanTin bt)
        {
            try
            {
                await Update(trang.ThemBanTin(bt.Id));
                await AC.BanTin.Update(bt.SetTrang(trang.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BanTin][Them_BanTin]:" + ex.Message, ex);
            }

        }
    }
}
