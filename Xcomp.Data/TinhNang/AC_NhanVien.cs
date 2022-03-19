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
    public class AC_NhanVien
    {
        
        private readonly INhanVienRepository _NhanVienRepository;

        private readonly IUnitOfWork _uow;

        public AC_NhanVien(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _NhanVienRepository = services.GetRequiredService<INhanVienRepository>();

        }

        public async Task RemoveAll()
        {
            _NhanVienRepository.RemoveAll();
            await _uow.CommitAsync();

        }

        public async Task<NhanVien> Create(NhanVien ltc)
        {
            _NhanVienRepository.Add(ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<NhanVien> Update(NhanVien ltc)
        {
            _NhanVienRepository.Update(ltc.Id,ltc);
            await _uow.CommitAsync();
            return ltc;

        }

        public async Task<NhanVien> GetById(string id)
        {   
            return await _NhanVienRepository.GetByIdAsync(id);
        }

        public async Task<List<NhanVien>> Get(List<string> Dsid)
        {
            return Dsid == null ? new List<NhanVien>() : (List<NhanVien>)(await _NhanVienRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
        }

        
        //---------------------------

        public async Task ThemCongViec(NhanVien nv, CongViec cv)
        {
            await AC.CongViec.Update(cv.SetNhanVien(nv.Id));
            await Update(nv.ThemCongViec(cv.Id));
        }

        public async Task NhanThongBao(NhanVien nv, ThongBao tb)
        {
            nv.QL_NhanThongBao(tb);
            await Update(nv);
        }

        public async Task ThemLog(NhanVien nv, Log lg)
        {
            
            try
            {
                nv.QL_ThemLog(lg);
                await Update(nv);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][ThemLog]: " + ex.Message + ": Nhân viên: " + JsonSerializer.Serialize(nv), ex);
            }
        }
        //------------------------
        public async Task<NhanVien> Create_NhanVien(NhanVienRequest model, bool NhanVienToChuc = false)
        {
            try
            {
                var tc = await AC.ToChuc.GetById(model.IdToChuc);

                //Tạo mới nhân viên
                var nv = new NhanVien()
                {
                    Name = model.Ten.Trim(),
                    VaiTro = model.VaiTro,
                    IdToChuc = tc.Id,
                    Phone = model.SoDienThoai,
                    GioiThieu = model.GioiThieu,
                    CreatedBy = model.IdNguoiTao,
                    IdHeThong = SystemInfo.HeThong != null ? SystemInfo.HeThong.Id : model.IdHeThong
                };

               

                await AC.NhanVien.Create(nv);

                //Thêm nhân viên vào tổ chức
                if (NhanVienToChuc)
                {
                    tc.ThemNhanVienToChuc(nv.Id);
                }

                await AC.ToChuc.Update(tc.ThemNhanVien(nv.Id));

                //Thêm nhân viên vào phòng ban
                if (model.IdPhongBan != null)
                {
                    var pb = await AC.PhongBan.GetById(model.IdPhongBan);
                    if (pb != null)
                    {
                        nv.IdPhongBan = pb.Id;
                        await Update(nv);
                        await AC.PhongBan.Update(pb.ThemNhanVien(nv.Id));
                    }
                }    
                

                //Kết nối nhân viên với người dùng
                if (model.SoDienThoai != null)
                {
                    var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
                    if (nd != null)
                    {
                        nv.IdNguoiDung = nd.Id;
                        await Update(nv);
                        await AC.NguoiDung.Update(nd.ThemNhanVien(nv.Id));

                        //Gửi thông báo tới người dùng
                        var tb_taomoinguoidung = await AC.ThongBao.Create(new ThongBao
                        {
                            Loai = LoaiThongBao.Tao_NhanVien,
                            IdDoiTuongGui = nv.IdToChuc,
                            IdDoiTuongNhan = nv.Id,
                            IdNguoinhan = nv.IdNguoiDung,
                            NoiDung = "Lời mời tham gia hợp tác từ " + tc.Name
                        });
                        await NhanThongBao(nv, tb_taomoinguoidung);
                        await AC.NguoiDung.NhanThongBao(nd, tb_taomoinguoidung);
                    }
                }

                //Thêm log tạo nhân viên
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Tao_NhanVien,
                    IdNguoiDung = nv.CreatedBy,
                    IdDoiTuong = nv.Id,
                    NoiDung = "Người dùng tạo nhân viên"
                });

                await ThemLog(nv, lg);


                return nv;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][Create_NhanVien]: " + ex.Message +": Model: "+ JsonSerializer.Serialize(model), ex);
            }
            
        }

        public async Task<NhanVien> Update_NhanVien(NhanVienRequest model)
        {
            try
            {
                var nv = await AC.NhanVien.GetById(model.Id);

                //Update số điện thoại 
                if (model.SoDienThoai != nv.Phone)
                {
                    //Xóa người dùng
                    if (nv.IdNguoiDung != null)
                    {
                        var ndc = await AC.NguoiDung.GetById(nv.IdNguoiDung);
                        nv.IdNguoiDung = null;
                        await AC.NguoiDung.Update(ndc.XoaNhanVien(nv.Id));
                    }
                    nv.Phone = null;
                    //Update người dùng mới theo số điện thoại
                    if (model.SoDienThoai != null)
                    {
                        nv.Phone = model.SoDienThoai.Trim();
                        var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
                        if (nd != null)
                        {
                            var tc = await AC.ToChuc.GetById(nv.IdToChuc);
                            nv.IdNguoiDung = nd.Id;
                            await Update(nv);
                            await AC.NguoiDung.Update(nd.ThemNhanVien(nv.Id));

                            //Gửi thông báo tới người dùng
                            var tb_taomoinguoidung = await AC.ThongBao.Create(new ThongBao
                            {
                                Loai = LoaiThongBao.Tao_NhanVien,
                                IdDoiTuongGui = nv.IdToChuc,
                                IdDoiTuongNhan = nv.Id,
                                IdNguoinhan = nv.IdNguoiDung,
                                NoiDung = "Lời mời tham gia hợp tác từ " + tc.Name
                            });
                            await NhanThongBao(nv, tb_taomoinguoidung);
                            await AC.NguoiDung.NhanThongBao(nd, tb_taomoinguoidung);
                        }
                    }

                }

                nv.Name = model.Ten.Trim();
                nv.VaiTro = model.VaiTro;
                nv.GioiThieu = model.GioiThieu;
                nv.TrangThai = model.TrangThai;
                nv.UpdatedBy = model.IdNguoiTao;
                nv.UpdatedAt = DateTime.Now;

                await Update(nv);

                //Thêm log update 
                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Update_NhanVien,
                    IdNguoiDung = nv.UpdatedBy,
                    IdDoiTuong = nv.Id,
                    NoiDung = "Người dùng update nhân viên"
                });

                await ThemLog(nv, lg);

                return nv;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][Update_NhanVien]: " + ex.Message + ": Model: " + JsonSerializer.Serialize(model), ex);
            }
            

        }

        public async Task ThemPhanSu(PhanSuRequest model)
        {
            try
            {
                var cv = await AC.CongViec.GetById(model.IdCongViec);
                var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
                var nv = await AC.NhanVien.GetById(model.IdNhanVien);
                var ps = await AC.PhanSu.GetById(model.IdPhanSu);
                await AC.PhongBan.ThemPhanSuNhanVien(pb, nv, ps);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][ThemPhanSu]: " + ex.Message, ex);
            }
           
        }

        public async Task XoaPhanSu(PhanSuRequest model)
        {
            try
            {
                var cv = await AC.CongViec.GetById(model.IdCongViec);
                var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
                var nv = await AC.NhanVien.GetById(model.IdNhanVien);
                var ps = await AC.PhanSu.GetById(model.IdPhanSu);
                await AC.PhongBan.XoaPhanSuNhanVien(pb, nv, ps);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo mới nhân viên [AC_NhanVien][XoaPhanSu]: " + ex.Message , ex);
            }
            
        }


    }
}
