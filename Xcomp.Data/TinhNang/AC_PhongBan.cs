using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcomp.Data.IRepositories;
using Xcomp.Share.Common;
using Xcomp.Share.Domain;

namespace Xcomp.Data.TinhNang
{
    public class AC_PhongBan
    {
        
        private readonly IPhongBanRepository _PhongBanRepository;

        private readonly IUnitOfWork _uow;

        public AC_PhongBan(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _PhongBanRepository = services.GetRequiredService<IPhongBanRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _PhongBanRepository.RemoveAll();
                await _uow.CommitAsync();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][RemoveAll]:" + ex.Message, ex);
            }
            

        }

        public async Task<PhongBan> Create(PhongBan ltc)
        {
            try
            {
                _PhongBanRepository.Add(ltc);
                await _uow.CommitAsync();
                return ltc;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Create]:" + ex.Message, ex);
            }
        }

        public async Task<PhongBan> Update(PhongBan ltc)
        {
            try
            {
                _PhongBanRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Update]:" + ex.Message, ex);
            }
           

        }

        public async Task<PhongBan> GetById(string id)
        {
            try
            {
                return await _PhongBanRepository.GetByIdAsync(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<PhongBan>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<PhongBan>() : (List<PhongBan>)(await _PhongBanRepository.GetAllAsync(c => Dsid.Contains(c.Id)));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Get]:" + ex.Message, ex);
            }
           
        }

        public async Task<List<PhongBan>> GetByCode(string Code)
        {
            try
            {
                return (List<PhongBan>)(await _PhongBanRepository.GetAllAsync(c => c.CodeLoaiPhongBan == Code));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][GetByCode]:" + ex.Message, ex);
            }
            
        }
        //---------------------------

        public async Task Them_NhanVien(PhongBan pb, NhanVien nv)
        {
            try
            {
                await AC.NhanVien.Update(nv.SetPhongBan(pb.Id));
                await Update(pb.ThemNhanVien(nv.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Them_NhanVien]:" + ex.Message, ex);
            }
            
        }

        public async Task Them_DoiTuong(PhongBan pb, DoiTuong bn)
        {

            try
            {
                await AC.DoiTuong.Update((DoiTuong)bn.Truong_Set(pb.Id, "DsPhongBanDoiTuong"));
                await Update((PhongBan)pb.DS_Add(bn.Id, "DsPhongBanDoiTuong"));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Them_DoiTuong]:" + ex.Message, ex);
            }
            
        }


        public async Task Them_Nhom(PhongBan pb, Nhom nhom)
        {
            try
            {
                await AC.Nhom.Update(nhom.SetPhongBan(pb.Id));
                await Update(pb.ThemNhom(nhom.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Them_Nhom]:" + ex.Message, ex);
            }
        }

        public async Task Them_Lich(PhongBan pb, Lich lich, string MucDich)
        {
            try
            {
                await AC.Lich.Update((Lich)lich.DS_Add(pb.Id,MucDich));
                await Update((PhongBan)pb.DS_Add(lich.Id,MucDich));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Them_Nhom]:" + ex.Message, ex);
            }
        }

        public async Task ThemPhanSuNhanVien(PhongBan pb, NhanVien nv, PhanSu ps)
        {
            try
            {
                await Update((PhongBan)pb.DS_Add(nv.Id, "PhongBan_" + ps.Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][ThemPhanSuNhanVien]:" + ex.Message, ex);
            }
            
        }

        public async Task ThemPhanSuNhom(PhongBan pb, Nhom nhom, PhanSu ps)
        {
            try
            {
                await Update((PhongBan)pb.DS_Add(nhom.Id, "PhongBan_Nhom_" + ps.Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][ThemPhanSuNhanVien]:" + ex.Message, ex);
            }

        }

        public async Task XoaPhanSuNhanVien(PhongBan pb, NhanVien nv, PhanSu ps)
        {
            try
            {
                await Update((PhongBan)pb.DS_Xoa(nv.Id, "PhongBan_" + ps.Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][ThemPhanSuNhanVien]:" + ex.Message, ex);
            }
            
        }

        public async Task XoaPhanSuNhom(PhongBan pb, Nhom nv, PhanSu ps)
        {
            try
            {
                await Update((PhongBan)pb.DS_Xoa(nv.Id, "PhongBan_Nhom_" + ps.Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][ThemPhanSuNhom]:" + ex.Message, ex);
            }

        }

        public async Task ThemGiaoDich(PhongBan pb, GiaoDich gd)
        {
            try
            {
                await Update(pb.ThemGiaoDich(gd.Id));
                await AC.GiaoDich.Update(gd.SetPhongBan(pb.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][ThemGiaoDich]:" + ex.Message, ex);
            }
            
        }

        public async Task<PhongBan> Create_PhongBan(PhongBanRequest model)
        {
            try
            {
                var tc = await AC.ToChuc.GetById(model.IdToChuc);

                var lpb = await AC.LoaiPhongBan.GetById(model.IdLoaiPhongBan);

                var pb = new PhongBan()
                {
                    Name = model.Ten.Trim(),
                    LoaiPhongBan = lpb.Name,
                    CodeLoaiPhongBan = lpb.Code,
                    GioiThieu = model.GioiThieu,
                    CreatedBy = model.IdNguoiTao,
                    CreatedAt = DateTime.Now
                };

                await Create(pb);
                await AC.ToChuc.Them_PhongBan(tc, pb);
                return pb;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Create_PhongBan]:" + ex.Message, ex);
            }
            
        }

        public async Task<PhongBan> Update_PhongBan(PhongBanRequest model)
        {
            try
            {
                var pb = await AC.PhongBan.GetById(model.Id);

                pb.Name = model.Ten.Trim();

                pb.GioiThieu = model.GioiThieu;
                pb.TrangThai = model.TrangThai;

                

                if (model.IdPhongBanMe != pb.IdPhongBanMe)
                {
                    //Xóa tổ chức mẹ cũ
                    if (pb.IdPhongBanMe != null)
                    {
                        var tcm = await GetById(pb.IdPhongBanMe);
                        await Update(tcm.XoaPhongBanCon(pb.Id));
                        pb.IdPhongBanMe = null;
                        //await Update(pb);
                    }

                    //Thay tổ chức mẹ mới
                    if (model.IdPhongBanMe != null)
                    {
                        var tcm = await GetById(model.IdPhongBanMe);
                        await Update(tcm.ThemPhongBanCon(pb.Id));
                        pb.IdPhongBanMe = model.IdPhongBanMe;
                        //await Update(pb);
                    }
                }

                await Update(pb);

                return pb;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_PhongBan][Update_PhongBan]:" + ex.Message, ex);
            }
            
        }

    }
}
