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
    public class AC_NguyenLieu
    {

        private readonly INguyenLieuRepository _NguyenLieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_NguyenLieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _NguyenLieuRepository = services.GetRequiredService<INguyenLieuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _NguyenLieuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<NguyenLieu> Create(NguyenLieu tc)
        {
            try
            {
                _NguyenLieuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<NguyenLieu> Update(NguyenLieu ltc)
        {
            try
            {
                _NguyenLieuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<NguyenLieu> GetById(string id)
        {
            try
            {
                return await _NguyenLieuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<NguyenLieu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<NguyenLieu>() : (List<NguyenLieu>)(await _NguyenLieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][Get]:" + ex.Message, ex);
            }

        }

        //------------------------
        public async Task Them_GiongNguyenLieu(NguyenLieu nl, GiongNguyenLieu gnl)
        {
            try
            {
                await Update(nl.ThemGiongNguyenLieu(gnl.Id));
                await AC.GiongNguyenLieu.Update(gnl.SetNguyenLieu(nl.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][Them_GiongNguyenLieu]:" + ex.Message, ex);
            }

        }

        public async Task Them_BoPhanNguyenLieu(NguyenLieu nl, BoPhanNguyenLieu gnl)
        {
            try
            {
                await Update(nl.ThemBoPhanNguyenLieu(gnl.Id));
                await AC.BoPhanNguyenLieu.Update(gnl.SetNguyenLieu(nl.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_NguyenLieu][Them_BoPhanNguyenLieu]:" + ex.Message, ex);
            }

        }

    }
}
