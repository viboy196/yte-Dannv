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
    public class AC_BoPhanNguyenLieu
    {

        private readonly IBoPhanNguyenLieuRepository _BoPhanNguyenLieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_BoPhanNguyenLieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _BoPhanNguyenLieuRepository = services.GetRequiredService<IBoPhanNguyenLieuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _BoPhanNguyenLieuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BoPhanNguyenLieu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<BoPhanNguyenLieu> Create(BoPhanNguyenLieu tc)
        {
            try
            {
                _BoPhanNguyenLieuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BoPhanNguyenLieu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<BoPhanNguyenLieu> Update(BoPhanNguyenLieu ltc)
        {
            try
            {
                _BoPhanNguyenLieuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BoPhanNguyenLieu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<BoPhanNguyenLieu> GetById(string id)
        {
            try
            {
                return await _BoPhanNguyenLieuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BoPhanNguyenLieu][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<BoPhanNguyenLieu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<BoPhanNguyenLieu>() : (List<BoPhanNguyenLieu>)(await _BoPhanNguyenLieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_BoPhanNguyenLieu][Get]:" + ex.Message, ex);
            }

        }

        


    }
}
