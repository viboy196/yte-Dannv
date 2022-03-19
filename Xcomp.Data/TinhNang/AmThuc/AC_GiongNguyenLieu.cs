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
    public class AC_GiongNguyenLieu
    {

        private readonly IGiongNguyenLieuRepository _GiongNguyenLieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_GiongNguyenLieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _GiongNguyenLieuRepository = services.GetRequiredService<IGiongNguyenLieuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _GiongNguyenLieuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiongNguyenLieu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<GiongNguyenLieu> Create(GiongNguyenLieu tc)
        {
            try
            {
                _GiongNguyenLieuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiongNguyenLieu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<GiongNguyenLieu> Update(GiongNguyenLieu ltc)
        {
            try
            {
                _GiongNguyenLieuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiongNguyenLieu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<GiongNguyenLieu> GetById(string id)
        {
            try
            {
                return await _GiongNguyenLieuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiongNguyenLieu][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<GiongNguyenLieu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<GiongNguyenLieu>() : (List<GiongNguyenLieu>)(await _GiongNguyenLieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_GiongNguyenLieu][Get]:" + ex.Message, ex);
            }

        }

        


    }
}
