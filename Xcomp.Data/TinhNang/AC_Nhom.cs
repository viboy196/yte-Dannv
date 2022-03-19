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
    public class AC_Nhom
    {
        
        private readonly INhomRepository _NhomRepository;

        private readonly IUnitOfWork _uow;

        public AC_Nhom(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _NhomRepository = services.GetRequiredService<INhomRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _NhomRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<Nhom> Create(Nhom tc)
        {
            try
            {
                _NhomRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Create]:" + ex.Message, ex);
            }

        }

        public async Task<Nhom> Update(Nhom ltc)
        {
            try
            {
                _NhomRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Update]:" + ex.Message, ex);
            }

        }

        public async Task<Nhom> GetById(string id)
        {
            try
            {
                return await _NhomRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<Nhom>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<Nhom>() : (List<Nhom>)(await _NhomRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Get]:" + ex.Message, ex);
            }
            
        }

        
        //---------------------------
        public async Task ThemLog(Nhom tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][ThemLog]:" + ex.Message, ex);
            }
        }

        public async Task Them_NhanVien(Nhom nhom, NhanVien nv)
        {
            try
            {
                await AC.NhanVien.Update(nv.ThemNhom(nhom.Id));
                await Update(nhom.ThemNhanVien(nv.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Them_NhanVien]:" + ex.Message, ex);
            }
        }

        public async Task Xoa_NhanVien(Nhom nhom, NhanVien nv)
        {
            try
            {
                await AC.NhanVien.Update(nv.XoaNhom(nhom.Id));
                await Update(nhom.XoaNhanVien(nv.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Xoa_NhanVien]:" + ex.Message, ex);
            }
        }

        public async Task Them_Lich(Nhom nhom, Lich l)
        {
            try
            {
                await AC.Lich.Update(l.SetNhom(nhom.Id));
                await Update(nhom.ThemLich(l.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Them_Lich]:" + ex.Message, ex);
            }
        }
        //-------------------------------


        public async Task<Nhom> Create_Nhom(NhomRequest model)
        {
            try
            {
                

                var pb = await AC.PhongBan.GetById(model.IdPhongBan);

                var nhom = new Nhom()
                {
                    Name = model.Ten.Trim(),
                    IdPhongBan =pb.Id,                    
                    GioiThieu = model.GioiThieu,
                    CreatedBy = model.IdNguoiTao,
                    CreatedAt = DateTime.Now,
                    TrangThai = TrangThaiNhom.DangHoatDong
                };

                await Create(nhom);
                await AC.PhongBan.Them_Nhom(pb,nhom);
                return nhom;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Create_Nhom]:" + ex.Message, ex);
            }

        }

        public async Task<Nhom> Update_Nhom(NhomRequest model)
        {
            try
            {
                var nhom = await AC.Nhom.GetById(model.Id);

                nhom.Name = model.Ten.Trim();

                nhom.GioiThieu = model.GioiThieu;
                nhom.TrangThai = model.TrangThai;

                await Update(nhom);

                return nhom;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Update_Nhom]:" + ex.Message, ex);
            }

        }

        public async Task Add_NhanVien(string idnhom, string idnv)
        {
            try
            {
                var nhom = await AC.Nhom.GetById(idnhom);
                var nv = await AC.NhanVien.GetById(idnv);
                await Them_NhanVien(nhom, nv);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Add_NhanVien]:" + ex.Message, ex);
            }

        }

        public async Task Xoa_NhanVien(string idnhom, string idnv)
        {
            try
            {
                var nhom = await AC.Nhom.GetById(idnhom);
                var nv = await AC.NhanVien.GetById(idnv);
                await Xoa_NhanVien(nhom, nv);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_Nhom][Xoa_NhanVien]:" + ex.Message, ex);
            }

        }

        public async Task ThemPhanSu(PhanSuRequest model)
        {
            try
            {
                var cv = await AC.CongViec.GetById(model.IdCongViec);
                var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
                var nhom = await AC.Nhom.GetById(model.IdNhom);
                var ps = await AC.PhanSu.GetById(model.IdPhanSu);
                await AC.PhongBan.ThemPhanSuNhom(pb, nhom, ps);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_Nhom][ThemPhanSu]: " + ex.Message, ex);
            }

        }

        public async Task XoaPhanSu(PhanSuRequest model)
        {
            try
            {
                var cv = await AC.CongViec.GetById(model.IdCongViec);
                var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
                var nhom = await AC.Nhom.GetById(model.IdNhom);
                var ps = await AC.PhanSu.GetById(model.IdPhanSu);
                await AC.PhongBan.XoaPhanSuNhom(pb, nhom, ps);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][XoaPhanSu]: " + ex.Message, ex);
            }

        }


    }
}
