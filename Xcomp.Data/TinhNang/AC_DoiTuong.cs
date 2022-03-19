using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
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
    public class AC_DoiTuong
    {
        
        private readonly IDoiTuongRepository _DoiTuongRepository;

        private readonly IUnitOfWork _uow;

        public AC_DoiTuong(IServiceProvider services)

        {
            _uow = services.GetRequiredService<IUnitOfWork>();
            _DoiTuongRepository = services.GetRequiredService<IDoiTuongRepository>();

        }

        public async Task RemoveAll()
        {
            try
            {
                _DoiTuongRepository.RemoveAll();
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][RemoveAll]:" + ex.Message, ex);
            }

        }

        public async Task<DoiTuong> Create(DoiTuong tc)
        {
            try
            {
                _DoiTuongRepository.Add(tc);
                await _uow.CommitAsync();
                return tc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Create]:" + ex.Message, ex);
            }

        }

        public async Task<DoiTuong> Update(DoiTuong ltc)
        {
            try
            {
                _DoiTuongRepository.Update(ltc.Id, ltc);
                await _uow.CommitAsync();
                return ltc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Update]:" + ex.Message, ex);
            }

        }

        public async Task<DoiTuong> GetById(string id)
        {
            try
            {
                return await _DoiTuongRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][GetById]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<DoiTuong>> Get(List<string> Dsid)
        {
            try
            {
                return Dsid == null ? new List<DoiTuong>() : (List<DoiTuong>)(await _DoiTuongRepository.GetAllAsync(c => Dsid.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Get]:" + ex.Message, ex);
            }
            
        }

        public async Task<List<DoiTuong>> GetByCode(string Code)
        {
            try
            {
                return (List<DoiTuong>)(await _DoiTuongRepository.GetAllAsync(c => c.CodeLoaiDoiTuong == Code));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][GetByCode]:" + ex.Message, ex);
            }
        }
        //---------------------------
        public async Task ThemLog(DoiTuong tc, Log lg)
        {
            try
            {
                tc.QL_ThemLog(lg);
                await Update(tc);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][ThemLog]:" + ex.Message, ex);
            }
        }

        

        public async Task<DoiTuong> Create_DoiTuong(DoiTuongRequest model)
        {
            try
            {
                var nd = await AC.NguoiDung.GetById(model.IdNguoiTao);
                var ldt = await AC.LoaiDoiTuong.GetByCode(model.CodeLoaiDoiTuong);

                var bn = new DoiTuong()
                {
                    Name = model.Ten,
                    Phone = model.SoDienThoai,
                    GioiThieu = model.GioiThieu,
                    CreatedBy = model.IdNguoiTao,
                    LoaiDoiTuong = ldt.Name,
                    CodeLoaiDoiTuong = ldt.Code
                };

                await Create(bn);

                var lg = await AC.Log.Create(new Log
                {
                    LoaiLog = LoaiLog.Tao_BenhNhan,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = bn.Id,
                    NoiDung = "Tạo đối tượng",
                    Data = new BsonDocument
                    {
                        {"Name",bn.Name }
                    }
                });

                if (bn.Phone != null) lg.Data.Set("Phone", bn.Phone);
                if (bn.GioiThieu != null) lg.Data.Set("GioiThieu", bn.GioiThieu);

                await ThemLog(bn, lg);

                //Đưa bệnh nhân vào danh sách bệnh nhân của phòng hoặc khoa
                var cv = await AC.CongViec.GetById(model.IdCongViec);
                var pb = await AC.PhongBan.GetById(cv.IdPhongBan);
                await AC.PhongBan.Them_DoiTuong(pb, bn);


                return bn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Create_DoiTuong]:" + ex.Message, ex);
            }

        }

        public async Task<DoiTuong> Update_DoiTuong(DoiTuongRequest model)
        {
            try
            {
                var bn = await AC.DoiTuong.GetById(model.Id);

                var lg = new Log
                {
                    LoaiLog = LoaiLog.Update_BenhNhan,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = bn.Id,
                    NoiDung = "Update thông tin đối tượng: ",
                    Data = new BsonDocument()
                };

                if (bn.Name != model.Ten)
                {
                    lg.NoiDung += "[Name]";
                    lg.Data.Set("Name", model.Ten);
                    bn.Name = model.Ten;
                }

                if (bn.Phone != model.SoDienThoai)
                {
                    lg.NoiDung += "[Phone]";
                    if (model.SoDienThoai != null) lg.Data.Set("Phone", model.SoDienThoai);
                    bn.Phone = model.SoDienThoai;
                }

                if (bn.GioiThieu != model.GioiThieu)
                {
                    lg.NoiDung += "[GioiThieu]";
                    if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
                    bn.GioiThieu = model.GioiThieu;
                }

                if (bn.TrangThaiHoSo != model.TrangThai)
                {
                    lg.NoiDung += "[TrangThai]";
                    if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
                    bn.TrangThaiHoSo = model.TrangThai;
                }

                if (bn.CodeLoaiDoiTuong != model.CodeLoaiDoiTuong)
                {
                    lg.NoiDung += "[CodeLoaiDoiTuong]";
                    if (model.CodeLoaiDoiTuong != null) lg.Data.Set("CodeLoaiDoiTuong", model.CodeLoaiDoiTuong);
                    var ldt = await AC.LoaiDoiTuong.GetByCode(model.CodeLoaiDoiTuong);
                    bn.CodeLoaiDoiTuong = ldt.Code; bn.LoaiDoiTuong = ldt.Name;
                }

                await AC.Log.Create(lg);

                //save Update
                bn.UpdatedAt = DateTime.Now;
                bn.UpdatedBy = model.IdNguoiTao;
                await Update(bn);

                //Thêm log
                await ThemLog(bn, lg);

                return bn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Update_DoiTuong]:" + ex.Message, ex);
            }


        }

        public async Task Them_TienIch(TienIchRequest model)
        {
            try
            {
                var bn = await GetById(model.IdDoiTuong);
                var lti = await AC.LoaiTienIch.GetById(model.IdLoaiTienIch);

                var ti = await AC.TienIch.Create(new TienIch
                {
                    LoaiTienIch = lti.Name,
                    CodeLoaiTienIch = lti.Code,
                    CodeHeThong = lti.CodeHeThong,
                    VaiTroNguoiDung = model.VaiTro,
                    GioiThieu = model.GioiThieu,
                    Name = model.Ten,
                    Phone = model.SoDienThoai

                });

                await AC.TienIch.Set_DoiTuong(ti, bn);

                if (model.SoDienThoai != null)
                {
                    var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
                    if (nd != null)
                    {
                        await AC.TienIch.Set_NguoiDung(ti, nd);
                    }
                }

                var lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = bn.Id,
                    NoiDung = "Tạo tiện ích đối tượng ",
                    Data = new BsonDocument
                    {
                        {"Id",ti.Id },
                        {"LoaiTienIch",ti.LoaiTienIch },
                        {"CodeLoaiTienIch",ti.CodeLoaiTienIch }
                    }
                };

                if (ti.Name != null) lg.Data.Set("Name", ti.Name);
                if (ti.Phone != null) lg.Data.Set("Phone", ti.Phone);
                if (ti.VaiTroNguoiDung != null) lg.Data.Set("VaiTroNguoiDung", ti.VaiTroNguoiDung);
                if (ti.GioiThieu != null) lg.Data.Set("GioiThieu", ti.GioiThieu);

                await AC.Log.Create(lg);

                await ThemLog(bn, lg);

                lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = bn.Id,
                    NoiDung = "Tạo tiện ích đối tượng ",
                    Data = new BsonDocument
                {
                    {"Id",ti.Id },
                    {"LoaiTienIch",ti.LoaiTienIch },
                    {"CodeLoaiTienIch",ti.CodeLoaiTienIch }
                }
                };

                if (ti.Name != null) lg.Data.Set("Name", ti.Name);
                if (ti.Phone != null) lg.Data.Set("Phone", ti.Phone);
                if (ti.VaiTroNguoiDung != null) lg.Data.Set("VaiTroNguoiDung", ti.VaiTroNguoiDung);
                if (ti.GioiThieu != null) lg.Data.Set("GioiThieu", ti.GioiThieu);

                await AC.Log.Create(lg);

                await AC.TienIch.ThemLog(ti, lg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Them_TienIch]:" + ex.Message, ex);
            }

        }

        public async Task Update_TienIch(TienIchRequest model)
        {
            try
            {
                var bn = await GetById(model.IdDoiTuong);
                var ti = await AC.TienIch.GetById(model.Id);

                var lg = new Log
                {
                    LoaiLog = LoaiLog.Update_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = ti.Id,
                    NoiDung = "Update thông tin tiện ích: ",
                    Data = new BsonDocument()
                };

                var lti = await AC.LoaiTienIch.GetById(model.IdLoaiTienIch);
                if (ti.CodeLoaiTienIch != lti.Code)
                {
                    lg.NoiDung += "[LoaiTienIch]";
                    lg.Data.Set("LoaiTienIch", lti.Name);
                    lg.NoiDung += "[CodeLoaiTienIch]";
                    lg.Data.Set("CodeLoaiTienIch", lti.Code);
                    ti.LoaiTienIch = lti.Name;
                    ti.CodeLoaiTienIch = lti.Code;
                }

                if (ti.Name != model.Ten)
                {
                    lg.NoiDung += "[Name]";
                    lg.Data.Set("Name", model.Ten);
                    ti.Name = model.Ten;
                }

                if (ti.Phone != model.SoDienThoai)
                {
                    if (ti.IdNguoidung != null)
                    {
                        await AC.TienIch.Xoa_NguoiDung(ti, await AC.NguoiDung.GetById(ti.IdNguoidung));
                    }

                    lg.NoiDung += "[Phone]";
                    if (model.SoDienThoai != null) lg.Data.Set("Phone", model.SoDienThoai);
                    ti.Phone = model.SoDienThoai;

                    var nd = await AC.NguoiDung.GetByPhone(model.SoDienThoai);
                    if (nd != null)
                    {
                        await AC.TienIch.Set_NguoiDung(ti, nd);
                    }
                }

                if (ti.GioiThieu != model.GioiThieu)
                {
                    lg.NoiDung += "[GioiThieu]";
                    if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
                    ti.GioiThieu = model.GioiThieu;
                }

                if (ti.VaiTroNguoiDung != model.VaiTro)
                {
                    lg.NoiDung += "[VaiTroNguoiDung]";
                    if (model.GioiThieu != null) lg.Data.Set("VaiTroNguoiDung", model.VaiTro);
                    ti.VaiTroNguoiDung = model.VaiTro;
                }

                if (ti.TrangThaiHoSo != model.TrangThai)
                {
                    lg.NoiDung += "[TrangThai]";
                    if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
                    ti.TrangThaiHoSo = model.TrangThai;
                }

                await AC.Log.Create(lg);

                //save Update
                ti.UpdatedAt = DateTime.Now;
                ti.UpdatedBy = model.IdNguoiTao;
                await AC.TienIch.Update(ti);

                //Thêm log
                await AC.TienIch.ThemLog(ti, lg);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Update_TienIch]:" + ex.Message, ex);
            }

        }

        public async Task Them_Ca(CaRequest model)
        {
            try
            {
                var bn = await GetById(model.IdDoiTuong);
                var lc = await AC.LoaiCa.GetById(model.IdLoaiCa);

                var ca = await AC.Ca.Create(new Ca
                {
                    CodeLoaiCa = lc.Code,
                    LoaiCa = lc.Name,
                    GioiThieu = lc.GioiThieu

                });

                await AC.Ca.SetDoiTuong(ca, bn);



                var lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_Ca,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = bn.Id,
                    NoiDung = "Tạo ca cho đối tượng ",
                    Data = new BsonDocument
                {
                    {"Id",ca.Id },
                    {"LoaiCa",ca.LoaiCa },
                    {"CodeLoaiCa",ca.CodeLoaiCa }
                }
                };


                if (ca.GioiThieu != null) lg.Data.Set("GioiThieu", ca.GioiThieu);

                await AC.Log.Create(lg);

                await ThemLog(bn, lg);

                lg = new Log
                {
                    LoaiLog = LoaiLog.Tao_Ca,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = ca.Id,
                    NoiDung = "Tạo ca cho đối tượng ",
                    Data = new BsonDocument
                    {
                        {"Id",ca.Id },
                        {"LoaiCa",ca.LoaiCa },
                        {"CodeLoaiCa",ca.CodeLoaiCa }
                    }
                };


                if (ca.GioiThieu != null) lg.Data.Set("GioiThieu", ca.GioiThieu);

                await AC.Log.Create(lg);

                await AC.Ca.ThemLog(ca, lg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiThuong][Them_Ca]:" + ex.Message, ex);
            }


        }


        public async Task Update_Ca(CaRequest model)
        {
            try
            {
                var bn = await GetById(model.IdDoiTuong);
                var ca = await AC.Ca.GetById(model.Id);

                var lg = new Log
                {
                    LoaiLog = LoaiLog.Update_TienIch,
                    IdNguoiDung = model.IdNguoiTao,
                    IdDoiTuong = ca.Id,
                    NoiDung = "Update thông tin ca: ",
                    Data = new BsonDocument()
                };

                var lc = await AC.LoaiCa.GetById(model.IdLoaiCa);
                if (ca.CodeLoaiCa != lc.Code)
                {
                    lg.NoiDung += "[LoaiCa]";
                    lg.Data.Set("LoaiCa", lc.Name);
                    lg.NoiDung += "[CodeLoaiCa]";
                    lg.Data.Set("CodeLoaiCa", lc.Code);
                    ca.LoaiCa = lc.Name;
                    ca.CodeLoaiCa = lc.Code;
                }


                if (ca.GioiThieu != model.GioiThieu)
                {
                    lg.NoiDung += "[GioiThieu]";
                    if (model.GioiThieu != null) lg.Data.Set("GioiThieu", model.GioiThieu);
                    ca.GioiThieu = model.GioiThieu;
                }


                if (ca.TrangThaiHoSo != model.TrangThai)
                {
                    lg.NoiDung += "[TrangThai]";
                    if (model.TrangThai != null) lg.Data.Set("TrangThai", model.TrangThai);
                    ca.TrangThaiHoSo = model.TrangThai;
                }

                await AC.Log.Create(lg);

                //save Update
                ca.UpdatedAt = DateTime.Now;
                ca.UpdatedBy = model.IdNguoiTao;
                await AC.Ca.Update(ca);

                //Thêm log
                await AC.Ca.ThemLog(ca, lg);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Lỗi khi tạo tổ chức [AC_DoiTuong][Update_Ca]:" + ex.Message, ex);
            }


        }

    }
}
