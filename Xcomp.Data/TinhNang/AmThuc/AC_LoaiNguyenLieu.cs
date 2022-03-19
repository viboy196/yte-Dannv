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
    public class AC_LoaiNguyenLieu
    {

        private readonly ILoaiNguyenLieuRepository _LoaiNguyenLieuRepository;

        private readonly IUnitOfWork _uow;

        public AC_LoaiNguyenLieu(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _LoaiNguyenLieuRepository = services.GetRequiredService<ILoaiNguyenLieuRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _LoaiNguyenLieuRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiNguyenLieu> Create(LoaiNguyenLieu tc)
        {
            try
            {
                _LoaiNguyenLieuRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][Create]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiNguyenLieu> Update(LoaiNguyenLieu ltc)
        {
            try
            {
                _LoaiNguyenLieuRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][Update]:" + ex.Message, ex);
            }

        }

        public async Task<LoaiNguyenLieu> GetById(string id)
        {
            try
            {
                return await _LoaiNguyenLieuRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][GetById]:" + ex.Message, ex);
            }

        }

        public async Task<List<LoaiNguyenLieu>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<LoaiNguyenLieu>() : (List<LoaiNguyenLieu>)(await _LoaiNguyenLieuRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][Get]:" + ex.Message, ex);
            }

        }

        public async Task<List<LoaiNguyenLieu>> GetAll()
        {
            try
            {
                return (List<LoaiNguyenLieu>)await _LoaiNguyenLieuRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][GetAll]:" + ex.Message, ex);
            }
           

        }

        //-------------------

        public async Task Them_NguyenLieu(LoaiNguyenLieu lnl, NguyenLieu nl)
        {
            try
            {
                await Update(lnl.ThemNguyenLieu(nl.Id));
                await AC.NguyenLieu.Update(nl.SetLoaiNguyenLieu(lnl.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_LoaiNguyenLieu][Them_NguyenLieu]:" + ex.Message, ex);
            }

        }


    }
}
