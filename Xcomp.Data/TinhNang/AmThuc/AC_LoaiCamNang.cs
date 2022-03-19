using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_LoaiCamNang
    {

        private readonly ILoaiCamNangRepository _LoaiCamNangRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiCamNang(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiCamNangRepository = services.GetRequiredService<ILoaiCamNangRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LoaiCamNangRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiCamNang][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiCamNang> Create(LoaiCamNang tc)
        {
            try
            {
                _LoaiCamNangRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiCamNang][Create]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiCamNang> Update(LoaiCamNang ltc)
        {
            try
            {
                _LoaiCamNangRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiCamNang][Update]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiCamNang> GetById(string id)
        {
            try
            {
                return await _LoaiCamNangRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiCamNang][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<LoaiCamNang>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<LoaiCamNang>() : (List<LoaiCamNang>)(await _LoaiCamNangRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiCamNang][Get]:" + ex.Message, ex);
            }

        }

        


    }
}
