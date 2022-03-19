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
    public class AC_ToChuc
    {
        
        private readonly IToChucRepository _ToChucRepository;

        private readonly IUnitOfWork _uow;

        public AC_ToChuc(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _ToChucRepository = services.GetRequiredService<IToChucRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _ToChucRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<ToChuc> Create(ToChuc tc)
        {
            try
            {
                _ToChucRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Create]:" + ex.Message, ex);
            }

        }

        public async Task<ToChuc> Update(ToChuc ltc)
        {
            try
            {
                _ToChucRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Update]:" + ex.Message, ex);
            }

        }

        public async Task<ToChuc> GetById(string id)
        {
            try
            {
                return await _ToChucRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ToChuc>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<ToChuc>() : (List<ToChuc>)(await _ToChucRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<ToChuc>> GetByCode(string Code)
        {
            try
            {
                return (List<ToChuc>)(await _ToChucRepository.GetAllAsync(c => c.CodeLoaiToChuc == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(ToChuc tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][ThemLog]:" + ex.Message, ex);
            }
        }
        //-------------------------------
        public async Task Them_San(ToChuc tc, San s)
        {
            try
            {
                await Update(tc.ThemSan(s.Id));
                await AC.San.Update(s.ThemToChuc(tc.Id));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Them_San]:" + ex.Message, ex);
            }            
        }

        public async Task Them_PhongBan(ToChuc tc, PhongBan pb)
        {
            try
            {
                await Update(tc.ThemPhongBan(pb.Id));
                await AC.PhongBan.Update(pb.SetToChuc(tc.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Them_Phongban]:" + ex.Message, ex);
            }
            
        }

        public async Task Them_Trang(ToChuc tc, Trang trang)
        {
            try
            {
                await Update(tc.ThemTrang(trang.Id));
                await AC.Trang.Update(trang.SetToChuc(tc.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Them_Trang]:" + ex.Message, ex);
            }

        }

        public async Task Set_TrangChu(ToChuc tc, Trang trang)
        {
            try
            {
                tc.IdTrangChu = trang.Id;
                await Update(tc);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Set_TrangChu]:" + ex.Message, ex);
            }

        }

        public async Task Xoa_TrangChu(ToChuc tc)
        {
            try
            {
                tc.IdTrangChu = null;
                await Update(tc);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Xoa_TrangChu]:" + ex.Message, ex);
            }

        }

        public async Task Them_NhanVien(ToChuc tc, NhanVien nv, bool NhanVienToChuc = false)
        {
            try
            {
                await AC.NhanVien.Update(nv.SetToChuc(tc.Id));
                await Update(tc.ThemNhanVien(nv.Id));
                if (NhanVienToChuc) await Update(tc.ThemNhanVienToChuc(nv.Id));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Them_NhanVien]:" + ex.Message + ": Tổ chức: " + JsonSerializer.Serialize(tc)
                    + ": Nhân Viên: " + JsonSerializer.Serialize(nv) + ": Nhân viên tổ chức: " + NhanVienToChuc, ex);
            }
        }

        //-------------------------------------
        public async Task<ToChuc> Create_ToChuc(ToChucRequest model)
        {
            try
            {
                //Tạo tổ chức
                var ltc = await AC.LoaiToChuc.GetById(model.IdLoaiToChuc);

                var tc = new ToChuc()
                {
                    Name = model.Ten.Trim(),
                    LoaiToChuc = ltc.Name,
                    CodeLoaiToChuc = ltc.Code,
                    GioiThieu = model.GioiThieu,
                    IdHeThong = SystemInfo.HeThong.Id
                };

                await Create(tc);

                //Thêm log tạo tổ chức
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Tao_ToChuc,
                    IdNguoiDung = tc.CreatedBy,
                    IdDoiTuong = tc.Id,
                    NoiDung = "Người dùng tạo tổ chức"
                });

                await ThemLog(tc, lg);

                //Thêm tô chức vào danh sách của người tạo
                var nd = await AC.NguoiDung.GetById(model.IdNguoiTao);
                await AC.NguoiDung.ThemToChuc(nd, tc);

                return tc;

            }catch(Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Create_ToChuc]:" + ex.Message + ": Model: " + JsonSerializer.Serialize(model), ex);
            }
        }

        public async Task<ToChuc> Update_ToChuc(ToChucRequest model)
        {
            try
            {
                //Cập nhật thông tin tổ chức
                var tc = await GetById(model.Id);

                tc.Name = model.Ten.Trim();
                tc.GioiThieu = model.GioiThieu;
                tc.TrangThai = model.TrangThai;
                tc.UpdatedAt = DateTime.Now;
                tc.UpdatedBy = model.IdNguoiTao;

                await Update(tc);

                //Cập nhật thông tin tổ chức mẹ
                if (model.IdToChucMe != tc.IdToChucMe)
                {
                    //Xóa tổ chức mẹ cũ
                    if (tc.IdToChucMe != null)
                    {
                        var tcm = await GetById(tc.IdToChucMe);
                        await Update(tcm.XoaToChucCon(tc.Id));
                        tc.IdToChucMe = null;
                        await Update(tc);
                    }

                    //Thay tổ chức mẹ mới
                    if (model.IdToChucMe != null)
                    {
                        var tcm = await GetById(model.IdToChucMe);
                        await Update(tcm.ThemToChucCon(tc.Id));
                        tc.IdToChucMe = model.IdToChucMe;
                        await Update(tc);
                    }
                }

                //Thêm log update tổ chức
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Update_ToChuc,
                    IdNguoiDung = tc.UpdatedBy,
                    IdDoiTuong = tc.Id,
                    NoiDung = "Người dùng update tổ chức"
                });

                await ThemLog(tc, lg);

                return tc;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Update_ToChuc]:" + ex.Message + ": Model: " + JsonSerializer.Serialize(model), ex);
            }
            
        }

        public async Task Them_QuanHeToChuc(ToChuc tc, ToChuc tcs, string QuanHe)
        {
            try
            {
               
                await Update((ToChuc)tc.DS_Add(tcs.Id,"Truoc"+QuanHe));
                await Update((ToChuc)tcs.DS_Add(tc.Id, "Sau" + QuanHe));


            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_ToChuc][Them_QuanHeToChuc]:" + ex.Message , ex);
            }
        }

    }
}
